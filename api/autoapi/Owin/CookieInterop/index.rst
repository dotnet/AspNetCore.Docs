

CookieInterop Class
===================





Namespace
    :dn:ns:`Owin`
Assemblies
    * Microsoft.AspNet.Identity.AspNetCoreCompat

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Owin.CookieInterop`








Syntax
------

.. code-block:: csharp

    public class CookieInterop








.. dn:class:: Owin.CookieInterop
    :hidden:

.. dn:class:: Owin.CookieInterop

Methods
-------

.. dn:class:: Owin.CookieInterop
    :noindex:
    :hidden:

    
    .. dn:method:: Owin.CookieInterop.CreateSharedDataFormat(System.IO.DirectoryInfo, System.String)
    
        
    
        
        :type keyDirectory: System.IO.DirectoryInfo
    
        
        :type authenticationType: System.String
        :rtype: Microsoft.Owin.Security.ISecureDataFormat<Microsoft.Owin.Security.ISecureDataFormat`1>{Microsoft.Owin.Security.AuthenticationTicket<Microsoft.Owin.Security.AuthenticationTicket>}
    
        
        .. code-block:: csharp
    
            public static ISecureDataFormat<AuthenticationTicket> CreateSharedDataFormat(DirectoryInfo keyDirectory, string authenticationType)
    

