

ModelExpression Class
=====================






Describes an :any:`System.Linq.Expressions.Expression` passed to a tag helper.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ViewFeatures`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExpression`








Syntax
------

.. code-block:: csharp

    public sealed class ModelExpression








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExpression
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExpression

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExpression
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExpression.ModelExpression(System.String, Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExpression` class.
    
        
    
        
        :param name: 
            String representation of the :any:`System.Linq.Expressions.Expression` of interest.
        
        :type name: System.String
    
        
        :param modelExplorer: 
            Includes the model and metadata about the :any:`System.Linq.Expressions.Expression` of interest.
        
        :type modelExplorer: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer
    
        
        .. code-block:: csharp
    
            public ModelExpression(string name, ModelExplorer modelExplorer)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExpression
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExpression.Metadata
    
        
    
        
        Metadata about the :any:`System.Linq.Expressions.Expression` of interest.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
    
        
        .. code-block:: csharp
    
            public ModelMetadata Metadata { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExpression.Model
    
        
    
        
        Gets the model object for the :any:`System.Linq.Expressions.Expression` of interest.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public object Model { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExpression.ModelExplorer
    
        
    
        
        Gets the model explorer for the :any:`System.Linq.Expressions.Expression` of interest.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer
    
        
        .. code-block:: csharp
    
            public ModelExplorer ModelExplorer { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExpression.Name
    
        
    
        
        String representation of the :any:`System.Linq.Expressions.Expression` of interest.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Name { get; }
    

