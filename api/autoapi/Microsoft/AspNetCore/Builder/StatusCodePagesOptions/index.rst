

StatusCodePagesOptions Class
============================






Options for StatusCodePagesMiddleware.


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
* :dn:cls:`Microsoft.AspNetCore.Builder.StatusCodePagesOptions`








Syntax
------

.. code-block:: csharp

    public class StatusCodePagesOptions








.. dn:class:: Microsoft.AspNetCore.Builder.StatusCodePagesOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.StatusCodePagesOptions

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Builder.StatusCodePagesOptions
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Builder.StatusCodePagesOptions.StatusCodePagesOptions()
    
        
    
        
        .. code-block:: csharp
    
            public StatusCodePagesOptions()
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Builder.StatusCodePagesOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Builder.StatusCodePagesOptions.HandleAsync
    
        
        :rtype: System.Func<System.Func`2>{Microsoft.AspNetCore.Diagnostics.StatusCodeContext<Microsoft.AspNetCore.Diagnostics.StatusCodeContext>, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}
    
        
        .. code-block:: csharp
    
            public Func<StatusCodeContext, Task> HandleAsync { get; set; }
    

