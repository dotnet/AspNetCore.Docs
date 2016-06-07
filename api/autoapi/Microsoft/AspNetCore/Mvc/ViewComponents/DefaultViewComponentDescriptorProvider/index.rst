

DefaultViewComponentDescriptorProvider Class
============================================






Default implementation of :any:`Microsoft.AspNetCore.Mvc.ViewComponents.IViewComponentDescriptorProvider`\.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentDescriptorProvider`








Syntax
------

.. code-block:: csharp

    public class DefaultViewComponentDescriptorProvider : IViewComponentDescriptorProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentDescriptorProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentDescriptorProvider

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentDescriptorProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentDescriptorProvider.DefaultViewComponentDescriptorProvider(Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentDescriptorProvider`\.
    
        
    
        
        :param partManager: The :any:`Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager`\.
        
        :type partManager: Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager
    
        
        .. code-block:: csharp
    
            public DefaultViewComponentDescriptorProvider(ApplicationPartManager partManager)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentDescriptorProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentDescriptorProvider.GetCandidateTypes()
    
        
    
        
        Gets the candidate :any:`System.Reflection.TypeInfo` instances provided by the :any:`Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager`\.
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.Reflection.TypeInfo<System.Reflection.TypeInfo>}
        :return: A list of :any:`System.Reflection.TypeInfo` instances.
    
        
        .. code-block:: csharp
    
            protected virtual IEnumerable<TypeInfo> GetCandidateTypes()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewComponents.DefaultViewComponentDescriptorProvider.GetViewComponents()
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentDescriptor<Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentDescriptor>}
    
        
        .. code-block:: csharp
    
            public virtual IEnumerable<ViewComponentDescriptor> GetViewComponents()
    

