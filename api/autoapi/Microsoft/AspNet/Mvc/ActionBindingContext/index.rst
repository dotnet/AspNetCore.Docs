

ActionBindingContext Class
==========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ActionBindingContext`








Syntax
------

.. code-block:: csharp

   public class ActionBindingContext





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/ActionBindingContext.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ActionBindingContext

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ActionBindingContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ActionBindingContext.InputFormatters
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.Formatters.IInputFormatter}
    
        
        .. code-block:: csharp
    
           public IList<IInputFormatter> InputFormatters { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ActionBindingContext.ModelBinder
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.IModelBinder
    
        
        .. code-block:: csharp
    
           public IModelBinder ModelBinder { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ActionBindingContext.OutputFormatters
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.Formatters.IOutputFormatter}
    
        
        .. code-block:: csharp
    
           public IList<IOutputFormatter> OutputFormatters { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ActionBindingContext.ValidatorProvider
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.Validation.IModelValidatorProvider
    
        
        .. code-block:: csharp
    
           public IModelValidatorProvider ValidatorProvider { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ActionBindingContext.ValueProvider
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.IValueProvider
    
        
        .. code-block:: csharp
    
           public IValueProvider ValueProvider { get; set; }
    

