

ViewComponentConventions Class
==============================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ViewComponents`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentConventions`








Syntax
------

.. code-block:: csharp

    public class ViewComponentConventions








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentConventions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentConventions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentConventions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentConventions.GetComponentFullName(System.Reflection.TypeInfo)
    
        
    
        
        :type componentType: System.Reflection.TypeInfo
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string GetComponentFullName(TypeInfo componentType)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentConventions.GetComponentName(System.Reflection.TypeInfo)
    
        
    
        
        :type componentType: System.Reflection.TypeInfo
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string GetComponentName(TypeInfo componentType)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentConventions.IsComponent(System.Reflection.TypeInfo)
    
        
    
        
        :type typeInfo: System.Reflection.TypeInfo
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public static bool IsComponent(TypeInfo typeInfo)
    

