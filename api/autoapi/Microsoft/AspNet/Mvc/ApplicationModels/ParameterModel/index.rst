

ParameterModel Class
====================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ApplicationModels.ParameterModel`








Syntax
------

.. code-block:: csharp

   public class ParameterModel : ICommonModel, IPropertyModel, IBindingModel





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/ApplicationModels/ParameterModel.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ApplicationModels.ParameterModel

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ApplicationModels.ParameterModel
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ApplicationModels.ParameterModel.ParameterModel(Microsoft.AspNet.Mvc.ApplicationModels.ParameterModel)
    
        
        
        
        :type other: Microsoft.AspNet.Mvc.ApplicationModels.ParameterModel
    
        
        .. code-block:: csharp
    
           public ParameterModel(ParameterModel other)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ApplicationModels.ParameterModel.ParameterModel(System.Reflection.ParameterInfo, System.Collections.Generic.IReadOnlyList<System.Object>)
    
        
        
        
        :type parameterInfo: System.Reflection.ParameterInfo
        
        
        :type attributes: System.Collections.Generic.IReadOnlyList{System.Object}
    
        
        .. code-block:: csharp
    
           public ParameterModel(ParameterInfo parameterInfo, IReadOnlyList<object> attributes)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ApplicationModels.ParameterModel
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.ParameterModel.Action
    
        
        :rtype: Microsoft.AspNet.Mvc.ApplicationModels.ActionModel
    
        
        .. code-block:: csharp
    
           public ActionModel Action { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.ParameterModel.Attributes
    
        
        :rtype: System.Collections.Generic.IReadOnlyList{System.Object}
    
        
        .. code-block:: csharp
    
           public IReadOnlyList<object> Attributes { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.ParameterModel.BindingInfo
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.BindingInfo
    
        
        .. code-block:: csharp
    
           public BindingInfo BindingInfo { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.ParameterModel.Microsoft.AspNet.Mvc.ApplicationModels.ICommonModel.MemberInfo
    
        
        :rtype: System.Reflection.MemberInfo
    
        
        .. code-block:: csharp
    
           MemberInfo ICommonModel.MemberInfo { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.ParameterModel.Microsoft.AspNet.Mvc.ApplicationModels.ICommonModel.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string ICommonModel.Name { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.ParameterModel.ParameterInfo
    
        
        :rtype: System.Reflection.ParameterInfo
    
        
        .. code-block:: csharp
    
           public ParameterInfo ParameterInfo { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.ParameterModel.ParameterName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ParameterName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.ParameterModel.Properties
    
        
        :rtype: System.Collections.Generic.IDictionary{System.Object,System.Object}
    
        
        .. code-block:: csharp
    
           public IDictionary<object, object> Properties { get; }
    

