# Custom Model Binding Demo

You can test the `ByteArrayModelBinder` by running the application and POSTing a base64-encoded string to the ImageController endpoint (/api/image/). You should specify the file and filename proparties in the request Body as form-data (using Postman or a similar tool). You can use [this sample string](Base64String.txt). The result will be saved in the wwwroot/images/upload folder with the filename you specified.

To test the custom binding example, try the following endpoints:
/api/authors/1
/api/authors/2 (NOT FOUND)
/api/boundauthors/1
/api/boundauthors/2 (NOT FOUND)
/api/boundauthors/get/1
/api/boundauthors/get/2 (NO CONTENT) - this action doesn't check for null and return a Not Found
