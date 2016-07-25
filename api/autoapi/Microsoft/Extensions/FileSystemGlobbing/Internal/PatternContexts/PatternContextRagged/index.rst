

PatternContextRagged Class
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
* :dn:cls:`Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContext{Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextRagged.FrameData}`
* :dn:cls:`Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextRagged`








Syntax
------

.. code-block:: csharp

    public abstract class PatternContextRagged : PatternContext<PatternContextRagged.FrameData>, IPatternContext








.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextRagged
    :hidden:

.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextRagged

Constructors
------------

.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextRagged
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextRagged.PatternContextRagged(Microsoft.Extensions.FileSystemGlobbing.Internal.IRaggedPattern)
    
        
    
        
        :type pattern: Microsoft.Extensions.FileSystemGlobbing.Internal.IRaggedPattern
    
        
        .. code-block:: csharp
    
            public PatternContextRagged(IRaggedPattern pattern)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextRagged
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextRagged.CalculateStem(Microsoft.Extensions.FileSystemGlobbing.Abstractions.FileInfoBase)
    
        
    
        
        :type matchedFile: Microsoft.Extensions.FileSystemGlobbing.Abstractions.FileInfoBase
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            protected string CalculateStem(FileInfoBase matchedFile)
    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextRagged.IsEndingGroup()
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            protected bool IsEndingGroup()
    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextRagged.IsStartingGroup()
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            protected bool IsStartingGroup()
    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextRagged.PopDirectory()
    
        
    
        
        .. code-block:: csharp
    
            public override void PopDirectory()
    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextRagged.PushDirectory(Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoBase)
    
        
    
        
        :type directory: Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoBase
    
        
        .. code-block:: csharp
    
            public override sealed void PushDirectory(DirectoryInfoBase directory)
    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextRagged.Test(Microsoft.Extensions.FileSystemGlobbing.Abstractions.FileInfoBase)
    
        
    
        
        :type file: Microsoft.Extensions.FileSystemGlobbing.Abstractions.FileInfoBase
        :rtype: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternTestResult
    
        
        .. code-block:: csharp
    
            public override PatternTestResult Test(FileInfoBase file)
    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextRagged.TestMatchingGroup(Microsoft.Extensions.FileSystemGlobbing.Abstractions.FileSystemInfoBase)
    
        
    
        
        :type value: Microsoft.Extensions.FileSystemGlobbing.Abstractions.FileSystemInfoBase
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            protected bool TestMatchingGroup(FileSystemInfoBase value)
    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextRagged.TestMatchingSegment(System.String)
    
        
    
        
        :type value: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            protected bool TestMatchingSegment(string value)
    

Properties
----------

.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextRagged
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextRagged.Pattern
    
        
        :rtype: Microsoft.Extensions.FileSystemGlobbing.Internal.IRaggedPattern
    
        
        .. code-block:: csharp
    
            protected IRaggedPattern Pattern { get; }
    

