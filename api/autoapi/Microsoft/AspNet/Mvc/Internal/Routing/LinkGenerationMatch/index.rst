

LinkGenerationMatch Struct
==========================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public struct LinkGenerationMatch





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/Internal/Routing/LinkGenerationMatch.cs>`_





.. dn:structure:: Microsoft.AspNet.Mvc.Internal.Routing.LinkGenerationMatch

Constructors
------------

.. dn:structure:: Microsoft.AspNet.Mvc.Internal.Routing.LinkGenerationMatch
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Internal.Routing.LinkGenerationMatch.LinkGenerationMatch(Microsoft.AspNet.Mvc.Routing.AttributeRouteLinkGenerationEntry, System.Boolean)
    
        
        
        
        :type entry: Microsoft.AspNet.Mvc.Routing.AttributeRouteLinkGenerationEntry
        
        
        :type isFallbackMatch: System.Boolean
    
        
        .. code-block:: csharp
    
           public LinkGenerationMatch(AttributeRouteLinkGenerationEntry entry, bool isFallbackMatch)
    

Properties
----------

.. dn:structure:: Microsoft.AspNet.Mvc.Internal.Routing.LinkGenerationMatch
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Internal.Routing.LinkGenerationMatch.Entry
    
        
        :rtype: Microsoft.AspNet.Mvc.Routing.AttributeRouteLinkGenerationEntry
    
        
        .. code-block:: csharp
    
           public AttributeRouteLinkGenerationEntry Entry { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Internal.Routing.LinkGenerationMatch.IsFallbackMatch
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsFallbackMatch { get; }
    

