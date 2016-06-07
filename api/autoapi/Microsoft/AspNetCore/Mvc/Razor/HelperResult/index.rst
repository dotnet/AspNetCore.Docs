

HelperResult Class
==================






Represents a deferred write operation in a :any:`Microsoft.AspNetCore.Mvc.Razor.RazorPage`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Razor`
Assemblies
    * Microsoft.AspNetCore.Mvc.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Razor.HelperResult`








Syntax
------

.. code-block:: csharp

    public class HelperResult : IHtmlContent








.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.HelperResult
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.HelperResult

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.HelperResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.HelperResult.WriteAction
    
        
    
        
        Gets the asynchronous delegate to invoke when :dn:meth:`Microsoft.AspNetCore.Mvc.Razor.HelperResult.WriteTo(System.IO.TextWriter,System.Text.Encodings.Web.HtmlEncoder)` is called.
    
        
        :rtype: System.Func<System.Func`2>{System.IO.TextWriter<System.IO.TextWriter>, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}
    
        
        .. code-block:: csharp
    
            public Func<TextWriter, Task> WriteAction
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.HelperResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.HelperResult.HelperResult(System.Func<System.IO.TextWriter, System.Threading.Tasks.Task>)
    
        
    
        
        Creates a new instance of :any:`Microsoft.AspNetCore.Mvc.Razor.HelperResult`\.
    
        
    
        
        :param asyncAction: The asynchronous delegate to invoke when 
            :dn:meth:`Microsoft.AspNetCore.Mvc.Razor.HelperResult.WriteTo(System.IO.TextWriter,System.Text.Encodings.Web.HtmlEncoder)` is called.
        
        :type asyncAction: System.Func<System.Func`2>{System.IO.TextWriter<System.IO.TextWriter>, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}
    
        
        .. code-block:: csharp
    
            public HelperResult(Func<TextWriter, Task> asyncAction)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.HelperResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.HelperResult.WriteTo(System.IO.TextWriter, System.Text.Encodings.Web.HtmlEncoder)
    
        
    
        
        Method invoked to produce content from the :any:`Microsoft.AspNetCore.Mvc.Razor.HelperResult`\.
    
        
    
        
        :param writer: The :any:`System.IO.TextWriter` instance to write to.
        
        :type writer: System.IO.TextWriter
    
        
        :param encoder: The :any:`System.Text.Encodings.Web.HtmlEncoder` to encode the content.
        
        :type encoder: System.Text.Encodings.Web.HtmlEncoder
    
        
        .. code-block:: csharp
    
            public virtual void WriteTo(TextWriter writer, HtmlEncoder encoder)
    

