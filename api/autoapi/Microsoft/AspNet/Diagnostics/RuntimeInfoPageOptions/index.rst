

RuntimeInfoPageOptions Class
============================



.. contents:: 
   :local:



Summary
-------

Options for the RuntimeInfoPage





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Diagnostics.RuntimeInfoPageOptions`








Syntax
------

.. code-block:: csharp

   public class RuntimeInfoPageOptions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/diagnostics/src/Microsoft.AspNet.Diagnostics/RuntimeInfo/RuntimeInfoPageOptions.cs>`_





.. dn:class:: Microsoft.AspNet.Diagnostics.RuntimeInfoPageOptions

Constructors
------------

.. dn:class:: Microsoft.AspNet.Diagnostics.RuntimeInfoPageOptions
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Diagnostics.RuntimeInfoPageOptions.RuntimeInfoPageOptions()
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Diagnostics.RuntimeInfoPageOptions` class
    
        
    
        
        .. code-block:: csharp
    
           public RuntimeInfoPageOptions()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Diagnostics.RuntimeInfoPageOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Diagnostics.RuntimeInfoPageOptions.Path
    
        
    
        Specifies which request path will be responded to. Exact match only. Set to null to handle all requests.
    
        
        :rtype: Microsoft.AspNet.Http.PathString
    
        
        .. code-block:: csharp
    
           public PathString Path { get; set; }
    

