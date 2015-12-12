

PropertiesSerializer Class
==========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.PropertiesSerializer`








Syntax
------

.. code-block:: csharp

   public class PropertiesSerializer : IDataSerializer<AuthenticationProperties>





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.Authentication/DataHandler/PropertiesSerializer.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.PropertiesSerializer

Methods
-------

.. dn:class:: Microsoft.AspNet.Authentication.PropertiesSerializer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authentication.PropertiesSerializer.Deserialize(System.Byte[])
    
        
        
        
        :type data: System.Byte[]
        :rtype: Microsoft.AspNet.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
           public virtual AuthenticationProperties Deserialize(byte[] data)
    
    .. dn:method:: Microsoft.AspNet.Authentication.PropertiesSerializer.Read(System.IO.BinaryReader)
    
        
        
        
        :type reader: System.IO.BinaryReader
        :rtype: Microsoft.AspNet.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
           public virtual AuthenticationProperties Read(BinaryReader reader)
    
    .. dn:method:: Microsoft.AspNet.Authentication.PropertiesSerializer.Serialize(Microsoft.AspNet.Http.Authentication.AuthenticationProperties)
    
        
        
        
        :type model: Microsoft.AspNet.Http.Authentication.AuthenticationProperties
        :rtype: System.Byte[]
    
        
        .. code-block:: csharp
    
           public virtual byte[] Serialize(AuthenticationProperties model)
    
    .. dn:method:: Microsoft.AspNet.Authentication.PropertiesSerializer.Write(System.IO.BinaryWriter, Microsoft.AspNet.Http.Authentication.AuthenticationProperties)
    
        
        
        
        :type writer: System.IO.BinaryWriter
        
        
        :type properties: Microsoft.AspNet.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
           public virtual void Write(BinaryWriter writer, AuthenticationProperties properties)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.PropertiesSerializer
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.PropertiesSerializer.Default
    
        
        :rtype: Microsoft.AspNet.Authentication.PropertiesSerializer
    
        
        .. code-block:: csharp
    
           public static PropertiesSerializer Default { get; }
    

