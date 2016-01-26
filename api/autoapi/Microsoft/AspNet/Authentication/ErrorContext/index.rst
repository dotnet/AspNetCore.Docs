

ErrorContext Class
==================



.. contents:: 
   :local:



Summary
-------

Provides error context information to middleware providers.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.BaseContext`
* :dn:cls:`Microsoft.AspNet.Authentication.BaseControlContext`
* :dn:cls:`Microsoft.AspNet.Authentication.ErrorContext`








Syntax
------

.. code-block:: csharp

   public class ErrorContext : BaseControlContext





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authentication/Events/ErrorContext.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.ErrorContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authentication.ErrorContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authentication.ErrorContext.ErrorContext(Microsoft.AspNet.Http.HttpContext, System.Exception)
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        
        
        :type error: System.Exception
    
        
        .. code-block:: csharp
    
           public ErrorContext(HttpContext context, Exception error)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.ErrorContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.ErrorContext.Error
    
        
    
        User friendly error message for the error.
    
        
        :rtype: System.Exception
    
        
        .. code-block:: csharp
    
           public Exception Error { get; set; }
    

