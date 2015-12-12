

IAssemblyProvider Interface
===========================



.. contents:: 
   :local:



Summary
-------

Specifies the contract for discovering assemblies that may contain Mvc specific types such as controllers,
view components and precompiled views.











Syntax
------

.. code-block:: csharp

   public interface IAssemblyProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/Infrastructure/IAssemblyProvider.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Infrastructure.IAssemblyProvider

Properties
----------

.. dn:interface:: Microsoft.AspNet.Mvc.Infrastructure.IAssemblyProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Infrastructure.IAssemblyProvider.CandidateAssemblies
    
        
    
        Gets the sequence of candidate :any:`System.Reflection.Assembly` instances that the application
        uses for discovery of Mvc specific types.
    
        
        :rtype: System.Collections.Generic.IEnumerable{System.Reflection.Assembly}
    
        
        .. code-block:: csharp
    
           IEnumerable<Assembly> CandidateAssemblies { get; }
    

