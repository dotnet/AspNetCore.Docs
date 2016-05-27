

ISecret Interface
=================






Represents a secret value.


Namespace
    :dn:ns:`Microsoft.AspNetCore.DataProtection`
Assemblies
    * Microsoft.AspNetCore.DataProtection

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface ISecret : IDisposable








.. dn:interface:: Microsoft.AspNetCore.DataProtection.ISecret
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.DataProtection.ISecret

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.DataProtection.ISecret
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.DataProtection.ISecret.Length
    
        
    
        
        The length (in bytes) of the secret value.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            int Length
            {
                get;
            }
    

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.DataProtection.ISecret
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.ISecret.WriteSecretIntoBuffer(System.ArraySegment<System.Byte>)
    
        
    
        
        Writes the secret value to the specified buffer.
    
        
    
        
        :param buffer: The buffer which should receive the secret value.
        
        :type buffer: System.ArraySegment<System.ArraySegment`1>{System.Byte<System.Byte>}
    
        
        .. code-block:: csharp
    
            void WriteSecretIntoBuffer(ArraySegment<byte> buffer)
    

