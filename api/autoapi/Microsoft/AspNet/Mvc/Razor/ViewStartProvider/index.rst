

ViewStartProvider Class
=======================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.ViewStartProvider`








Syntax
------

.. code-block:: csharp

   public class ViewStartProvider : IViewStartProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Razor/ViewStartProvider.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.ViewStartProvider

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.ViewStartProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Razor.ViewStartProvider.ViewStartProvider(Microsoft.AspNet.Mvc.Razor.IRazorPageFactory)
    
        
        
        
        :type pageFactory: Microsoft.AspNet.Mvc.Razor.IRazorPageFactory
    
        
        .. code-block:: csharp
    
           public ViewStartProvider(IRazorPageFactory pageFactory)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.ViewStartProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.ViewStartProvider.GetViewStartPages(System.String)
    
        
        
        
        :type path: System.String
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.Razor.IRazorPage}
    
        
        .. code-block:: csharp
    
           public IEnumerable<IRazorPage> GetViewStartPages(string path)
    

