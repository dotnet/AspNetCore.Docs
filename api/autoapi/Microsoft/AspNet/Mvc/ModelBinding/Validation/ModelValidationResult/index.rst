

ModelValidationResult Class
===========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelValidationResult`








Syntax
------

.. code-block:: csharp

   public class ModelValidationResult





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Abstractions/ModelBinding/Validation/ModelValidationResult.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelValidationResult

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelValidationResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelValidationResult.ModelValidationResult(System.String, System.String)
    
        
        
        
        :type memberName: System.String
        
        
        :type message: System.String
    
        
        .. code-block:: csharp
    
           public ModelValidationResult(string memberName, string message)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelValidationResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelValidationResult.MemberName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string MemberName { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelValidationResult.Message
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Message { get; }
    

