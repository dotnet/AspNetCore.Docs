

MappingLocation Class
=====================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.CodeGenerators`
Assemblies
    * Microsoft.AspNetCore.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.CodeGenerators.MappingLocation`








Syntax
------

.. code-block:: csharp

    public class MappingLocation








.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.MappingLocation
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.MappingLocation

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.MappingLocation
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.CodeGenerators.MappingLocation.MappingLocation()
    
        
    
        
        .. code-block:: csharp
    
            public MappingLocation()
    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.CodeGenerators.MappingLocation.MappingLocation(Microsoft.AspNetCore.Razor.SourceLocation, System.Int32)
    
        
    
        
        :type location: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        :type contentLength: System.Int32
    
        
        .. code-block:: csharp
    
            public MappingLocation(SourceLocation location, int contentLength)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.MappingLocation
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.MappingLocation.AbsoluteIndex
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int AbsoluteIndex { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.MappingLocation.CharacterIndex
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int CharacterIndex { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.MappingLocation.ContentLength
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int ContentLength { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.MappingLocation.FilePath
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string FilePath { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.MappingLocation.LineIndex
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int LineIndex { get; }
    

Operators
---------

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.MappingLocation
    :noindex:
    :hidden:

    
    .. dn:operator:: Microsoft.AspNetCore.Razor.CodeGenerators.MappingLocation.Equality(Microsoft.AspNetCore.Razor.CodeGenerators.MappingLocation, Microsoft.AspNetCore.Razor.CodeGenerators.MappingLocation)
    
        
    
        
        :type left: Microsoft.AspNetCore.Razor.CodeGenerators.MappingLocation
    
        
        :type right: Microsoft.AspNetCore.Razor.CodeGenerators.MappingLocation
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public static bool operator ==(MappingLocation left, MappingLocation right)
    
    .. dn:operator:: Microsoft.AspNetCore.Razor.CodeGenerators.MappingLocation.Inequality(Microsoft.AspNetCore.Razor.CodeGenerators.MappingLocation, Microsoft.AspNetCore.Razor.CodeGenerators.MappingLocation)
    
        
    
        
        :type left: Microsoft.AspNetCore.Razor.CodeGenerators.MappingLocation
    
        
        :type right: Microsoft.AspNetCore.Razor.CodeGenerators.MappingLocation
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public static bool operator !=(MappingLocation left, MappingLocation right)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.MappingLocation
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.MappingLocation.Equals(System.Object)
    
        
    
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.MappingLocation.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int GetHashCode()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.MappingLocation.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string ToString()
    

