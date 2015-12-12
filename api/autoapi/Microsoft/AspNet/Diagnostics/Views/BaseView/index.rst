

BaseView Class
==============



.. contents:: 
   :local:



Summary
-------

Infrastructure





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Diagnostics.Views.BaseView`








Syntax
------

.. code-block:: csharp

   public abstract class BaseView





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/diagnostics/src/Microsoft.AspNet.Diagnostics/Views/BaseView.cs>`_





.. dn:class:: Microsoft.AspNet.Diagnostics.Views.BaseView

Methods
-------

.. dn:class:: Microsoft.AspNet.Diagnostics.Views.BaseView
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Diagnostics.Views.BaseView.BeginWriteAttribute(System.String, System.String, System.Int32, System.String, System.Int32, System.Int32)
    
        
        
        
        :type name: System.String
        
        
        :type begining: System.String
        
        
        :type startPosition: System.Int32
        
        
        :type ending: System.String
        
        
        :type endPosition: System.Int32
        
        
        :type thingy: System.Int32
    
        
        .. code-block:: csharp
    
           protected void BeginWriteAttribute(string name, string begining, int startPosition, string ending, int endPosition, int thingy)
    
    .. dn:method:: Microsoft.AspNet.Diagnostics.Views.BaseView.EndWriteAttribute()
    
        
    
        
        .. code-block:: csharp
    
           protected void EndWriteAttribute()
    
    .. dn:method:: Microsoft.AspNet.Diagnostics.Views.BaseView.ExecuteAsync()
    
        
    
        Execute an individual request
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public abstract Task ExecuteAsync()
    
    .. dn:method:: Microsoft.AspNet.Diagnostics.Views.BaseView.ExecuteAsync(Microsoft.AspNet.Http.HttpContext)
    
        
    
        Execute an individual request
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task ExecuteAsync(HttpContext context)
    
    .. dn:method:: Microsoft.AspNet.Diagnostics.Views.BaseView.HtmlEncodeAndReplaceLineBreaks(System.String)
    
        
        
        
        :type input: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           protected string HtmlEncodeAndReplaceLineBreaks(string input)
    
    .. dn:method:: Microsoft.AspNet.Diagnostics.Views.BaseView.Write(Microsoft.AspNet.Diagnostics.Views.HelperResult)
    
        
    
        :dn:meth:`Microsoft.AspNet.Diagnostics.Views.HelperResult.WriteTo(System.IO.TextWriter)` is invoked
    
        
        
        
        :param result: The  to invoke
        
        :type result: Microsoft.AspNet.Diagnostics.Views.HelperResult
    
        
        .. code-block:: csharp
    
           protected void Write(HelperResult result)
    
    .. dn:method:: Microsoft.AspNet.Diagnostics.Views.BaseView.Write(System.Object)
    
        
    
        Convert to string and html encode
    
        
        
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
           protected void Write(object value)
    
    .. dn:method:: Microsoft.AspNet.Diagnostics.Views.BaseView.Write(System.String)
    
        
    
        Html encode and write
    
        
        
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
           protected void Write(string value)
    
    .. dn:method:: Microsoft.AspNet.Diagnostics.Views.BaseView.WriteAttributeTo(System.IO.TextWriter, System.String, System.String, System.String, Microsoft.AspNet.Diagnostics.Views.AttributeValue[])
    
        
    
        Writes the given attribute to the given writer
    
        
        
        
        :param writer: The  instance to write to.
        
        :type writer: System.IO.TextWriter
        
        
        :param name: The name of the attribute to write
        
        :type name: System.String
        
        
        :param leader: The value of the prefix
        
        :type leader: System.String
        
        
        :param trailer: The value of the suffix
        
        :type trailer: System.String
        
        
        :param values: The s to write.
        
        :type values: Microsoft.AspNet.Diagnostics.Views.AttributeValue[]
    
        
        .. code-block:: csharp
    
           protected void WriteAttributeTo(TextWriter writer, string name, string leader, string trailer, params AttributeValue[] values)
    
    .. dn:method:: Microsoft.AspNet.Diagnostics.Views.BaseView.WriteAttributeValue(System.String, System.Int32, System.Object, System.Int32, System.Int32, System.Boolean)
    
        
        
        
        :type thingy: System.String
        
        
        :type startPostion: System.Int32
        
        
        :type value: System.Object
        
        
        :type endValue: System.Int32
        
        
        :type dealyo: System.Int32
        
        
        :type yesno: System.Boolean
    
        
        .. code-block:: csharp
    
           protected void WriteAttributeValue(string thingy, int startPostion, object value, int endValue, int dealyo, bool yesno)
    
    .. dn:method:: Microsoft.AspNet.Diagnostics.Views.BaseView.WriteLiteral(System.Object)
    
        
    
        Write the given value directly to the output
    
        
        
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
           protected void WriteLiteral(object value)
    
    .. dn:method:: Microsoft.AspNet.Diagnostics.Views.BaseView.WriteLiteral(System.String)
    
        
    
        Write the given value directly to the output
    
        
        
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
           protected void WriteLiteral(string value)
    
    .. dn:method:: Microsoft.AspNet.Diagnostics.Views.BaseView.WriteLiteralTo(System.IO.TextWriter, System.Object)
    
        
    
        Writes the specified ``value`` without HTML encoding to the ``writer``.
    
        
        
        
        :param writer: The  instance to write to.
        
        :type writer: System.IO.TextWriter
        
        
        :param value: The  to write.
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
           protected void WriteLiteralTo(TextWriter writer, object value)
    
    .. dn:method:: Microsoft.AspNet.Diagnostics.Views.BaseView.WriteLiteralTo(System.IO.TextWriter, System.String)
    
        
    
        Writes the specified ``value`` without HTML encoding to :dn:prop:`Microsoft.AspNet.Diagnostics.Views.BaseView.Output`\.
    
        
        
        
        :type writer: System.IO.TextWriter
        
        
        :param value: The  to write.
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
           protected void WriteLiteralTo(TextWriter writer, string value)
    
    .. dn:method:: Microsoft.AspNet.Diagnostics.Views.BaseView.WriteTo(System.IO.TextWriter, System.Object)
    
        
    
        Writes the specified ``value`` to ``writer``.
    
        
        
        
        :param writer: The  instance to write to.
        
        :type writer: System.IO.TextWriter
        
        
        :param value: The  to write.
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
           protected void WriteTo(TextWriter writer, object value)
    
    .. dn:method:: Microsoft.AspNet.Diagnostics.Views.BaseView.WriteTo(System.IO.TextWriter, System.String)
    
        
    
        Writes the specified ``value`` with HTML encoding to ``writer``.
    
        
        
        
        :param writer: The  instance to write to.
        
        :type writer: System.IO.TextWriter
        
        
        :param value: The  to write.
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
           protected void WriteTo(TextWriter writer, string value)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Diagnostics.Views.BaseView
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Views.BaseView.Context
    
        
    
        The request context
    
        
        :rtype: Microsoft.AspNet.Http.HttpContext
    
        
        .. code-block:: csharp
    
           protected HttpContext Context { get; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Views.BaseView.HtmlEncoder
    
        
    
        Html encoder used to encode content.
    
        
        :rtype: Microsoft.Extensions.WebEncoders.IHtmlEncoder
    
        
        .. code-block:: csharp
    
           protected IHtmlEncoder HtmlEncoder { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Views.BaseView.JavaScriptStringEncoder
    
        
    
        JavaScript encoder used to encode content.
    
        
        :rtype: Microsoft.Extensions.WebEncoders.IJavaScriptStringEncoder
    
        
        .. code-block:: csharp
    
           protected IJavaScriptStringEncoder JavaScriptStringEncoder { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Views.BaseView.Output
    
        
    
        The output stream
    
        
        :rtype: System.IO.StreamWriter
    
        
        .. code-block:: csharp
    
           protected StreamWriter Output { get; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Views.BaseView.Request
    
        
    
        The request
    
        
        :rtype: Microsoft.AspNet.Http.HttpRequest
    
        
        .. code-block:: csharp
    
           protected HttpRequest Request { get; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Views.BaseView.Response
    
        
    
        The response
    
        
        :rtype: Microsoft.AspNet.Http.HttpResponse
    
        
        .. code-block:: csharp
    
           protected HttpResponse Response { get; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Views.BaseView.UrlEncoder
    
        
    
        Url encoder used to encode content.
    
        
        :rtype: Microsoft.Extensions.WebEncoders.IUrlEncoder
    
        
        .. code-block:: csharp
    
           protected IUrlEncoder UrlEncoder { get; set; }
    

