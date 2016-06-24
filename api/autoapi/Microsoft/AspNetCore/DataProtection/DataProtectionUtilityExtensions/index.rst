

DataProtectionUtilityExtensions Class
=====================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.DataProtection`
Assemblies
    * Microsoft.AspNetCore.DataProtection

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.DataProtection.DataProtectionUtilityExtensions`








Syntax
------

.. code-block:: csharp

    public class DataProtectionUtilityExtensions








.. dn:class:: Microsoft.AspNetCore.DataProtection.DataProtectionUtilityExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.DataProtection.DataProtectionUtilityExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.DataProtection.DataProtectionUtilityExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.DataProtectionUtilityExtensions.GetApplicationUniqueIdentifier(System.IServiceProvider)
    
        
    
        
        Returns a unique identifier for this application.
    
        
    
        
        :param services: The application-level :any:`System.IServiceProvider`\.
        
        :type services: System.IServiceProvider
        :rtype: System.String
        :return: A unique application identifier, or null if <em>services</em> is null
            or cannot provide a unique application identifier.
    
        
        .. code-block:: csharp
    
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static string GetApplicationUniqueIdentifier(this IServiceProvider services)
    

