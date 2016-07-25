

SkipIfEnvironmentVariableNotEnabledAttribute Class
==================================================






Skip test if a given environment variable is not enabled. To enable the test, set environment variable 
to "true" for the test process.


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
* :dn:cls:`Microsoft.AspNetCore.Server.Testing.SkipIfEnvironmentVariableNotEnabledAttribute`








Syntax
------

.. code-block:: csharp

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class SkipIfEnvironmentVariableNotEnabledAttribute : Attribute, _Attribute, ITestCondition








.. dn:class:: Microsoft.AspNetCore.Server.Testing.SkipIfEnvironmentVariableNotEnabledAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Testing.SkipIfEnvironmentVariableNotEnabledAttribute

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Testing.SkipIfEnvironmentVariableNotEnabledAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Testing.SkipIfEnvironmentVariableNotEnabledAttribute.SkipIfEnvironmentVariableNotEnabledAttribute(System.String)
    
        
    
        
        :type environmentVariableName: System.String
    
        
        .. code-block:: csharp
    
            public SkipIfEnvironmentVariableNotEnabledAttribute(string environmentVariableName)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Server.Testing.SkipIfEnvironmentVariableNotEnabledAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Server.Testing.SkipIfEnvironmentVariableNotEnabledAttribute.AdditionalInfo
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string AdditionalInfo { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Testing.SkipIfEnvironmentVariableNotEnabledAttribute.IsMet
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsMet { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Testing.SkipIfEnvironmentVariableNotEnabledAttribute.SkipReason
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string SkipReason { get; }
    

