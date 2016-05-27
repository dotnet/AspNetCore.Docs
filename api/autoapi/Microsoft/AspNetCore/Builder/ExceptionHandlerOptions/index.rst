

ExceptionHandlerOptions Class
=============================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Builder`
Assemblies
    * Microsoft.AspNetCore.Diagnostics

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Builder.ExceptionHandlerOptions`








Syntax
------

.. code-block:: csharp

    public class ExceptionHandlerOptions








.. dn:class:: Microsoft.AspNetCore.Builder.ExceptionHandlerOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.ExceptionHandlerOptions

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Builder.ExceptionHandlerOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Builder.ExceptionHandlerOptions.ExceptionHandler
    
        
        :rtype: Microsoft.AspNetCore.Http.RequestDelegate
    
        
        .. code-block:: csharp
    
            public RequestDelegate ExceptionHandler
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.ExceptionHandlerOptions.ExceptionHandlingPath
    
        
        :rtype: Microsoft.AspNetCore.Http.PathString
    
        
        .. code-block:: csharp
    
            public PathString ExceptionHandlingPath
            {
                get;
                set;
            }
    

