

ModelClientValidationRule Class
===============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelClientValidationRule`








Syntax
------

.. code-block:: csharp

   public class ModelClientValidationRule





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Abstractions/ModelBinding/Validation/ModelClientValidationRule.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelClientValidationRule

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelClientValidationRule
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelClientValidationRule.ModelClientValidationRule(System.String)
    
        
        
        
        :type errorMessage: System.String
    
        
        .. code-block:: csharp
    
           public ModelClientValidationRule(string errorMessage)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelClientValidationRule.ModelClientValidationRule(System.String, System.String)
    
        
        
        
        :type validationType: System.String
        
        
        :type errorMessage: System.String
    
        
        .. code-block:: csharp
    
           public ModelClientValidationRule(string validationType, string errorMessage)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelClientValidationRule
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelClientValidationRule.ErrorMessage
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ErrorMessage { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelClientValidationRule.ValidationParameters
    
        
        :rtype: System.Collections.Generic.IDictionary{System.String,System.Object}
    
        
        .. code-block:: csharp
    
           public IDictionary<string, object> ValidationParameters { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelClientValidationRule.ValidationType
    
        
    
        Identifier of the :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelClientValidationRule`\. If client-side validation is enabled, default
        validation attribute generator uses this :any:`System.String` as part of the generated "data-val"
        attribute name. Must be unique in the set of enabled validation rules.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ValidationType { get; }
    

