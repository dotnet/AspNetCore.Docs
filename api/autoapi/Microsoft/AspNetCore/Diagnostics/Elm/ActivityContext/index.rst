

ActivityContext Class
=====================





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
* :dn:cls:`Microsoft.AspNetCore.Diagnostics.Elm.ActivityContext`








Syntax
------

.. code-block:: csharp

    public class ActivityContext








.. dn:class:: Microsoft.AspNetCore.Diagnostics.Elm.ActivityContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Diagnostics.Elm.ActivityContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.Elm.ActivityContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.Elm.ActivityContext.HttpInfo
    
        
        :rtype: Microsoft.AspNetCore.Diagnostics.Elm.HttpInfo
    
        
        .. code-block:: csharp
    
            public HttpInfo HttpInfo
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.Elm.ActivityContext.Id
    
        
        :rtype: System.Guid
    
        
        .. code-block:: csharp
    
            public Guid Id
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.Elm.ActivityContext.IsCollapsed
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsCollapsed
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.Elm.ActivityContext.RepresentsScope
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool RepresentsScope
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.Elm.ActivityContext.Root
    
        
        :rtype: Microsoft.AspNetCore.Diagnostics.Elm.ScopeNode
    
        
        .. code-block:: csharp
    
            public ScopeNode Root
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.Elm.ActivityContext.Time
    
        
        :rtype: System.DateTimeOffset
    
        
        .. code-block:: csharp
    
            public DateTimeOffset Time
            {
                get;
                set;
            }
    

