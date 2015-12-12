

HtmlLocalizerFactory Class
==========================



.. contents:: 
   :local:



Summary
-------

An :any:`Microsoft.AspNet.Mvc.Localization.IHtmlLocalizerFactory` that creates instances of :any:`Microsoft.AspNet.Mvc.Localization.HtmlLocalizer`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Localization.HtmlLocalizerFactory`








Syntax
------

.. code-block:: csharp

   public class HtmlLocalizerFactory : IHtmlLocalizerFactory





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Localization/HtmlLocalizerFactory.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Localization.HtmlLocalizerFactory

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Localization.HtmlLocalizerFactory
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Localization.HtmlLocalizerFactory.HtmlLocalizerFactory(Microsoft.Extensions.Localization.IStringLocalizerFactory, Microsoft.Extensions.WebEncoders.IHtmlEncoder)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.Localization.HtmlLocalizer`\.
    
        
        
        
        :param localizerFactory: The .
        
        :type localizerFactory: Microsoft.Extensions.Localization.IStringLocalizerFactory
        
        
        :param encoder: The .
        
        :type encoder: Microsoft.Extensions.WebEncoders.IHtmlEncoder
    
        
        .. code-block:: csharp
    
           public HtmlLocalizerFactory(IStringLocalizerFactory localizerFactory, IHtmlEncoder encoder)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Localization.HtmlLocalizerFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Localization.HtmlLocalizerFactory.Create(System.String, System.String)
    
        
    
        Creates an :any:`Microsoft.AspNet.Mvc.Localization.HtmlLocalizer`\.
    
        
        
        
        :param baseName: The base name of the resource to load strings from.
        
        :type baseName: System.String
        
        
        :param location: The location to load resources from.
        
        :type location: System.String
        :rtype: Microsoft.AspNet.Mvc.Localization.IHtmlLocalizer
        :return: The <see cref="T:Microsoft.AspNet.Mvc.Localization.HtmlLocalizer" />.
    
        
        .. code-block:: csharp
    
           public virtual IHtmlLocalizer Create(string baseName, string location)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Localization.HtmlLocalizerFactory.Create(System.Type)
    
        
    
        Creates an :any:`Microsoft.AspNet.Mvc.Localization.HtmlLocalizer` using the :any:`System.Reflection.Assembly` and 
        :dn:prop:`System.Type.FullName` of the specified :any:`System.Type`\.
    
        
        
        
        :param resourceSource: The .
        
        :type resourceSource: System.Type
        :rtype: Microsoft.AspNet.Mvc.Localization.IHtmlLocalizer
        :return: The <see cref="T:Microsoft.AspNet.Mvc.Localization.HtmlLocalizer" />.
    
        
        .. code-block:: csharp
    
           public virtual IHtmlLocalizer Create(Type resourceSource)
    

