

DefaultViewComponentDescriptorProvider Class
============================================



.. contents:: 
   :local:



Summary
-------

Default implementation of :any:`Microsoft.AspNet.Mvc.ViewComponents.IViewComponentDescriptorProvider`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentDescriptorProvider`








Syntax
------

.. code-block:: csharp

   public class DefaultViewComponentDescriptorProvider : IViewComponentDescriptorProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewComponents/DefaultViewComponentDescriptorProvider.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentDescriptorProvider

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentDescriptorProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentDescriptorProvider.DefaultViewComponentDescriptorProvider(Microsoft.AspNet.Mvc.Infrastructure.IAssemblyProvider)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentDescriptorProvider`\.
    
        
        
        
        :param assemblyProvider: The .
        
        :type assemblyProvider: Microsoft.AspNet.Mvc.Infrastructure.IAssemblyProvider
    
        
        .. code-block:: csharp
    
           public DefaultViewComponentDescriptorProvider(IAssemblyProvider assemblyProvider)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentDescriptorProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentDescriptorProvider.GetCandidateTypes()
    
        
    
        Gets the candidate :any:`System.Reflection.TypeInfo` instances. The results of this will be provided to 
        :dn:meth:`Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentDescriptorProvider.IsViewComponentType(System.Reflection.TypeInfo)` for filtering.
    
        
        :rtype: System.Collections.Generic.IEnumerable{System.Reflection.TypeInfo}
        :return: A list of <see cref="T:System.Reflection.TypeInfo" /> instances.
    
        
        .. code-block:: csharp
    
           protected virtual IEnumerable<TypeInfo> GetCandidateTypes()
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentDescriptorProvider.GetViewComponents()
    
        
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.ViewComponents.ViewComponentDescriptor}
    
        
        .. code-block:: csharp
    
           public virtual IEnumerable<ViewComponentDescriptor> GetViewComponents()
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewComponents.DefaultViewComponentDescriptorProvider.IsViewComponentType(System.Reflection.TypeInfo)
    
        
    
        Determines whether or not the given :any:`System.Reflection.TypeInfo` is a View Component class.
    
        
        
        
        :param typeInfo: The .
        
        :type typeInfo: System.Reflection.TypeInfo
        :rtype: System.Boolean
        :return: <c>true</c> if <paramref name="typeInfo" />represents a View Component class, otherwise <c>false</c>.
    
        
        .. code-block:: csharp
    
           protected virtual bool IsViewComponentType(TypeInfo typeInfo)
    

