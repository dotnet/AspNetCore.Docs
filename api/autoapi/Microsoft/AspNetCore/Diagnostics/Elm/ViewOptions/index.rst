

ViewOptions Class
=================






Options for viewing elm logs.


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
* :dn:cls:`Microsoft.AspNetCore.Diagnostics.Elm.ViewOptions`








Syntax
------

.. code-block:: csharp

    public class ViewOptions








.. dn:class:: Microsoft.AspNetCore.Diagnostics.Elm.ViewOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Diagnostics.Elm.ViewOptions

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.Elm.ViewOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.Elm.ViewOptions.MinLevel
    
        
    
        
        The minimum :any:`Microsoft.Extensions.Logging.LogLevel` of logs shown on the elm page.
    
        
        :rtype: Microsoft.Extensions.Logging.LogLevel
    
        
        .. code-block:: csharp
    
            public LogLevel MinLevel
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.Elm.ViewOptions.NamePrefix
    
        
    
        
        The prefix for the logger names of logs shown on the elm page.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string NamePrefix
            {
                get;
                set;
            }
    

