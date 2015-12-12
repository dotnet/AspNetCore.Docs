

FromFormAttribute Class
=======================



.. contents:: 
   :local:



Summary
-------

Specifies that a parameter or property should be bound using form-data in the request body.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNet.Mvc.FromFormAttribute`








Syntax
------

.. code-block:: csharp

   public class FromFormAttribute : Attribute, _Attribute, IBindingSourceMetadata, IModelNameProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/FromFormAttribute.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.FromFormAttribute

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.FromFormAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.FromFormAttribute.BindingSource
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.BindingSource
    
        
        .. code-block:: csharp
    
           public BindingSource BindingSource { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.FromFormAttribute.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Name { get; set; }
    

