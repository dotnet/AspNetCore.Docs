

PropertyModel Class
===================






A type which is used to represent a property in a :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.ControllerModel`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ApplicationModels`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ApplicationModels.PropertyModel`








Syntax
------

.. code-block:: csharp

    [DebuggerDisplay("PropertyModel: Name={PropertyName}")]
    public class PropertyModel : ICommonModel, IPropertyModel, IBindingModel








.. dn:class:: Microsoft.AspNetCore.Mvc.ApplicationModels.PropertyModel
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ApplicationModels.PropertyModel

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ApplicationModels.PropertyModel
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.PropertyModel.Attributes
    
        
    
        
        Gets any attributes which are annotated on the property.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public IReadOnlyList<object> Attributes
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.PropertyModel.BindingInfo
    
        
    
        
        Gets or sets the :dn:prop:`Microsoft.AspNetCore.Mvc.ApplicationModels.PropertyModel.BindingInfo` associated with this model.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.BindingInfo
    
        
        .. code-block:: csharp
    
            public BindingInfo BindingInfo
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.PropertyModel.Controller
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.ControllerModel` this :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.PropertyModel` is associated with.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ApplicationModels.ControllerModel
    
        
        .. code-block:: csharp
    
            public ControllerModel Controller
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.PropertyModel.Microsoft.AspNetCore.Mvc.ApplicationModels.ICommonModel.MemberInfo
    
        
        :rtype: System.Reflection.MemberInfo
    
        
        .. code-block:: csharp
    
            MemberInfo ICommonModel.MemberInfo
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.PropertyModel.Microsoft.AspNetCore.Mvc.ApplicationModels.ICommonModel.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string ICommonModel.Name
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.PropertyModel.Properties
    
        
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.Object<System.Object>, System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public IDictionary<object, object> Properties
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.PropertyModel.PropertyInfo
    
        
    
        
        Gets the underlying :dn:prop:`Microsoft.AspNetCore.Mvc.ApplicationModels.PropertyModel.PropertyInfo`\.
    
        
        :rtype: System.Reflection.PropertyInfo
    
        
        .. code-block:: csharp
    
            public PropertyInfo PropertyInfo
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.PropertyModel.PropertyName
    
        
    
        
        Gets or sets the name of the property represented by this model.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string PropertyName
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ApplicationModels.PropertyModel
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ApplicationModels.PropertyModel.PropertyModel(Microsoft.AspNetCore.Mvc.ApplicationModels.PropertyModel)
    
        
    
        
        Creats a new instance of :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.PropertyModel` from a given :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.PropertyModel`\.
    
        
    
        
        :param other: The :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.PropertyModel` which needs to be copied.
        
        :type other: Microsoft.AspNetCore.Mvc.ApplicationModels.PropertyModel
    
        
        .. code-block:: csharp
    
            public PropertyModel(PropertyModel other)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ApplicationModels.PropertyModel.PropertyModel(System.Reflection.PropertyInfo, System.Collections.Generic.IReadOnlyList<System.Object>)
    
        
    
        
        Creates a new instance of :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.PropertyModel`\.
    
        
    
        
        :param propertyInfo: The :dn:prop:`Microsoft.AspNetCore.Mvc.ApplicationModels.PropertyModel.PropertyInfo` for the underlying property.
        
        :type propertyInfo: System.Reflection.PropertyInfo
    
        
        :param attributes: Any attributes which are annotated on the property.
        
        :type attributes: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public PropertyModel(PropertyInfo propertyInfo, IReadOnlyList<object> attributes)
    

