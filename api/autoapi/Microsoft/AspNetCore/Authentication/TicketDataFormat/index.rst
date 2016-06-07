

TicketDataFormat Class
======================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication`
Assemblies
    * Microsoft.AspNetCore.Authentication

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Authentication.SecureDataFormat{Microsoft.AspNetCore.Authentication.AuthenticationTicket}`
* :dn:cls:`Microsoft.AspNetCore.Authentication.TicketDataFormat`








Syntax
------

.. code-block:: csharp

    public class TicketDataFormat : SecureDataFormat<AuthenticationTicket>, ISecureDataFormat<AuthenticationTicket>








.. dn:class:: Microsoft.AspNetCore.Authentication.TicketDataFormat
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.TicketDataFormat

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authentication.TicketDataFormat
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authentication.TicketDataFormat.TicketDataFormat(Microsoft.AspNetCore.DataProtection.IDataProtector)
    
        
    
        
        :type protector: Microsoft.AspNetCore.DataProtection.IDataProtector
    
        
        .. code-block:: csharp
    
            public TicketDataFormat(IDataProtector protector)
    

