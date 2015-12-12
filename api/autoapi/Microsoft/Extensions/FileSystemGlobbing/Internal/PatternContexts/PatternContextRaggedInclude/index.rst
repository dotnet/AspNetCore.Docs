

PatternContextRaggedInclude Class
=================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContext{Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextRagged.FrameData}`
* :dn:cls:`Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextRagged`
* :dn:cls:`Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextRaggedInclude`








Syntax
------

.. code-block:: csharp

   public class PatternContextRaggedInclude : PatternContextRagged, IPatternContext





GitHub
------

`View on GitHub <https://github.com/aspnet/filesystem/blob/master/src/Microsoft.Extensions.FileSystemGlobbing/Internal/PatternContexts/PatternContextRaggedInclude.cs>`_





.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextRaggedInclude

Constructors
------------

.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextRaggedInclude
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextRaggedInclude.PatternContextRaggedInclude(Microsoft.Extensions.FileSystemGlobbing.Internal.IRaggedPattern)
    
        
        
        
        :type pattern: Microsoft.Extensions.FileSystemGlobbing.Internal.IRaggedPattern
    
        
        .. code-block:: csharp
    
           public PatternContextRaggedInclude(IRaggedPattern pattern)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextRaggedInclude
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextRaggedInclude.Declare(System.Action<Microsoft.Extensions.FileSystemGlobbing.Internal.IPathSegment, System.Boolean>)
    
        
        
        
        :type onDeclare: System.Action{Microsoft.Extensions.FileSystemGlobbing.Internal.IPathSegment,System.Boolean}
    
        
        .. code-block:: csharp
    
           public override void Declare(Action<IPathSegment, bool> onDeclare)
    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextRaggedInclude.Test(Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoBase)
    
        
        
        
        :type directory: Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoBase
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool Test(DirectoryInfoBase directory)
    

