

IViewStartProvider Interface
============================



.. contents:: 
   :local:



Summary
-------

Defines methods for locating ViewStart pages that are applicable to a page.











Syntax
------

.. code-block:: csharp

   public interface IViewStartProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Razor/IViewStartProvider.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Razor.IViewStartProvider

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.Razor.IViewStartProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.IViewStartProvider.GetViewStartPages(System.String)
    
        
    
        Given a view path, returns a sequence of ViewStart instances
        that are applicable to the specified view.
    
        
        
        
        :param path: The path of the page to locate ViewStart files for.
        
        :type path: System.String
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.Razor.IRazorPage}
        :return: A sequence of <see cref="T:Microsoft.AspNet.Mvc.Razor.IRazorPage" /> that represent ViewStart.
    
        
        .. code-block:: csharp
    
           IEnumerable<IRazorPage> GetViewStartPages(string path)
    

