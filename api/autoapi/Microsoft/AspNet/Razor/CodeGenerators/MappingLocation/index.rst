

MappingLocation Class
=====================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.CodeGenerators.MappingLocation`








Syntax
------

.. code-block:: csharp

   public class MappingLocation





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/CodeGenerators/MappingLocation.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.MappingLocation

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.MappingLocation
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.CodeGenerators.MappingLocation.MappingLocation()
    
        
    
        
        .. code-block:: csharp
    
           public MappingLocation()
    
    .. dn:constructor:: Microsoft.AspNet.Razor.CodeGenerators.MappingLocation.MappingLocation(Microsoft.AspNet.Razor.SourceLocation, System.Int32)
    
        
        
        
        :type location: Microsoft.AspNet.Razor.SourceLocation
        
        
        :type contentLength: System.Int32
    
        
        .. code-block:: csharp
    
           public MappingLocation(SourceLocation location, int contentLength)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.MappingLocation
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.MappingLocation.Equals(System.Object)
    
        
        
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.MappingLocation.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int GetHashCode()
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.MappingLocation.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string ToString()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.MappingLocation
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.CodeGenerators.MappingLocation.AbsoluteIndex
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int AbsoluteIndex { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.CodeGenerators.MappingLocation.CharacterIndex
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int CharacterIndex { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.CodeGenerators.MappingLocation.ContentLength
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int ContentLength { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.CodeGenerators.MappingLocation.FilePath
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string FilePath { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.CodeGenerators.MappingLocation.LineIndex
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int LineIndex { get; }
    

