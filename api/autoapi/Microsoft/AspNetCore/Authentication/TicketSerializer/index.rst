

TicketSerializer Class
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
* :dn:cls:`Microsoft.AspNetCore.Authentication.TicketSerializer`








Syntax
------

.. code-block:: csharp

    public class TicketSerializer : IDataSerializer<AuthenticationTicket>








.. dn:class:: Microsoft.AspNetCore.Authentication.TicketSerializer
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.TicketSerializer

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authentication.TicketSerializer
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authentication.TicketSerializer.Default
    
        
        :rtype: Microsoft.AspNetCore.Authentication.TicketSerializer
    
        
        .. code-block:: csharp
    
            public static TicketSerializer Default { get; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authentication.TicketSerializer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authentication.TicketSerializer.Deserialize(System.Byte[])
    
        
    
        
        :type data: System.Byte<System.Byte>[]
        :rtype: Microsoft.AspNetCore.Authentication.AuthenticationTicket
    
        
        .. code-block:: csharp
    
            public virtual AuthenticationTicket Deserialize(byte[] data)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.TicketSerializer.Read(System.IO.BinaryReader)
    
        
    
        
        :type reader: System.IO.BinaryReader
        :rtype: Microsoft.AspNetCore.Authentication.AuthenticationTicket
    
        
        .. code-block:: csharp
    
            public virtual AuthenticationTicket Read(BinaryReader reader)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.TicketSerializer.ReadClaim(System.IO.BinaryReader, System.Security.Claims.ClaimsIdentity)
    
        
    
        
        :type reader: System.IO.BinaryReader
    
        
        :type identity: System.Security.Claims.ClaimsIdentity
        :rtype: System.Security.Claims.Claim
    
        
        .. code-block:: csharp
    
            protected virtual Claim ReadClaim(BinaryReader reader, ClaimsIdentity identity)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.TicketSerializer.ReadIdentity(System.IO.BinaryReader)
    
        
    
        
        :type reader: System.IO.BinaryReader
        :rtype: System.Security.Claims.ClaimsIdentity
    
        
        .. code-block:: csharp
    
            protected virtual ClaimsIdentity ReadIdentity(BinaryReader reader)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.TicketSerializer.Serialize(Microsoft.AspNetCore.Authentication.AuthenticationTicket)
    
        
    
        
        :type ticket: Microsoft.AspNetCore.Authentication.AuthenticationTicket
        :rtype: System.Byte<System.Byte>[]
    
        
        .. code-block:: csharp
    
            public virtual byte[] Serialize(AuthenticationTicket ticket)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.TicketSerializer.Write(System.IO.BinaryWriter, Microsoft.AspNetCore.Authentication.AuthenticationTicket)
    
        
    
        
        :type writer: System.IO.BinaryWriter
    
        
        :type ticket: Microsoft.AspNetCore.Authentication.AuthenticationTicket
    
        
        .. code-block:: csharp
    
            public virtual void Write(BinaryWriter writer, AuthenticationTicket ticket)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.TicketSerializer.WriteClaim(System.IO.BinaryWriter, System.Security.Claims.Claim)
    
        
    
        
        :type writer: System.IO.BinaryWriter
    
        
        :type claim: System.Security.Claims.Claim
    
        
        .. code-block:: csharp
    
            protected virtual void WriteClaim(BinaryWriter writer, Claim claim)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.TicketSerializer.WriteIdentity(System.IO.BinaryWriter, System.Security.Claims.ClaimsIdentity)
    
        
    
        
        :type writer: System.IO.BinaryWriter
    
        
        :type identity: System.Security.Claims.ClaimsIdentity
    
        
        .. code-block:: csharp
    
            protected virtual void WriteIdentity(BinaryWriter writer, ClaimsIdentity identity)
    

