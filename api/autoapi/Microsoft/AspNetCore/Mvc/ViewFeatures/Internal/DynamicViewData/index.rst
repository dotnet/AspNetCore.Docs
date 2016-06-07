

DynamicViewData Class
=====================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ViewFeatures.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Dynamic.DynamicObject`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.DynamicViewData`








Syntax
------

.. code-block:: csharp

    public class DynamicViewData : DynamicObject, IDynamicMetaObjectProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.DynamicViewData
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.DynamicViewData

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.DynamicViewData
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.DynamicViewData.DynamicViewData(System.Func<Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary>)
    
        
    
        
        :type viewDataFunc: System.Func<System.Func`1>{Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary>}
    
        
        .. code-block:: csharp
    
            public DynamicViewData(Func<ViewDataDictionary> viewDataFunc)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.DynamicViewData
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.DynamicViewData.GetDynamicMemberNames()
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public override IEnumerable<string> GetDynamicMemberNames()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.DynamicViewData.TryGetMember(System.Dynamic.GetMemberBinder, out System.Object)
    
        
    
        
        :type binder: System.Dynamic.GetMemberBinder
    
        
        :type result: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool TryGetMember(GetMemberBinder binder, out object result)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.DynamicViewData.TrySetMember(System.Dynamic.SetMemberBinder, System.Object)
    
        
    
        
        :type binder: System.Dynamic.SetMemberBinder
    
        
        :type value: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool TrySetMember(SetMemberBinder binder, object value)
    

