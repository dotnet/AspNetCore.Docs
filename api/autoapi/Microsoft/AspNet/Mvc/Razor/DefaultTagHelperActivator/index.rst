

DefaultTagHelperActivator Class
===============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.DefaultTagHelperActivator`








Syntax
------

.. code-block:: csharp

   public class DefaultTagHelperActivator : ITagHelperActivator





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Razor/DefaultTagHelperActivator.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.DefaultTagHelperActivator

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.DefaultTagHelperActivator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Razor.DefaultTagHelperActivator.DefaultTagHelperActivator()
    
        
    
        Instantiates a new :any:`Microsoft.AspNet.Mvc.Razor.DefaultTagHelperActivator` instance.
    
        
    
        
        .. code-block:: csharp
    
           public DefaultTagHelperActivator()
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.DefaultTagHelperActivator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.DefaultTagHelperActivator.Activate<TTagHelper>(TTagHelper, Microsoft.AspNet.Mvc.Rendering.ViewContext)
    
        
        
        
        :type tagHelper: {TTagHelper}
        
        
        :type context: Microsoft.AspNet.Mvc.Rendering.ViewContext
    
        
        .. code-block:: csharp
    
           public void Activate<TTagHelper>(TTagHelper tagHelper, ViewContext context)where TTagHelper : ITagHelper
    

