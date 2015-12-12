

HelperResult Class
==================



.. contents:: 
   :local:



Summary
-------

Represents a deferred write operation in a :any:`Microsoft.AspNet.Mvc.Razor.RazorPage`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.HelperResult`








Syntax
------

.. code-block:: csharp

   public class HelperResult : IHtmlContent





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Razor/HelperResult.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.HelperResult

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.HelperResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Razor.HelperResult.HelperResult(System.Func<System.IO.TextWriter, System.Threading.Tasks.Task>)
    
        
    
        Creates a new instance of :any:`Microsoft.AspNet.Mvc.Razor.HelperResult`\.
    
        
        
        
        :param asyncAction: The asynchronous delegate to invoke when
            is called.
        
        :type asyncAction: System.Func{System.IO.TextWriter,System.Threading.Tasks.Task}
    
        
        .. code-block:: csharp
    
           public HelperResult(Func<TextWriter, Task> asyncAction)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.HelperResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.HelperResult.WriteTo(System.IO.TextWriter, Microsoft.Extensions.WebEncoders.IHtmlEncoder)
    
        
    
        Method invoked to produce content from the :any:`Microsoft.AspNet.Mvc.Razor.HelperResult`\.
    
        
        
        
        :param writer: The  instance to write to.
        
        :type writer: System.IO.TextWriter
        
        
        :param encoder: The  to encode the content.
        
        :type encoder: Microsoft.Extensions.WebEncoders.IHtmlEncoder
    
        
        .. code-block:: csharp
    
           public virtual void WriteTo(TextWriter writer, IHtmlEncoder encoder)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.HelperResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.HelperResult.WriteAction
    
        
    
        Gets the asynchronous delegate to invoke when :dn:meth:`Microsoft.AspNet.Mvc.Razor.HelperResult.WriteTo(System.IO.TextWriter,Microsoft.Extensions.WebEncoders.IHtmlEncoder)` is called.
    
        
        :rtype: System.Func{System.IO.TextWriter,System.Threading.Tasks.Task}
    
        
        .. code-block:: csharp
    
           public Func<TextWriter, Task> WriteAction { get; }
    

