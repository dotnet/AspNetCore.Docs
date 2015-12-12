

HttpMethodConstraint Class
==========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ActionConstraints.HttpMethodConstraint`








Syntax
------

.. code-block:: csharp

   public class HttpMethodConstraint : IActionConstraint, IActionConstraintMetadata





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/ActionConstraints/HttpMethodConstraint.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ActionConstraints.HttpMethodConstraint

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ActionConstraints.HttpMethodConstraint
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ActionConstraints.HttpMethodConstraint.HttpMethodConstraint(System.Collections.Generic.IEnumerable<System.String>)
    
        
        
        
        :type httpMethods: System.Collections.Generic.IEnumerable{System.String}
    
        
        .. code-block:: csharp
    
           public HttpMethodConstraint(IEnumerable<string> httpMethods)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ActionConstraints.HttpMethodConstraint
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ActionConstraints.HttpMethodConstraint.Accept(Microsoft.AspNet.Mvc.ActionConstraints.ActionConstraintContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ActionConstraints.ActionConstraintContext
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Accept(ActionConstraintContext context)
    

Fields
------

.. dn:class:: Microsoft.AspNet.Mvc.ActionConstraints.HttpMethodConstraint
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Mvc.ActionConstraints.HttpMethodConstraint.HttpMethodConstraintOrder
    
        
    
        
        .. code-block:: csharp
    
           public static readonly int HttpMethodConstraintOrder
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ActionConstraints.HttpMethodConstraint
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ActionConstraints.HttpMethodConstraint.HttpMethods
    
        
        :rtype: System.Collections.Generic.IEnumerable{System.String}
    
        
        .. code-block:: csharp
    
           public IEnumerable<string> HttpMethods { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ActionConstraints.HttpMethodConstraint.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Order { get; }
    

