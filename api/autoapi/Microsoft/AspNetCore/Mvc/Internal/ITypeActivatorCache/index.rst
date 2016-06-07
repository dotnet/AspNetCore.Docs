

ITypeActivatorCache Interface
=============================






Caches :any:`Microsoft.Extensions.DependencyInjection.ObjectFactory` instances produced by 
:dn:meth:`Microsoft.Extensions.DependencyInjection.ActivatorUtilities.CreateFactory(System.Type,System.Type[])`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface ITypeActivatorCache








.. dn:interface:: Microsoft.AspNetCore.Mvc.Internal.ITypeActivatorCache
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Internal.ITypeActivatorCache

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Internal.ITypeActivatorCache
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.ITypeActivatorCache.CreateInstance<TInstance>(System.IServiceProvider, System.Type)
    
        
    
        
        Creates an instance of <em>TInstance</em>.
    
        
    
        
        :param serviceProvider: The :any:`System.IServiceProvider` used to resolve dependencies for
            <em>optionType</em>.
        
        :type serviceProvider: System.IServiceProvider
    
        
        :param optionType: The :any:`System.Type` of the <em>TInstance</em> to create.
        
        :type optionType: System.Type
        :rtype: TInstance
    
        
        .. code-block:: csharp
    
            TInstance CreateInstance<TInstance>(IServiceProvider serviceProvider, Type optionType)
    

