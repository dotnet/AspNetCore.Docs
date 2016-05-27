

ArrayModelBinder<TElement> Class
================================






:any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder` implementation for binding array values.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.Binders.CollectionModelBinder{{TElement}}`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.Binders.ArrayModelBinder\<TElement>`








Syntax
------

.. code-block:: csharp

    public class ArrayModelBinder<TElement> : CollectionModelBinder<TElement>, ICollectionModelBinder, IModelBinder








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.ArrayModelBinder`1
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.ArrayModelBinder<TElement>

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.ArrayModelBinder<TElement>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.ArrayModelBinder<TElement>.ArrayModelBinder(Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Binders.ArrayModelBinder\`1`\.
    
        
    
        
        :param elementBinder: 
            The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder` for binding <em>TElement</em>.
        
        :type elementBinder: Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder
    
        
        .. code-block:: csharp
    
            public ArrayModelBinder(IModelBinder elementBinder)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.ArrayModelBinder<TElement>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.ArrayModelBinder<TElement>.CanCreateInstance(System.Type)
    
        
    
        
        :type targetType: System.Type
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool CanCreateInstance(Type targetType)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.ArrayModelBinder<TElement>.ConvertToCollectionType(System.Type, System.Collections.Generic.IEnumerable<TElement>)
    
        
    
        
        :type targetType: System.Type
    
        
        :type collection: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{TElement}
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            protected override object ConvertToCollectionType(Type targetType, IEnumerable<TElement> collection)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.ArrayModelBinder<TElement>.CopyToModel(System.Object, System.Collections.Generic.IEnumerable<TElement>)
    
        
    
        
        :type target: System.Object
    
        
        :type sourceCollection: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{TElement}
    
        
        .. code-block:: csharp
    
            protected override void CopyToModel(object target, IEnumerable<TElement> sourceCollection)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.ArrayModelBinder<TElement>.CreateEmptyCollection(System.Type)
    
        
    
        
        :type targetType: System.Type
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            protected override object CreateEmptyCollection(Type targetType)
    

