

ActionDescriptorExtensions Class
================================



.. contents:: 
   :local:



Summary
-------

Extension methods for :any:`Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Abstractions.ActionDescriptorExtensions`








Syntax
------

.. code-block:: csharp

   public class ActionDescriptorExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Abstractions/Abstractions/ActionDescriptorExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Abstractions.ActionDescriptorExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Abstractions.ActionDescriptorExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Abstractions.ActionDescriptorExtensions.GetProperty<T>(Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor)
    
        
    
        Gets the value of a property from the :dn:prop:`Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor.Properties` collection
        using the provided value of ``T`` as the key.
    
        
        
        
        :param actionDescriptor: The action descriptor.
        
        :type actionDescriptor: Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor
        :rtype: {T}
        :return: The property or the default value of <typeparamref name="T" />.
    
        
        .. code-block:: csharp
    
           public static T GetProperty<T>(ActionDescriptor actionDescriptor)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Abstractions.ActionDescriptorExtensions.SetProperty<T>(Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor, T)
    
        
    
        Sets the value of an property in the :dn:prop:`Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor.Properties` collection using
        the provided value of ``T`` as the key.
    
        
        
        
        :param actionDescriptor: The action descriptor.
        
        :type actionDescriptor: Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor
        
        
        :param value: The value of the property.
        
        :type value: {T}
    
        
        .. code-block:: csharp
    
           public static void SetProperty<T>(ActionDescriptor actionDescriptor, T value)
    

