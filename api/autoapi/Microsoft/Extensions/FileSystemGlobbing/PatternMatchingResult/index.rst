

PatternMatchingResult Class
===========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.FileSystemGlobbing.PatternMatchingResult`








Syntax
------

.. code-block:: csharp

   public class PatternMatchingResult





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/filesystem/src/Microsoft.Extensions.FileSystemGlobbing/PatternMatchingResult.cs>`_





.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.PatternMatchingResult

Constructors
------------

.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.PatternMatchingResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.FileSystemGlobbing.PatternMatchingResult.PatternMatchingResult(System.Collections.Generic.IEnumerable<Microsoft.Extensions.FileSystemGlobbing.FilePatternMatch>)
    
        
        
        
        :type files: System.Collections.Generic.IEnumerable{Microsoft.Extensions.FileSystemGlobbing.FilePatternMatch}
    
        
        .. code-block:: csharp
    
           public PatternMatchingResult(IEnumerable<FilePatternMatch> files)
    

Properties
----------

.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.PatternMatchingResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.FileSystemGlobbing.PatternMatchingResult.Files
    
        
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.Extensions.FileSystemGlobbing.FilePatternMatch}
    
        
        .. code-block:: csharp
    
           public IEnumerable<FilePatternMatch> Files { get; set; }
    

