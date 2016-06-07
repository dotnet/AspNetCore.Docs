

ParameterModel Class
====================





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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ApplicationModels.ParameterModel`








Syntax
------

.. code-block:: csharp

    [DebuggerDisplay("ParameterModel: Name={ParameterName}")]
    public class ParameterModel : ICommonModel, IPropertyModel, IBindingModel








.. dn:class:: Microsoft.AspNetCore.Mvc.ApplicationModels.ParameterModel
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ApplicationModels.ParameterModel

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ApplicationModels.ParameterModel
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.ParameterModel.Action
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ApplicationModels.ActionModel
    
        
        .. code-block:: csharp
    
            public ActionModel Action
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.ParameterModel.Attributes
    
        
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public IReadOnlyList<object> Attributes
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.ParameterModel.BindingInfo
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.BindingInfo
    
        
        .. code-block:: csharp
    
            public BindingInfo BindingInfo
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.ParameterModel.Microsoft.AspNetCore.Mvc.ApplicationModels.ICommonModel.MemberInfo
    
        
        :rtype: System.Reflection.MemberInfo
    
        
        .. code-block:: csharp
    
            MemberInfo ICommonModel.MemberInfo
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.ParameterModel.Microsoft.AspNetCore.Mvc.ApplicationModels.ICommonModel.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string ICommonModel.Name
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.ParameterModel.ParameterInfo
    
        
        :rtype: System.Reflection.ParameterInfo
    
        
        .. code-block:: csharp
    
            public ParameterInfo ParameterInfo
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.ParameterModel.ParameterName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ParameterName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.ParameterModel.Properties
    
        
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.Object<System.Object>, System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public IDictionary<object, object> Properties
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ApplicationModels.ParameterModel
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ApplicationModels.ParameterModel.ParameterModel(Microsoft.AspNetCore.Mvc.ApplicationModels.ParameterModel)
    
        
    
        
        :type other: Microsoft.AspNetCore.Mvc.ApplicationModels.ParameterModel
    
        
        .. code-block:: csharp
    
            public ParameterModel(ParameterModel other)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ApplicationModels.ParameterModel.ParameterModel(System.Reflection.ParameterInfo, System.Collections.Generic.IReadOnlyList<System.Object>)
    
        
    
        
        :type parameterInfo: System.Reflection.ParameterInfo
    
        
        :type attributes: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public ParameterModel(ParameterInfo parameterInfo, IReadOnlyList<object> attributes)
    

