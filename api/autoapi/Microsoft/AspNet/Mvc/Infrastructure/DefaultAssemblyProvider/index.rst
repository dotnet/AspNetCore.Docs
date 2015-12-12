

DefaultAssemblyProvider Class
=============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Infrastructure.DefaultAssemblyProvider`








Syntax
------

.. code-block:: csharp

   public class DefaultAssemblyProvider : IAssemblyProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/Infrastructure/DefaultAssemblyProvider.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Infrastructure.DefaultAssemblyProvider

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Infrastructure.DefaultAssemblyProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Infrastructure.DefaultAssemblyProvider.DefaultAssemblyProvider(Microsoft.Extensions.PlatformAbstractions.ILibraryManager)
    
        
        
        
        :type libraryManager: Microsoft.Extensions.PlatformAbstractions.ILibraryManager
    
        
        .. code-block:: csharp
    
           public DefaultAssemblyProvider(ILibraryManager libraryManager)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Infrastructure.DefaultAssemblyProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Infrastructure.DefaultAssemblyProvider.GetCandidateLibraries()
    
        
    
        Returns a list of libraries that references the assemblies in :dn:prop:`Microsoft.AspNet.Mvc.Infrastructure.DefaultAssemblyProvider.ReferenceAssemblies`\.
        By default it returns all assemblies that reference any of the primary MVC assemblies
        while ignoring MVC assemblies.
    
        
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.Extensions.PlatformAbstractions.Library}
        :return: A set of <see cref="T:Microsoft.Extensions.PlatformAbstractions.Library" />.
    
        
        .. code-block:: csharp
    
           protected virtual IEnumerable<Library> GetCandidateLibraries()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Infrastructure.DefaultAssemblyProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Infrastructure.DefaultAssemblyProvider.CandidateAssemblies
    
        
        :rtype: System.Collections.Generic.IEnumerable{System.Reflection.Assembly}
    
        
        .. code-block:: csharp
    
           public IEnumerable<Assembly> CandidateAssemblies { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Infrastructure.DefaultAssemblyProvider.ReferenceAssemblies
    
        
    
        Gets the set of assembly names that are used as root for discovery of
        MVC controllers, view components and views.
    
        
        :rtype: System.Collections.Generic.HashSet{System.String}
    
        
        .. code-block:: csharp
    
           protected virtual HashSet<string> ReferenceAssemblies { get; }
    

