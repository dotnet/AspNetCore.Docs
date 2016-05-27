

RuntimeInfoPageOptions Class
============================






Options for the RuntimeInfoPage


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
* :dn:cls:`Microsoft.AspNetCore.Builder.RuntimeInfoPageOptions`








Syntax
------

.. code-block:: csharp

    public class RuntimeInfoPageOptions








.. dn:class:: Microsoft.AspNetCore.Builder.RuntimeInfoPageOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.RuntimeInfoPageOptions

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Builder.RuntimeInfoPageOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Builder.RuntimeInfoPageOptions.Path
    
        
    
        
        Specifies which request path will be responded to. Exact match only. Set to null to handle all requests.
    
        
        :rtype: Microsoft.AspNetCore.Http.PathString
    
        
        .. code-block:: csharp
    
            public PathString Path
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Builder.RuntimeInfoPageOptions
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Builder.RuntimeInfoPageOptions.RuntimeInfoPageOptions()
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Builder.RuntimeInfoPageOptions` class
    
        
    
        
        .. code-block:: csharp
    
            public RuntimeInfoPageOptions()
    

