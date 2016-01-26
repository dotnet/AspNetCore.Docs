

SkipIfIISVariationsNotEnabledAttribute Class
============================================



.. contents:: 
   :local:



Summary
-------

Skip test if IIS variations are not enabled. To enable set environment variable
IIS_VARIATIONS_ENABLED=true for the test process.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNet.Server.Testing.SkipIfIISVariationsNotEnabledAttribute`








Syntax
------

.. code-block:: csharp

   public class SkipIfIISVariationsNotEnabledAttribute : Attribute, _Attribute, ITestCondition





GitHub
------

`View on GitHub <https://github.com/aspnet/hosting/blob/master/src/Microsoft.AspNet.Server.Testing/xunit/SkipIfIISVariationsNotEnabledAttribute.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Testing.SkipIfIISVariationsNotEnabledAttribute

Properties
----------

.. dn:class:: Microsoft.AspNet.Server.Testing.SkipIfIISVariationsNotEnabledAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Server.Testing.SkipIfIISVariationsNotEnabledAttribute.IsMet
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsMet { get; }
    
    .. dn:property:: Microsoft.AspNet.Server.Testing.SkipIfIISVariationsNotEnabledAttribute.SkipReason
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string SkipReason { get; }
    

