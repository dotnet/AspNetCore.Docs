

ConsumesAttribute Class
=======================






A filter that specifies the supported request content types. :dn:prop:`Microsoft.AspNetCore.Mvc.ConsumesAttribute.ContentTypes` is used to select an
action when there would otherwise be multiple matches.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ConsumesAttribute`








Syntax
------

.. code-block:: csharp

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class ConsumesAttribute : Attribute, _Attribute, IResourceFilter, IFilterMetadata, IConsumesActionConstraint, IActionConstraint, IActionConstraintMetadata, IApiRequestMetadataProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.ConsumesAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ConsumesAttribute

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ConsumesAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ConsumesAttribute.ConsumesAttribute(System.String, System.String[])
    
        
    
        
        Creates a new instance of :any:`Microsoft.AspNetCore.Mvc.ConsumesAttribute`\.
    
        
    
        
        :type contentType: System.String
    
        
        :type otherContentTypes: System.String<System.String>[]
    
        
        .. code-block:: csharp
    
            public ConsumesAttribute(string contentType, params string[] otherContentTypes)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ConsumesAttribute
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ConsumesAttribute.Accept(Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintContext
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Accept(ActionConstraintContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ConsumesAttribute.OnResourceExecuted(Microsoft.AspNetCore.Mvc.Filters.ResourceExecutedContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.ResourceExecutedContext
    
        
        .. code-block:: csharp
    
            public void OnResourceExecuted(ResourceExecutedContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ConsumesAttribute.OnResourceExecuting(Microsoft.AspNetCore.Mvc.Filters.ResourceExecutingContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.ResourceExecutingContext
    
        
        .. code-block:: csharp
    
            public void OnResourceExecuting(ResourceExecutingContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ConsumesAttribute.SetContentTypes(Microsoft.AspNetCore.Mvc.Formatters.MediaTypeCollection)
    
        
    
        
        :type contentTypes: Microsoft.AspNetCore.Mvc.Formatters.MediaTypeCollection
    
        
        .. code-block:: csharp
    
            public void SetContentTypes(MediaTypeCollection contentTypes)
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Mvc.ConsumesAttribute
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Mvc.ConsumesAttribute.ConsumesActionConstraintOrder
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public static readonly int ConsumesActionConstraintOrder
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ConsumesAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ConsumesAttribute.ContentTypes
    
        
    
        
        Gets or sets the supported request content types. Used to select an action when there would otherwise be
        multiple matches.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Formatters.MediaTypeCollection
    
        
        .. code-block:: csharp
    
            public MediaTypeCollection ContentTypes { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ConsumesAttribute.Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraint.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            int IActionConstraint.Order { get; }
    

