

SkipIfCurrentRuntimeIsCoreClrAttribute Class
============================================



.. contents:: 
   :local:



Summary
-------

Skips a test if the DNX used to run the test is CoreClr.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNet.Server.Testing.SkipIfCurrentRuntimeIsCoreClrAttribute`








Syntax
------

.. code-block:: csharp

   public class SkipIfCurrentRuntimeIsCoreClrAttribute : Attribute, _Attribute, ITestCondition





GitHub
------

`View on GitHub <https://github.com/aspnet/hosting/blob/master/src/Microsoft.AspNet.Server.Testing/xunit/SkipIfCurrentRuntimeIsCoreClr.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Testing.SkipIfCurrentRuntimeIsCoreClrAttribute

Properties
----------

.. dn:class:: Microsoft.AspNet.Server.Testing.SkipIfCurrentRuntimeIsCoreClrAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Server.Testing.SkipIfCurrentRuntimeIsCoreClrAttribute.IsMet
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsMet { get; }
    
    .. dn:property:: Microsoft.AspNet.Server.Testing.SkipIfCurrentRuntimeIsCoreClrAttribute.SkipReason
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string SkipReason { get; }
    

