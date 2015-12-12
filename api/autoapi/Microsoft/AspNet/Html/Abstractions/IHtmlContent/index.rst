

IHtmlContent Interface
======================



.. contents:: 
   :local:



Summary
-------

HTML content which can be written to a TextWriter.











Syntax
------

.. code-block:: csharp

   public interface IHtmlContent





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.Html.Abstractions/IHtmlContent.cs>`_





.. dn:interface:: Microsoft.AspNet.Html.Abstractions.IHtmlContent

Methods
-------

.. dn:interface:: Microsoft.AspNet.Html.Abstractions.IHtmlContent
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Html.Abstractions.IHtmlContent.WriteTo(System.IO.TextWriter, Microsoft.Extensions.WebEncoders.IHtmlEncoder)
    
        
    
        Writes the content by encoding it with the specified ``encoder``
        to the specified ``writer``.
    
        
        
        
        :param writer: The  to which the content is written.
        
        :type writer: System.IO.TextWriter
        
        
        :param encoder: The  which encodes the content to be written.
        
        :type encoder: Microsoft.Extensions.WebEncoders.IHtmlEncoder
    
        
        .. code-block:: csharp
    
           void WriteTo(TextWriter writer, IHtmlEncoder encoder)
    

