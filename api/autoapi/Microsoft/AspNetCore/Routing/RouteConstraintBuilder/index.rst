

RouteConstraintBuilder Class
============================






A builder for produding a mapping of keys to see :any:`Microsoft.AspNetCore.Routing.IRouteConstraint`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Routing`
Assemblies
    * Microsoft.AspNetCore.Routing

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Routing.RouteConstraintBuilder`








Syntax
------

.. code-block:: csharp

    public class RouteConstraintBuilder








.. dn:class:: Microsoft.AspNetCore.Routing.RouteConstraintBuilder
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Routing.RouteConstraintBuilder

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Routing.RouteConstraintBuilder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Routing.RouteConstraintBuilder.RouteConstraintBuilder(Microsoft.AspNetCore.Routing.IInlineConstraintResolver, System.String)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Routing.RouteConstraintBuilder` instance.
    
        
    
        
        :param inlineConstraintResolver: The :any:`Microsoft.AspNetCore.Routing.IInlineConstraintResolver`\.
        
        :type inlineConstraintResolver: Microsoft.AspNetCore.Routing.IInlineConstraintResolver
    
        
        :param displayName: The display name (for use in error messages).
        
        :type displayName: System.String
    
        
        .. code-block:: csharp
    
            public RouteConstraintBuilder(IInlineConstraintResolver inlineConstraintResolver, string displayName)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Routing.RouteConstraintBuilder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Routing.RouteConstraintBuilder.AddConstraint(System.String, System.Object)
    
        
    
        
        Adds a constraint instance for the given key.
    
        
    
        
        :param key: The key.
        
        :type key: System.String
    
        
        :param value: 
            The constraint instance. Must either be a string or an instance of :any:`Microsoft.AspNetCore.Routing.IRouteConstraint`\.
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
            public void AddConstraint(string key, object value)
    
    .. dn:method:: Microsoft.AspNetCore.Routing.RouteConstraintBuilder.AddResolvedConstraint(System.String, System.String)
    
        
    
        
        Adds a constraint for the given key, resolved by the :any:`Microsoft.AspNetCore.Routing.IInlineConstraintResolver`\.
    
        
    
        
        :param key: The key.
        
        :type key: System.String
    
        
        :param constraintText: The text to be resolved by :any:`Microsoft.AspNetCore.Routing.IInlineConstraintResolver`\.
        
        :type constraintText: System.String
    
        
        .. code-block:: csharp
    
            public void AddResolvedConstraint(string key, string constraintText)
    
    .. dn:method:: Microsoft.AspNetCore.Routing.RouteConstraintBuilder.Build()
    
        
    
        
        Builds a mapping of constraints.
    
        
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, Microsoft.AspNetCore.Routing.IRouteConstraint<Microsoft.AspNetCore.Routing.IRouteConstraint>}
        :return: An :any:`System.Collections.Generic.IDictionary\`2` of the constraints.
    
        
        .. code-block:: csharp
    
            public IDictionary<string, IRouteConstraint> Build()
    
    .. dn:method:: Microsoft.AspNetCore.Routing.RouteConstraintBuilder.SetOptional(System.String)
    
        
    
        
        Sets the given key as optional.
    
        
    
        
        :param key: The key.
        
        :type key: System.String
    
        
        .. code-block:: csharp
    
            public void SetOptional(string key)
    

