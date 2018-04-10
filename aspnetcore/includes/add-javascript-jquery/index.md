## Calling the Web API with Javascript and jQuery

In this section, an HTML page is added that uses AJAX to call the web API. jQuery is used to make the AJAX calls and to update the page with the results. Add an HTML page with the following:

[!code-html[Main](samples/sample3.html)]

There are several ways to get jQuery. For this example, the library is loaded from [http://jquery.com/](http://jquery.com/).

### Getting a List of ToDos

To get a list of ToDos, send an HTTP GET request to &quot;/api/todo&quot;.

The jQuery [getJSON](http://api.jquery.com/jQuery.getJSON/) function sends an AJAX request to the Api, which returns a JSON structured item, representing an object or array. The `done` function specifies a callback that is called if the request succeeds. In the callback, we update the DOM with the Todo information.

[!code-html[Main](samples/sample4.html)]

### Getting a ToDo By ID

To get a ToDo by ID, send an HTTP GET request to &quot;/api/todo/*id*&quot;, where *id* is the ToDo ID.

[!code-javascript[Main](samples/sample5.js)]

We still call `getJSON` to send the AJAX request, but this time we put the ID in the request URI. The response from this request is a JSON representation of a single Todo.
