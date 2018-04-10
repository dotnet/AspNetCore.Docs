## Call the Web API with jQuery

In this section, an HTML page is added that uses jQuery to call the Web API. jQuery initiates the request and updates the page with the details from the API's response. Add an HTML page with the following:

[!code-html[Main](samples/sample3.html)]

There are several ways to get jQuery. In the preceding snippet, the library is loaded from a CDN.

### Get a list of ToDos

To get a list of ToDos, send an HTTP GET request to &quot;/api/todo&quot;.

The jQuery [getJSON](https://api.jquery.com/jQuery.getJSON/) function sends an AJAX request to the API, which returns JSON representing an object or array. The `done` function specifies a callback that is called if the request succeeds. In the callback, the DOM is updated with the ToDo information.

[!code-javascript[Main](samples/sample4.html)]

### Get a ToDo by ID

To get a ToDo by ID, send an HTTP GET request to &quot;/api/todo/*id*&quot;, where *id* is the ToDo ID.

[!code-javascript[Main](samples/sample5.js)]

The `getJSON` function is still invoked to send the AJAX request, but this time the ID is included in the request URI. The response from this request is a JSON representation of a single ToDo item.
