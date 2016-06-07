

ErrorPageModel Class
====================






Holds data to be displayed on the error page.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Diagnostics.Views`
Assemblies
    * Microsoft.AspNetCore.Diagnostics

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Diagnostics.Views.ErrorPageModel`








Syntax
------

.. code-block:: csharp

    public class ErrorPageModel








.. dn:class:: Microsoft.AspNetCore.Diagnostics.Views.ErrorPageModel
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Diagnostics.Views.ErrorPageModel

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.Views.ErrorPageModel
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.Views.ErrorPageModel.Cookies
    
        
    
        
        Request cookies.
    
        
        :rtype: Microsoft.AspNetCore.Http.IRequestCookieCollection
    
        
        .. code-block:: csharp
    
            public IRequestCookieCollection Cookies
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.Views.ErrorPageModel.ErrorDetails
    
        
    
        
        Detailed information about each exception in the stack.
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Diagnostics.Views.ErrorDetails<Microsoft.AspNetCore.Diagnostics.Views.ErrorDetails>}
    
        
        .. code-block:: csharp
    
            public IEnumerable<ErrorDetails> ErrorDetails
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.Views.ErrorPageModel.Headers
    
        
    
        
        Request headers.
    
        
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, Microsoft.Extensions.Primitives.StringValues<Microsoft.Extensions.Primitives.StringValues>}
    
        
        .. code-block:: csharp
    
            public IDictionary<string, StringValues> Headers
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.Views.ErrorPageModel.Options
    
        
    
        
        Options for what output to display.
    
        
        :rtype: Microsoft.AspNetCore.Builder.DeveloperExceptionPageOptions
    
        
        .. code-block:: csharp
    
            public DeveloperExceptionPageOptions Options
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.Views.ErrorPageModel.Query
    
        
    
        
        Parsed query data.
    
        
        :rtype: Microsoft.AspNetCore.Http.IQueryCollection
    
        
        .. code-block:: csharp
    
            public IQueryCollection Query
            {
                get;
                set;
            }
    

