

ApiDescriptionExtensions Class
==============================



.. contents:: 
   :local:



Summary
-------

Extension methods for :any:`Microsoft.AspNet.Mvc.ApiExplorer.ApiDescription`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionExtensions`








Syntax
------

.. code-block:: csharp

   public class ApiDescriptionExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ApiExplorer/ApiDescriptionExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionExtensions.GetProperty<T>(Microsoft.AspNet.Mvc.ApiExplorer.ApiDescription)
    
        
    
        Gets the value of a property from the :dn:prop:`Microsoft.AspNet.Mvc.ApiExplorer.ApiDescription.Properties` collection
        using the provided value of ``T`` as the key.
    
        
        
        
        :param apiDescription: The .
        
        :type apiDescription: Microsoft.AspNet.Mvc.ApiExplorer.ApiDescription
        :rtype: {T}
        :return: The property or the default value of <typeparamref name="T" />.
    
        
        .. code-block:: csharp
    
           public static T GetProperty<T>(ApiDescription apiDescription)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ApiExplorer.ApiDescriptionExtensions.SetProperty<T>(Microsoft.AspNet.Mvc.ApiExplorer.ApiDescription, T)
    
        
    
        Sets the value of an property in the :dn:prop:`Microsoft.AspNet.Mvc.ApiExplorer.ApiDescription.Properties` collection using
        the provided value of ``T`` as the key.
    
        
        
        
        :param apiDescription: The .
        
        :type apiDescription: Microsoft.AspNet.Mvc.ApiExplorer.ApiDescription
        
        
        :param value: The value of the property.
        
        :type value: {T}
    
        
        .. code-block:: csharp
    
           public static void SetProperty<T>(ApiDescription apiDescription, T value)
    

