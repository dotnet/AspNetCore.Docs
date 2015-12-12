

HtmlTextWriter Class
====================



.. contents:: 
   :local:



Summary
-------

A :any:`System.IO.TextWriter` which supports special processing of :any:`Microsoft.AspNet.Html.Abstractions.IHtmlContent`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.MarshalByRefObject`
* :dn:cls:`System.IO.TextWriter`
* :dn:cls:`Microsoft.AspNet.Mvc.ViewFeatures.HtmlTextWriter`








Syntax
------

.. code-block:: csharp

   public abstract class HtmlTextWriter : TextWriter, IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.ViewFeatures/HtmlTextWriter.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlTextWriter

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlTextWriter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlTextWriter.Write(Microsoft.AspNet.Html.Abstractions.IHtmlContent)
    
        
    
        Writes an :any:`Microsoft.AspNet.Html.Abstractions.IHtmlContent` value.
    
        
        
        
        :param value: The  value.
        
        :type value: Microsoft.AspNet.Html.Abstractions.IHtmlContent
    
        
        .. code-block:: csharp
    
           public abstract void Write(IHtmlContent value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlTextWriter.Write(System.Object)
    
        
        
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
           public override void Write(object value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.HtmlTextWriter.WriteLine(System.Object)
    
        
        
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
           public override void WriteLine(object value)
    

