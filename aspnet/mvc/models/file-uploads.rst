File Uploads
============

By `Steve Smith`_

ASP.NET MVC actions support uploading of one or more files, using simple model binding for smaller files, or streaming for larger files.

.. contents:: Sections
  :local:
  :depth: 1

Uploading Small Files with Model Binding
----------------------------------------

To upload small files, you can use a multi-part HTML form or construct a POST request using JavaScript. To POST files using a form an HTML form, you can use something like the following:

(sample HTML markup)

The individual files uploaded to the server can be accessed through Model Binding(link) using the IFormFile(link) interface. IFormFile has the following structure:

(sample)

The following example loops through the files that were uploaded and displays information about each file, such as its filename and size.

(sample)

(screenshot)





Uploading Large Files with Streaming
------------------------------------

If the size or frequency of files uploads is causing performance or resource problems for the app, consider streaming the file upload rather than buffering it in its entirety (as the model binding approach does).

.. code-block:: html
  :emphasize-lines: 8-12

  <form action="/movies/Create" method="post">
    <div class="form-horizontal">
      <h4>Movie</h4>
      <div class="text-danger"></div>
      <div class="form-group">
        <label class="col-md-2 control-label" for="ReleaseDate">ReleaseDate</label>
        <div class="col-md-10">
          <input class="form-control" type="datetime"
          data-val="true" data-val-required="The ReleaseDate field is required."
          id="ReleaseDate" name="ReleaseDate" value="" />
          <span class="text-danger field-validation-valid"
          data-valmsg-for="ReleaseDate" data-valmsg-replace="true"></span>
        </div>
      </div>
      </div>
  </form>

Troubleshooting
---------------

HTTP 404.13 - Not Found
The request filtering module is configured to deny a request that exceeds the request content length.

Check in web.config <system.webServer><security><requestFiltering><requestLimits maxAllowedContentLength="" /></></></> setting.

More info: https://www.iis.net/configreference/system.webserver/security/requestfiltering/requestlimits

The default is 30000000, which is approximately 28.6MB.

Workarounds:
1) Configure the maxAllowedContentLength

.. code-block:: xml

  <system.webServer>
    <security>
      <requestFiltering>
        <!-- This will handle requests up to 50MB -->
        <requestLimits maxAllowedContentLength="52428800" />
      </requestFiltering>
    </security>
  </system.webServer>

2) Host from Kestrel
