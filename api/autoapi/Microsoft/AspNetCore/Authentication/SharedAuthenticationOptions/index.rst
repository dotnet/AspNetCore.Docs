

SharedAuthenticationOptions Class
=================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication`
Assemblies
    * Microsoft.AspNetCore.Authentication

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Authentication.SharedAuthenticationOptions`








Syntax
------

.. code-block:: csharp

    public class SharedAuthenticationOptions








.. dn:class:: Microsoft.AspNetCore.Authentication.SharedAuthenticationOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.SharedAuthenticationOptions

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authentication.SharedAuthenticationOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authentication.SharedAuthenticationOptions.SignInScheme
    
        
    
        
        Gets or sets the authentication scheme corresponding to the default middleware
        responsible of persisting user's identity after a successful authentication.
        This value typically corresponds to a cookie middleware registered in the Startup class.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string SignInScheme
            {
                get;
                set;
            }
    

