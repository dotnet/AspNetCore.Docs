

SkipOn32BitOSAttribute Class
============================



.. contents:: 
   :local:



Summary
-------

Skips a 64 bit test if the current Windows OS is 32-bit.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNet.Server.Testing.SkipOn32BitOSAttribute`








Syntax
------

.. code-block:: csharp

   public class SkipOn32BitOSAttribute : Attribute, _Attribute, ITestCondition





GitHub
------

`View on GitHub <https://github.com/aspnet/hosting/blob/master/src/Microsoft.AspNet.Server.Testing/xunit/SkipOn32BitOSAttribute.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Testing.SkipOn32BitOSAttribute

Properties
----------

.. dn:class:: Microsoft.AspNet.Server.Testing.SkipOn32BitOSAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Server.Testing.SkipOn32BitOSAttribute.IsMet
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsMet { get; }
    
    .. dn:property:: Microsoft.AspNet.Server.Testing.SkipOn32BitOSAttribute.SkipReason
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string SkipReason { get; }
    

