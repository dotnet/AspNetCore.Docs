

IExcludeTypeValidationFilter Interface
======================================



.. contents:: 
   :local:



Summary
-------

Provides an interface which is used to determine if :any:`System.Type`\s are excluded from model validation.











Syntax
------

.. code-block:: csharp

   public interface IExcludeTypeValidationFilter





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/ModelBinding/Validation/IExcludeTypeValidationFilter.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.ModelBinding.Validation.IExcludeTypeValidationFilter

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.ModelBinding.Validation.IExcludeTypeValidationFilter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.Validation.IExcludeTypeValidationFilter.IsTypeExcluded(System.Type)
    
        
    
        Determines if the given type is excluded from validation.
    
        
        
        
        :param type: The  for which the check is to be performed.
        
        :type type: System.Type
        :rtype: System.Boolean
        :return: True if the type is to be excluded. False otherwise.
    
        
        .. code-block:: csharp
    
           bool IsTypeExcluded(Type type)
    

