

ModelChunk Class
================



.. contents:: 
   :local:



Summary
-------

:any:`Microsoft.AspNet.Razor.Chunks.Chunk` for an <c>@model</c> directive.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Chunks.Chunk`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.ModelChunk`








Syntax
------

.. code-block:: csharp

   public class ModelChunk : Chunk





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Razor.Host/ModelChunk.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.ModelChunk

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.ModelChunk
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Razor.ModelChunk.ModelChunk(System.String)
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Mvc.Razor.ModelChunk`\.
    
        
        
        
        :param modelType: The type of the view's model.
        
        :type modelType: System.String
    
        
        .. code-block:: csharp
    
           public ModelChunk(string modelType)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.ModelChunk
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.ModelChunk.ModelType
    
        
    
        Gets the type of the view's model.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ModelType { get; }
    

