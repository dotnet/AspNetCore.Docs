

FilePatternMatch Struct
=======================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public struct FilePatternMatch : IEquatable<FilePatternMatch>





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/filesystem/src/Microsoft.Extensions.FileSystemGlobbing/FilePatternMatch.cs>`_





.. dn:structure:: Microsoft.Extensions.FileSystemGlobbing.FilePatternMatch

Constructors
------------

.. dn:structure:: Microsoft.Extensions.FileSystemGlobbing.FilePatternMatch
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.FileSystemGlobbing.FilePatternMatch.FilePatternMatch(System.String, System.String)
    
        
        
        
        :type path: System.String
        
        
        :type stem: System.String
    
        
        .. code-block:: csharp
    
           public FilePatternMatch(string path, string stem)
    

Methods
-------

.. dn:structure:: Microsoft.Extensions.FileSystemGlobbing.FilePatternMatch
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.FilePatternMatch.Equals(Microsoft.Extensions.FileSystemGlobbing.FilePatternMatch)
    
        
        
        
        :type other: Microsoft.Extensions.FileSystemGlobbing.FilePatternMatch
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Equals(FilePatternMatch other)
    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.FilePatternMatch.Equals(System.Object)
    
        
        
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.FilePatternMatch.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int GetHashCode()
    

Properties
----------

.. dn:structure:: Microsoft.Extensions.FileSystemGlobbing.FilePatternMatch
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.FileSystemGlobbing.FilePatternMatch.Path
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Path { get; }
    
    .. dn:property:: Microsoft.Extensions.FileSystemGlobbing.FilePatternMatch.Stem
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Stem { get; }
    

