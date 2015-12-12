

ModelExplorer Class
===================



.. contents:: 
   :local:



Summary
-------

Associates a model object with it's corresponding :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer`








Syntax
------

.. code-block:: csharp

   public class ModelExplorer





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewFeatures/ModelExplorer.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer.ModelExplorer(Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider, Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata, System.Object)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer`\.
    
        
        
        
        :param metadataProvider: The .
        
        :type metadataProvider: Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider
        
        
        :param metadata: The .
        
        :type metadata: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata
        
        
        :param model: The model object. May be null.
        
        :type model: System.Object
    
        
        .. code-block:: csharp
    
           public ModelExplorer(IModelMetadataProvider metadataProvider, ModelMetadata metadata, object model)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer.ModelExplorer(Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider, Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer, Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata, System.Func<System.Object, System.Object>)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer`\.
    
        
        
        
        :param metadataProvider: The .
        
        :type metadataProvider: Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider
        
        
        :param container: The container .
        
        :type container: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
        
        
        :param metadata: The .
        
        :type metadata: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata
        
        
        :param modelAccessor: A model accessor function. May be null.
        
        :type modelAccessor: System.Func{System.Object,System.Object}
    
        
        .. code-block:: csharp
    
           public ModelExplorer(IModelMetadataProvider metadataProvider, ModelExplorer container, ModelMetadata metadata, Func<object, object> modelAccessor)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer.ModelExplorer(Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider, Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer, Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata, System.Object)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer`\.
    
        
        
        
        :param metadataProvider: The .
        
        :type metadataProvider: Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider
        
        
        :param container: The container .
        
        :type container: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
        
        
        :param metadata: The .
        
        :type metadata: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata
        
        
        :param model: The model object. May be null.
        
        :type model: System.Object
    
        
        .. code-block:: csharp
    
           public ModelExplorer(IModelMetadataProvider metadataProvider, ModelExplorer container, ModelMetadata metadata, object model)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer.GetExplorerForExpression(Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata, System.Func<System.Object, System.Object>)
    
        
    
        Gets a :any:`Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer` for the provided model value and model :any:`System.Type`\.
    
        
        
        
        :type metadata: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata
        
        
        :type modelAccessor: System.Func{System.Object,System.Object}
        :rtype: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
        :return: A <see cref="T:Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer" />.
    
        
        .. code-block:: csharp
    
           public ModelExplorer GetExplorerForExpression(ModelMetadata metadata, Func<object, object> modelAccessor)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer.GetExplorerForExpression(Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata, System.Object)
    
        
    
        Gets a :any:`Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer` for the provided model value and model :any:`System.Type`\.
    
        
        
        
        :type metadata: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata
        
        
        :param model: The model value.
        
        :type model: System.Object
        :rtype: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
        :return: A <see cref="T:Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer" />.
    
        
        .. code-block:: csharp
    
           public ModelExplorer GetExplorerForExpression(ModelMetadata metadata, object model)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer.GetExplorerForExpression(System.Type, System.Func<System.Object, System.Object>)
    
        
    
        Gets a :any:`Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer` for the provided model value and model :any:`System.Type`\.
    
        
        
        
        :param modelType: The model .
        
        :type modelType: System.Type
        
        
        :type modelAccessor: System.Func{System.Object,System.Object}
        :rtype: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
        :return: A <see cref="T:Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer" />.
    
        
        .. code-block:: csharp
    
           public ModelExplorer GetExplorerForExpression(Type modelType, Func<object, object> modelAccessor)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer.GetExplorerForExpression(System.Type, System.Object)
    
        
    
        Gets a :any:`Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer` for the provided model value and model :any:`System.Type`\.
    
        
        
        
        :param modelType: The model .
        
        :type modelType: System.Type
        
        
        :param model: The model value.
        
        :type model: System.Object
        :rtype: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
        :return: A <see cref="T:Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer" />.
    
        
        .. code-block:: csharp
    
           public ModelExplorer GetExplorerForExpression(Type modelType, object model)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer.GetExplorerForModel(System.Object)
    
        
    
        Gets a :any:`Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer` for the given ``model`` value.
    
        
        
        
        :param model: The model value.
        
        :type model: System.Object
        :rtype: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
        :return: A <see cref="T:Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer" />.
    
        
        .. code-block:: csharp
    
           public ModelExplorer GetExplorerForModel(object model)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer.GetExplorerForProperty(System.String)
    
        
    
        Gets a :any:`Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer` for the property with given ``name``, or <c>null</c> if
        the property cannot be found.
    
        
        
        
        :param name: The property name.
        
        :type name: System.String
        :rtype: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
        :return: A <see cref="T:Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer" />, or <c>null</c>.
    
        
        .. code-block:: csharp
    
           public ModelExplorer GetExplorerForProperty(string name)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer.GetExplorerForProperty(System.String, System.Func<System.Object, System.Object>)
    
        
    
        Gets a :any:`Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer` for the property with given ``name``, or <c>null</c> if
        the property cannot be found.
    
        
        
        
        :param name: The property name.
        
        :type name: System.String
        
        
        :param modelAccessor: An accessor for the model value.
        
        :type modelAccessor: System.Func{System.Object,System.Object}
        :rtype: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
        :return: A <see cref="T:Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer" />, or <c>null</c>.
    
        
        .. code-block:: csharp
    
           public ModelExplorer GetExplorerForProperty(string name, Func<object, object> modelAccessor)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer.GetExplorerForProperty(System.String, System.Object)
    
        
    
        Gets a :any:`Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer` for the property with given ``name``, or <c>null</c> if
        the property cannot be found.
    
        
        
        
        :param name: The property name.
        
        :type name: System.String
        
        
        :param model: The model value.
        
        :type model: System.Object
        :rtype: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
        :return: A <see cref="T:Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer" />, or <c>null</c>.
    
        
        .. code-block:: csharp
    
           public ModelExplorer GetExplorerForProperty(string name, object model)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer.Container
    
        
    
        Gets the container :any:`Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
    
        
        .. code-block:: csharp
    
           public ModelExplorer Container { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer.Metadata
    
        
    
        Gets the :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata
    
        
        .. code-block:: csharp
    
           public ModelMetadata Metadata { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer.Model
    
        
    
        Gets the model object.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public object Model { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer.ModelType
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
           public Type ModelType { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer.Properties
    
        
    
        Gets the properties.
    
        
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer}
    
        
        .. code-block:: csharp
    
           public IEnumerable<ModelExplorer> Properties { get; }
    

