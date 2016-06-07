

DefaultTagHelperFactory Class
=============================






Default implementation for :any:`Microsoft.AspNetCore.Mvc.Razor.ITagHelperFactory`\.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultTagHelperFactory`








Syntax
------

.. code-block:: csharp

    public class DefaultTagHelperFactory : ITagHelperFactory








.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultTagHelperFactory
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultTagHelperFactory

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultTagHelperFactory
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultTagHelperFactory.DefaultTagHelperFactory(Microsoft.AspNetCore.Mvc.Razor.ITagHelperActivator)
    
        
    
        
        Initializes a new :any:`Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultTagHelperFactory` instance.
    
        
    
        
        :param activator: 
            The :any:`Microsoft.AspNetCore.Mvc.Razor.ITagHelperActivator` used to create tag helper instances.
        
        :type activator: Microsoft.AspNetCore.Mvc.Razor.ITagHelperActivator
    
        
        .. code-block:: csharp
    
            public DefaultTagHelperFactory(ITagHelperActivator activator)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultTagHelperFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultTagHelperFactory.CreateTagHelper<TTagHelper>(Microsoft.AspNetCore.Mvc.Rendering.ViewContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
        :rtype: TTagHelper
    
        
        .. code-block:: csharp
    
            public TTagHelper CreateTagHelper<TTagHelper>(ViewContext context)where TTagHelper : ITagHelper
    

