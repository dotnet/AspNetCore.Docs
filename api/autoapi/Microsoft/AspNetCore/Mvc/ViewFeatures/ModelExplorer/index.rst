

ModelExplorer Class
===================






Associates a model object with it's corresponding :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata`\.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer`








Syntax
------

.. code-block:: csharp

    [DebuggerDisplay("DeclaredType={Metadata.ModelType.Name} PropertyName={Metadata.PropertyName}")]
    public class ModelExplorer








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer.Container
    
        
    
        
        Gets the container :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer
    
        
        .. code-block:: csharp
    
            public ModelExplorer Container
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer.Metadata
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
    
        
        .. code-block:: csharp
    
            public ModelMetadata Metadata
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer.Model
    
        
    
        
        Gets the model object.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public object Model
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer.ModelType
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
            public Type ModelType
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer.Properties
    
        
    
        
        Gets the properties.
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer<Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer>}
    
        
        .. code-block:: csharp
    
            public IEnumerable<ModelExplorer> Properties
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer.ModelExplorer(Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider, Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata, System.Object)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer`\.
    
        
    
        
        :param metadataProvider: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider`\.
        
        :type metadataProvider: Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider
    
        
        :param metadata: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata`\.
        
        :type metadata: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
    
        
        :param model: The model object. May be <code>null</code>.
        
        :type model: System.Object
    
        
        .. code-block:: csharp
    
            public ModelExplorer(IModelMetadataProvider metadataProvider, ModelMetadata metadata, object model)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer.ModelExplorer(Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider, Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer, Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata, System.Func<System.Object, System.Object>)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer`\.
    
        
    
        
        :param metadataProvider: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider`\.
        
        :type metadataProvider: Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider
    
        
        :param container: The container :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer`\.
        
        :type container: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer
    
        
        :param metadata: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata`\.
        
        :type metadata: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
    
        
        :param modelAccessor: A model accessor function..
        
        :type modelAccessor: System.Func<System.Func`2>{System.Object<System.Object>, System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public ModelExplorer(IModelMetadataProvider metadataProvider, ModelExplorer container, ModelMetadata metadata, Func<object, object> modelAccessor)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer.ModelExplorer(Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider, Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer, Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata, System.Object)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer`\.
    
        
    
        
        :param metadataProvider: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider`\.
        
        :type metadataProvider: Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider
    
        
        :param container: The container :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer`\.
        
        :type container: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer
    
        
        :param metadata: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata`\.
        
        :type metadata: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
    
        
        :param model: The model object. May be <code>null</code>.
        
        :type model: System.Object
    
        
        .. code-block:: csharp
    
            public ModelExplorer(IModelMetadataProvider metadataProvider, ModelExplorer container, ModelMetadata metadata, object model)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer.GetExplorerForExpression(Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata, System.Func<System.Object, System.Object>)
    
        
    
        
        Gets a :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer` for the provided model value and model :any:`System.Type`\.
    
        
    
        
        :param metadata: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata` associated with the model.
        
        :type metadata: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
    
        
        :param modelAccessor: A model accessor function.
        
        :type modelAccessor: System.Func<System.Func`2>{System.Object<System.Object>, System.Object<System.Object>}
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer
        :return: A :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer`\.
    
        
        .. code-block:: csharp
    
            public ModelExplorer GetExplorerForExpression(ModelMetadata metadata, Func<object, object> modelAccessor)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer.GetExplorerForExpression(Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata, System.Object)
    
        
    
        
        Gets a :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer` for the provided model value and model :any:`System.Type`\.
    
        
    
        
        :param metadata: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata` associated with the model.
        
        :type metadata: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
    
        
        :param model: The model value.
        
        :type model: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer
        :return: A :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer`\.
    
        
        .. code-block:: csharp
    
            public ModelExplorer GetExplorerForExpression(ModelMetadata metadata, object model)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer.GetExplorerForExpression(System.Type, System.Func<System.Object, System.Object>)
    
        
    
        
        Gets a :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer` for the provided model value and model :any:`System.Type`\.
    
        
    
        
        :param modelType: The model :any:`System.Type`\.
        
        :type modelType: System.Type
    
        
        :param modelAccessor: A model accessor function.
        
        :type modelAccessor: System.Func<System.Func`2>{System.Object<System.Object>, System.Object<System.Object>}
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer
        :return: A :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer`\.
    
        
        .. code-block:: csharp
    
            public ModelExplorer GetExplorerForExpression(Type modelType, Func<object, object> modelAccessor)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer.GetExplorerForExpression(System.Type, System.Object)
    
        
    
        
        Gets a :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer` for the provided model value and model :any:`System.Type`\.
    
        
    
        
        :param modelType: The model :any:`System.Type`\.
        
        :type modelType: System.Type
    
        
        :param model: The model value.
        
        :type model: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer
        :return: A :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer`\.
    
        
        .. code-block:: csharp
    
            public ModelExplorer GetExplorerForExpression(Type modelType, object model)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer.GetExplorerForModel(System.Object)
    
        
    
        
        Gets a :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer` for the given <em>model</em> value.
    
        
    
        
        :param model: The model value.
        
        :type model: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer
        :return: A :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer`\.
    
        
        .. code-block:: csharp
    
            public ModelExplorer GetExplorerForModel(object model)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer.GetExplorerForProperty(System.String)
    
        
    
        
        Gets a :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer` for the property with given <em>name</em>, or <code>null</code> if
        the property cannot be found.
    
        
    
        
        :param name: The property name.
        
        :type name: System.String
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer
        :return: A :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer`\, or <code>null</code>.
    
        
        .. code-block:: csharp
    
            public ModelExplorer GetExplorerForProperty(string name)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer.GetExplorerForProperty(System.String, System.Func<System.Object, System.Object>)
    
        
    
        
        Gets a :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer` for the property with given <em>name</em>, or <code>null</code> if
        the property cannot be found.
    
        
    
        
        :param name: The property name.
        
        :type name: System.String
    
        
        :param modelAccessor: An accessor for the model value.
        
        :type modelAccessor: System.Func<System.Func`2>{System.Object<System.Object>, System.Object<System.Object>}
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer
        :return: A :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer`\, or <code>null</code>.
    
        
        .. code-block:: csharp
    
            public ModelExplorer GetExplorerForProperty(string name, Func<object, object> modelAccessor)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer.GetExplorerForProperty(System.String, System.Object)
    
        
    
        
        Gets a :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer` for the property with given <em>name</em>, or <code>null</code> if
        the property cannot be found.
    
        
    
        
        :param name: The property name.
        
        :type name: System.String
    
        
        :param model: The model value.
        
        :type model: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer
        :return: A :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer`\, or <code>null</code>.
    
        
        .. code-block:: csharp
    
            public ModelExplorer GetExplorerForProperty(string name, object model)
    

