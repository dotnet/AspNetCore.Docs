

ActionDescriptorExtensions Class
================================






Extension methods for :any:`Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Abstractions`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptorExtensions`








Syntax
------

.. code-block:: csharp

    public class ActionDescriptorExtensions








.. dn:class:: Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptorExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptorExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptorExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptorExtensions.GetProperty<T>(Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor)
    
        
    
        
        Gets the value of a property from the :dn:prop:`Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor.Properties` collection
        using the provided value of <em>T</em> as the key.
    
        
    
        
        :param actionDescriptor: The action descriptor.
        
        :type actionDescriptor: Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor
        :rtype: T
        :return: The property or the default value of <em>T</em>.
    
        
        .. code-block:: csharp
    
            public static T GetProperty<T>(ActionDescriptor actionDescriptor)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptorExtensions.SetProperty<T>(Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor, T)
    
        
    
        
        Sets the value of an property in the :dn:prop:`Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor.Properties` collection using
        the provided value of <em>T</em> as the key.
    
        
    
        
        :param actionDescriptor: The action descriptor.
        
        :type actionDescriptor: Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor
    
        
        :param value: The value of the property.
        
        :type value: T
    
        
        .. code-block:: csharp
    
            public static void SetProperty<T>(ActionDescriptor actionDescriptor, T value)
    

