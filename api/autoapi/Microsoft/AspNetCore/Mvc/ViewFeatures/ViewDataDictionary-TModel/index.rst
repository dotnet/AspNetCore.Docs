

ViewDataDictionary<TModel> Class
================================





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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary\<TModel>`








Syntax
------

.. code-block:: csharp

    public class ViewDataDictionary<TModel> : ViewDataDictionary, IDictionary<string, object>, ICollection<KeyValuePair<string, object>>, IEnumerable<KeyValuePair<string, object>>, IEnumerable








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary`1
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<TModel>

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<TModel>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<TModel>.ViewDataDictionary(Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider, Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary\`1` class.
    
        
    
        
        :type metadataProvider: Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider
    
        
        :type modelState: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary
    
        
        .. code-block:: csharp
    
            public ViewDataDictionary(IModelMetadataProvider metadataProvider, ModelStateDictionary modelState)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<TModel>.ViewDataDictionary(Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary\`1` class based in part on an
        existing :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary` instance.
    
        
    
        
        :type source: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary
    
        
        .. code-block:: csharp
    
            public ViewDataDictionary(ViewDataDictionary source)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<TModel>.ViewDataDictionary(Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary, System.Object)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary\`1` class based in part on an
        existing :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary` instance. This constructor is careful to avoid exceptions 
        :dn:meth:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary.SetModel(System.Object)` may throw when <em>model</em> is <code>null</code>.
    
        
    
        
        :type source: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary
    
        
        :type model: System.Object
    
        
        .. code-block:: csharp
    
            public ViewDataDictionary(ViewDataDictionary source, object model)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<TModel>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<TModel>.Model
    
        
        :rtype: TModel
    
        
        .. code-block:: csharp
    
            public TModel Model { get; set; }
    

