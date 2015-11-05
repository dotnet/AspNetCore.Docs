Bundling and Minification
=========================

By `Erik Reitan`_ 

Bundling and minification are two techniques you can use in ASP.NET 5 to improve page load performance for your web application. Bundling makes it easy to combine or bundle multiple files into a single file. Minification performs a variety of different code optimizations to scripts and CSS, which results in smaller payloads. Bundling and minification improves load time performance by reducing the number of requests to the server and reducing the size of the requested assets (such as CSS and JavaScript files.)

Bundling and minification primarily improve the first page request load time. Once a web page has been requested, the browser caches the assets (JavaScript, CSS and images) so bundling and minification won’t provide any performance boost when requesting the same page, or pages on the same site requesting the same assets. If you don’t set the expires header correctly on your assets, and you don’t use bundling and minification, the browsers freshness heuristics will mark the assets stale after a few days and the browser will require a validation request for each asset. In this case, bundling and minification provide a performance increase after the first page request. 

Because bundling combines multiple files into a single file, it reduces the number of requests to the server that is required to retrieve and display a web asset, such as a web page. You can create CSS, JavaScript and other bundles. Fewer files, means fewer HTTP requests from your browser to the server or from the service providing your application.

Minification performs a variety of different code optimizations to reduce the size of requested assets (such as CSS, image, JavaScript files). Common results of minification include removing unnecessary white space and comments, and shortening variable names to one character. 

Consider the following JavaScript function:

.. code-block:: javascript

	AddAltToImg = function (imageTagAndImageID, imageContext) {
		///<signature>
		///<summary> Adds an alt tab to the image
		// </summary>
		//<param name="imgElement" type="String">The image selector.</param>
		//<param name="ContextForImage" type="String">The image context.</param>
		///</signature>
		var imageElement = $(imageTagAndImageID, imageContext);
		imageElement.attr('alt', imageElement.attr('id').replace(/ID/, ''));
	}

After minification, the function is reduced to the following:

.. code-block:: javascript

	AddAltToImg=function(t,a){var r=$(t,a);r.attr("alt",r.attr("id").replace(/ID/,""))};
	
In addition to removing the comments and unnecessary whitespace, the following parameters and variable names were renamed (shortened) as follows:

==================  =======  
Original            Renamed      
==================  =======  
imageTagAndImageID  t  
imageContext        a  
imageElement        r   
==================  =======  

See Also
--------

	- :doc:`using-gulp`
	- :doc:`using-grunt`