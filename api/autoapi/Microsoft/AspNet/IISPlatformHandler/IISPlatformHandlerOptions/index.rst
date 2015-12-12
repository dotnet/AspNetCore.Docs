

IISPlatformHandlerOptions Class
===============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.IISPlatformHandler.IISPlatformHandlerOptions`








Syntax
------

.. code-block:: csharp

   public class IISPlatformHandlerOptions





GitHub
------

`View on GitHub <https://github.com/aspnet/iisintegration/blob/master/src/Microsoft.AspNet.IISPlatformHandler/IISPlatformHandlerOptions.cs>`_





.. dn:class:: Microsoft.AspNet.IISPlatformHandler.IISPlatformHandlerOptions

Properties
----------

.. dn:class:: Microsoft.AspNet.IISPlatformHandler.IISPlatformHandlerOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.IISPlatformHandler.IISPlatformHandlerOptions.AuthenticationDescriptions
    
        
    
        Additional information about the authentication type which is made available to the application.
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Http.Authentication.AuthenticationDescription}
    
        
        .. code-block:: csharp
    
           public IList<AuthenticationDescription> AuthenticationDescriptions { get; }
    
    .. dn:property:: Microsoft.AspNet.IISPlatformHandler.IISPlatformHandlerOptions.AutomaticAuthentication
    
        
    
        If true the authentication middleware alter the request user coming in and respond to generic challenges.
        If false the authentication middleware will only provide identity and respond to challenges when explicitly indicated
        by the AuthenticationScheme.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool AutomaticAuthentication { get; set; }
    

