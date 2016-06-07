

HtmlLocalizerFactory Class
==========================






An :any:`Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizerFactory` that creates instances of :any:`Microsoft.AspNetCore.Mvc.Localization.HtmlLocalizer` using the
registered :any:`Microsoft.Extensions.Localization.IStringLocalizerFactory`\.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Localization.HtmlLocalizerFactory`








Syntax
------

.. code-block:: csharp

    public class HtmlLocalizerFactory : IHtmlLocalizerFactory








.. dn:class:: Microsoft.AspNetCore.Mvc.Localization.HtmlLocalizerFactory
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Localization.HtmlLocalizerFactory

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Localization.HtmlLocalizerFactory
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Localization.HtmlLocalizerFactory.HtmlLocalizerFactory(Microsoft.Extensions.Localization.IStringLocalizerFactory)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.Localization.HtmlLocalizerFactory`\.
    
        
    
        
        :param localizerFactory: The :any:`Microsoft.Extensions.Localization.IStringLocalizerFactory`\.
        
        :type localizerFactory: Microsoft.Extensions.Localization.IStringLocalizerFactory
    
        
        .. code-block:: csharp
    
            public HtmlLocalizerFactory(IStringLocalizerFactory localizerFactory)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Localization.HtmlLocalizerFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Localization.HtmlLocalizerFactory.Create(System.String, System.String)
    
        
    
        
        Creates an :any:`Microsoft.AspNetCore.Mvc.Localization.HtmlLocalizer` using the specified base name and location.
    
        
    
        
        :param baseName: The base name of the resource to load strings from.
        
        :type baseName: System.String
    
        
        :param location: The location to load resources from.
        
        :type location: System.String
        :rtype: Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizer
        :return: The :any:`Microsoft.AspNetCore.Mvc.Localization.HtmlLocalizer`\.
    
        
        .. code-block:: csharp
    
            public virtual IHtmlLocalizer Create(string baseName, string location)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Localization.HtmlLocalizerFactory.Create(System.Type)
    
        
    
        
        Creates an :any:`Microsoft.AspNetCore.Mvc.Localization.HtmlLocalizer` using the specified :any:`System.Type`\.
    
        
    
        
        :param resourceSource: The :any:`System.Type` to load resources for.
        
        :type resourceSource: System.Type
        :rtype: Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizer
        :return: The :any:`Microsoft.AspNetCore.Mvc.Localization.HtmlLocalizer`\.
    
        
        .. code-block:: csharp
    
            public virtual IHtmlLocalizer Create(Type resourceSource)
    

