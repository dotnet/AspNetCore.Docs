

GeneratedTagHelperAttributeContext Class
========================================



.. contents:: 
   :local:



Summary
-------

Contains information for the :any:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper` attribute code
generation process.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.GeneratedTagHelperAttributeContext`








Syntax
------

.. code-block:: csharp

   public class GeneratedTagHelperAttributeContext





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Razor.Host/GeneratedTagHelperAttributeContext.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.GeneratedTagHelperAttributeContext

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.GeneratedTagHelperAttributeContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.GeneratedTagHelperAttributeContext.CreateModelExpressionMethodName
    
        
    
        Name the method to create <c>ModelExpression</c>s.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string CreateModelExpressionMethodName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.GeneratedTagHelperAttributeContext.ModelExpressionTypeName
    
        
    
        Name of the model expression type.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ModelExpressionTypeName { get; set; }
    

