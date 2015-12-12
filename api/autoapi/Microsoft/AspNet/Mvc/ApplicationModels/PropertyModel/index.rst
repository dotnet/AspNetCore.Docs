

PropertyModel Class
===================



.. contents:: 
   :local:



Summary
-------

A type which is used to represent a property in a :any:`Microsoft.AspNet.Mvc.ApplicationModels.ControllerModel`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ApplicationModels.PropertyModel`








Syntax
------

.. code-block:: csharp

   public class PropertyModel : ICommonModel, IPropertyModel, IBindingModel





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/ApplicationModels/PropertyModel.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ApplicationModels.PropertyModel

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ApplicationModels.PropertyModel
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ApplicationModels.PropertyModel.PropertyModel(Microsoft.AspNet.Mvc.ApplicationModels.PropertyModel)
    
        
    
        Creats a new instance of :any:`Microsoft.AspNet.Mvc.ApplicationModels.PropertyModel` from a given :any:`Microsoft.AspNet.Mvc.ApplicationModels.PropertyModel`\.
    
        
        
        
        :param other: The  which needs to be copied.
        
        :type other: Microsoft.AspNet.Mvc.ApplicationModels.PropertyModel
    
        
        .. code-block:: csharp
    
           public PropertyModel(PropertyModel other)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ApplicationModels.PropertyModel.PropertyModel(System.Reflection.PropertyInfo, System.Collections.Generic.IReadOnlyList<System.Object>)
    
        
    
        Creates a new instance of :any:`Microsoft.AspNet.Mvc.ApplicationModels.PropertyModel`\.
    
        
        
        
        :param propertyInfo: The  for the underlying property.
        
        :type propertyInfo: System.Reflection.PropertyInfo
        
        
        :param attributes: Any attributes which are annotated on the property.
        
        :type attributes: System.Collections.Generic.IReadOnlyList{System.Object}
    
        
        .. code-block:: csharp
    
           public PropertyModel(PropertyInfo propertyInfo, IReadOnlyList<object> attributes)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ApplicationModels.PropertyModel
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.PropertyModel.Attributes
    
        
    
        Gets any attributes which are annotated on the property.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList{System.Object}
    
        
        .. code-block:: csharp
    
           public IReadOnlyList<object> Attributes { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.PropertyModel.BindingInfo
    
        
    
        Gets or sets the :dn:prop:`Microsoft.AspNet.Mvc.ApplicationModels.PropertyModel.BindingInfo` associated with this model.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.BindingInfo
    
        
        .. code-block:: csharp
    
           public BindingInfo BindingInfo { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.PropertyModel.Controller
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Mvc.ApplicationModels.ControllerModel` this :any:`Microsoft.AspNet.Mvc.ApplicationModels.PropertyModel` is associated with.
    
        
        :rtype: Microsoft.AspNet.Mvc.ApplicationModels.ControllerModel
    
        
        .. code-block:: csharp
    
           public ControllerModel Controller { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.PropertyModel.Microsoft.AspNet.Mvc.ApplicationModels.ICommonModel.MemberInfo
    
        
        :rtype: System.Reflection.MemberInfo
    
        
        .. code-block:: csharp
    
           MemberInfo ICommonModel.MemberInfo { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.PropertyModel.Microsoft.AspNet.Mvc.ApplicationModels.ICommonModel.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string ICommonModel.Name { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.PropertyModel.Properties
    
        
        :rtype: System.Collections.Generic.IDictionary{System.Object,System.Object}
    
        
        .. code-block:: csharp
    
           public IDictionary<object, object> Properties { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.PropertyModel.PropertyInfo
    
        
    
        Gets the underlying :dn:prop:`Microsoft.AspNet.Mvc.ApplicationModels.PropertyModel.PropertyInfo`\.
    
        
        :rtype: System.Reflection.PropertyInfo
    
        
        .. code-block:: csharp
    
           public PropertyInfo PropertyInfo { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.PropertyModel.PropertyName
    
        
    
        Gets or sets the name of the property represented by this model.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string PropertyName { get; set; }
    

