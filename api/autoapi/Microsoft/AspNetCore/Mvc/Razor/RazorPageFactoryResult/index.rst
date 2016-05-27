

RazorPageFactoryResult Struct
=============================






Result of :dn:meth:`Microsoft.AspNetCore.Mvc.Razor.IRazorPageFactoryProvider.CreateFactory(System.String)`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Razor`
Assemblies
    * Microsoft.AspNetCore.Mvc.Razor

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public struct RazorPageFactoryResult








.. dn:structure:: Microsoft.AspNetCore.Mvc.Razor.RazorPageFactoryResult
    :hidden:

.. dn:structure:: Microsoft.AspNetCore.Mvc.Razor.RazorPageFactoryResult

Properties
----------

.. dn:structure:: Microsoft.AspNetCore.Mvc.Razor.RazorPageFactoryResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.RazorPageFactoryResult.ExpirationTokens
    
        
    
        
        One or more :any:`Microsoft.Extensions.Primitives.IChangeToken`\s associated with this instance of
        :any:`Microsoft.AspNetCore.Mvc.Razor.RazorPageFactoryResult`\.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.Extensions.Primitives.IChangeToken<Microsoft.Extensions.Primitives.IChangeToken>}
    
        
        .. code-block:: csharp
    
            public IList<IChangeToken> ExpirationTokens
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.RazorPageFactoryResult.RazorPageFactory
    
        
    
        
        The :any:`Microsoft.AspNetCore.Mvc.Razor.IRazorPage` factory.
    
        
        :rtype: System.Func<System.Func`1>{Microsoft.AspNetCore.Mvc.Razor.IRazorPage<Microsoft.AspNetCore.Mvc.Razor.IRazorPage>}
    
        
        .. code-block:: csharp
    
            public Func<IRazorPage> RazorPageFactory
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.RazorPageFactoryResult.Success
    
        
    
        
        Gets a value that determines if the page was successfully located.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Success
            {
                get;
            }
    

Constructors
------------

.. dn:structure:: Microsoft.AspNetCore.Mvc.Razor.RazorPageFactoryResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.RazorPageFactoryResult.RazorPageFactoryResult(System.Collections.Generic.IList<Microsoft.Extensions.Primitives.IChangeToken>)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.Razor.RazorPageFactoryResult` with the
        specified <em>expirationTokens</em>.
    
        
    
        
        :param expirationTokens: One or more :any:`Microsoft.Extensions.Primitives.IChangeToken` instances.
        
        :type expirationTokens: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.Extensions.Primitives.IChangeToken<Microsoft.Extensions.Primitives.IChangeToken>}
    
        
        .. code-block:: csharp
    
            public RazorPageFactoryResult(IList<IChangeToken> expirationTokens)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.RazorPageFactoryResult.RazorPageFactoryResult(System.Func<Microsoft.AspNetCore.Mvc.Razor.IRazorPage>, System.Collections.Generic.IList<Microsoft.Extensions.Primitives.IChangeToken>)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.Razor.RazorPageFactoryResult` with the
        specified :any:`Microsoft.AspNetCore.Mvc.Razor.IRazorPage` factory.
    
        
    
        
        :param razorPageFactory: The :any:`Microsoft.AspNetCore.Mvc.Razor.IRazorPage` factory.
        
        :type razorPageFactory: System.Func<System.Func`1>{Microsoft.AspNetCore.Mvc.Razor.IRazorPage<Microsoft.AspNetCore.Mvc.Razor.IRazorPage>}
    
        
        :param expirationTokens: One or more :any:`Microsoft.Extensions.Primitives.IChangeToken` instances.
        
        :type expirationTokens: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.Extensions.Primitives.IChangeToken<Microsoft.Extensions.Primitives.IChangeToken>}
    
        
        .. code-block:: csharp
    
            public RazorPageFactoryResult(Func<IRazorPage> razorPageFactory, IList<IChangeToken> expirationTokens)
    

