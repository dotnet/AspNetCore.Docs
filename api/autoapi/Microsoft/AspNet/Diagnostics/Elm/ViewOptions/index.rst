

ViewOptions Class
=================



.. contents:: 
   :local:



Summary
-------

Options for viewing elm logs.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Diagnostics.Elm.ViewOptions`








Syntax
------

.. code-block:: csharp

   public class ViewOptions





GitHub
------

`View on GitHub <https://github.com/aspnet/diagnostics/blob/master/src/Microsoft.AspNet.Diagnostics.Elm/ViewOptions.cs>`_





.. dn:class:: Microsoft.AspNet.Diagnostics.Elm.ViewOptions

Properties
----------

.. dn:class:: Microsoft.AspNet.Diagnostics.Elm.ViewOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Elm.ViewOptions.MinLevel
    
        
    
        The minimum :any:`Microsoft.Extensions.Logging.LogLevel` of logs shown on the elm page.
    
        
        :rtype: Microsoft.Extensions.Logging.LogLevel
    
        
        .. code-block:: csharp
    
           public LogLevel MinLevel { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Elm.ViewOptions.NamePrefix
    
        
    
        The prefix for the logger names of logs shown on the elm page.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string NamePrefix { get; set; }
    

