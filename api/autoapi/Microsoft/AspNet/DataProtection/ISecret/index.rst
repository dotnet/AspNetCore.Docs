

ISecret Interface
=================



.. contents:: 
   :local:



Summary
-------

Represents a secret value.











Syntax
------

.. code-block:: csharp

   public interface ISecret : IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/dataprotection/src/Microsoft.AspNet.DataProtection/ISecret.cs>`_





.. dn:interface:: Microsoft.AspNet.DataProtection.ISecret

Methods
-------

.. dn:interface:: Microsoft.AspNet.DataProtection.ISecret
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.DataProtection.ISecret.WriteSecretIntoBuffer(System.ArraySegment<System.Byte>)
    
        
    
        Writes the secret value to the specified buffer.
    
        
        
        
        :param buffer: The buffer which should receive the secret value.
        
        :type buffer: System.ArraySegment{System.Byte}
    
        
        .. code-block:: csharp
    
           void WriteSecretIntoBuffer(ArraySegment<byte> buffer)
    

Properties
----------

.. dn:interface:: Microsoft.AspNet.DataProtection.ISecret
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.DataProtection.ISecret.Length
    
        
    
        The length (in bytes) of the secret value.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int Length { get; }
    

