

StaticAssemblyProvider Class
============================



.. contents:: 
   :local:



Summary
-------

A :any:`Microsoft.AspNet.Mvc.Infrastructure.IAssemblyProvider` with a fixed set of candidate assemblies.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Infrastructure.StaticAssemblyProvider`








Syntax
------

.. code-block:: csharp

   public class StaticAssemblyProvider : IAssemblyProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/Infrastructure/StaticAssemblyProvider.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Infrastructure.StaticAssemblyProvider

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Infrastructure.StaticAssemblyProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Infrastructure.StaticAssemblyProvider.CandidateAssemblies
    
        
    
        Gets the list of candidate assemblies.
    
        
        :rtype: System.Collections.Generic.IList{System.Reflection.Assembly}
    
        
        .. code-block:: csharp
    
           public IList<Assembly> CandidateAssemblies { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Infrastructure.StaticAssemblyProvider.Microsoft.AspNet.Mvc.Infrastructure.IAssemblyProvider.CandidateAssemblies
    
        
        :rtype: System.Collections.Generic.IEnumerable{System.Reflection.Assembly}
    
        
        .. code-block:: csharp
    
           IEnumerable<Assembly> IAssemblyProvider.CandidateAssemblies { get; }
    

