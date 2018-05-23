# Custom Model Binding Demo

Test `ByteArrayModelBinder` by running the app and POSTing a base64-encoded string to the `ImageController` endpoint (`/api/image/`). Specify the file and filename properties in the request body as form-data (using [Postman](https://www.getpostman.com/) or a similar tool). You can use [this sample string](Base64String.txt). The result is saved in the *wwwroot/images/upload* folder with the filename specified.

To test the custom binding example, try the following endpoints:

* /api/authors/1
* /api/authors/2 (NOT FOUND)
* /api/boundauthors/1
* /api/boundauthors/2 (NOT FOUND)
* /api/boundauthors/get/1
* /api/boundauthors/get/2 (NO CONTENT) &ndash; This action doesn't check for null and returns a *404 Not Found*.
