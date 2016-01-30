

IRazorPageFactory Interface
===========================



.. contents:: 
   :local:



Summary
-------

Defines methods that are used for creating :any:`Microsoft.AspNet.Mvc.Razor.IRazorPage` instances at a given path.











Syntax
------

.. code-block:: csharp

   public interface IRazorPageFactory





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Razor/IRazorPageFactory.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Razor.IRazorPageFactory

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.Razor.IRazorPageFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.IRazorPageFactory.CreateInstance(System.String)
    
        
    
        Creates a :any:`Microsoft.AspNet.Mvc.Razor.IRazorPage` for the specified path.
    
        
        
        
        :param relativePath: The path to locate the page.
        
        :type relativePath: System.String
        :rtype: Microsoft.AspNet.Mvc.Razor.IRazorPage
        :return: The IRazorPage instance if it exists, null otherwise.
    
        
        .. code-block:: csharp
    
           IRazorPage CreateInstance(string relativePath)
    

