

ScopeNode Class
===============



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Diagnostics.Elm.ScopeNode`








Syntax
------

.. code-block:: csharp

   public class ScopeNode





GitHub
------

`View on GitHub <https://github.com/aspnet/diagnostics/blob/master/src/Microsoft.AspNet.Diagnostics.Elm/ScopeNode.cs>`_





.. dn:class:: Microsoft.AspNet.Diagnostics.Elm.ScopeNode

Properties
----------

.. dn:class:: Microsoft.AspNet.Diagnostics.Elm.ScopeNode
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Elm.ScopeNode.Children
    
        
        :rtype: System.Collections.Generic.List{Microsoft.AspNet.Diagnostics.Elm.ScopeNode}
    
        
        .. code-block:: csharp
    
           public List<ScopeNode> Children { get; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Elm.ScopeNode.EndTime
    
        
        :rtype: System.DateTimeOffset
    
        
        .. code-block:: csharp
    
           public DateTimeOffset EndTime { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Elm.ScopeNode.Messages
    
        
        :rtype: System.Collections.Generic.List{Microsoft.AspNet.Diagnostics.Elm.LogInfo}
    
        
        .. code-block:: csharp
    
           public List<LogInfo> Messages { get; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Elm.ScopeNode.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Name { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Elm.ScopeNode.Parent
    
        
        :rtype: Microsoft.AspNet.Diagnostics.Elm.ScopeNode
    
        
        .. code-block:: csharp
    
           public ScopeNode Parent { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Elm.ScopeNode.StartTime
    
        
        :rtype: System.DateTimeOffset
    
        
        .. code-block:: csharp
    
           public DateTimeOffset StartTime { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Elm.ScopeNode.State
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public object State { get; set; }
    

