

InjectChunk Class
=================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Chunks.Chunk`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.InjectChunk`








Syntax
------

.. code-block:: csharp

   public class InjectChunk : Chunk





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Razor.Host/InjectChunk.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.InjectChunk

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.InjectChunk
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Razor.InjectChunk.InjectChunk(System.String, System.String)
    
        
    
        Represents the chunk for an @inject statement.
    
        
        
        
        :param typeName: The type name of the property to be injected
        
        :type typeName: System.String
        
        
        :param propertyName: The member name of the property to be injected.
        
        :type propertyName: System.String
    
        
        .. code-block:: csharp
    
           public InjectChunk(string typeName, string propertyName)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.InjectChunk
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.InjectChunk.MemberName
    
        
    
        Gets or sets the name of the property to be injected.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string MemberName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.InjectChunk.TypeName
    
        
    
        Gets or sets the type name of the property to be injected.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string TypeName { get; set; }
    

