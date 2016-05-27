

IHtmlContentContainer Interface
===============================






Defines a contract for :any:`Microsoft.AspNetCore.Html.IHtmlContent` instances made up of several components which
can be copied into an :any:`Microsoft.AspNetCore.Html.IHtmlContentBuilder`\.


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

    public interface IHtmlContentContainer : IHtmlContent








.. dn:interface:: Microsoft.AspNetCore.Html.IHtmlContentContainer
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Html.IHtmlContentContainer

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Html.IHtmlContentContainer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Html.IHtmlContentContainer.CopyTo(Microsoft.AspNetCore.Html.IHtmlContentBuilder)
    
        
    
        
        Copies the contained content of this :any:`Microsoft.AspNetCore.Html.IHtmlContentContainer` into <em>builder</em>.
    
        
    
        
        :param builder: The :any:`Microsoft.AspNetCore.Html.IHtmlContentBuilder`\.
        
        :type builder: Microsoft.AspNetCore.Html.IHtmlContentBuilder
    
        
        .. code-block:: csharp
    
            void CopyTo(IHtmlContentBuilder builder)
    
    .. dn:method:: Microsoft.AspNetCore.Html.IHtmlContentContainer.MoveTo(Microsoft.AspNetCore.Html.IHtmlContentBuilder)
    
        
    
        
        <p>
        Moves the contained content of this :any:`Microsoft.AspNetCore.Html.IHtmlContentContainer` into <em>builder</em>.
        </p>
        <p>
        After :dn:meth:`Microsoft.AspNetCore.Html.IHtmlContentContainer.MoveTo(Microsoft.AspNetCore.Html.IHtmlContentBuilder)` is called, this :any:`Microsoft.AspNetCore.Html.IHtmlContentContainer` instance should be left
        in an empty state.
        </p>
    
        
    
        
        :param builder: The :any:`Microsoft.AspNetCore.Html.IHtmlContentBuilder`\.
        
        :type builder: Microsoft.AspNetCore.Html.IHtmlContentBuilder
    
        
        .. code-block:: csharp
    
            void MoveTo(IHtmlContentBuilder builder)
    

