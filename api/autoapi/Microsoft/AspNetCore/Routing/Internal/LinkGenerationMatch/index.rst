

LinkGenerationMatch Struct
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

    public struct LinkGenerationMatch








.. dn:structure:: Microsoft.AspNetCore.Routing.Internal.LinkGenerationMatch
    :hidden:

.. dn:structure:: Microsoft.AspNetCore.Routing.Internal.LinkGenerationMatch

Properties
----------

.. dn:structure:: Microsoft.AspNetCore.Routing.Internal.LinkGenerationMatch
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Routing.Internal.LinkGenerationMatch.Entry
    
        
        :rtype: Microsoft.AspNetCore.Routing.Tree.TreeRouteLinkGenerationEntry
    
        
        .. code-block:: csharp
    
            public TreeRouteLinkGenerationEntry Entry
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Internal.LinkGenerationMatch.IsFallbackMatch
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsFallbackMatch
            {
                get;
            }
    

Constructors
------------

.. dn:structure:: Microsoft.AspNetCore.Routing.Internal.LinkGenerationMatch
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Routing.Internal.LinkGenerationMatch.LinkGenerationMatch(Microsoft.AspNetCore.Routing.Tree.TreeRouteLinkGenerationEntry, System.Boolean)
    
        
    
        
        :type entry: Microsoft.AspNetCore.Routing.Tree.TreeRouteLinkGenerationEntry
    
        
        :type isFallbackMatch: System.Boolean
    
        
        .. code-block:: csharp
    
            public LinkGenerationMatch(TreeRouteLinkGenerationEntry entry, bool isFallbackMatch)
    

