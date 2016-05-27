

AspNetTicketDataFormat Class
============================





Namespace
    :dn:ns:`Microsoft.Owin.Security.Interop`
Assemblies
    * Microsoft.Owin.Security.Interop

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Owin.Security.DataHandler.SecureDataFormat{Microsoft.Owin.Security.AuthenticationTicket}`
* :dn:cls:`Microsoft.Owin.Security.Interop.AspNetTicketDataFormat`








Syntax
------

.. code-block:: csharp

    public class AspNetTicketDataFormat : SecureDataFormat<AuthenticationTicket>, ISecureDataFormat<AuthenticationTicket>








.. dn:class:: Microsoft.Owin.Security.Interop.AspNetTicketDataFormat
    :hidden:

.. dn:class:: Microsoft.Owin.Security.Interop.AspNetTicketDataFormat

Constructors
------------

.. dn:class:: Microsoft.Owin.Security.Interop.AspNetTicketDataFormat
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Owin.Security.Interop.AspNetTicketDataFormat.AspNetTicketDataFormat(Microsoft.Owin.Security.DataProtection.IDataProtector)
    
        
    
        
        :type protector: Microsoft.Owin.Security.DataProtection.IDataProtector
    
        
        .. code-block:: csharp
    
            public AspNetTicketDataFormat(IDataProtector protector)
    

