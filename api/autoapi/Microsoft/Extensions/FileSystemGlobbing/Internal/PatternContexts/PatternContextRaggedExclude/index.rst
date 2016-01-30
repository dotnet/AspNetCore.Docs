

PatternContextRaggedExclude Class
=================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContext{Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextRagged.FrameData}`
* :dn:cls:`Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextRagged`
* :dn:cls:`Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextRaggedExclude`








Syntax
------

.. code-block:: csharp

   public class PatternContextRaggedExclude : PatternContextRagged, IPatternContext





GitHub
------

`View on GitHub <https://github.com/aspnet/filesystem/blob/master/src/Microsoft.Extensions.FileSystemGlobbing/Internal/PatternContexts/PatternContextRaggedExclude.cs>`_





.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextRaggedExclude

Constructors
------------

.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextRaggedExclude
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextRaggedExclude.PatternContextRaggedExclude(Microsoft.Extensions.FileSystemGlobbing.Internal.IRaggedPattern)
    
        
        
        
        :type pattern: Microsoft.Extensions.FileSystemGlobbing.Internal.IRaggedPattern
    
        
        .. code-block:: csharp
    
           public PatternContextRaggedExclude(IRaggedPattern pattern)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextRaggedExclude
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContextRaggedExclude.Test(Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoBase)
    
        
        
        
        :type directory: Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoBase
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool Test(DirectoryInfoBase directory)
    

