param (
  [string] $BaseUrl,
  [string] $ApplicationFolder
)

function Test-BlazorApplication {
  param (
    [string] $BaseUrl,
    [string] $ApplicationFolder,
    [switch] $PassThrough
  )

  $res = New-ApplicationInformation $ApplicationFolder;
  $res.Validate();

  $tmpFolder = "$($env:TEMP)/$(new-guid)";

  try {
    if (-not (Test-Path $tmpFolder)) {
      mkdir $tmpFolder | Out-Null;  
    }
    New-DownloadedApplicationInformation $BaseUrl $tmpFolder;
    $web = New-ApplicationInformation $tmpFolder;
    $web.Validate();
  }
  finally {
    Remove-Item $tmpFolder -Recurse -Force;
  }
  
  $errors = Compare-Applications $res $web;
  $result = [ValidationErrors]::new();
  $result.ComparisonErrors = $errors;
  $result.DownloadedAppErrors = $web;
  $result.PublishedAppErrors = $res.Errors;
  $result.PublishedApp = $res;
  $result.DownloadedApp = $web;

  if ($PassThrough) {
    return $result;
  }
  else {
    if ($result.IsValid()) {
      "No errors found. Application is consistent."
    }
    else {
      foreach ($publishError in $result.PublishedAppErrors) {
        Write-Host $publishError;
      }
      foreach ($downloadError in $result.DownloadedAppErrors) {
        Write-Host $downloadError;
      }
      foreach ($comparisonError in $result.ComparisonErrors) {
        Write-Host $comparisonError;
      }
    }
  }
}

class ValidationErrors {
  [string []] $PublishedAppErrors;
  [string []] $DownloadedAppErrors;
  [string []] $ComparisonErrors;
  [ApplicationInformation] $PublishedApp;
  [ApplicationInformation] $DownloadedApp;

  [bool] IsValid() {
    return $this.ComparisonErrors.Length -eq 0 -and $this.DownloadedAppErrors.Length -eq 0 -and $this.PublishedAppErrors.Length -eq 0;
  }
}

function Compare-Applications([ApplicationInformation]$output, [ApplicationInformation]$web) {
  $errors = @();
  foreach ($resource in $web.Files) {
    $outputResource = $output.Files | Where-Object Name -EQ $resource.Name | Select-Object -First 1;
    if (-not ($outputResource.Signature -eq $resource.Signature)) {
      $errors += "Signature mismatch between file in the publish folder '$($outputResource.Name) $($outputResource.Signature)' and downloaded file '$($resource.Name) $($resource.Signature)'";
    }
  }

  return $errors;
}

function New-DownloadedApplicationInformation {
  param (
    [string] $BaseUrl,
    [string] $TempFolder
  )

  $base = $BaseUrl;
  if (-not $BaseUrl.EndsWith("/")) {
    $base + "/";
  }

  $blazorBootJsonUrl = $base + "_framework/blazor.boot.json";
  $frameworkFolder = Join-Path $TempFolder "_framework";
  $blazorBootJsonPath = Join-Path $TempFolder "_framework/blazor.boot.json";

  if (-not (Test-Path $frameworkFolder)) {
    mkdir $frameworkFolder | Out-Null;
  }
  New-FileWithAllEncodings $blazorBootJsonUrl $blazorBootJsonPath;
  [BlazorBootJson]$bootJson = ConvertTo-BlazorBootJson $blazorBootJsonPath;
  foreach ($resource in $bootJson.Resources) {
    New-FileWithAllEncodings $base + "_framework/$($resource.Name)" (Join-Path $frameworkFolder $resource.Name);
  }

  $serviceWorkerAssetsUrl = $base + "service-worker-assets.js";
  $serviceWorkerAssetsPath = Join-Path $TempFolder "service-worker-assets.js";

  $serviceWorkerAssetsResponse = Invoke-WebRequest $serviceWorkerAssetsUrl;
  if ($serviceWorkerAssetsResponse.StatusCode -eq 200) {        
    New-FileWithAllEncodings $serviceWorkerAssetsUrl $serviceWorkerAssetsPath;
    [ServiceWorkerAssetsManifest]$serviceWorkerAssets = ConvertTo-serviceWorkerAssets $serviceWorkerAssetsPath;
    foreach ($asset in $serviceWorkerAssets.Assets) {
      $assetPath = Join-Path $TempFolder $asset.Name;
      $assetDir = [System.IO.Path]::GetDirectoryName($assetPath);
      if (-not (Test-Path $assetDir) -and $assetDir -ne '') {
        mkdir $assetDir | Out-Null;
      }
      New-FileWithAllEncodings "$base$($asset.Name)" $assetPath;
    }
  }
}

function New-FileWithAllEncodings([string] $url, [string] $file) {
  Invoke-WebRequest $url -Headers @{'Accept-Encoding' = 'identity' } -OutFile "$file" | Out-Null;    
  if ($url.Contains("_framework")) {
    try {
      Get-AppFile $url 'br' "$($file).br";
    }
    catch {    
    }
    try {      
      Get-AppFile $url 'gzip' "$($file).gz";
    }
    catch {
    }    
  }
}

function Get-AppFile([string] $url, [string] $encoding, [string] $filePath) {
  [System.Net.Http.HttpClientHandler]$handler = [System.Net.Http.HttpClientHandler]::new();
  $handler.AutomaticDecompression = [System.Net.DecompressionMethods]::None;
  [System.Net.Http.HttpClient] $client = [System.Net.Http.HttpClient]::new($handler, $true);
  $request = [System.Net.Http.HttpRequestMessage]::new("GET", $url);
  $request.Headers.TryAddWithoutValidation("Accept-Encoding", $encoding) | Out-Null;
  $response = $client.Send($request);
  if (Test-Path $filePath) {
    return;
  }
  $file = New-Item $filePath -ItemType File;
  [System.IO.FileStream]$stream = $file.OpenWrite();
  $response.Content.CopyTo($stream, $null, [System.Threading.CancellationToken]::None) | Out-Null;
  $stream.Flush() | Out-Null;
  $stream.Close();
  $client.Dispose();
}

function New-ApplicationInformation([string]$Folder) {
  $candidates = Get-ChildItem -Recurse -File $Folder;
  [BlazorFile []] $files = @();
  
  foreach ($candidate in $candidates) {
    $blazorFile = New-BlazorFile $Folder $candidate;
    $files += $blazorFile;
  }

  $result = [ApplicationInformation]::new();
  $result.Files = $files;

  return $result;
}

function New-BlazorFile {
  param (
    [string] $Base,
    [System.IO.FileInfo] $File
  )
  $name = $File.Name;
  $extension = $File.Extension;
  $relativePath = [System.IO.Path]::GetRelativePath($Base, $File.FullName).Replace("\", "/");
  $source = $File.FullName;
  if ($File.Extension -eq '.gz') {
    $content = Expand-GzipFile $File;
  }
  elseif ($File.Extension -eq '.br') {
    $content = Expand-BrotliFile $File;
  }
  else {
    $content = Get-Content $File -AsByteStream;    
  }
  $dataStream = [System.IO.MemoryStream]::new($content);
  $signature = Get-FileHash -InputStream $dataStream -Algorithm SHA256;
  $signatureBytes = [byte[]] -split ($signature.Hash -replace '..', '0x$& ');
  $signatureBase64 = [System.Convert]::ToBase64String($signatureBytes);
  $dataStream.Dispose();
  $dataStream = $null;

  $blazorFile = [BlazorFile]::new();
  $blazorFile.Name = $name;
  $blazorFile.Extension = $extension;
  $blazorFile.RelativePath = $relativePath;
  $blazorFile.Source = $source;
  $blazorFile.Content = $content;
  $blazorFile.Signature = $signatureBase64;

  if ($File.Name -eq "blazor.boot.json") {
    $blazorFile.ParsedContent = ConvertTo-BlazorBootJson $File;
  }

  if ($File.Name -eq "service-worker-assets.js") {
    $blazorFile.ParsedContent = ConvertTo-ServiceWorkerAssets $File;
  }

  return $blazorFile;
}

function Expand-BrotliFile([string] $File) {
  $compressedBytes = Get-Content $File -AsByteStream;
  $compressedStream = [System.IO.MemoryStream]::new($compressedBytes);
  $contentStream = [System.IO.MemoryStream]::new();
  $decompressionStream = [System.IO.Compression.BrotliStream]::new($compressedStream, [System.IO.Compression.CompressionMode]::Decompress);
  $decompressionStream.CopyTo($contentStream) | Out-Null;
  $contentStream.Seek(0, [System.IO.SeekOrigin]::Begin) | Out-Null;
  $content = $contentStream.ToArray();
  return $content;
}

function Expand-GzipFile([string] $File) {
  $compressedBytes = Get-Content $File -AsByteStream;
  $compressedStream = [System.IO.MemoryStream]::new($compressedBytes);
  $contentStream = [System.IO.MemoryStream]::new();
  $decompressionStream = [System.IO.Compression.GZipStream]::new($compressedStream, [System.IO.Compression.CompressionMode]::Decompress);
  $decompressionStream.CopyTo($contentStream) | Out-Null;
  $contentStream.Seek(0, [System.IO.SeekOrigin]::Begin) | Out-Null;
  $content = $contentStream.ToArray();
  return $content;
}

function ConvertTo-BlazorBootJson([string]$File) {
  $parsed = [BlazorBootJson]::new();
  $data = ConvertFrom-Json (Get-Content $File -Raw) -Depth 10;
  $resources = @();
  foreach ($prop in $data.resources.assembly.PSObject.Properties) {
    $resources += [BlazorResource]::new($prop.Name, ($prop.Value -replace "sha256-", ""));
  }
  foreach ($prop in $data.resources.runtime.PSObject.Properties) {
    $resources += [BlazorResource]::new($prop.Name, ($prop.Value -replace "sha256-", ""));
  }

  $parsed.Resources = $resources;

  return $parsed;
}

function ConvertTo-ServiceWorkerAssets([string] $File) {
  $parsed = [ServiceWorkerAssetsManifest]::new();
  $jsContent = (Get-Content $File -Raw);
  $jsContentNoPrefix = $jsContent -replace "self.assetsManifest = ", "";
  $jsonContent = $jsContentNoPrefix.Trim().TrimEnd(";")
  $data = ConvertFrom-Json $jsonContent -Depth 10;
  $assets = @();
  for ($i = 0; $i -lt $data.assets.Length; $i++) {
    $candidate = $data.assets[$i];
    $assets += [ServiceWorkerAsset]::new($candidate.url, ($candidate.hash -replace "sha256-", "").Trim());
  }

  $parsed.Assets = $assets;
  $parsed.Version = $data.version;

  return $parsed;
}

class ApplicationInformation {
  [BlazorFile []] $Files;
  [BlazorFile] $BlazorBootJson;
  [BlazorFile] $ServiceWorkerAssets;
  [string []] $Errors;

  [void] Validate() {
    foreach ($file in $this.Files) {
      if ($file.Name -eq 'blazor.boot.json') {
        $this.BlazorBootJson = $file;
      }
      if ($file.Name -eq 'service-worker-assets.js') {
        $this.ServiceWorkerAssets = $file;
      }
    }

    foreach ($file in $this.Files) {
      if (($file.Extension -eq '.br') -or ($file.Extension -eq '.gz')) {
        continue;
      }
      $brotli = $this.Files | Where-Object RelativePath -EQ "$($file.RelativePath).br" | Select-Object -First 1;
      $gzip = $this.Files | Where-Object RelativePath -EQ "$($file.RelativePath).gz" | Select-Object -First 1;
      if (($null -ne $brotli) -and ($brotli.Signature -ne $file.Signature)) {
        $this.Errors += "Signatures for '$($file.RelativePath) ($($file.Signature))' and '$($brotli.RelativePath) ($($brotli.Signature))' do not match."
      }
      if (($null -ne $gzip) -and ($gzip.Signature -ne $file.Signature)) {
        $this.Errors += "Signatures for '$($file.RelativePath) ($($file.Signature))' and '$($gzip.RelativePath) ($($gzip.Signature))' do not match."
      }
      if (($file.Name -ne 'blazor.boot.json') -and ($file.Name -ne 'service-worker-assets.js') -and ($file.Name -ne 'service-worker.js')) {
        [BlazorBootJson] $bootJson = $this.BlazorBootJson.ParsedContent;
        $bootJsonEntry = $bootJson.Resources | Where-Object Name -EQ $file.Name | Select-Object -First 1;
        if (($null -ne $bootJsonEntry) -and ($file.Signature -ne $bootJsonEntry.Integrity)) {
          $this.Errors += "Integrity mismatch for '$($file.RelativePath) ($($file.Signature))' and blazor.boot.json entry '$($bootJsonEntry.Name) ($($bootJsonEntry.Integrity))'."
        }

        if ($null -ne $this.ServiceWorkerAssets) {
          [ServiceWorkerAssetsManifest] $workerAssetsManifest = $this.ServiceWorkerAssets.ParsedContent;
          $assetsEntry = $workerAssetsManifest.Assets | Where-Object Name -EQ $file.RelativePath | Select-Object -First 1;

          if (($null -eq $assetsEntry) || $assetsEntry.Count -ne 1) {
            $this.Errors += "Could not find entry for '$($file.RelativePath) in service-worker-assets.js."
          }
          if ($file.Signature -ne $assetsEntry.Integrity) {
            $this.Errors += "Integrity mismatch for '$($file.RelativePath) ($($file.Signature))' and service-worker-assets.js entry '$($assetsEntry.Name) ($($assetsEntry.Integrity))'."
          }
        }
      }
      if ($file.Name -eq 'blazor.boot.json') {
        if ($null -ne $this.ServiceWorkerAssets) {
          [ServiceWorkerAssetsManifest] $workerAssetsManifest = $this.ServiceWorkerAssets.ParsedContent;
          $assetsEntry = $workerAssetsManifest.Assets | Where-Object Name -EQ $file.RelativePath | Select-Object -First 1;

          if (($null -eq $assetsEntry) || $assetsEntry.Count -ne 1) {
            $this.Errors += "Could not find entry for '$($file.RelativePath) in service-worker-assets.js."
          }
          if ($file.Signature -ne $assetsEntry.Integrity) {
            $this.Errors += "Integrity mismatch for '$($file.RelativePath) ($($file.Signature))' and service-worker-assets.js entry '$($assetsEntry.Name) ($($assetsEntry.Integrity))'."
          }
        }
      }
    }
  }
}

class BlazorFile {
  [string] $Name;
  [string] $Extension;
  [string] $RelativePath;
  [string] $Source;
  [byte []] $Content;
  [string] $Signature;
  [object] $ParsedContent;
}

class BlazorBootJson {
  [BlazorResource []] $Resources
}

class ServiceWorkerAssetsManifest {
  [string] $Version;
  [ServiceWorkerAsset []] $Assets
}

class ServiceWorkerAsset {

  ServiceWorkerAsset(
    [string]$name,
    [string]$integrity) {
    $this.Name = $name;
    $this.Integrity = $integrity;
  }

  [string]$Name;
  [string]$Integrity;
}

class BlazorResource {

  BlazorResource(
    [string]$name,
    [string]$integrity) {
    $this.Name = $name;
    $this.Integrity = $integrity;
  }

  [string]$Name;
  [string]$Integrity;
}

Test-BlazorApplication $BaseUrl $ApplicationFolder
