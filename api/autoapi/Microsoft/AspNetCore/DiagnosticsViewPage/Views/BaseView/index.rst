

BaseView Class
==============






Infrastructure


Namespace
    :dn:ns:`Microsoft.AspNetCore.DiagnosticsViewPage.Views`
Assemblies
    * Microsoft.AspNetCore.Diagnostics

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.DiagnosticsViewPage.Views.BaseView`








Syntax
------

.. code-block:: csharp

    public abstract class BaseView








.. dn:class:: Microsoft.AspNetCore.DiagnosticsViewPage.Views.BaseView
    :hidden:

.. dn:class:: Microsoft.AspNetCore.DiagnosticsViewPage.Views.BaseView

Properties
----------

.. dn:class:: Microsoft.AspNetCore.DiagnosticsViewPage.Views.BaseView
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.DiagnosticsViewPage.Views.BaseView.Context
    
        
    
        
        The request context
    
        
        :rtype: Microsoft.AspNetCore.Http.HttpContext
    
        
        .. code-block:: csharp
    
            protected HttpContext Context
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.DiagnosticsViewPage.Views.BaseView.HtmlEncoder
    
        
    
        
        Html encoder used to encode content.
    
        
        :rtype: System.Text.Encodings.Web.HtmlEncoder
    
        
        .. code-block:: csharp
    
            protected HtmlEncoder HtmlEncoder
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.DiagnosticsViewPage.Views.BaseView.JavaScriptEncoder
    
        
    
        
        JavaScript encoder used to encode content.
    
        
        :rtype: System.Text.Encodings.Web.JavaScriptEncoder
    
        
        .. code-block:: csharp
    
            protected JavaScriptEncoder JavaScriptEncoder
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.DiagnosticsViewPage.Views.BaseView.Output
    
        
    
        
        The output stream
    
        
        :rtype: System.IO.StreamWriter
    
        
        .. code-block:: csharp
    
            protected StreamWriter Output
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.DiagnosticsViewPage.Views.BaseView.Request
    
        
    
        
        The request
    
        
        :rtype: Microsoft.AspNetCore.Http.HttpRequest
    
        
        .. code-block:: csharp
    
            protected HttpRequest Request
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.DiagnosticsViewPage.Views.BaseView.Response
    
        
    
        
        The response
    
        
        :rtype: Microsoft.AspNetCore.Http.HttpResponse
    
        
        .. code-block:: csharp
    
            protected HttpResponse Response
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.DiagnosticsViewPage.Views.BaseView.UrlEncoder
    
        
    
        
        Url encoder used to encode content.
    
        
        :rtype: System.Text.Encodings.Web.UrlEncoder
    
        
        .. code-block:: csharp
    
            protected UrlEncoder UrlEncoder
            {
                get;
                set;
            }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.DiagnosticsViewPage.Views.BaseView
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.DiagnosticsViewPage.Views.BaseView.BeginWriteAttribute(System.String, System.String, System.Int32, System.String, System.Int32, System.Int32)
    
        
    
        
        :type name: System.String
    
        
        :type begining: System.String
    
        
        :type startPosition: System.Int32
    
        
        :type ending: System.String
    
        
        :type endPosition: System.Int32
    
        
        :type thingy: System.Int32
    
        
        .. code-block:: csharp
    
            protected void BeginWriteAttribute(string name, string begining, int startPosition, string ending, int endPosition, int thingy)
    
    .. dn:method:: Microsoft.AspNetCore.DiagnosticsViewPage.Views.BaseView.EndWriteAttribute()
    
        
    
        
        .. code-block:: csharp
    
            protected void EndWriteAttribute()
    
    .. dn:method:: Microsoft.AspNetCore.DiagnosticsViewPage.Views.BaseView.ExecuteAsync()
    
        
    
        
        Execute an individual request
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public abstract Task ExecuteAsync()
    
    .. dn:method:: Microsoft.AspNetCore.DiagnosticsViewPage.Views.BaseView.ExecuteAsync(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        Execute an individual request
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task ExecuteAsync(HttpContext context)
    
    .. dn:method:: Microsoft.AspNetCore.DiagnosticsViewPage.Views.BaseView.HtmlEncodeAndReplaceLineBreaks(System.String)
    
        
    
        
        :type input: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            protected string HtmlEncodeAndReplaceLineBreaks(string input)
    
    .. dn:method:: Microsoft.AspNetCore.DiagnosticsViewPage.Views.BaseView.Write(Microsoft.AspNetCore.DiagnosticsViewPage.Views.HelperResult)
    
        
    
        
        :dn:meth:`Microsoft.AspNetCore.DiagnosticsViewPage.Views.HelperResult.WriteTo(System.IO.TextWriter)` is invoked
    
        
    
        
        :param result: The :any:`Microsoft.AspNetCore.DiagnosticsViewPage.Views.HelperResult` to invoke
        
        :type result: Microsoft.AspNetCore.DiagnosticsViewPage.Views.HelperResult
    
        
        .. code-block:: csharp
    
            protected void Write(HelperResult result)
    
    .. dn:method:: Microsoft.AspNetCore.DiagnosticsViewPage.Views.BaseView.Write(System.Object)
    
        
    
        
        Convert to string and html encode
    
        
    
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
            protected void Write(object value)
    
    .. dn:method:: Microsoft.AspNetCore.DiagnosticsViewPage.Views.BaseView.Write(System.String)
    
        
    
        
        Html encode and write
    
        
    
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
            protected void Write(string value)
    
    .. dn:method:: Microsoft.AspNetCore.DiagnosticsViewPage.Views.BaseView.WriteAttributeTo(System.IO.TextWriter, System.String, System.String, System.String, Microsoft.AspNetCore.DiagnosticsViewPage.Views.AttributeValue[])
    
        
    
        
        Writes the given attribute to the given writer
    
        
    
        
        :param writer: The :any:`System.IO.TextWriter` instance to write to.
        
        :type writer: System.IO.TextWriter
    
        
        :param name: The name of the attribute to write
        
        :type name: System.String
    
        
        :param leader: The value of the prefix
        
        :type leader: System.String
    
        
        :param trailer: The value of the suffix
        
        :type trailer: System.String
    
        
        :param values: The :any:`Microsoft.AspNetCore.DiagnosticsViewPage.Views.AttributeValue`\s to write.
        
        :type values: Microsoft.AspNetCore.DiagnosticsViewPage.Views.AttributeValue<Microsoft.AspNetCore.DiagnosticsViewPage.Views.AttributeValue>[]
    
        
        .. code-block:: csharp
    
            protected void WriteAttributeTo(TextWriter writer, string name, string leader, string trailer, params AttributeValue[] values)
    
    .. dn:method:: Microsoft.AspNetCore.DiagnosticsViewPage.Views.BaseView.WriteAttributeValue(System.String, System.Int32, System.Object, System.Int32, System.Int32, System.Boolean)
    
        
    
        
        :type thingy: System.String
    
        
        :type startPostion: System.Int32
    
        
        :type value: System.Object
    
        
        :type endValue: System.Int32
    
        
        :type dealyo: System.Int32
    
        
        :type yesno: System.Boolean
    
        
        .. code-block:: csharp
    
            protected void WriteAttributeValue(string thingy, int startPostion, object value, int endValue, int dealyo, bool yesno)
    
    .. dn:method:: Microsoft.AspNetCore.DiagnosticsViewPage.Views.BaseView.WriteLiteral(System.Object)
    
        
    
        
        Write the given value directly to the output
    
        
    
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
            protected void WriteLiteral(object value)
    
    .. dn:method:: Microsoft.AspNetCore.DiagnosticsViewPage.Views.BaseView.WriteLiteral(System.String)
    
        
    
        
        Write the given value directly to the output
    
        
    
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
            protected void WriteLiteral(string value)
    
    .. dn:method:: Microsoft.AspNetCore.DiagnosticsViewPage.Views.BaseView.WriteLiteralTo(System.IO.TextWriter, System.Object)
    
        
    
        
        Writes the specified <em>value</em> without HTML encoding to the <em>writer</em>.
    
        
    
        
        :param writer: The :any:`System.IO.TextWriter` instance to write to.
        
        :type writer: System.IO.TextWriter
    
        
        :param value: The :any:`System.Object` to write.
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
            protected void WriteLiteralTo(TextWriter writer, object value)
    
    .. dn:method:: Microsoft.AspNetCore.DiagnosticsViewPage.Views.BaseView.WriteLiteralTo(System.IO.TextWriter, System.String)
    
        
    
        
        Writes the specified <em>value</em> without HTML encoding to :dn:prop:`Microsoft.AspNetCore.DiagnosticsViewPage.Views.BaseView.Output`\.
    
        
    
        
        :param writer: The :any:`System.IO.TextWriter` instance to write to.
        
        :type writer: System.IO.TextWriter
    
        
        :param value: The :any:`System.String` to write.
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
            protected void WriteLiteralTo(TextWriter writer, string value)
    
    .. dn:method:: Microsoft.AspNetCore.DiagnosticsViewPage.Views.BaseView.WriteTo(System.IO.TextWriter, System.Object)
    
        
    
        
        Writes the specified <em>value</em> to <em>writer</em>.
    
        
    
        
        :param writer: The :any:`System.IO.TextWriter` instance to write to.
        
        :type writer: System.IO.TextWriter
    
        
        :param value: The :any:`System.Object` to write.
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
            protected void WriteTo(TextWriter writer, object value)
    
    .. dn:method:: Microsoft.AspNetCore.DiagnosticsViewPage.Views.BaseView.WriteTo(System.IO.TextWriter, System.String)
    
        
    
        
        Writes the specified <em>value</em> with HTML encoding to <em>writer</em>.
    
        
    
        
        :param writer: The :any:`System.IO.TextWriter` instance to write to.
        
        :type writer: System.IO.TextWriter
    
        
        :param value: The :any:`System.String` to write.
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
            protected void WriteTo(TextWriter writer, string value)
    

