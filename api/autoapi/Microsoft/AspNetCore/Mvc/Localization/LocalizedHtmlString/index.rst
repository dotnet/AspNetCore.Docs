

LocalizedHtmlString Class
=========================






An :any:`Microsoft.AspNetCore.Html.IHtmlContent` with localized content.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Localization`
Assemblies
    * Microsoft.AspNetCore.Mvc.Localization

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Localization.LocalizedHtmlString`








Syntax
------

.. code-block:: csharp

    public class LocalizedHtmlString : IHtmlContent








.. dn:class:: Microsoft.AspNetCore.Mvc.Localization.LocalizedHtmlString
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Localization.LocalizedHtmlString

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Localization.LocalizedHtmlString
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Localization.LocalizedHtmlString.LocalizedHtmlString(System.String, System.String)
    
        
    
        
        Creates an instance of :any:`Microsoft.AspNetCore.Mvc.Localization.LocalizedHtmlString`\.
    
        
    
        
        :param name: The name of the string resource.
        
        :type name: System.String
    
        
        :param value: The string resource.
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
            public LocalizedHtmlString(string name, string value)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Localization.LocalizedHtmlString.LocalizedHtmlString(System.String, System.String, System.Boolean)
    
        
    
        
        Creates an instance of :any:`Microsoft.AspNetCore.Mvc.Localization.LocalizedHtmlString`\.
    
        
    
        
        :param name: The name of the string resource.
        
        :type name: System.String
    
        
        :param value: The string resource.
        
        :type value: System.String
    
        
        :param isResourceNotFound: A flag that indicates if the resource is not found.
        
        :type isResourceNotFound: System.Boolean
    
        
        .. code-block:: csharp
    
            public LocalizedHtmlString(string name, string value, bool isResourceNotFound)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Localization.LocalizedHtmlString.LocalizedHtmlString(System.String, System.String, System.Boolean, System.Object[])
    
        
    
        
        Creates an instance of :any:`Microsoft.AspNetCore.Mvc.Localization.LocalizedHtmlString`\.
    
        
    
        
        :param name: The name of the string resource.
        
        :type name: System.String
    
        
        :param value: The string resource.
        
        :type value: System.String
    
        
        :param isResourceNotFound: A flag that indicates if the resource is not found.
        
        :type isResourceNotFound: System.Boolean
    
        
        :param arguments: The values to format the <em>value</em> with.
        
        :type arguments: System.Object<System.Object>[]
    
        
        .. code-block:: csharp
    
            public LocalizedHtmlString(string name, string value, bool isResourceNotFound, params object[] arguments)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Localization.LocalizedHtmlString
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Localization.LocalizedHtmlString.IsResourceNotFound
    
        
    
        
        Gets a flag that indicates if the resource is not found.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsResourceNotFound { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Localization.LocalizedHtmlString.Name
    
        
    
        
        The name of the string resource.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Name { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Localization.LocalizedHtmlString.Value
    
        
    
        
        The string resource.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Value { get; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Localization.LocalizedHtmlString
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Localization.LocalizedHtmlString.WriteTo(System.IO.TextWriter, System.Text.Encodings.Web.HtmlEncoder)
    
        
    
        
        :type writer: System.IO.TextWriter
    
        
        :type encoder: System.Text.Encodings.Web.HtmlEncoder
    
        
        .. code-block:: csharp
    
            public void WriteTo(TextWriter writer, HtmlEncoder encoder)
    

