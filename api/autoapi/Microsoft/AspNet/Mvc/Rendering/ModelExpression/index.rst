

ModelExpression Class
=====================



.. contents:: 
   :local:



Summary
-------

Describes an :any:`System.Linq.Expressions.Expression` passed to a tag helper.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Rendering.ModelExpression`








Syntax
------

.. code-block:: csharp

   public sealed class ModelExpression





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewFeatures/ModelExpression.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Rendering.ModelExpression

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Rendering.ModelExpression
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Rendering.ModelExpression.ModelExpression(System.String, Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Mvc.Rendering.ModelExpression` class.
    
        
        
        
        :param name: String representation of the  of interest.
        
        :type name: System.String
        
        
        :param modelExplorer: Includes the model and metadata about the  of interest.
        
        :type modelExplorer: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
    
        
        .. code-block:: csharp
    
           public ModelExpression(string name, ModelExplorer modelExplorer)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Rendering.ModelExpression
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Rendering.ModelExpression.Metadata
    
        
    
        Metadata about the :any:`System.Linq.Expressions.Expression` of interest.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata
    
        
        .. code-block:: csharp
    
           public ModelMetadata Metadata { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Rendering.ModelExpression.Model
    
        
    
        Gets the model object for the :any:`System.Linq.Expressions.Expression` of interest.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public object Model { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Rendering.ModelExpression.ModelExplorer
    
        
    
        Gets the model explorer for the :any:`System.Linq.Expressions.Expression` of interest.
    
        
        :rtype: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
    
        
        .. code-block:: csharp
    
           public ModelExplorer ModelExplorer { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Rendering.ModelExpression.Name
    
        
    
        String representation of the :any:`System.Linq.Expressions.Expression` of interest.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Name { get; }
    

