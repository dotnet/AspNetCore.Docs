param(
    [Parameter(Position=0,mandatory=$true)]
    $application,
    [Parameter(Position=1,mandatory=$true)]
    $location
)

$werHive = "HKLM:\SOFTWARE\Microsoft\Windows\Windows Error Reporting";
$ldHive = "$werHive\LocalDumps";
$applicationHive = "$ldHive\$application";

if (!(Test-Path $ldHive))
{
    New-Item -Path $werHive -Name "LocalDumps";
}

if (!(Test-Path $applicationHive))
{
    New-Item -Path $ldHive -Name $application;
}

New-ItemProperty $applicationHive -Name "DumpFolder" -Value $location -PropertyType "ExpandString" -Force;
# Allow maximum 5 dumps
New-ItemProperty $applicationHive -Name "DumpCount" -Value 5 -PropertyType "DWORD" -Force;
# 2 - Full Dump
New-ItemProperty $applicationHive -Name "DumpType" -Value 2 -PropertyType "DWORD" -Force;
