

InjectChunk Class
=================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Razor`
Assemblies
    * Microsoft.AspNetCore.Mvc.Razor.Host

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.Chunks.Chunk`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Razor.InjectChunk`








Syntax
------

.. code-block:: csharp

    public class InjectChunk : Chunk








.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.InjectChunk
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.InjectChunk

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.InjectChunk
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.InjectChunk.MemberName
    
        
    
        
        Gets or sets the name of the property to be injected.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string MemberName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.InjectChunk.TypeName
    
        
    
        
        Gets or sets the type name of the property to be injected.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string TypeName
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.InjectChunk
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.InjectChunk.InjectChunk(System.String, System.String)
    
        
    
        
        Represents the chunk for an @inject statement.
    
        
    
        
        :param typeName: The type name of the property to be injected
        
        :type typeName: System.String
    
        
        :param propertyName: The member name of the property to be injected.
        
        :type propertyName: System.String
    
        
        .. code-block:: csharp
    
            public InjectChunk(string typeName, string propertyName)
    

