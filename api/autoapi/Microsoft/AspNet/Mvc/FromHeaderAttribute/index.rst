

FromHeaderAttribute Class
=========================



.. contents:: 
   :local:



Summary
-------

Specifies that a parameter or property should be bound using the request headers.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNet.Mvc.FromHeaderAttribute`








Syntax
------

.. code-block:: csharp

   public class FromHeaderAttribute : Attribute, _Attribute, IBindingSourceMetadata, IModelNameProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/FromHeaderAttribute.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.FromHeaderAttribute

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.FromHeaderAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.FromHeaderAttribute.BindingSource
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.BindingSource
    
        
        .. code-block:: csharp
    
           public BindingSource BindingSource { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.FromHeaderAttribute.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Name { get; set; }
    

