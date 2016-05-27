

CollectionModelBinder<TElement> Class
=====================================






:any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder` implementation for binding collection values.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ModelBinding.Binders`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.Binders.CollectionModelBinder\<TElement>`








Syntax
------

.. code-block:: csharp

    public class CollectionModelBinder<TElement> : ICollectionModelBinder, IModelBinder








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.CollectionModelBinder`1
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.CollectionModelBinder<TElement>

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.CollectionModelBinder<TElement>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.CollectionModelBinder<TElement>.ElementBinder
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder` instances for binding collection elements.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder
    
        
        .. code-block:: csharp
    
            protected IModelBinder ElementBinder
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.CollectionModelBinder<TElement>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.CollectionModelBinder<TElement>.CollectionModelBinder(Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Binders.CollectionModelBinder\`1`\.
    
        
    
        
        :param elementBinder: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder` for binding elements.
        
        :type elementBinder: Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder
    
        
        .. code-block:: csharp
    
            public CollectionModelBinder(IModelBinder elementBinder)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.CollectionModelBinder<TElement>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.CollectionModelBinder<TElement>.BindModelAsync(Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext)
    
        
    
        
        :type bindingContext: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task BindModelAsync(ModelBindingContext bindingContext)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.CollectionModelBinder<TElement>.CanCreateInstance(System.Type)
    
        
    
        
        :type targetType: System.Type
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public virtual bool CanCreateInstance(Type targetType)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.CollectionModelBinder<TElement>.ConvertToCollectionType(System.Type, System.Collections.Generic.IEnumerable<TElement>)
    
        
    
        
        Gets an :any:`System.Object` assignable to <em>targetType</em> that contains members from
        <em>collection</em>.
    
        
    
        
        :param targetType: :any:`System.Type` of the model.
        
        :type targetType: System.Type
    
        
        :param collection: 
            Collection of values retrieved from value providers. Or <code>null</code> if nothing was bound.
        
        :type collection: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{TElement}
        :rtype: System.Object
        :return: 
            An :any:`System.Object` assignable to <em>targetType</em>. Or <code>null</code> if nothing was bound.
    
        
        .. code-block:: csharp
    
            protected virtual object ConvertToCollectionType(Type targetType, IEnumerable<TElement> collection)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.CollectionModelBinder<TElement>.CopyToModel(System.Object, System.Collections.Generic.IEnumerable<TElement>)
    
        
    
        
        Adds values from <em>sourceCollection</em> to given <em>target</em>.
    
        
    
        
        :param target: :any:`System.Object` into which values are copied.
        
        :type target: System.Object
    
        
        :param sourceCollection: 
            Collection of values retrieved from value providers. Or <code>null</code> if nothing was bound.
        
        :type sourceCollection: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{TElement}
    
        
        .. code-block:: csharp
    
            protected virtual void CopyToModel(object target, IEnumerable<TElement> sourceCollection)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.CollectionModelBinder<TElement>.CreateEmptyCollection(System.Type)
    
        
    
        
        Create an :any:`System.Object` assignable to <em>targetType</em>.
    
        
    
        
        :param targetType: :any:`System.Type` of the model.
        
        :type targetType: System.Type
        :rtype: System.Object
        :return: An :any:`System.Object` assignable to <em>targetType</em>.
    
        
        .. code-block:: csharp
    
            protected virtual object CreateEmptyCollection(Type targetType)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.CollectionModelBinder<TElement>.CreateInstance(System.Type)
    
        
    
        
        Create an instance of <em>targetType</em>.
    
        
    
        
        :param targetType: :any:`System.Type` of the model.
        
        :type targetType: System.Type
        :rtype: System.Object
        :return: An instance of <em>targetType</em>.
    
        
        .. code-block:: csharp
    
            protected object CreateInstance(Type targetType)
    

