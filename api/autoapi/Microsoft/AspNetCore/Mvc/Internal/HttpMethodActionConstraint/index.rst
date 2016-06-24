

HttpMethodActionConstraint Class
================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.HttpMethodActionConstraint`








Syntax
------

.. code-block:: csharp

    public class HttpMethodActionConstraint : IActionConstraint, IActionConstraintMetadata








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.HttpMethodActionConstraint
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.HttpMethodActionConstraint

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.HttpMethodActionConstraint
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Internal.HttpMethodActionConstraint.HttpMethodActionConstraint(System.Collections.Generic.IEnumerable<System.String>)
    
        
    
        
        :type httpMethods: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public HttpMethodActionConstraint(IEnumerable<string> httpMethods)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.HttpMethodActionConstraint
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.HttpMethodActionConstraint.Accept(Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintContext
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Accept(ActionConstraintContext context)
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.HttpMethodActionConstraint
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Mvc.Internal.HttpMethodActionConstraint.HttpMethodConstraintOrder
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public static readonly int HttpMethodConstraintOrder
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.HttpMethodActionConstraint
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.HttpMethodActionConstraint.HttpMethods
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IEnumerable<string> HttpMethods { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.HttpMethodActionConstraint.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Order { get; }
    

