

LineMappingManager Class
========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.CodeGenerators.LineMappingManager`








Syntax
------

.. code-block:: csharp

   public class LineMappingManager





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/CodeGenerators/LineMappingManager.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.LineMappingManager

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.LineMappingManager
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.CodeGenerators.LineMappingManager.LineMappingManager()
    
        
    
        
        .. code-block:: csharp
    
           public LineMappingManager()
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.LineMappingManager
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.LineMappingManager.AddMapping(Microsoft.AspNet.Razor.CodeGenerators.MappingLocation, Microsoft.AspNet.Razor.CodeGenerators.MappingLocation)
    
        
        
        
        :type documentLocation: Microsoft.AspNet.Razor.CodeGenerators.MappingLocation
        
        
        :type generatedLocation: Microsoft.AspNet.Razor.CodeGenerators.MappingLocation
    
        
        .. code-block:: csharp
    
           public void AddMapping(MappingLocation documentLocation, MappingLocation generatedLocation)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.LineMappingManager
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.CodeGenerators.LineMappingManager.Mappings
    
        
        :rtype: System.Collections.Generic.List{Microsoft.AspNet.Razor.CodeGenerators.LineMapping}
    
        
        .. code-block:: csharp
    
           public List<LineMapping> Mappings { get; }
    

