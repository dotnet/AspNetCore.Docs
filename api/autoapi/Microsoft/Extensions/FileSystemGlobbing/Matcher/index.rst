

Matcher Class
=============





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
* :dn:cls:`Microsoft.Extensions.FileSystemGlobbing.Matcher`








Syntax
------

.. code-block:: csharp

    public class Matcher








.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.Matcher
    :hidden:

.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.Matcher

Constructors
------------

.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.Matcher
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.FileSystemGlobbing.Matcher.Matcher()
    
        
    
        
        .. code-block:: csharp
    
            public Matcher()
    
    .. dn:constructor:: Microsoft.Extensions.FileSystemGlobbing.Matcher.Matcher(System.StringComparison)
    
        
    
        
        :type comparisonType: System.StringComparison
    
        
        .. code-block:: csharp
    
            public Matcher(StringComparison comparisonType)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.Matcher
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.Matcher.AddExclude(System.String)
    
        
    
        
        :type pattern: System.String
        :rtype: Microsoft.Extensions.FileSystemGlobbing.Matcher
    
        
        .. code-block:: csharp
    
            public virtual Matcher AddExclude(string pattern)
    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.Matcher.AddInclude(System.String)
    
        
    
        
        :type pattern: System.String
        :rtype: Microsoft.Extensions.FileSystemGlobbing.Matcher
    
        
        .. code-block:: csharp
    
            public virtual Matcher AddInclude(string pattern)
    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.Matcher.Execute(Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoBase)
    
        
    
        
        :type directoryInfo: Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoBase
        :rtype: Microsoft.Extensions.FileSystemGlobbing.PatternMatchingResult
    
        
        .. code-block:: csharp
    
            public virtual PatternMatchingResult Execute(DirectoryInfoBase directoryInfo)
    

