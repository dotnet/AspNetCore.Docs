

UnobtrusiveValidationAttributesGenerator Class
==============================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ViewFeatures.UnobtrusiveValidationAttributesGenerator`








Syntax
------

.. code-block:: csharp

   public class UnobtrusiveValidationAttributesGenerator





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewFeatures/UnobtrusiveValidationAttributesGenerator.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.UnobtrusiveValidationAttributesGenerator

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.UnobtrusiveValidationAttributesGenerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.UnobtrusiveValidationAttributesGenerator.GetValidationAttributes(System.Collections.Generic.IEnumerable<Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelClientValidationRule>)
    
        
        
        
        :type clientRules: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelClientValidationRule}
        :rtype: System.Collections.Generic.IDictionary{System.String,System.Object}
    
        
        .. code-block:: csharp
    
           public static IDictionary<string, object> GetValidationAttributes(IEnumerable<ModelClientValidationRule> clientRules)
    

