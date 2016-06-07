

PatternBuilder Class
====================





Namespace
    :dn:ns:`Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns`
Assemblies
    * Microsoft.Extensions.FileSystemGlobbing

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns.PatternBuilder`








Syntax
------

.. code-block:: csharp

    public class PatternBuilder








.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns.PatternBuilder
    :hidden:

.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns.PatternBuilder

Properties
----------

.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns.PatternBuilder
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns.PatternBuilder.ComparisonType
    
        
        :rtype: System.StringComparison
    
        
        .. code-block:: csharp
    
            public StringComparison ComparisonType
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns.PatternBuilder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns.PatternBuilder.PatternBuilder()
    
        
    
        
        .. code-block:: csharp
    
            public PatternBuilder()
    
    .. dn:constructor:: Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns.PatternBuilder.PatternBuilder(System.StringComparison)
    
        
    
        
        :type comparisonType: System.StringComparison
    
        
        .. code-block:: csharp
    
            public PatternBuilder(StringComparison comparisonType)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns.PatternBuilder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns.PatternBuilder.Build(System.String)
    
        
    
        
        :type pattern: System.String
        :rtype: Microsoft.Extensions.FileSystemGlobbing.Internal.IPattern
    
        
        .. code-block:: csharp
    
            public IPattern Build(string pattern)
    

