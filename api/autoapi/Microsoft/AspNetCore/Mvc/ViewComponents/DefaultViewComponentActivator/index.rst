

DefaultViewComponentActivator Class
===================================






A default implementation of :any:`Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentActivator`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ViewComponents`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentActivator`








Syntax
------

.. code-block:: csharp

    public class DefaultViewComponentActivator : IViewComponentActivator








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentActivator
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentActivator

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentActivator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentActivator.DefaultViewComponentActivator(Microsoft.AspNetCore.Mvc.Internal.ITypeActivatorCache)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentActivator` class.
    
        
    
        
        :param typeActivatorCache: 
            The :any:`Microsoft.AspNetCore.Mvc.Internal.ITypeActivatorCache` used to create new view component instances.
        
        :type typeActivatorCache: Microsoft.AspNetCore.Mvc.Internal.ITypeActivatorCache
    
        
        .. code-block:: csharp
    
            public DefaultViewComponentActivator(ITypeActivatorCache typeActivatorCache)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentActivator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentActivator.Create(Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public virtual object Create(ViewComponentContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentActivator.Release(Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext, System.Object)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentContext
    
        
        :type viewComponent: System.Object
    
        
        .. code-block:: csharp
    
            public virtual void Release(ViewComponentContext context, object viewComponent)
    

