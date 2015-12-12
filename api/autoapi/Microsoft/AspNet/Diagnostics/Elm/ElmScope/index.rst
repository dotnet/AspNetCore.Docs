

ElmScope Class
==============



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Diagnostics.Elm.ElmScope`








Syntax
------

.. code-block:: csharp

   public class ElmScope





GitHub
------

`View on GitHub <https://github.com/aspnet/diagnostics/blob/master/src/Microsoft.AspNet.Diagnostics.Elm/ElmScope.cs>`_





.. dn:class:: Microsoft.AspNet.Diagnostics.Elm.ElmScope

Constructors
------------

.. dn:class:: Microsoft.AspNet.Diagnostics.Elm.ElmScope
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Diagnostics.Elm.ElmScope.ElmScope(System.String, System.Object)
    
        
        
        
        :type name: System.String
        
        
        :type state: System.Object
    
        
        .. code-block:: csharp
    
           public ElmScope(string name, object state)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Diagnostics.Elm.ElmScope
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Diagnostics.Elm.ElmScope.Push(Microsoft.AspNet.Diagnostics.Elm.ElmScope, Microsoft.AspNet.Diagnostics.Elm.ElmStore)
    
        
        
        
        :type scope: Microsoft.AspNet.Diagnostics.Elm.ElmScope
        
        
        :type store: Microsoft.AspNet.Diagnostics.Elm.ElmStore
        :rtype: System.IDisposable
    
        
        .. code-block:: csharp
    
           public static IDisposable Push(ElmScope scope, ElmStore store)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Diagnostics.Elm.ElmScope
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Elm.ElmScope.Context
    
        
        :rtype: Microsoft.AspNet.Diagnostics.Elm.ActivityContext
    
        
        .. code-block:: csharp
    
           public ActivityContext Context { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Elm.ElmScope.Current
    
        
        :rtype: Microsoft.AspNet.Diagnostics.Elm.ElmScope
    
        
        .. code-block:: csharp
    
           public static ElmScope Current { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Elm.ElmScope.Node
    
        
        :rtype: Microsoft.AspNet.Diagnostics.Elm.ScopeNode
    
        
        .. code-block:: csharp
    
           public ScopeNode Node { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Elm.ElmScope.Parent
    
        
        :rtype: Microsoft.AspNet.Diagnostics.Elm.ElmScope
    
        
        .. code-block:: csharp
    
           public ElmScope Parent { get; set; }
    

