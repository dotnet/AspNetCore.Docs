

ElmOptions Class
================






Options for ElmMiddleware


Namespace
    :dn:ns:`Microsoft.AspNetCore.Diagnostics.Elm`
Assemblies
    * Microsoft.AspNetCore.Diagnostics.Elm

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Diagnostics.Elm.ElmOptions`








Syntax
------

.. code-block:: csharp

    public class ElmOptions








.. dn:class:: Microsoft.AspNetCore.Diagnostics.Elm.ElmOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Diagnostics.Elm.ElmOptions

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.Elm.ElmOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.Elm.ElmOptions.Filter
    
        
    
        
        Determines whether log statements should be logged based on the name of the logger
        and the :dn:meth:`LogLevel` of the message.
    
        
        :rtype: System.Func<System.Func`3>{System.String<System.String>, Microsoft.Extensions.Logging.LogLevel<Microsoft.Extensions.Logging.LogLevel>, System.Boolean<System.Boolean>}
    
        
        .. code-block:: csharp
    
            public Func<string, LogLevel, bool> Filter
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.Elm.ElmOptions.Path
    
        
    
        
        Specifies the path to view the logs.
    
        
        :rtype: Microsoft.AspNetCore.Http.PathString
    
        
        .. code-block:: csharp
    
            public PathString Path
            {
                get;
                set;
            }
    

