

LiteralPathSegment Class
========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments.LiteralPathSegment`








Syntax
------

.. code-block:: csharp

   public class LiteralPathSegment : IPathSegment





GitHub
------

`View on GitHub <https://github.com/aspnet/filesystem/blob/master/src/Microsoft.Extensions.FileSystemGlobbing/Internal/PathSegments/LiteralPathSegment.cs>`_





.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments.LiteralPathSegment

Constructors
------------

.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments.LiteralPathSegment
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments.LiteralPathSegment.LiteralPathSegment(System.String, System.StringComparison)
    
        
        
        
        :type value: System.String
        
        
        :type comparisonType: System.StringComparison
    
        
        .. code-block:: csharp
    
           public LiteralPathSegment(string value, StringComparison comparisonType)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments.LiteralPathSegment
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments.LiteralPathSegment.Equals(System.Object)
    
        
        
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments.LiteralPathSegment.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int GetHashCode()
    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments.LiteralPathSegment.Match(System.String)
    
        
        
        
        :type value: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Match(string value)
    

Properties
----------

.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments.LiteralPathSegment
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments.LiteralPathSegment.CanProduceStem
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool CanProduceStem { get; }
    
    .. dn:property:: Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments.LiteralPathSegment.Value
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Value { get; }
    

