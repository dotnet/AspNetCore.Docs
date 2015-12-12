

ViewComponentMethodSelector Class
=================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ViewComponents.ViewComponentMethodSelector`








Syntax
------

.. code-block:: csharp

   public class ViewComponentMethodSelector





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewComponents/ViewComponentMethodSelector.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentMethodSelector

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentMethodSelector
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentMethodSelector.FindAsyncMethod(System.Reflection.TypeInfo, System.Object[])
    
        
        
        
        :type componentType: System.Reflection.TypeInfo
        
        
        :type args: System.Object[]
        :rtype: System.Reflection.MethodInfo
    
        
        .. code-block:: csharp
    
           public static MethodInfo FindAsyncMethod(TypeInfo componentType, object[] args)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentMethodSelector.FindSyncMethod(System.Reflection.TypeInfo, System.Object[])
    
        
        
        
        :type componentType: System.Reflection.TypeInfo
        
        
        :type args: System.Object[]
        :rtype: System.Reflection.MethodInfo
    
        
        .. code-block:: csharp
    
           public static MethodInfo FindSyncMethod(TypeInfo componentType, object[] args)
    

Fields
------

.. dn:class:: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentMethodSelector
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentMethodSelector.AsyncMethodName
    
        
    
        
        .. code-block:: csharp
    
           public const string AsyncMethodName
    
    .. dn:field:: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentMethodSelector.SyncMethodName
    
        
    
        
        .. code-block:: csharp
    
           public const string SyncMethodName
    

