

IStringLocalizerFactory Interface
=================================






Represents a factory that creates :any:`Microsoft.Extensions.Localization.IStringLocalizer` instances.


Namespace
    :dn:ns:`Microsoft.Extensions.Localization`
Assemblies
    * Microsoft.Extensions.Localization.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IStringLocalizerFactory








.. dn:interface:: Microsoft.Extensions.Localization.IStringLocalizerFactory
    :hidden:

.. dn:interface:: Microsoft.Extensions.Localization.IStringLocalizerFactory

Methods
-------

.. dn:interface:: Microsoft.Extensions.Localization.IStringLocalizerFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Localization.IStringLocalizerFactory.Create(System.String, System.String)
    
        
    
        
        Creates an :any:`Microsoft.Extensions.Localization.IStringLocalizer`\.
    
        
    
        
        :param baseName: The base name of the resource to load strings from.
        
        :type baseName: System.String
    
        
        :param location: The location to load resources from.
        
        :type location: System.String
        :rtype: Microsoft.Extensions.Localization.IStringLocalizer
        :return: The :any:`Microsoft.Extensions.Localization.IStringLocalizer`\.
    
        
        .. code-block:: csharp
    
            IStringLocalizer Create(string baseName, string location)
    
    .. dn:method:: Microsoft.Extensions.Localization.IStringLocalizerFactory.Create(System.Type)
    
        
    
        
        Creates an :any:`Microsoft.Extensions.Localization.IStringLocalizer` using the :any:`System.Reflection.Assembly` and 
        :dn:prop:`System.Type.FullName` of the specified :any:`System.Type`\.
    
        
    
        
        :param resourceSource: The :any:`System.Type`\.
        
        :type resourceSource: System.Type
        :rtype: Microsoft.Extensions.Localization.IStringLocalizer
        :return: The :any:`Microsoft.Extensions.Localization.IStringLocalizer`\.
    
        
        .. code-block:: csharp
    
            IStringLocalizer Create(Type resourceSource)
    

