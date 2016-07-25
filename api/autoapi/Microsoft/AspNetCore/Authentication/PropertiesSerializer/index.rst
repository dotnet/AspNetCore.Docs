

PropertiesSerializer Class
==========================





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
* :dn:cls:`Microsoft.AspNetCore.Authentication.PropertiesSerializer`








Syntax
------

.. code-block:: csharp

    public class PropertiesSerializer : IDataSerializer<AuthenticationProperties>








.. dn:class:: Microsoft.AspNetCore.Authentication.PropertiesSerializer
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.PropertiesSerializer

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authentication.PropertiesSerializer
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authentication.PropertiesSerializer.Default
    
        
        :rtype: Microsoft.AspNetCore.Authentication.PropertiesSerializer
    
        
        .. code-block:: csharp
    
            public static PropertiesSerializer Default { get; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authentication.PropertiesSerializer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authentication.PropertiesSerializer.Deserialize(System.Byte[])
    
        
    
        
        :type data: System.Byte<System.Byte>[]
        :rtype: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
            public virtual AuthenticationProperties Deserialize(byte[] data)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.PropertiesSerializer.Read(System.IO.BinaryReader)
    
        
    
        
        :type reader: System.IO.BinaryReader
        :rtype: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
            public virtual AuthenticationProperties Read(BinaryReader reader)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.PropertiesSerializer.Serialize(Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties)
    
        
    
        
        :type model: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
        :rtype: System.Byte<System.Byte>[]
    
        
        .. code-block:: csharp
    
            public virtual byte[] Serialize(AuthenticationProperties model)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.PropertiesSerializer.Write(System.IO.BinaryWriter, Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties)
    
        
    
        
        :type writer: System.IO.BinaryWriter
    
        
        :type properties: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
            public virtual void Write(BinaryWriter writer, AuthenticationProperties properties)
    

