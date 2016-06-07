

FailureContext Class
====================






Provides failure context information to middleware providers.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication`
Assemblies
    * Microsoft.AspNetCore.Authentication

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Authentication.BaseContext`
* :dn:cls:`Microsoft.AspNetCore.Authentication.BaseControlContext`
* :dn:cls:`Microsoft.AspNetCore.Authentication.FailureContext`








Syntax
------

.. code-block:: csharp

    public class FailureContext : BaseControlContext








.. dn:class:: Microsoft.AspNetCore.Authentication.FailureContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.FailureContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authentication.FailureContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authentication.FailureContext.Failure
    
        
    
        
        User friendly error message for the error.
    
        
        :rtype: System.Exception
    
        
        .. code-block:: csharp
    
            public Exception Failure
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authentication.FailureContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authentication.FailureContext.FailureContext(Microsoft.AspNetCore.Http.HttpContext, System.Exception)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        :type failure: System.Exception
    
        
        .. code-block:: csharp
    
            public FailureContext(HttpContext context, Exception failure)
    

