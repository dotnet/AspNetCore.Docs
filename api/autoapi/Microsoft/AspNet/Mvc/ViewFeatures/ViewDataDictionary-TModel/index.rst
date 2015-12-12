

ViewDataDictionary<TModel> Class
================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary`
* :dn:cls:`Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary\<TModel>`








Syntax
------

.. code-block:: csharp

   public class ViewDataDictionary<TModel> : ViewDataDictionary, IDictionary<string, object>, ICollection<KeyValuePair<string, object>>, IEnumerable<KeyValuePair<string, object>>, IEnumerable





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewFeatures/ViewDataDictionaryOfT.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary<TModel>

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary<TModel>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary<TModel>.ViewDataDictionary(Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider, Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary\`1` class.
    
        
        
        
        :type metadataProvider: Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider
        
        
        :type modelState: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary
    
        
        .. code-block:: csharp
    
           public ViewDataDictionary(IModelMetadataProvider metadataProvider, ModelStateDictionary modelState)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary<TModel>.ViewDataDictionary(Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary\`1` class based in part on an
        existing :any:`Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary` instance.
    
        
        
        
        :type source: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary
    
        
        .. code-block:: csharp
    
           public ViewDataDictionary(ViewDataDictionary source)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary<TModel>.ViewDataDictionary(Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary, System.Object)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary\`1` class based in part on an
        existing :any:`Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary` instance. This constructor is careful to avoid exceptions 
        :dn:meth:`Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary.SetModel(System.Object)` may throw when ``model`` is <c>null</c>.
    
        
        
        
        :type source: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary
        
        
        :type model: System.Object
    
        
        .. code-block:: csharp
    
           public ViewDataDictionary(ViewDataDictionary source, object model)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary<TModel>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary<TModel>.Model
    
        
        :rtype: {TModel}
    
        
        .. code-block:: csharp
    
           public TModel Model { get; set; }
    

