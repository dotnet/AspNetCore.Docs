

StatusCodePagesOptions Class
============================



.. contents:: 
   :local:



Summary
-------

Options for StatusCodePagesMiddleware.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Diagnostics.StatusCodePagesOptions`








Syntax
------

.. code-block:: csharp

   public class StatusCodePagesOptions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/diagnostics/src/Microsoft.AspNet.Diagnostics/StatusCodePage/StatusCodePagesOptions.cs>`_





.. dn:class:: Microsoft.AspNet.Diagnostics.StatusCodePagesOptions

Constructors
------------

.. dn:class:: Microsoft.AspNet.Diagnostics.StatusCodePagesOptions
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Diagnostics.StatusCodePagesOptions.StatusCodePagesOptions()
    
        
    
        
        .. code-block:: csharp
    
           public StatusCodePagesOptions()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Diagnostics.StatusCodePagesOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Diagnostics.StatusCodePagesOptions.HandleAsync
    
        
        :rtype: System.Func{Microsoft.AspNet.Diagnostics.StatusCodeContext,System.Threading.Tasks.Task}
    
        
        .. code-block:: csharp
    
           public Func<StatusCodeContext, Task> HandleAsync { get; set; }
    

