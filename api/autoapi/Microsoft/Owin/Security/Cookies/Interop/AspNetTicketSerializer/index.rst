

AspNetTicketSerializer Class
============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Owin.Security.Cookies.Interop.AspNetTicketSerializer`








Syntax
------

.. code-block:: csharp

   public class AspNetTicketSerializer : IDataSerializer<AuthenticationTicket>





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.Owin.Security.Cookies.Interop/AspNetTicketSerializer.cs>`_





.. dn:class:: Microsoft.Owin.Security.Cookies.Interop.AspNetTicketSerializer

Methods
-------

.. dn:class:: Microsoft.Owin.Security.Cookies.Interop.AspNetTicketSerializer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Owin.Security.Cookies.Interop.AspNetTicketSerializer.Deserialize(System.Byte[])
    
        
        
        
        :type data: System.Byte[]
        :rtype: Microsoft.Owin.Security.AuthenticationTicket
    
        
        .. code-block:: csharp
    
           public virtual AuthenticationTicket Deserialize(byte[] data)
    
    .. dn:method:: Microsoft.Owin.Security.Cookies.Interop.AspNetTicketSerializer.Read(System.IO.BinaryReader)
    
        
        
        
        :type reader: System.IO.BinaryReader
        :rtype: Microsoft.Owin.Security.AuthenticationTicket
    
        
        .. code-block:: csharp
    
           public virtual AuthenticationTicket Read(BinaryReader reader)
    
    .. dn:method:: Microsoft.Owin.Security.Cookies.Interop.AspNetTicketSerializer.ReadClaim(System.IO.BinaryReader, System.Security.Claims.ClaimsIdentity)
    
        
        
        
        :type reader: System.IO.BinaryReader
        
        
        :type identity: System.Security.Claims.ClaimsIdentity
        :rtype: System.Security.Claims.Claim
    
        
        .. code-block:: csharp
    
           protected virtual Claim ReadClaim(BinaryReader reader, ClaimsIdentity identity)
    
    .. dn:method:: Microsoft.Owin.Security.Cookies.Interop.AspNetTicketSerializer.ReadIdentity(System.IO.BinaryReader)
    
        
        
        
        :type reader: System.IO.BinaryReader
        :rtype: System.Security.Claims.ClaimsIdentity
    
        
        .. code-block:: csharp
    
           protected virtual ClaimsIdentity ReadIdentity(BinaryReader reader)
    
    .. dn:method:: Microsoft.Owin.Security.Cookies.Interop.AspNetTicketSerializer.Serialize(Microsoft.Owin.Security.AuthenticationTicket)
    
        
        
        
        :type ticket: Microsoft.Owin.Security.AuthenticationTicket
        :rtype: System.Byte[]
    
        
        .. code-block:: csharp
    
           public virtual byte[] Serialize(AuthenticationTicket ticket)
    
    .. dn:method:: Microsoft.Owin.Security.Cookies.Interop.AspNetTicketSerializer.Write(System.IO.BinaryWriter, Microsoft.Owin.Security.AuthenticationTicket)
    
        
        
        
        :type writer: System.IO.BinaryWriter
        
        
        :type ticket: Microsoft.Owin.Security.AuthenticationTicket
    
        
        .. code-block:: csharp
    
           public virtual void Write(BinaryWriter writer, AuthenticationTicket ticket)
    
    .. dn:method:: Microsoft.Owin.Security.Cookies.Interop.AspNetTicketSerializer.WriteClaim(System.IO.BinaryWriter, System.Security.Claims.Claim)
    
        
        
        
        :type writer: System.IO.BinaryWriter
        
        
        :type claim: System.Security.Claims.Claim
    
        
        .. code-block:: csharp
    
           protected virtual void WriteClaim(BinaryWriter writer, Claim claim)
    
    .. dn:method:: Microsoft.Owin.Security.Cookies.Interop.AspNetTicketSerializer.WriteIdentity(System.IO.BinaryWriter, System.Security.Claims.ClaimsIdentity)
    
        
        
        
        :type writer: System.IO.BinaryWriter
        
        
        :type identity: System.Security.Claims.ClaimsIdentity
    
        
        .. code-block:: csharp
    
           protected virtual void WriteIdentity(BinaryWriter writer, ClaimsIdentity identity)
    

Properties
----------

.. dn:class:: Microsoft.Owin.Security.Cookies.Interop.AspNetTicketSerializer
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Owin.Security.Cookies.Interop.AspNetTicketSerializer.Default
    
        
        :rtype: Microsoft.Owin.Security.DataHandler.Serializer.TicketSerializer
    
        
        .. code-block:: csharp
    
           public static TicketSerializer Default { get; }
    

