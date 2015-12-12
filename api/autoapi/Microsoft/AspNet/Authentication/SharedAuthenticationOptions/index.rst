

SharedAuthenticationOptions Class
=================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.SharedAuthenticationOptions`








Syntax
------

.. code-block:: csharp

   public class SharedAuthenticationOptions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.Authentication/SharedAuthenticationOptions.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.SharedAuthenticationOptions

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.SharedAuthenticationOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.SharedAuthenticationOptions.SignInScheme
    
        
    
        Gets or sets the authentication scheme corresponding to the default middleware
        responsible of persisting user's identity after a successful authentication.
        This value typically corresponds to a cookie middleware registered in the Startup class.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string SignInScheme { get; set; }
    

