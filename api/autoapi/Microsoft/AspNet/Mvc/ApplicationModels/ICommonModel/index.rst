

ICommonModel Interface
======================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface ICommonModel : IPropertyModel





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/ApplicationModels/ICommonModel.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.ApplicationModels.ICommonModel

Properties
----------

.. dn:interface:: Microsoft.AspNet.Mvc.ApplicationModels.ICommonModel
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.ICommonModel.Attributes
    
        
        :rtype: System.Collections.Generic.IReadOnlyList{System.Object}
    
        
        .. code-block:: csharp
    
           IReadOnlyList<object> Attributes { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.ICommonModel.MemberInfo
    
        
        :rtype: System.Reflection.MemberInfo
    
        
        .. code-block:: csharp
    
           MemberInfo MemberInfo { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.ICommonModel.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string Name { get; }
    

