

MatcherExtensions Class
=======================





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
* :dn:cls:`Microsoft.Extensions.FileSystemGlobbing.MatcherExtensions`








Syntax
------

.. code-block:: csharp

    public class MatcherExtensions








.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.MatcherExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.MatcherExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.MatcherExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.MatcherExtensions.AddExcludePatterns(Microsoft.Extensions.FileSystemGlobbing.Matcher, System.Collections.Generic.IEnumerable<System.String>[])
    
        
    
        
        :type matcher: Microsoft.Extensions.FileSystemGlobbing.Matcher
    
        
        :type excludePatternsGroups: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}[]
    
        
        .. code-block:: csharp
    
            public static void AddExcludePatterns(this Matcher matcher, params IEnumerable<string>[] excludePatternsGroups)
    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.MatcherExtensions.AddIncludePatterns(Microsoft.Extensions.FileSystemGlobbing.Matcher, System.Collections.Generic.IEnumerable<System.String>[])
    
        
    
        
        :type matcher: Microsoft.Extensions.FileSystemGlobbing.Matcher
    
        
        :type includePatternsGroups: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}[]
    
        
        .. code-block:: csharp
    
            public static void AddIncludePatterns(this Matcher matcher, params IEnumerable<string>[] includePatternsGroups)
    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.MatcherExtensions.GetResultsInFullPath(Microsoft.Extensions.FileSystemGlobbing.Matcher, System.String)
    
        
    
        
        :type matcher: Microsoft.Extensions.FileSystemGlobbing.Matcher
    
        
        :type directoryPath: System.String
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public static IEnumerable<string> GetResultsInFullPath(this Matcher matcher, string directoryPath)
    

