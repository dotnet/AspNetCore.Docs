

AntiforgeryTokenSet Class
=========================






The antiforgery token pair (cookie and request token) for a request.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Antiforgery`
Assemblies
    * Microsoft.AspNetCore.Antiforgery

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Antiforgery.AntiforgeryTokenSet`








Syntax
------

.. code-block:: csharp

    public class AntiforgeryTokenSet








.. dn:class:: Microsoft.AspNetCore.Antiforgery.AntiforgeryTokenSet
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Antiforgery.AntiforgeryTokenSet

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Antiforgery.AntiforgeryTokenSet
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Antiforgery.AntiforgeryTokenSet.CookieToken
    
        
    
        
        Gets the cookie token.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string CookieToken
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Antiforgery.AntiforgeryTokenSet.FormFieldName
    
        
    
        
        Gets the name of the form field used for the request token.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string FormFieldName
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Antiforgery.AntiforgeryTokenSet.HeaderName
    
        
    
        
        Gets the name of the header used for the request token.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string HeaderName
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Antiforgery.AntiforgeryTokenSet.RequestToken
    
        
    
        
        Gets the request token.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string RequestToken
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Antiforgery.AntiforgeryTokenSet
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Antiforgery.AntiforgeryTokenSet.AntiforgeryTokenSet(System.String, System.String, System.String, System.String)
    
        
    
        
        Creates the antiforgery token pair (cookie and request token) for a request.
    
        
    
        
        :param requestToken: The token that is supplied in the request.
        
        :type requestToken: System.String
    
        
        :param cookieToken: The token that is supplied in the request cookie.
        
        :type cookieToken: System.String
    
        
        :param formFieldName: The name of the form field used for the request token.
        
        :type formFieldName: System.String
    
        
        :param headerName: The name of the header used for the request token.
        
        :type headerName: System.String
    
        
        .. code-block:: csharp
    
            public AntiforgeryTokenSet(string requestToken, string cookieToken, string formFieldName, string headerName)
    

