

ICommonModel Interface
======================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ApplicationModels`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface ICommonModel : IPropertyModel








.. dn:interface:: Microsoft.AspNetCore.Mvc.ApplicationModels.ICommonModel
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.ApplicationModels.ICommonModel

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ApplicationModels.ICommonModel
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.ICommonModel.Attributes
    
        
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            IReadOnlyList<object> Attributes { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.ICommonModel.MemberInfo
    
        
        :rtype: System.Reflection.MemberInfo
    
        
        .. code-block:: csharp
    
            MemberInfo MemberInfo { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.ICommonModel.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string Name { get; }
    

