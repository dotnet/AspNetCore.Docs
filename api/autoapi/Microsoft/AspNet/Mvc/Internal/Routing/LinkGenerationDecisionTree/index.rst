

LinkGenerationDecisionTree Class
================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Internal.Routing.LinkGenerationDecisionTree`








Syntax
------

.. code-block:: csharp

   public class LinkGenerationDecisionTree





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/Internal/Routing/LinkGenerationDecisionTree.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Internal.Routing.LinkGenerationDecisionTree

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Internal.Routing.LinkGenerationDecisionTree
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Internal.Routing.LinkGenerationDecisionTree.LinkGenerationDecisionTree(System.Collections.Generic.IReadOnlyList<Microsoft.AspNet.Mvc.Routing.AttributeRouteLinkGenerationEntry>)
    
        
        
        
        :type entries: System.Collections.Generic.IReadOnlyList{Microsoft.AspNet.Mvc.Routing.AttributeRouteLinkGenerationEntry}
    
        
        .. code-block:: csharp
    
           public LinkGenerationDecisionTree(IReadOnlyList<AttributeRouteLinkGenerationEntry> entries)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Internal.Routing.LinkGenerationDecisionTree
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Internal.Routing.LinkGenerationDecisionTree.GetMatches(Microsoft.AspNet.Routing.VirtualPathContext)
    
        
        
        
        :type context: Microsoft.AspNet.Routing.VirtualPathContext
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.Internal.Routing.LinkGenerationMatch}
    
        
        .. code-block:: csharp
    
           public IList<LinkGenerationMatch> GetMatches(VirtualPathContext context)
    

