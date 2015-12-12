

MatcherContext Class
====================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.FileSystemGlobbing.Internal.MatcherContext`








Syntax
------

.. code-block:: csharp

   public class MatcherContext





GitHub
------

`View on GitHub <https://github.com/aspnet/filesystem/blob/master/src/Microsoft.Extensions.FileSystemGlobbing/Internal/MatcherContext.cs>`_





.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.Internal.MatcherContext

Constructors
------------

.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.Internal.MatcherContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.FileSystemGlobbing.Internal.MatcherContext.MatcherContext(System.Collections.Generic.IEnumerable<Microsoft.Extensions.FileSystemGlobbing.Internal.IPattern>, System.Collections.Generic.IEnumerable<Microsoft.Extensions.FileSystemGlobbing.Internal.IPattern>, Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoBase, System.StringComparison)
    
        
        
        
        :type includePatterns: System.Collections.Generic.IEnumerable{Microsoft.Extensions.FileSystemGlobbing.Internal.IPattern}
        
        
        :type excludePatterns: System.Collections.Generic.IEnumerable{Microsoft.Extensions.FileSystemGlobbing.Internal.IPattern}
        
        
        :type directoryInfo: Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoBase
        
        
        :type comparison: System.StringComparison
    
        
        .. code-block:: csharp
    
           public MatcherContext(IEnumerable<IPattern> includePatterns, IEnumerable<IPattern> excludePatterns, DirectoryInfoBase directoryInfo, StringComparison comparison)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.Internal.MatcherContext
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.Internal.MatcherContext.Execute()
    
        
        :rtype: Microsoft.Extensions.FileSystemGlobbing.PatternMatchingResult
    
        
        .. code-block:: csharp
    
           public PatternMatchingResult Execute()
    

