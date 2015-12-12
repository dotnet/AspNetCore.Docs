

LocalizedHtmlString Class
=========================



.. contents:: 
   :local:



Summary
-------

An :any:`Microsoft.AspNet.Mvc.Rendering.HtmlString` with localized content.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Rendering.HtmlString`
* :dn:cls:`Microsoft.AspNet.Mvc.Localization.LocalizedHtmlString`








Syntax
------

.. code-block:: csharp

   public class LocalizedHtmlString : HtmlString, IHtmlContent





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Localization/LocalizedHtmlString.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Localization.LocalizedHtmlString

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Localization.LocalizedHtmlString
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Localization.LocalizedHtmlString.LocalizedHtmlString(System.String, System.String)
    
        
    
        Creates an instance of :any:`Microsoft.AspNet.Mvc.Localization.LocalizedHtmlString`\.
    
        
        
        
        :param key: The name of the string resource.
        
        :type key: System.String
        
        
        :param value: The string resource.
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
           public LocalizedHtmlString(string key, string value)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Localization.LocalizedHtmlString.LocalizedHtmlString(System.String, System.String, System.Boolean)
    
        
    
        Creates an instance of :any:`Microsoft.AspNet.Mvc.Localization.LocalizedHtmlString`\.
    
        
        
        
        :param key: The name of the string resource.
        
        :type key: System.String
        
        
        :param value: The string resource.
        
        :type value: System.String
        
        
        :param isResourceNotFound: A flag that indicates if the resource is not found.
        
        :type isResourceNotFound: System.Boolean
    
        
        .. code-block:: csharp
    
           public LocalizedHtmlString(string key, string value, bool isResourceNotFound)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Localization.LocalizedHtmlString
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Localization.LocalizedHtmlString.IsResourceNotFound
    
        
    
        Gets a flag that indicates if the resource is not found.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsResourceNotFound { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Localization.LocalizedHtmlString.Key
    
        
    
        The name of the string resource.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Key { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Localization.LocalizedHtmlString.Value
    
        
    
        The string resource.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Value { get; }
    

