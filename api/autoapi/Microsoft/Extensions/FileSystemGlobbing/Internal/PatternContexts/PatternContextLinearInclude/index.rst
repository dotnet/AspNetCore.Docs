

PatternContextLinearInclude Class
=================================





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
* :dn:cls:`Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextLinearInclude`








Syntax
------

.. code-block:: csharp

    public class PatternContextLinearInclude : PatternContextLinear, IPatternContext








.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextLinearInclude
    :hidden:

.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextLinearInclude

Constructors
------------

.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextLinearInclude
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextLinearInclude.PatternContextLinearInclude(Microsoft.Extensions.FileSystemGlobbing.Internal.ILinearPattern)
    
        
    
        
        :type pattern: Microsoft.Extensions.FileSystemGlobbing.Internal.ILinearPattern
    
        
        .. code-block:: csharp
    
            public PatternContextLinearInclude(ILinearPattern pattern)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextLinearInclude
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextLinearInclude.Declare(System.Action<Microsoft.Extensions.FileSystemGlobbing.Internal.IPathSegment, System.Boolean>)
    
        
    
        
        :type onDeclare: System.Action<System.Action`2>{Microsoft.Extensions.FileSystemGlobbing.Internal.IPathSegment<Microsoft.Extensions.FileSystemGlobbing.Internal.IPathSegment>, System.Boolean<System.Boolean>}
    
        
        .. code-block:: csharp
    
            public override void Declare(Action<IPathSegment, bool> onDeclare)
    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextLinearInclude.Test(Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoBase)
    
        
    
        
        :type directory: Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoBase
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool Test(DirectoryInfoBase directory)
    

