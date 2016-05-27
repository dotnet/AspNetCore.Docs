

SkipIfIISVariationsNotEnabledAttribute Class
============================================






Skip test if IIS variations are not enabled. To enable set environment variable 
IIS_VARIATIONS_ENABLED=true for the test process.


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
* :dn:cls:`Microsoft.AspNetCore.Server.Testing.SkipIfIISVariationsNotEnabledAttribute`








Syntax
------

.. code-block:: csharp

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class SkipIfIISVariationsNotEnabledAttribute : Attribute, _Attribute, ITestCondition








.. dn:class:: Microsoft.AspNetCore.Server.Testing.SkipIfIISVariationsNotEnabledAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Testing.SkipIfIISVariationsNotEnabledAttribute

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Server.Testing.SkipIfIISVariationsNotEnabledAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Server.Testing.SkipIfIISVariationsNotEnabledAttribute.IsMet
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsMet
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Testing.SkipIfIISVariationsNotEnabledAttribute.SkipReason
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string SkipReason
            {
                get;
            }
    

