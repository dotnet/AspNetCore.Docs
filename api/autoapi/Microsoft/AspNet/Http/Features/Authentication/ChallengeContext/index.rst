

ChallengeContext Class
======================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Http.Features.Authentication.ChallengeContext`








Syntax
------

.. code-block:: csharp

   public class ChallengeContext





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.AspNet.Http.Features/Authentication/ChallengeContext.cs>`_





.. dn:class:: Microsoft.AspNet.Http.Features.Authentication.ChallengeContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Http.Features.Authentication.ChallengeContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Http.Features.Authentication.ChallengeContext.ChallengeContext(System.String)
    
        
        
        
        :type authenticationScheme: System.String
    
        
        .. code-block:: csharp
    
           public ChallengeContext(string authenticationScheme)
    
    .. dn:constructor:: Microsoft.AspNet.Http.Features.Authentication.ChallengeContext.ChallengeContext(System.String, System.Collections.Generic.IDictionary<System.String, System.String>, Microsoft.AspNet.Http.Features.Authentication.ChallengeBehavior)
    
        
        
        
        :type authenticationScheme: System.String
        
        
        :type properties: System.Collections.Generic.IDictionary{System.String,System.String}
        
        
        :type behavior: Microsoft.AspNet.Http.Features.Authentication.ChallengeBehavior
    
        
        .. code-block:: csharp
    
           public ChallengeContext(string authenticationScheme, IDictionary<string, string> properties, ChallengeBehavior behavior)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Http.Features.Authentication.ChallengeContext
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.Features.Authentication.ChallengeContext.Accept()
    
        
    
        
        .. code-block:: csharp
    
           public void Accept()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Http.Features.Authentication.ChallengeContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.Features.Authentication.ChallengeContext.Accepted
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Accepted { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.Features.Authentication.ChallengeContext.AuthenticationScheme
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string AuthenticationScheme { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.Features.Authentication.ChallengeContext.Behavior
    
        
        :rtype: Microsoft.AspNet.Http.Features.Authentication.ChallengeBehavior
    
        
        .. code-block:: csharp
    
           public ChallengeBehavior Behavior { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.Features.Authentication.ChallengeContext.Properties
    
        
        :rtype: System.Collections.Generic.IDictionary{System.String,System.String}
    
        
        .. code-block:: csharp
    
           public IDictionary<string, string> Properties { get; }
    

