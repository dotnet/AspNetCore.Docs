

ActivityContext Class
=====================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Diagnostics.Elm.ActivityContext`








Syntax
------

.. code-block:: csharp

   public class ActivityContext





GitHub
------

`View on GitHub <https://github.com/aspnet/diagnostics/blob/master/src/Microsoft.AspNet.Diagnostics.Elm/ActivityContext.cs>`_





.. dn:class:: Microsoft.AspNet.Diagnostics.Elm.ActivityContext

Properties
----------

.. dn:class:: Microsoft.AspNet.Diagnostics.Elm.ActivityContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Elm.ActivityContext.HttpInfo
    
        
        :rtype: Microsoft.AspNet.Diagnostics.Elm.HttpInfo
    
        
        .. code-block:: csharp
    
           public HttpInfo HttpInfo { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Elm.ActivityContext.Id
    
        
        :rtype: System.Guid
    
        
        .. code-block:: csharp
    
           public Guid Id { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Elm.ActivityContext.IsCollapsed
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsCollapsed { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Elm.ActivityContext.RepresentsScope
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool RepresentsScope { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Elm.ActivityContext.Root
    
        
        :rtype: Microsoft.AspNet.Diagnostics.Elm.ScopeNode
    
        
        .. code-block:: csharp
    
           public ScopeNode Root { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Elm.ActivityContext.Time
    
        
        :rtype: System.DateTimeOffset
    
        
        .. code-block:: csharp
    
           public DateTimeOffset Time { get; set; }
    

