

PatternMatchingResult Class
===========================





Namespace
    :dn:ns:`Microsoft.Extensions.FileSystemGlobbing`
Assemblies
    * Microsoft.Extensions.FileSystemGlobbing

----

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








.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.PatternMatchingResult
    :hidden:

.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.PatternMatchingResult

Properties
----------

.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.PatternMatchingResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.FileSystemGlobbing.PatternMatchingResult.Files
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.Extensions.FileSystemGlobbing.FilePatternMatch<Microsoft.Extensions.FileSystemGlobbing.FilePatternMatch>}
    
        
        .. code-block:: csharp
    
            public IEnumerable<FilePatternMatch> Files
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.PatternMatchingResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.FileSystemGlobbing.PatternMatchingResult.PatternMatchingResult(System.Collections.Generic.IEnumerable<Microsoft.Extensions.FileSystemGlobbing.FilePatternMatch>)
    
        
    
        
        :type files: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.Extensions.FileSystemGlobbing.FilePatternMatch<Microsoft.Extensions.FileSystemGlobbing.FilePatternMatch>}
    
        
        .. code-block:: csharp
    
            public PatternMatchingResult(IEnumerable<FilePatternMatch> files)
    

