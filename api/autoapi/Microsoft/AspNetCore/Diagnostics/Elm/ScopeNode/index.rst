

ScopeNode Class
===============





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
* :dn:cls:`Microsoft.AspNetCore.Diagnostics.Elm.ScopeNode`








Syntax
------

.. code-block:: csharp

    public class ScopeNode








.. dn:class:: Microsoft.AspNetCore.Diagnostics.Elm.ScopeNode
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Diagnostics.Elm.ScopeNode

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.Elm.ScopeNode
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.Elm.ScopeNode.Children
    
        
        :rtype: System.Collections.Generic.List<System.Collections.Generic.List`1>{Microsoft.AspNetCore.Diagnostics.Elm.ScopeNode<Microsoft.AspNetCore.Diagnostics.Elm.ScopeNode>}
    
        
        .. code-block:: csharp
    
            public List<ScopeNode> Children
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.Elm.ScopeNode.EndTime
    
        
        :rtype: System.DateTimeOffset
    
        
        .. code-block:: csharp
    
            public DateTimeOffset EndTime
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.Elm.ScopeNode.Messages
    
        
        :rtype: System.Collections.Generic.List<System.Collections.Generic.List`1>{Microsoft.AspNetCore.Diagnostics.Elm.LogInfo<Microsoft.AspNetCore.Diagnostics.Elm.LogInfo>}
    
        
        .. code-block:: csharp
    
            public List<LogInfo> Messages
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.Elm.ScopeNode.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Name
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.Elm.ScopeNode.Parent
    
        
        :rtype: Microsoft.AspNetCore.Diagnostics.Elm.ScopeNode
    
        
        .. code-block:: csharp
    
            public ScopeNode Parent
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.Elm.ScopeNode.StartTime
    
        
        :rtype: System.DateTimeOffset
    
        
        .. code-block:: csharp
    
            public DateTimeOffset StartTime
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.Elm.ScopeNode.State
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public object State
            {
                get;
                set;
            }
    

