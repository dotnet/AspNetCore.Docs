

AntiforgeryTokenSet Class
=========================



.. contents:: 
   :local:



Summary
-------

The antiforgery token pair (cookie and form token) for a request.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Antiforgery.AntiforgeryTokenSet`








Syntax
------

.. code-block:: csharp

   public class AntiforgeryTokenSet





GitHub
------

`View on GitHub <https://github.com/aspnet/antiforgery/blob/master/src/Microsoft.AspNet.Antiforgery/AntiforgeryTokenSet.cs>`_





.. dn:class:: Microsoft.AspNet.Antiforgery.AntiforgeryTokenSet

Constructors
------------

.. dn:class:: Microsoft.AspNet.Antiforgery.AntiforgeryTokenSet
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Antiforgery.AntiforgeryTokenSet.AntiforgeryTokenSet(System.String, System.String)
    
        
    
        Creates the antiforgery token pair (cookie and form token) for a request.
    
        
        
        
        :param formToken: The token that is supplied in the request form body.
        
        :type formToken: System.String
        
        
        :param cookieToken: The token that is supplied in the request cookie.
        
        :type cookieToken: System.String
    
        
        .. code-block:: csharp
    
           public AntiforgeryTokenSet(string formToken, string cookieToken)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Antiforgery.AntiforgeryTokenSet
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Antiforgery.AntiforgeryTokenSet.CookieToken
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string CookieToken { get; }
    
    .. dn:property:: Microsoft.AspNet.Antiforgery.AntiforgeryTokenSet.FormToken
    
        
    
        The token that is supplied in the request form body.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string FormToken { get; }
    

