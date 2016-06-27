

PatternContextLinear Class
==========================





Namespace
    :dn:ns:`Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts`
Assemblies
    * Microsoft.Extensions.FileSystemGlobbing

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContext{Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextLinear.FrameData}`
* :dn:cls:`Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextLinear`








Syntax
------

.. code-block:: csharp

    public abstract class PatternContextLinear : PatternContext<PatternContextLinear.FrameData>, IPatternContext








.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextLinear
    :hidden:

.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextLinear

Constructors
------------

.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextLinear
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextLinear.PatternContextLinear(Microsoft.Extensions.FileSystemGlobbing.Internal.ILinearPattern)
    
        
    
        
        :type pattern: Microsoft.Extensions.FileSystemGlobbing.Internal.ILinearPattern
    
        
        .. code-block:: csharp
    
            public PatternContextLinear(ILinearPattern pattern)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextLinear
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextLinear.CalculateStem(Microsoft.Extensions.FileSystemGlobbing.Abstractions.FileInfoBase)
    
        
    
        
        :type matchedFile: Microsoft.Extensions.FileSystemGlobbing.Abstractions.FileInfoBase
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            protected string CalculateStem(FileInfoBase matchedFile)
    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextLinear.IsLastSegment()
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            protected bool IsLastSegment()
    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextLinear.PushDirectory(Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoBase)
    
        
    
        
        :type directory: Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoBase
    
        
        .. code-block:: csharp
    
            public override void PushDirectory(DirectoryInfoBase directory)
    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextLinear.Test(Microsoft.Extensions.FileSystemGlobbing.Abstractions.FileInfoBase)
    
        
    
        
        :type file: Microsoft.Extensions.FileSystemGlobbing.Abstractions.FileInfoBase
        :rtype: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternTestResult
    
        
        .. code-block:: csharp
    
            public override PatternTestResult Test(FileInfoBase file)
    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextLinear.TestMatchingSegment(System.String)
    
        
    
        
        :type value: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            protected bool TestMatchingSegment(string value)
    

Properties
----------

.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextLinear
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextLinear.Pattern
    
        
        :rtype: Microsoft.Extensions.FileSystemGlobbing.Internal.ILinearPattern
    
        
        .. code-block:: csharp
    
            protected ILinearPattern Pattern { get; }
    

