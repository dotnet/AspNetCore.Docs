

ConsumesAttribute Class
=======================



.. contents:: 
   :local:



Summary
-------

Specifies the allowed content types which can be used to select the action based on request's content-type.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNet.Mvc.ConsumesAttribute`








Syntax
------

.. code-block:: csharp

   public class ConsumesAttribute : Attribute, _Attribute, IResourceFilter, IFilterMetadata, IConsumesActionConstraint, IActionConstraint, IActionConstraintMetadata





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/ConsumesAttribute.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ConsumesAttribute

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ConsumesAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ConsumesAttribute.ConsumesAttribute(System.String, System.String[])
    
        
    
        Creates a new instance of :any:`Microsoft.AspNet.Mvc.ConsumesAttribute`\.
    
        
        
        
        :type contentType: System.String
        
        
        :type otherContentTypes: System.String[]
    
        
        .. code-block:: csharp
    
           public ConsumesAttribute(string contentType, params string[] otherContentTypes)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ConsumesAttribute
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ConsumesAttribute.Accept(Microsoft.AspNet.Mvc.ActionConstraints.ActionConstraintContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ActionConstraints.ActionConstraintContext
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Accept(ActionConstraintContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ConsumesAttribute.OnResourceExecuted(Microsoft.AspNet.Mvc.Filters.ResourceExecutedContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Filters.ResourceExecutedContext
    
        
        .. code-block:: csharp
    
           public void OnResourceExecuted(ResourceExecutedContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ConsumesAttribute.OnResourceExecuting(Microsoft.AspNet.Mvc.Filters.ResourceExecutingContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Filters.ResourceExecutingContext
    
        
        .. code-block:: csharp
    
           public void OnResourceExecuting(ResourceExecutingContext context)
    

Fields
------

.. dn:class:: Microsoft.AspNet.Mvc.ConsumesAttribute
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Mvc.ConsumesAttribute.ConsumesActionConstraintOrder
    
        
    
        
        .. code-block:: csharp
    
           public static readonly int ConsumesActionConstraintOrder
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ConsumesAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ConsumesAttribute.ContentTypes
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.Net.Http.Headers.MediaTypeHeaderValue}
    
        
        .. code-block:: csharp
    
           public IList<MediaTypeHeaderValue> ContentTypes { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ConsumesAttribute.Microsoft.AspNet.Mvc.ActionConstraints.IActionConstraint.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int IActionConstraint.Order { get; }
    

