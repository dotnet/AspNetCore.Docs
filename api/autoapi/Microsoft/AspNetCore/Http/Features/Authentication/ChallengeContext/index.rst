

ChallengeContext Class
======================





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
* :dn:cls:`Microsoft.AspNetCore.Http.Features.Authentication.ChallengeContext`








Syntax
------

.. code-block:: csharp

    public class ChallengeContext








.. dn:class:: Microsoft.AspNetCore.Http.Features.Authentication.ChallengeContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Http.Features.Authentication.ChallengeContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Http.Features.Authentication.ChallengeContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.Authentication.ChallengeContext.Accepted
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Accepted
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.Authentication.ChallengeContext.AuthenticationScheme
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string AuthenticationScheme
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.Authentication.ChallengeContext.Behavior
    
        
        :rtype: Microsoft.AspNetCore.Http.Features.Authentication.ChallengeBehavior
    
        
        .. code-block:: csharp
    
            public ChallengeBehavior Behavior
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.Authentication.ChallengeContext.Properties
    
        
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IDictionary<string, string> Properties
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Http.Features.Authentication.ChallengeContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Http.Features.Authentication.ChallengeContext.ChallengeContext(System.String)
    
        
    
        
        :type authenticationScheme: System.String
    
        
        .. code-block:: csharp
    
            public ChallengeContext(string authenticationScheme)
    
    .. dn:constructor:: Microsoft.AspNetCore.Http.Features.Authentication.ChallengeContext.ChallengeContext(System.String, System.Collections.Generic.IDictionary<System.String, System.String>, Microsoft.AspNetCore.Http.Features.Authentication.ChallengeBehavior)
    
        
    
        
        :type authenticationScheme: System.String
    
        
        :type properties: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.String<System.String>}
    
        
        :type behavior: Microsoft.AspNetCore.Http.Features.Authentication.ChallengeBehavior
    
        
        .. code-block:: csharp
    
            public ChallengeContext(string authenticationScheme, IDictionary<string, string> properties, ChallengeBehavior behavior)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Http.Features.Authentication.ChallengeContext
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.Features.Authentication.ChallengeContext.Accept()
    
        
    
        
        .. code-block:: csharp
    
            public void Accept()
    

