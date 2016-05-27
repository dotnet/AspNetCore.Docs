

ModelChunk Class
================






:any:`Microsoft.AspNetCore.Razor.Chunks.Chunk` for an <code>@model</code> directive.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Razor.ModelChunk`








Syntax
------

.. code-block:: csharp

    public class ModelChunk : Chunk








.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.ModelChunk
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.ModelChunk

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.ModelChunk
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.ModelChunk.ModelType
    
        
    
        
        Gets the type of the view's model.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ModelType
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.ModelChunk
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.ModelChunk.ModelChunk(System.String)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.Razor.ModelChunk`\.
    
        
    
        
        :param modelType: The type of the view's model.
        
        :type modelType: System.String
    
        
        .. code-block:: csharp
    
            public ModelChunk(string modelType)
    

