

LineMapping Class
=================





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
* :dn:cls:`Microsoft.AspNetCore.Razor.CodeGenerators.LineMapping`








Syntax
------

.. code-block:: csharp

    public class LineMapping








.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.LineMapping
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.LineMapping

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.LineMapping
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.CodeGenerators.LineMapping.LineMapping(Microsoft.AspNetCore.Razor.CodeGenerators.MappingLocation, Microsoft.AspNetCore.Razor.CodeGenerators.MappingLocation)
    
        
    
        
        :type documentLocation: Microsoft.AspNetCore.Razor.CodeGenerators.MappingLocation
    
        
        :type generatedLocation: Microsoft.AspNetCore.Razor.CodeGenerators.MappingLocation
    
        
        .. code-block:: csharp
    
            public LineMapping(MappingLocation documentLocation, MappingLocation generatedLocation)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.LineMapping
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.LineMapping.DocumentLocation
    
        
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.MappingLocation
    
        
        .. code-block:: csharp
    
            public MappingLocation DocumentLocation { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.LineMapping.GeneratedLocation
    
        
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.MappingLocation
    
        
        .. code-block:: csharp
    
            public MappingLocation GeneratedLocation { get; }
    

Operators
---------

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.LineMapping
    :noindex:
    :hidden:

    
    .. dn:operator:: Microsoft.AspNetCore.Razor.CodeGenerators.LineMapping.Equality(Microsoft.AspNetCore.Razor.CodeGenerators.LineMapping, Microsoft.AspNetCore.Razor.CodeGenerators.LineMapping)
    
        
    
        
        :type left: Microsoft.AspNetCore.Razor.CodeGenerators.LineMapping
    
        
        :type right: Microsoft.AspNetCore.Razor.CodeGenerators.LineMapping
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public static bool operator ==(LineMapping left, LineMapping right)
    
    .. dn:operator:: Microsoft.AspNetCore.Razor.CodeGenerators.LineMapping.Inequality(Microsoft.AspNetCore.Razor.CodeGenerators.LineMapping, Microsoft.AspNetCore.Razor.CodeGenerators.LineMapping)
    
        
    
        
        :type left: Microsoft.AspNetCore.Razor.CodeGenerators.LineMapping
    
        
        :type right: Microsoft.AspNetCore.Razor.CodeGenerators.LineMapping
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public static bool operator !=(LineMapping left, LineMapping right)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.LineMapping
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.LineMapping.Equals(System.Object)
    
        
    
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.LineMapping.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int GetHashCode()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.LineMapping.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string ToString()
    

