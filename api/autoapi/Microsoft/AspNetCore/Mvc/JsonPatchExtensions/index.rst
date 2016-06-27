

JsonPatchExtensions Class
=========================






Extensions for :any:`Microsoft.AspNetCore.JsonPatch.JsonPatchDocument\`1`


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc`
Assemblies
    * Microsoft.AspNetCore.Mvc.Formatters.Json

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.JsonPatchExtensions`








Syntax
------

.. code-block:: csharp

    public class JsonPatchExtensions








.. dn:class:: Microsoft.AspNetCore.Mvc.JsonPatchExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.JsonPatchExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.JsonPatchExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.JsonPatchExtensions.ApplyTo<T>(Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<T>, T, Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary)
    
        
    
        
        Applies JSON patch operations on object and logs errors in :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary`\.
    
        
    
        
        :param patchDoc: The :any:`Microsoft.AspNetCore.JsonPatch.JsonPatchDocument\`1`\.
        
        :type patchDoc: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<Microsoft.AspNetCore.JsonPatch.JsonPatchDocument`1>{T}
    
        
        :param objectToApplyTo: The entity on which :any:`Microsoft.AspNetCore.JsonPatch.JsonPatchDocument\`1` is applied.
        
        :type objectToApplyTo: T
    
        
        :param modelState: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary` to add errors.
        
        :type modelState: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary
    
        
        .. code-block:: csharp
    
            public static void ApplyTo<T>(this JsonPatchDocument<T> patchDoc, T objectToApplyTo, ModelStateDictionary modelState)where T : class
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.JsonPatchExtensions.ApplyTo<T>(Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<T>, T, Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary, System.String)
    
        
    
        
        Applies JSON patch operations on object and logs errors in :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary`\.
    
        
    
        
        :param patchDoc: The :any:`Microsoft.AspNetCore.JsonPatch.JsonPatchDocument\`1`\.
        
        :type patchDoc: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<Microsoft.AspNetCore.JsonPatch.JsonPatchDocument`1>{T}
    
        
        :param objectToApplyTo: The entity on which :any:`Microsoft.AspNetCore.JsonPatch.JsonPatchDocument\`1` is applied.
        
        :type objectToApplyTo: T
    
        
        :param modelState: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary` to add errors.
        
        :type modelState: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary
    
        
        :param prefix: The prefix to use when looking up values in :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary`\.
        
        :type prefix: System.String
    
        
        .. code-block:: csharp
    
            public static void ApplyTo<T>(this JsonPatchDocument<T> patchDoc, T objectToApplyTo, ModelStateDictionary modelState, string prefix)where T : class
    

