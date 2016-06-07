

FrameData Struct
================





Namespace
    :dn:ns:`Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextRagged`
Assemblies
    * Microsoft.Extensions.FileSystemGlobbing

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public struct FrameData








.. dn:structure:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextRagged.FrameData
    :hidden:

.. dn:structure:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextRagged.FrameData

Properties
----------

.. dn:structure:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextRagged.FrameData
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextRagged.FrameData.Stem
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Stem
            {
                get;
            }
    
    .. dn:property:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextRagged.FrameData.StemItems
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IList<string> StemItems
            {
                get;
            }
    

Fields
------

.. dn:structure:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextRagged.FrameData
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextRagged.FrameData.BacktrackAvailable
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int BacktrackAvailable
    
    .. dn:field:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextRagged.FrameData.InStem
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool InStem
    
    .. dn:field:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextRagged.FrameData.IsNotApplicable
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsNotApplicable
    
    .. dn:field:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextRagged.FrameData.SegmentGroup
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.Extensions.FileSystemGlobbing.Internal.IPathSegment<Microsoft.Extensions.FileSystemGlobbing.Internal.IPathSegment>}
    
        
        .. code-block:: csharp
    
            public IList<IPathSegment> SegmentGroup
    
    .. dn:field:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextRagged.FrameData.SegmentGroupIndex
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int SegmentGroupIndex
    
    .. dn:field:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextRagged.FrameData.SegmentIndex
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int SegmentIndex
    

