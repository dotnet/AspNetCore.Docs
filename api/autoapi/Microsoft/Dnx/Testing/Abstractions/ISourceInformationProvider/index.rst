

ISourceInformationProvider Interface
====================================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface ISourceInformationProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/testing/blob/master/src/Microsoft.Dnx.Testing.Abstractions/ISourceInformationProvider.cs>`_





.. dn:interface:: Microsoft.Dnx.Testing.Abstractions.ISourceInformationProvider

Methods
-------

.. dn:interface:: Microsoft.Dnx.Testing.Abstractions.ISourceInformationProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Dnx.Testing.Abstractions.ISourceInformationProvider.GetSourceInformation(System.Reflection.MethodInfo)
    
        
        
        
        :type method: System.Reflection.MethodInfo
        :rtype: Microsoft.Dnx.Testing.Abstractions.SourceInformation
    
        
        .. code-block:: csharp
    
           SourceInformation GetSourceInformation(MethodInfo method)
    

