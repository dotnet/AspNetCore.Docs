

ElmOptions Class
================



.. contents:: 
   :local:



Summary
-------

Options for ElmMiddleware





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Diagnostics.Elm.ElmOptions`








Syntax
------

.. code-block:: csharp

   public class ElmOptions





GitHub
------

`View on GitHub <https://github.com/aspnet/diagnostics/blob/master/src/Microsoft.AspNet.Diagnostics.Elm/ElmOptions.cs>`_





.. dn:class:: Microsoft.AspNet.Diagnostics.Elm.ElmOptions

Properties
----------

.. dn:class:: Microsoft.AspNet.Diagnostics.Elm.ElmOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Elm.ElmOptions.Filter
    
        
    
        Determines whether log statements should be logged based on the name of the logger
        and the :any:`Microsoft.Extensions.Logging.LogLevel` of the message.
    
        
        :rtype: System.Func{System.String,Microsoft.Extensions.Logging.LogLevel,System.Boolean}
    
        
        .. code-block:: csharp
    
           public Func<string, LogLevel, bool> Filter { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Elm.ElmOptions.Path
    
        
    
        Specifies the path to view the logs.
    
        
        :rtype: Microsoft.AspNet.Http.PathString
    
        
        .. code-block:: csharp
    
           public PathString Path { get; set; }
    

