

SignOutContext Class
====================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Http.Features.Authentication.SignOutContext`








Syntax
------

.. code-block:: csharp

   public class SignOutContext





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.Http.Features/Authentication/SignOutContext.cs>`_





.. dn:class:: Microsoft.AspNet.Http.Features.Authentication.SignOutContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Http.Features.Authentication.SignOutContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Http.Features.Authentication.SignOutContext.SignOutContext(System.String, System.Collections.Generic.IDictionary<System.String, System.String>)
    
        
        
        
        :type authenticationScheme: System.String
        
        
        :type properties: System.Collections.Generic.IDictionary{System.String,System.String}
    
        
        .. code-block:: csharp
    
           public SignOutContext(string authenticationScheme, IDictionary<string, string> properties)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Http.Features.Authentication.SignOutContext
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.Features.Authentication.SignOutContext.Accept()
    
        
    
        
        .. code-block:: csharp
    
           public void Accept()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Http.Features.Authentication.SignOutContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.Features.Authentication.SignOutContext.Accepted
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Accepted { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.Features.Authentication.SignOutContext.AuthenticationScheme
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string AuthenticationScheme { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.Features.Authentication.SignOutContext.Properties
    
        
        :rtype: System.Collections.Generic.IDictionary{System.String,System.String}
    
        
        .. code-block:: csharp
    
           public IDictionary<string, string> Properties { get; }
    

