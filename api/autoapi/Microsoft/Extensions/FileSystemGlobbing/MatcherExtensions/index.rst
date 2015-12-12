

MatcherExtensions Class
=======================



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





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/filesystem/src/Microsoft.Extensions.FileSystemGlobbing/MatcherExtensions.cs>`_





.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.MatcherExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.MatcherExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.MatcherExtensions.AddExcludePatterns(Microsoft.Extensions.FileSystemGlobbing.Matcher, System.Collections.Generic.IEnumerable<System.String>[])
    
        
        
        
        :type matcher: Microsoft.Extensions.FileSystemGlobbing.Matcher
        
        
        :type excludePatternsGroups: System.Collections.Generic.IEnumerable{System.String}[]
    
        
        .. code-block:: csharp
    
           public static void AddExcludePatterns(Matcher matcher, params IEnumerable<string>[] excludePatternsGroups)
    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.MatcherExtensions.AddIncludePatterns(Microsoft.Extensions.FileSystemGlobbing.Matcher, System.Collections.Generic.IEnumerable<System.String>[])
    
        
        
        
        :type matcher: Microsoft.Extensions.FileSystemGlobbing.Matcher
        
        
        :type includePatternsGroups: System.Collections.Generic.IEnumerable{System.String}[]
    
        
        .. code-block:: csharp
    
           public static void AddIncludePatterns(Matcher matcher, params IEnumerable<string>[] includePatternsGroups)
    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.MatcherExtensions.GetResultsInFullPath(Microsoft.Extensions.FileSystemGlobbing.Matcher, System.String)
    
        
        
        
        :type matcher: Microsoft.Extensions.FileSystemGlobbing.Matcher
        
        
        :type directoryPath: System.String
        :rtype: System.Collections.Generic.IEnumerable{System.String}
    
        
        .. code-block:: csharp
    
           public static IEnumerable<string> GetResultsInFullPath(Matcher matcher, string directoryPath)
    

