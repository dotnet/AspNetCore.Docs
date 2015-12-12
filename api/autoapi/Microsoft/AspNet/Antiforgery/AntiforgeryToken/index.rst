

AntiforgeryToken Class
======================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Antiforgery.AntiforgeryToken`








Syntax
------

.. code-block:: csharp

   public sealed class AntiforgeryToken





GitHub
------

`View on GitHub <https://github.com/aspnet/antiforgery/blob/master/src/Microsoft.AspNet.Antiforgery/AntiforgeryToken.cs>`_





.. dn:class:: Microsoft.AspNet.Antiforgery.AntiforgeryToken

Properties
----------

.. dn:class:: Microsoft.AspNet.Antiforgery.AntiforgeryToken
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Antiforgery.AntiforgeryToken.AdditionalData
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string AdditionalData { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Antiforgery.AntiforgeryToken.ClaimUid
    
        
        :rtype: Microsoft.AspNet.Antiforgery.BinaryBlob
    
        
        .. code-block:: csharp
    
           public BinaryBlob ClaimUid { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Antiforgery.AntiforgeryToken.IsSessionToken
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsSessionToken { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Antiforgery.AntiforgeryToken.SecurityToken
    
        
        :rtype: Microsoft.AspNet.Antiforgery.BinaryBlob
    
        
        .. code-block:: csharp
    
           public BinaryBlob SecurityToken { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Antiforgery.AntiforgeryToken.Username
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Username { get; set; }
    

