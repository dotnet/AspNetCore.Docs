

IISOptions Class
================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Builder`
Assemblies
    * Microsoft.AspNetCore.Server.IISIntegration

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Builder.IISOptions`








Syntax
------

.. code-block:: csharp

    public class IISOptions








.. dn:class:: Microsoft.AspNetCore.Builder.IISOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.IISOptions

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Builder.IISOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Builder.IISOptions.AuthenticationDescriptions
    
        
    
        
        Additional information about the authentication type which is made available to the application.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Http.Authentication.AuthenticationDescription<Microsoft.AspNetCore.Http.Authentication.AuthenticationDescription>}
    
        
        .. code-block:: csharp
    
            public IList<AuthenticationDescription> AuthenticationDescriptions { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.IISOptions.AutomaticAuthentication
    
        
    
        
        If true the authentication middleware alter the request user coming in and respond to generic challenges.
        If false the authentication middleware will only provide identity and respond to challenges when explicitly indicated
        by the AuthenticationScheme.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool AutomaticAuthentication { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.IISOptions.ForwardClientCertificate
    
        
    
        
        Populates the ITLSConnectionFeature if the MS-ASPNETCORE-CLIENTCERT request header is present.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool ForwardClientCertificate { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.IISOptions.ForwardWindowsAuthentication
    
        
    
        
        If true authentication middleware will try to authenticate using platform handler windows authentication
        If false authentication middleware won't be added
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool ForwardWindowsAuthentication { get; set; }
    

