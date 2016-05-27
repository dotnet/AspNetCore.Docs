

AntiforgerySerializationContext Class
=====================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Antiforgery.Internal`
Assemblies
    * Microsoft.AspNetCore.Antiforgery

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Antiforgery.Internal.AntiforgerySerializationContext`








Syntax
------

.. code-block:: csharp

    public class AntiforgerySerializationContext








.. dn:class:: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgerySerializationContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgerySerializationContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgerySerializationContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgerySerializationContext.Reader
    
        
        :rtype: System.IO.BinaryReader
    
        
        .. code-block:: csharp
    
            public BinaryReader Reader
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgerySerializationContext.Sha256
    
        
        :rtype: System.Security.Cryptography.SHA256
    
        
        .. code-block:: csharp
    
            public SHA256 Sha256
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgerySerializationContext.Stream
    
        
        :rtype: System.IO.MemoryStream
    
        
        .. code-block:: csharp
    
            public MemoryStream Stream
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgerySerializationContext.Writer
    
        
        :rtype: System.IO.BinaryWriter
    
        
        .. code-block:: csharp
    
            public BinaryWriter Writer
            {
                get;
            }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgerySerializationContext
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgerySerializationContext.GetChars(System.Int32)
    
        
    
        
        :type count: System.Int32
        :rtype: System.Char<System.Char>[]
    
        
        .. code-block:: csharp
    
            public char[] GetChars(int count)
    
    .. dn:method:: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgerySerializationContext.Reset()
    
        
    
        
        .. code-block:: csharp
    
            public void Reset()
    

