

WelcomePageOptions Class
========================



.. contents:: 
   :local:



Summary
-------

Options for the WelcomePageMiddleware.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Diagnostics.WelcomePageOptions`








Syntax
------

.. code-block:: csharp

   public class WelcomePageOptions





GitHub
------

`View on GitHub <https://github.com/aspnet/diagnostics/blob/master/src/Microsoft.AspNet.Diagnostics/WelcomePage/WelcomePageOptions.cs>`_





.. dn:class:: Microsoft.AspNet.Diagnostics.WelcomePageOptions

Properties
----------

.. dn:class:: Microsoft.AspNet.Diagnostics.WelcomePageOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Diagnostics.WelcomePageOptions.Path
    
        
    
        Specifies which requests paths will be responded to. Exact matches only. Leave null to handle all requests.
    
        
        :rtype: Microsoft.AspNet.Http.PathString
    
        
        .. code-block:: csharp
    
           public PathString Path { get; set; }
    

