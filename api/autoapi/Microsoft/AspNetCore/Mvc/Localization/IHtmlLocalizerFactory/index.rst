

IHtmlLocalizerFactory Interface
===============================






A factory that creates :any:`Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizer` instances.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Localization`
Assemblies
    * Microsoft.AspNetCore.Mvc.Localization

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IHtmlLocalizerFactory








.. dn:interface:: Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizerFactory
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizerFactory

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizerFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizerFactory.Create(System.String, System.String)
    
        
    
        
        Creates an :any:`Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizer`\.
    
        
    
        
        :param baseName: The base name of the resource to load strings from.
        
        :type baseName: System.String
    
        
        :param location: The location to load resources from.
        
        :type location: System.String
        :rtype: Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizer
        :return: The :any:`Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizer`\.
    
        
        .. code-block:: csharp
    
            IHtmlLocalizer Create(string baseName, string location)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizerFactory.Create(System.Type)
    
        
    
        
        Creates an :any:`Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizer` using the :any:`System.Reflection.Assembly` and 
        :dn:prop:`System.Type.FullName` of the specified :any:`System.Type`\.
    
        
    
        
        :param resourceSource: The :any:`System.Type`\.
        
        :type resourceSource: System.Type
        :rtype: Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizer
        :return: The :any:`Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizer`\.
    
        
        .. code-block:: csharp
    
            IHtmlLocalizer Create(Type resourceSource)
    

