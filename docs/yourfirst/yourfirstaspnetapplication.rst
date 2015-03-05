.. highlight:: c#

Your First ASP.NET Application Using Visual Studio
==================================================

Header
======

Some content

Subhead
^^^^^^^

Some other content and here is some code::
	
	using System;
	using System.Web;
	// just kidding, we aren't going to use System.Web!
	public class Foo
	{
		public void Bar()
		{
			var x = new String();
			
			x = x.ToLower();
		}
	}
	
That's it for that code block. What if we want to now show some HTML markup?

.. code-block:: html
	
	<html>
	<head><title>Title</title></head>
	<body>
		<div class="container"></div>
	</body>
	</html>

The above should be highlighted as HTML.
