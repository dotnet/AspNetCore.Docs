

Context Struct
==============





Namespace
    :dn:ns:`Microsoft.AspNetCore.Hosting.Internal.HostingApplication`
Assemblies
    * Microsoft.AspNetCore.Hosting

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public struct Context








.. dn:structure:: Microsoft.AspNetCore.Hosting.Internal.HostingApplication.Context
    :hidden:

.. dn:structure:: Microsoft.AspNetCore.Hosting.Internal.HostingApplication.Context

Properties
----------

.. dn:structure:: Microsoft.AspNetCore.Hosting.Internal.HostingApplication.Context
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Hosting.Internal.HostingApplication.Context.HttpContext
    
        
        :rtype: Microsoft.AspNetCore.Http.HttpContext
    
        
        .. code-block:: csharp
    
            public HttpContext HttpContext
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Hosting.Internal.HostingApplication.Context.Scope
    
        
        :rtype: System.IDisposable
    
        
        .. code-block:: csharp
    
            public IDisposable Scope
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Hosting.Internal.HostingApplication.Context.StartTimestamp
    
        
        :rtype: System.Int64
    
        
        .. code-block:: csharp
    
            public long StartTimestamp
            {
                get;
                set;
            }
    

