

ElmScope Class
==============





Namespace
    :dn:ns:`Microsoft.AspNetCore.Diagnostics.Elm`
Assemblies
    * Microsoft.AspNetCore.Diagnostics.Elm

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Diagnostics.Elm.ElmScope`








Syntax
------

.. code-block:: csharp

    public class ElmScope








.. dn:class:: Microsoft.AspNetCore.Diagnostics.Elm.ElmScope
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Diagnostics.Elm.ElmScope

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.Elm.ElmScope
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Diagnostics.Elm.ElmScope.ElmScope(System.String, System.Object)
    
        
    
        
        :type name: System.String
    
        
        :type state: System.Object
    
        
        .. code-block:: csharp
    
            public ElmScope(string name, object state)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.Elm.ElmScope
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.Elm.ElmScope.Context
    
        
        :rtype: Microsoft.AspNetCore.Diagnostics.Elm.ActivityContext
    
        
        .. code-block:: csharp
    
            public ActivityContext Context { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.Elm.ElmScope.Current
    
        
        :rtype: Microsoft.AspNetCore.Diagnostics.Elm.ElmScope
    
        
        .. code-block:: csharp
    
            public static ElmScope Current { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.Elm.ElmScope.Node
    
        
        :rtype: Microsoft.AspNetCore.Diagnostics.Elm.ScopeNode
    
        
        .. code-block:: csharp
    
            public ScopeNode Node { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.Elm.ElmScope.Parent
    
        
        :rtype: Microsoft.AspNetCore.Diagnostics.Elm.ElmScope
    
        
        .. code-block:: csharp
    
            public ElmScope Parent { get; set; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.Elm.ElmScope
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Diagnostics.Elm.ElmScope.Push(Microsoft.AspNetCore.Diagnostics.Elm.ElmScope, Microsoft.AspNetCore.Diagnostics.Elm.ElmStore)
    
        
    
        
        :type scope: Microsoft.AspNetCore.Diagnostics.Elm.ElmScope
    
        
        :type store: Microsoft.AspNetCore.Diagnostics.Elm.ElmStore
        :rtype: System.IDisposable
    
        
        .. code-block:: csharp
    
            public static IDisposable Push(ElmScope scope, ElmStore store)
    

