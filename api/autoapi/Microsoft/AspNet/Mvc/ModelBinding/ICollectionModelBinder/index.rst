

ICollectionModelBinder Interface
================================



.. contents:: 
   :local:



Summary
-------

Interface for model binding collections.











Syntax
------

.. code-block:: csharp

   public interface ICollectionModelBinder : IModelBinder





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/ModelBinding/ICollectionModelBinder.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.ModelBinding.ICollectionModelBinder

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.ModelBinding.ICollectionModelBinder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ICollectionModelBinder.CanCreateInstance(System.Type)
    
        
    
        Gets an indication whether or not this :any:`Microsoft.AspNet.Mvc.ModelBinding.ICollectionModelBinder` implementation can create
        an :any:`System.Object` assignable to ``targetType``.
    
        
        
        
        :param targetType: of the model.
        
        :type targetType: System.Type
        :rtype: System.Boolean
        :return: <c>true</c> if this <see cref="T:Microsoft.AspNet.Mvc.ModelBinding.ICollectionModelBinder" /> implementation can create an <see cref="T:System.Object" />
            assignable to <paramref name="targetType" />; <c>false</c> otherwise.
    
        
        .. code-block:: csharp
    
           bool CanCreateInstance(Type targetType)
    

