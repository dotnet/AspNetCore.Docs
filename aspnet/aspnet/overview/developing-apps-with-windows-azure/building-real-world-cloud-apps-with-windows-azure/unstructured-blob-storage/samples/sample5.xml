if (await container.CreateIfNotExistsAsync())
{
    // Enable public access on the newly created "images" container
    await container.SetPermissionsAsync(
        new BlobContainerPermissions
        {
            PublicAccess =
                BlobContainerPublicAccessType.Blob
        });

    log.Information("Successfully created Blob Storage Images Container and made it public");
}