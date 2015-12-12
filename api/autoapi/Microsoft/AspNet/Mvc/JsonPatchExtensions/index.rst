

JsonPatchExtensions Class
=========================



.. contents:: 
   :local:



Summary
-------

Extensions for :any:`Microsoft.AspNet.JsonPatch.JsonPatchDocument\`1`





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.JsonPatchExtensions`








Syntax
------

.. code-block:: csharp

   public class JsonPatchExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Formatters.Json/JsonPatchExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.JsonPatchExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.JsonPatchExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.JsonPatchExtensions.ApplyTo<T>(Microsoft.AspNet.JsonPatch.JsonPatchDocument<T>, T, Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary)
    
        
    
        Applies JSON patch operations on object and logs errors in :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary`\.
    
        
        
        
        :param patchDoc: The .
        
        :type patchDoc: Microsoft.AspNet.JsonPatch.JsonPatchDocument{{T}}
        
        
        :param objectToApplyTo: The entity on which  is applied.
        
        :type objectToApplyTo: {T}
        
        
        :param modelState: The  to add errors.
        
        :type modelState: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary
    
        
        .. code-block:: csharp
    
           public static void ApplyTo<T>(JsonPatchDocument<T> patchDoc, T objectToApplyTo, ModelStateDictionary modelState)where T : class
    
    .. dn:method:: Microsoft.AspNet.Mvc.JsonPatchExtensions.ApplyTo<T>(Microsoft.AspNet.JsonPatch.JsonPatchDocument<T>, T, Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary, System.String)
    
        
    
        Applies JSON patch operations on object and logs errors in :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary`\.
    
        
        
        
        :param patchDoc: The .
        
        :type patchDoc: Microsoft.AspNet.JsonPatch.JsonPatchDocument{{T}}
        
        
        :param objectToApplyTo: The entity on which  is applied.
        
        :type objectToApplyTo: {T}
        
        
        :param modelState: The  to add errors.
        
        :type modelState: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary
        
        
        :param prefix: The prefix to use when looking up values in .
        
        :type prefix: System.String
    
        
        .. code-block:: csharp
    
           public static void ApplyTo<T>(JsonPatchDocument<T> patchDoc, T objectToApplyTo, ModelStateDictionary modelState, string prefix)where T : class
    

