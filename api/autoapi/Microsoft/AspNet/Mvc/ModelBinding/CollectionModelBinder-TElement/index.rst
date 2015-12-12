

CollectionModelBinder<TElement> Class
=====================================



.. contents:: 
   :local:



Summary
-------

:any:`Microsoft.AspNet.Mvc.ModelBinding.IModelBinder` implementation for binding collection values.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.CollectionModelBinder\<TElement>`








Syntax
------

.. code-block:: csharp

   public class CollectionModelBinder<TElement> : ICollectionModelBinder, IModelBinder





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/ModelBinding/CollectionModelBinder.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.CollectionModelBinder<TElement>

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.CollectionModelBinder<TElement>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.CollectionModelBinder<TElement>.BindModelAsync(Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext)
    
        
        
        
        :type bindingContext: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Mvc.ModelBinding.ModelBindingResult}
    
        
        .. code-block:: csharp
    
           public virtual Task<ModelBindingResult> BindModelAsync(ModelBindingContext bindingContext)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.CollectionModelBinder<TElement>.CanCreateInstance(System.Type)
    
        
        
        
        :type targetType: System.Type
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public virtual bool CanCreateInstance(Type targetType)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.CollectionModelBinder<TElement>.ConvertToCollectionType(System.Type, System.Collections.Generic.IEnumerable<TElement>)
    
        
    
        Gets an :any:`System.Object` assignable to ``targetType`` that contains members from
        ``collection``.
    
        
        
        
        :param targetType: of the model.
        
        :type targetType: System.Type
        
        
        :param collection: Collection of values retrieved from value providers. Or null if nothing was bound.
        
        :type collection: System.Collections.Generic.IEnumerable{{TElement}}
        :rtype: System.Object
        :return: An <see cref="T:System.Object" /> assignable to <paramref name="targetType" />. Or <c>null</c> if nothing was bound.
    
        
        .. code-block:: csharp
    
           protected virtual object ConvertToCollectionType(Type targetType, IEnumerable<TElement> collection)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.CollectionModelBinder<TElement>.CopyToModel(System.Object, System.Collections.Generic.IEnumerable<TElement>)
    
        
    
        Adds values from ``sourceCollection`` to given ``target``.
    
        
        
        
        :param target: into which values are copied.
        
        :type target: System.Object
        
        
        :param sourceCollection: Collection of values retrieved from value providers. Or null if nothing was bound.
        
        :type sourceCollection: System.Collections.Generic.IEnumerable{{TElement}}
    
        
        .. code-block:: csharp
    
           protected virtual void CopyToModel(object target, IEnumerable<TElement> sourceCollection)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.CollectionModelBinder<TElement>.CreateEmptyCollection(System.Type)
    
        
    
        Create an :any:`System.Object` assignable to ``targetType``.
    
        
        
        
        :param targetType: of the model.
        
        :type targetType: System.Type
        :rtype: System.Object
        :return: An <see cref="T:System.Object" /> assignable to <paramref name="targetType" />.
    
        
        .. code-block:: csharp
    
           protected virtual object CreateEmptyCollection(Type targetType)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.CollectionModelBinder<TElement>.CreateInstance(System.Type)
    
        
    
        Create an instance of ``targetType``.
    
        
        
        
        :param targetType: of the model.
        
        :type targetType: System.Type
        :rtype: System.Object
        :return: An instance of <paramref name="targetType" />.
    
        
        .. code-block:: csharp
    
           protected object CreateInstance(Type targetType)
    

