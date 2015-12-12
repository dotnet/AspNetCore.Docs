

TicketSerializer Class
======================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.TicketSerializer`








Syntax
------

.. code-block:: csharp

   public class TicketSerializer : IDataSerializer<AuthenticationTicket>





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.Authentication/DataHandler/TicketSerializer.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.TicketSerializer

Methods
-------

.. dn:class:: Microsoft.AspNet.Authentication.TicketSerializer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authentication.TicketSerializer.Deserialize(System.Byte[])
    
        
        
        
        :type data: System.Byte[]
        :rtype: Microsoft.AspNet.Authentication.AuthenticationTicket
    
        
        .. code-block:: csharp
    
           public virtual AuthenticationTicket Deserialize(byte[] data)
    
    .. dn:method:: Microsoft.AspNet.Authentication.TicketSerializer.Read(System.IO.BinaryReader)
    
        
        
        
        :type reader: System.IO.BinaryReader
        :rtype: Microsoft.AspNet.Authentication.AuthenticationTicket
    
        
        .. code-block:: csharp
    
           public virtual AuthenticationTicket Read(BinaryReader reader)
    
    .. dn:method:: Microsoft.AspNet.Authentication.TicketSerializer.ReadClaim(System.IO.BinaryReader, System.Security.Claims.ClaimsIdentity)
    
        
        
        
        :type reader: System.IO.BinaryReader
        
        
        :type identity: System.Security.Claims.ClaimsIdentity
        :rtype: System.Security.Claims.Claim
    
        
        .. code-block:: csharp
    
           protected virtual Claim ReadClaim(BinaryReader reader, ClaimsIdentity identity)
    
    .. dn:method:: Microsoft.AspNet.Authentication.TicketSerializer.ReadIdentity(System.IO.BinaryReader)
    
        
        
        
        :type reader: System.IO.BinaryReader
        :rtype: System.Security.Claims.ClaimsIdentity
    
        
        .. code-block:: csharp
    
           protected virtual ClaimsIdentity ReadIdentity(BinaryReader reader)
    
    .. dn:method:: Microsoft.AspNet.Authentication.TicketSerializer.Serialize(Microsoft.AspNet.Authentication.AuthenticationTicket)
    
        
        
        
        :type ticket: Microsoft.AspNet.Authentication.AuthenticationTicket
        :rtype: System.Byte[]
    
        
        .. code-block:: csharp
    
           public virtual byte[] Serialize(AuthenticationTicket ticket)
    
    .. dn:method:: Microsoft.AspNet.Authentication.TicketSerializer.Write(System.IO.BinaryWriter, Microsoft.AspNet.Authentication.AuthenticationTicket)
    
        
        
        
        :type writer: System.IO.BinaryWriter
        
        
        :type ticket: Microsoft.AspNet.Authentication.AuthenticationTicket
    
        
        .. code-block:: csharp
    
           public virtual void Write(BinaryWriter writer, AuthenticationTicket ticket)
    
    .. dn:method:: Microsoft.AspNet.Authentication.TicketSerializer.WriteClaim(System.IO.BinaryWriter, System.Security.Claims.Claim)
    
        
        
        
        :type writer: System.IO.BinaryWriter
        
        
        :type claim: System.Security.Claims.Claim
    
        
        .. code-block:: csharp
    
           protected virtual void WriteClaim(BinaryWriter writer, Claim claim)
    
    .. dn:method:: Microsoft.AspNet.Authentication.TicketSerializer.WriteIdentity(System.IO.BinaryWriter, System.Security.Claims.ClaimsIdentity)
    
        
        
        
        :type writer: System.IO.BinaryWriter
        
        
        :type identity: System.Security.Claims.ClaimsIdentity
    
        
        .. code-block:: csharp
    
           protected virtual void WriteIdentity(BinaryWriter writer, ClaimsIdentity identity)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.TicketSerializer
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.TicketSerializer.Default
    
        
        :rtype: Microsoft.AspNet.Authentication.TicketSerializer
    
        
        .. code-block:: csharp
    
           public static TicketSerializer Default { get; }
    

