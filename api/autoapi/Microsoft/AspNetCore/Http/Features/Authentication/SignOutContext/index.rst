

SignOutContext Class
====================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Http.Features.Authentication`
Assemblies
    * Microsoft.AspNetCore.Http.Features

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Http.Features.Authentication.SignOutContext`








Syntax
------

.. code-block:: csharp

    public class SignOutContext








.. dn:class:: Microsoft.AspNetCore.Http.Features.Authentication.SignOutContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Http.Features.Authentication.SignOutContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Http.Features.Authentication.SignOutContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.Authentication.SignOutContext.Accepted
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Accepted
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.Authentication.SignOutContext.AuthenticationScheme
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string AuthenticationScheme
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.Authentication.SignOutContext.Properties
    
        
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IDictionary<string, string> Properties
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Http.Features.Authentication.SignOutContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Http.Features.Authentication.SignOutContext.SignOutContext(System.String, System.Collections.Generic.IDictionary<System.String, System.String>)
    
        
    
        
        :type authenticationScheme: System.String
    
        
        :type properties: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public SignOutContext(string authenticationScheme, IDictionary<string, string> properties)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Http.Features.Authentication.SignOutContext
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.Features.Authentication.SignOutContext.Accept()
    
        
    
        
        .. code-block:: csharp
    
            public void Accept()
    

