

SkipIfCurrentRuntimeIsCoreClrAttribute Class
============================================






Skips a test if the runtime used to run the test is CoreClr.


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
* :dn:cls:`Microsoft.AspNetCore.Server.Testing.SkipIfCurrentRuntimeIsCoreClrAttribute`








Syntax
------

.. code-block:: csharp

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class SkipIfCurrentRuntimeIsCoreClrAttribute : Attribute, _Attribute, ITestCondition








.. dn:class:: Microsoft.AspNetCore.Server.Testing.SkipIfCurrentRuntimeIsCoreClrAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Testing.SkipIfCurrentRuntimeIsCoreClrAttribute

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Server.Testing.SkipIfCurrentRuntimeIsCoreClrAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Server.Testing.SkipIfCurrentRuntimeIsCoreClrAttribute.IsMet
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsMet { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Testing.SkipIfCurrentRuntimeIsCoreClrAttribute.SkipReason
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string SkipReason { get; }
    

