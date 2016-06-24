

ServiceBasedTagHelperActivator Class
====================================






A :any:`Microsoft.AspNetCore.Mvc.Razor.ITagHelperActivator` that retrieves tag helpers as services from the request's 
:any:`System.IServiceProvider`\.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Razor.Internal.ServiceBasedTagHelperActivator`








Syntax
------

.. code-block:: csharp

    public class ServiceBasedTagHelperActivator : ITagHelperActivator








.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Internal.ServiceBasedTagHelperActivator
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Internal.ServiceBasedTagHelperActivator

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Internal.ServiceBasedTagHelperActivator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.Internal.ServiceBasedTagHelperActivator.Create<TTagHelper>(Microsoft.AspNetCore.Mvc.Rendering.ViewContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
        :rtype: TTagHelper
    
        
        .. code-block:: csharp
    
            public TTagHelper Create<TTagHelper>(ViewContext context)where TTagHelper : ITagHelper
    

