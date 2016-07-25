

OutboundMatchResult Struct
==========================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Routing.Internal`
Assemblies
    * Microsoft.AspNetCore.Routing

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public struct OutboundMatchResult








.. dn:structure:: Microsoft.AspNetCore.Routing.Internal.OutboundMatchResult
    :hidden:

.. dn:structure:: Microsoft.AspNetCore.Routing.Internal.OutboundMatchResult

Constructors
------------

.. dn:structure:: Microsoft.AspNetCore.Routing.Internal.OutboundMatchResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Routing.Internal.OutboundMatchResult.OutboundMatchResult(Microsoft.AspNetCore.Routing.Tree.OutboundMatch, System.Boolean)
    
        
    
        
        :type match: Microsoft.AspNetCore.Routing.Tree.OutboundMatch
    
        
        :type isFallbackMatch: System.Boolean
    
        
        .. code-block:: csharp
    
            public OutboundMatchResult(OutboundMatch match, bool isFallbackMatch)
    

Properties
----------

.. dn:structure:: Microsoft.AspNetCore.Routing.Internal.OutboundMatchResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Routing.Internal.OutboundMatchResult.IsFallbackMatch
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsFallbackMatch { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Internal.OutboundMatchResult.Match
    
        
        :rtype: Microsoft.AspNetCore.Routing.Tree.OutboundMatch
    
        
        .. code-block:: csharp
    
            public OutboundMatch Match { get; }
    

