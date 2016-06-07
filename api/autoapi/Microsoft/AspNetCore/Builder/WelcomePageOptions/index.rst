

WelcomePageOptions Class
========================






Options for the WelcomePageMiddleware.


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
* :dn:cls:`Microsoft.AspNetCore.Builder.WelcomePageOptions`








Syntax
------

.. code-block:: csharp

    public class WelcomePageOptions








.. dn:class:: Microsoft.AspNetCore.Builder.WelcomePageOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.WelcomePageOptions

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Builder.WelcomePageOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Builder.WelcomePageOptions.Path
    
        
    
        
        Specifies which requests paths will be responded to. Exact matches only. Leave null to handle all requests.
    
        
        :rtype: Microsoft.AspNetCore.Http.PathString
    
        
        .. code-block:: csharp
    
            public PathString Path
            {
                get;
                set;
            }
    

