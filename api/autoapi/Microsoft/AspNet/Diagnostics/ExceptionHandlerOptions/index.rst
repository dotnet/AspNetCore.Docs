

ExceptionHandlerOptions Class
=============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Diagnostics.ExceptionHandlerOptions`








Syntax
------

.. code-block:: csharp

   public class ExceptionHandlerOptions





GitHub
------

`View on GitHub <https://github.com/aspnet/diagnostics/blob/master/src/Microsoft.AspNet.Diagnostics/ExceptionHandler/ExceptionHandlerOptions.cs>`_





.. dn:class:: Microsoft.AspNet.Diagnostics.ExceptionHandlerOptions

Properties
----------

.. dn:class:: Microsoft.AspNet.Diagnostics.ExceptionHandlerOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Diagnostics.ExceptionHandlerOptions.ExceptionHandler
    
        
        :rtype: Microsoft.AspNet.Builder.RequestDelegate
    
        
        .. code-block:: csharp
    
           public RequestDelegate ExceptionHandler { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.ExceptionHandlerOptions.ExceptionHandlingPath
    
        
        :rtype: Microsoft.AspNet.Http.PathString
    
        
        .. code-block:: csharp
    
           public PathString ExceptionHandlingPath { get; set; }
    

