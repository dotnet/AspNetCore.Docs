

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

    
    .. dn:constructor:: Microsoft.AspNetCore.Routing.Internal.LinkGenerationDecisionTree.LinkGenerationDecisionTree(System.Collections.Generic.IReadOnlyList<Microsoft.AspNetCore.Routing.Tree.TreeRouteLinkGenerationEntry>)
    
        
    
        
        :type entries: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Routing.Tree.TreeRouteLinkGenerationEntry<Microsoft.AspNetCore.Routing.Tree.TreeRouteLinkGenerationEntry>}
    
        
        .. code-block:: csharp
    
            public LinkGenerationDecisionTree(IReadOnlyList<TreeRouteLinkGenerationEntry> entries)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Routing.Internal.LinkGenerationDecisionTree
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Routing.Internal.LinkGenerationDecisionTree.GetMatches(Microsoft.AspNetCore.Routing.VirtualPathContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Routing.VirtualPathContext
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Routing.Internal.LinkGenerationMatch<Microsoft.AspNetCore.Routing.Internal.LinkGenerationMatch>}
    
        
        .. code-block:: csharp
    
            public IList<LinkGenerationMatch> GetMatches(VirtualPathContext context)
    

