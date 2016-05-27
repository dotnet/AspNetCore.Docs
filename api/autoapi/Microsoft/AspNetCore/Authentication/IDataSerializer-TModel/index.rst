

IDataSerializer<TModel> Interface
=================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication`
Assemblies
    * Microsoft.AspNetCore.Authentication

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IDataSerializer<TModel>








.. dn:interface:: Microsoft.AspNetCore.Authentication.IDataSerializer`1
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Authentication.IDataSerializer<TModel>

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Authentication.IDataSerializer<TModel>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authentication.IDataSerializer<TModel>.Deserialize(System.Byte[])
    
        
    
        
        :type data: System.Byte<System.Byte>[]
        :rtype: TModel
    
        
        .. code-block:: csharp
    
            TModel Deserialize(byte[] data)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.IDataSerializer<TModel>.Serialize(TModel)
    
        
    
        
        :type model: TModel
        :rtype: System.Byte<System.Byte>[]
    
        
        .. code-block:: csharp
    
            byte[] Serialize(TModel model)
    

