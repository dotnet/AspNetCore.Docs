

IHtmlLocalizerFactory Interface
===============================



.. contents:: 
   :local:



Summary
-------

A factory that creates :any:`Microsoft.AspNet.Mvc.Localization.IHtmlLocalizer` instances.











Syntax
------

.. code-block:: csharp

   public interface IHtmlLocalizerFactory





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Localization/IHtmlLocalizerFactory.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Localization.IHtmlLocalizerFactory

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.Localization.IHtmlLocalizerFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Localization.IHtmlLocalizerFactory.Create(System.String, System.String)
    
        
    
        Creates an :any:`Microsoft.AspNet.Mvc.Localization.IHtmlLocalizer`\.
    
        
        
        
        :param baseName: The base name of the resource to load strings from.
        
        :type baseName: System.String
        
        
        :param location: The location to load resources from.
        
        :type location: System.String
        :rtype: Microsoft.AspNet.Mvc.Localization.IHtmlLocalizer
        :return: The <see cref="T:Microsoft.AspNet.Mvc.Localization.IHtmlLocalizer" />.
    
        
        .. code-block:: csharp
    
           IHtmlLocalizer Create(string baseName, string location)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Localization.IHtmlLocalizerFactory.Create(System.Type)
    
        
    
        Creates an :any:`Microsoft.AspNet.Mvc.Localization.IHtmlLocalizer` using the :any:`System.Reflection.Assembly` and 
        :dn:prop:`System.Type.FullName` of the specified :any:`System.Type`\.
    
        
        
        
        :param resourceSource: The .
        
        :type resourceSource: System.Type
        :rtype: Microsoft.AspNet.Mvc.Localization.IHtmlLocalizer
        :return: The <see cref="T:Microsoft.AspNet.Mvc.Localization.IHtmlLocalizer" />.
    
        
        .. code-block:: csharp
    
           IHtmlLocalizer Create(Type resourceSource)
    

