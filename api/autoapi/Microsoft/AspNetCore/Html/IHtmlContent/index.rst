

IHtmlContent Interface
======================






HTML content which can be written to a TextWriter.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Html`
Assemblies
    * Microsoft.AspNetCore.Html.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IHtmlContent








.. dn:interface:: Microsoft.AspNetCore.Html.IHtmlContent
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Html.IHtmlContent

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Html.IHtmlContent
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Html.IHtmlContent.WriteTo(System.IO.TextWriter, System.Text.Encodings.Web.HtmlEncoder)
    
        
    
        
        Writes the content by encoding it with the specified <em>encoder</em>
        to the specified <em>writer</em>.
    
        
    
        
        :param writer: The :any:`System.IO.TextWriter` to which the content is written.
        
        :type writer: System.IO.TextWriter
    
        
        :param encoder: The :any:`System.Text.Encodings.Web.HtmlEncoder` which encodes the content to be written.
        
        :type encoder: System.Text.Encodings.Web.HtmlEncoder
    
        
        .. code-block:: csharp
    
            void WriteTo(TextWriter writer, HtmlEncoder encoder)
    

