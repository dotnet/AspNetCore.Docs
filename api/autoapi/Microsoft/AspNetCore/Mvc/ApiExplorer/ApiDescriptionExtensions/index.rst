

ApiDescriptionExtensions Class
==============================






Extension methods for :any:`Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescription`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ApiExplorer`
Assemblies
    * Microsoft.AspNetCore.Mvc.ApiExplorer

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionExtensions`








Syntax
------

.. code-block:: csharp

    public class ApiDescriptionExtensions








.. dn:class:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionExtensions.GetProperty<T>(Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescription)
    
        
    
        
        Gets the value of a property from the :dn:prop:`Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescription.Properties` collection
        using the provided value of <em>T</em> as the key.
    
        
    
        
        :param apiDescription: The :any:`Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescription`\.
        
        :type apiDescription: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescription
        :rtype: T
        :return: The property or the default value of <em>T</em>.
    
        
        .. code-block:: csharp
    
            public static T GetProperty<T>(this ApiDescription apiDescription)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionExtensions.SetProperty<T>(Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescription, T)
    
        
    
        
        Sets the value of an property in the :dn:prop:`Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescription.Properties` collection using
        the provided value of <em>T</em> as the key.
    
        
    
        
        :param apiDescription: The :any:`Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescription`\.
        
        :type apiDescription: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescription
    
        
        :param value: The value of the property.
        
        :type value: T
    
        
        .. code-block:: csharp
    
            public static void SetProperty<T>(this ApiDescription apiDescription, T value)
    

