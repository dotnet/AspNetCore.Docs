

DefaultTagHelperActivator Class
===============================






Default implementation of :any:`Microsoft.AspNetCore.Mvc.Razor.ITagHelperActivator`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Razor.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultTagHelperActivator`








Syntax
------

.. code-block:: csharp

    public class DefaultTagHelperActivator : ITagHelperActivator








.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultTagHelperActivator
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultTagHelperActivator

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultTagHelperActivator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultTagHelperActivator.DefaultTagHelperActivator(Microsoft.AspNetCore.Mvc.Internal.ITypeActivatorCache)
    
        
    
        
        Instantiates a new :any:`Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultTagHelperActivator` instance.
    
        
    
        
        :param typeActivatorCache: The :any:`Microsoft.AspNetCore.Mvc.Internal.ITypeActivatorCache`\.
        
        :type typeActivatorCache: Microsoft.AspNetCore.Mvc.Internal.ITypeActivatorCache
    
        
        .. code-block:: csharp
    
            public DefaultTagHelperActivator(ITypeActivatorCache typeActivatorCache)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultTagHelperActivator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultTagHelperActivator.Create<TTagHelper>(Microsoft.AspNetCore.Mvc.Rendering.ViewContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
        :rtype: TTagHelper
    
        
        .. code-block:: csharp
    
            public TTagHelper Create<TTagHelper>(ViewContext context)where TTagHelper : ITagHelper
    

