# Create a new storage account
New-AzureStorageAccount -StorageAccountName $Name -Location $Location -Verbose
 
# Get the access key of the storage account
$key = Get-AzureStorageKey -StorageAccountName $Name
 
# Generate the connection string of the storage account
$connectionString = "BlobEndpoint=http://$Name.blob.core.windows.net/;QueueEndpoint=http://$Name.queue.core.windows.net/;TableEndpoint=http://$Name.table.core.windows.net/;AccountName=$Name;AccountKey=$primaryKey"
 
#Return a hashtable of storage account values
Return @{AccountName = $Name; AccessKey = $key.Primary; ConnectionString = $connectionString}