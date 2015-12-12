

DynamicViewData Class
=====================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Dynamic.DynamicObject`
* :dn:cls:`Microsoft.AspNet.Mvc.ViewFeatures.DynamicViewData`








Syntax
------

.. code-block:: csharp

   public class DynamicViewData : DynamicObject, IDynamicMetaObjectProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewFeatures/DynamicViewData.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.DynamicViewData

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.DynamicViewData
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ViewFeatures.DynamicViewData.DynamicViewData(System.Func<Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary>)
    
        
        
        
        :type viewDataFunc: System.Func{Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary}
    
        
        .. code-block:: csharp
    
           public DynamicViewData(Func<ViewDataDictionary> viewDataFunc)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.DynamicViewData
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.DynamicViewData.GetDynamicMemberNames()
    
        
        :rtype: System.Collections.Generic.IEnumerable{System.String}
    
        
        .. code-block:: csharp
    
           public override IEnumerable<string> GetDynamicMemberNames()
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.DynamicViewData.TryGetMember(System.Dynamic.GetMemberBinder, out System.Object)
    
        
        
        
        :type binder: System.Dynamic.GetMemberBinder
        
        
        :type result: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool TryGetMember(GetMemberBinder binder, out object result)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.DynamicViewData.TrySetMember(System.Dynamic.SetMemberBinder, System.Object)
    
        
        
        
        :type binder: System.Dynamic.SetMemberBinder
        
        
        :type value: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool TrySetMember(SetMemberBinder binder, object value)
    

