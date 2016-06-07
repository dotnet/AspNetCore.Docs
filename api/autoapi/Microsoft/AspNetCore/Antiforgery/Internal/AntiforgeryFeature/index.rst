

AntiforgeryFeature Class
========================






Used to hold per-request state.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Antiforgery.Internal`
Assemblies
    * Microsoft.AspNetCore.Antiforgery

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryFeature`








Syntax
------

.. code-block:: csharp

    public class AntiforgeryFeature : IAntiforgeryFeature








.. dn:class:: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryFeature
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryFeature

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryFeature.CookieToken
    
        
        :rtype: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryToken
    
        
        .. code-block:: csharp
    
            public AntiforgeryToken CookieToken
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryFeature.HaveDeserializedCookieToken
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool HaveDeserializedCookieToken
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryFeature.HaveDeserializedRequestToken
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool HaveDeserializedRequestToken
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryFeature.HaveGeneratedNewCookieToken
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool HaveGeneratedNewCookieToken
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryFeature.HaveStoredNewCookieToken
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool HaveStoredNewCookieToken
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryFeature.NewCookieToken
    
        
        :rtype: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryToken
    
        
        .. code-block:: csharp
    
            public AntiforgeryToken NewCookieToken
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryFeature.NewCookieTokenString
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string NewCookieTokenString
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryFeature.NewRequestToken
    
        
        :rtype: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryToken
    
        
        .. code-block:: csharp
    
            public AntiforgeryToken NewRequestToken
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryFeature.NewRequestTokenString
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string NewRequestTokenString
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryFeature.RequestToken
    
        
        :rtype: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryToken
    
        
        .. code-block:: csharp
    
            public AntiforgeryToken RequestToken
            {
                get;
                set;
            }
    

