

TestSink Class
==============





Namespace
    :dn:ns:`Microsoft.Extensions.Logging.Testing`
Assemblies
    * Microsoft.Extensions.Logging.Testing

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Logging.Testing.TestSink`








Syntax
------

.. code-block:: csharp

    public class TestSink








.. dn:class:: Microsoft.Extensions.Logging.Testing.TestSink
    :hidden:

.. dn:class:: Microsoft.Extensions.Logging.Testing.TestSink

Constructors
------------

.. dn:class:: Microsoft.Extensions.Logging.Testing.TestSink
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Logging.Testing.TestSink.TestSink(System.Func<Microsoft.Extensions.Logging.Testing.WriteContext, System.Boolean>, System.Func<Microsoft.Extensions.Logging.Testing.BeginScopeContext, System.Boolean>)
    
        
    
        
        :type writeEnabled: System.Func<System.Func`2>{Microsoft.Extensions.Logging.Testing.WriteContext<Microsoft.Extensions.Logging.Testing.WriteContext>, System.Boolean<System.Boolean>}
    
        
        :type beginEnabled: System.Func<System.Func`2>{Microsoft.Extensions.Logging.Testing.BeginScopeContext<Microsoft.Extensions.Logging.Testing.BeginScopeContext>, System.Boolean<System.Boolean>}
    
        
        .. code-block:: csharp
    
            public TestSink(Func<WriteContext, bool> writeEnabled = null, Func<BeginScopeContext, bool> beginEnabled = null)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Logging.Testing.TestSink
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.Testing.TestSink.Begin(Microsoft.Extensions.Logging.Testing.BeginScopeContext)
    
        
    
        
        :type context: Microsoft.Extensions.Logging.Testing.BeginScopeContext
    
        
        .. code-block:: csharp
    
            public void Begin(BeginScopeContext context)
    
    .. dn:method:: Microsoft.Extensions.Logging.Testing.TestSink.EnableWithTypeName<T>(Microsoft.Extensions.Logging.Testing.BeginScopeContext)
    
        
    
        
        :type context: Microsoft.Extensions.Logging.Testing.BeginScopeContext
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public static bool EnableWithTypeName<T>(BeginScopeContext context)
    
    .. dn:method:: Microsoft.Extensions.Logging.Testing.TestSink.EnableWithTypeName<T>(Microsoft.Extensions.Logging.Testing.WriteContext)
    
        
    
        
        :type context: Microsoft.Extensions.Logging.Testing.WriteContext
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public static bool EnableWithTypeName<T>(WriteContext context)
    
    .. dn:method:: Microsoft.Extensions.Logging.Testing.TestSink.Write(Microsoft.Extensions.Logging.Testing.WriteContext)
    
        
    
        
        :type context: Microsoft.Extensions.Logging.Testing.WriteContext
    
        
        .. code-block:: csharp
    
            public void Write(WriteContext context)
    

Properties
----------

.. dn:class:: Microsoft.Extensions.Logging.Testing.TestSink
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Logging.Testing.TestSink.BeginEnabled
    
        
        :rtype: System.Func<System.Func`2>{Microsoft.Extensions.Logging.Testing.BeginScopeContext<Microsoft.Extensions.Logging.Testing.BeginScopeContext>, System.Boolean<System.Boolean>}
    
        
        .. code-block:: csharp
    
            public Func<BeginScopeContext, bool> BeginEnabled { get; set; }
    
    .. dn:property:: Microsoft.Extensions.Logging.Testing.TestSink.Scopes
    
        
        :rtype: System.Collections.Generic.List<System.Collections.Generic.List`1>{Microsoft.Extensions.Logging.Testing.BeginScopeContext<Microsoft.Extensions.Logging.Testing.BeginScopeContext>}
    
        
        .. code-block:: csharp
    
            public List<BeginScopeContext> Scopes { get; set; }
    
    .. dn:property:: Microsoft.Extensions.Logging.Testing.TestSink.WriteEnabled
    
        
        :rtype: System.Func<System.Func`2>{Microsoft.Extensions.Logging.Testing.WriteContext<Microsoft.Extensions.Logging.Testing.WriteContext>, System.Boolean<System.Boolean>}
    
        
        .. code-block:: csharp
    
            public Func<WriteContext, bool> WriteEnabled { get; set; }
    
    .. dn:property:: Microsoft.Extensions.Logging.Testing.TestSink.Writes
    
        
        :rtype: System.Collections.Generic.List<System.Collections.Generic.List`1>{Microsoft.Extensions.Logging.Testing.WriteContext<Microsoft.Extensions.Logging.Testing.WriteContext>}
    
        
        .. code-block:: csharp
    
            public List<WriteContext> Writes { get; set; }
    

