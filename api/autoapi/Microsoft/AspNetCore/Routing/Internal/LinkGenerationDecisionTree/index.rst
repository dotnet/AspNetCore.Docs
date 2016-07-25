

LinkGenerationDecisionTree Class
================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Routing.Internal`
Assemblies
    * Microsoft.AspNetCore.Routing

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Routing.Internal.LinkGenerationDecisionTree`








Syntax
------

.. code-block:: csharp

    public class LinkGenerationDecisionTree








.. dn:class:: Microsoft.AspNetCore.Routing.Internal.LinkGenerationDecisionTree
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Routing.Internal.LinkGenerationDecisionTree

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Routing.Internal.LinkGenerationDecisionTree
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Routing.Internal.LinkGenerationDecisionTree.LinkGenerationDecisionTree(System.Collections.Generic.IReadOnlyList<Microsoft.AspNetCore.Routing.Tree.OutboundMatch>)
    
        
    
        
        :type entries: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Routing.Tree.OutboundMatch<Microsoft.AspNetCore.Routing.Tree.OutboundMatch>}
    
        
        .. code-block:: csharp
    
            public LinkGenerationDecisionTree(IReadOnlyList<OutboundMatch> entries)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Routing.Internal.LinkGenerationDecisionTree
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Routing.Internal.LinkGenerationDecisionTree.GetMatches(Microsoft.AspNetCore.Routing.VirtualPathContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Routing.VirtualPathContext
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Routing.Internal.OutboundMatchResult<Microsoft.AspNetCore.Routing.Internal.OutboundMatchResult>}
    
        
        .. code-block:: csharp
    
            public IList<OutboundMatchResult> GetMatches(VirtualPathContext context)
    

