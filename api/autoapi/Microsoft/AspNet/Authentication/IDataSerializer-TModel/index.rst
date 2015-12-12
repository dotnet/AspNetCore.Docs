

IDataSerializer<TModel> Interface
=================================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IDataSerializer<TModel>





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authentication/DataHandler/IDataSerializer.cs>`_





.. dn:interface:: Microsoft.AspNet.Authentication.IDataSerializer<TModel>

Methods
-------

.. dn:interface:: Microsoft.AspNet.Authentication.IDataSerializer<TModel>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authentication.IDataSerializer<TModel>.Deserialize(System.Byte[])
    
        
        
        
        :type data: System.Byte[]
        :rtype: {TModel}
    
        
        .. code-block:: csharp
    
           TModel Deserialize(byte[] data)
    
    .. dn:method:: Microsoft.AspNet.Authentication.IDataSerializer<TModel>.Serialize(TModel)
    
        
        
        
        :type model: {TModel}
        :rtype: System.Byte[]
    
        
        .. code-block:: csharp
    
           byte[] Serialize(TModel model)
    

