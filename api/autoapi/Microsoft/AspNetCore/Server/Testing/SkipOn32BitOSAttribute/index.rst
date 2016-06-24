

SkipOn32BitOSAttribute Class
============================






Skips a 64 bit test if the current Windows OS is 32-bit.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Testing`
Assemblies
    * Microsoft.AspNetCore.Server.Testing

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNetCore.Server.Testing.SkipOn32BitOSAttribute`








Syntax
------

.. code-block:: csharp

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class SkipOn32BitOSAttribute : Attribute, _Attribute, ITestCondition








.. dn:class:: Microsoft.AspNetCore.Server.Testing.SkipOn32BitOSAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Testing.SkipOn32BitOSAttribute

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Server.Testing.SkipOn32BitOSAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Server.Testing.SkipOn32BitOSAttribute.IsMet
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsMet { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Testing.SkipOn32BitOSAttribute.SkipReason
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string SkipReason { get; }
    

