

IStringLocalizerFactory Interface
=================================



.. contents:: 
   :local:



Summary
-------

Represents a factory that creates :any:`Microsoft.Extensions.Localization.IStringLocalizer` instances.











Syntax
------

.. code-block:: csharp

   public interface IStringLocalizerFactory





GitHub
------

`View on GitHub <https://github.com/aspnet/localization/blob/master/src/Microsoft.Extensions.Localization.Abstractions/IStringLocalizerFactory.cs>`_





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
        :return: The <see cref="T:Microsoft.Extensions.Localization.IStringLocalizer" />.
    
        
        .. code-block:: csharp
    
           IStringLocalizer Create(string baseName, string location)
    
    .. dn:method:: Microsoft.Extensions.Localization.IStringLocalizerFactory.Create(System.Type)
    
        
    
        Creates an :any:`Microsoft.Extensions.Localization.IStringLocalizer` using the :any:`System.Reflection.Assembly` and 
        :dn:prop:`System.Type.FullName` of the specified :any:`System.Type`\.
    
        
        
        
        :param resourceSource: The .
        
        :type resourceSource: System.Type
        :rtype: Microsoft.Extensions.Localization.IStringLocalizer
        :return: The <see cref="T:Microsoft.Extensions.Localization.IStringLocalizer" />.
    
        
        .. code-block:: csharp
    
           IStringLocalizer Create(Type resourceSource)
    

