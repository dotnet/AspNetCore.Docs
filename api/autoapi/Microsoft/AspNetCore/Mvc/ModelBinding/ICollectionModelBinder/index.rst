

ICollectionModelBinder Interface
================================






Interface for model binding collections.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ModelBinding`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface ICollectionModelBinder : IModelBinder








.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.ICollectionModelBinder
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.ICollectionModelBinder

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.ICollectionModelBinder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ICollectionModelBinder.CanCreateInstance(System.Type)
    
        
    
        
        Gets an indication whether or not this :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ICollectionModelBinder` implementation can create
        an :any:`System.Object` assignable to <em>targetType</em>.
    
        
    
        
        :param targetType: :any:`System.Type` of the model.
        
        :type targetType: System.Type
        :rtype: System.Boolean
        :return: 
            <code>true</code> if this :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ICollectionModelBinder` implementation can create an :any:`System.Object`
            assignable to <em>targetType</em>; <code>false</code> otherwise.
    
        
        .. code-block:: csharp
    
            bool CanCreateInstance(Type targetType)
    

