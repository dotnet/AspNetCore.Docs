

ModelStateEntry Class
=====================



.. contents:: 
   :local:



Summary
-------

An entry in a :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateEntry`








Syntax
------

.. code-block:: csharp

   public class ModelStateEntry





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Abstractions/ModelBinding/ModelState.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateEntry

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateEntry
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateEntry.AttemptedValue
    
        
    
        Gets the set of values contained in :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateEntry.RawValue`\, joined into a comma-separated string.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string AttemptedValue { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateEntry.Errors
    
        
    
        Gets the :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelErrorCollection` for this entry.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.ModelErrorCollection
    
        
        .. code-block:: csharp
    
           public ModelErrorCollection Errors { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateEntry.RawValue
    
        
    
        Gets the raw value from the request associated with this entry.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public object RawValue { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateEntry.ValidationState
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelValidationState` for this entry.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.ModelValidationState
    
        
        .. code-block:: csharp
    
           public ModelValidationState ValidationState { get; set; }
    

