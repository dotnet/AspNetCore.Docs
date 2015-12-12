

RouteConstraintBuilder Class
============================



.. contents:: 
   :local:



Summary
-------

A builder for produding a mapping of keys to see :any:`Microsoft.AspNet.Routing.IRouteConstraint`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Routing.RouteConstraintBuilder`








Syntax
------

.. code-block:: csharp

   public class RouteConstraintBuilder





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/routing/src/Microsoft.AspNet.Routing/RouteConstraintBuilder.cs>`_





.. dn:class:: Microsoft.AspNet.Routing.RouteConstraintBuilder

Constructors
------------

.. dn:class:: Microsoft.AspNet.Routing.RouteConstraintBuilder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Routing.RouteConstraintBuilder.RouteConstraintBuilder(Microsoft.AspNet.Routing.IInlineConstraintResolver, System.String)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Routing.RouteConstraintBuilder` instance.
    
        
        
        
        :param inlineConstraintResolver: The .
        
        :type inlineConstraintResolver: Microsoft.AspNet.Routing.IInlineConstraintResolver
        
        
        :param displayName: The display name (for use in error messages).
        
        :type displayName: System.String
    
        
        .. code-block:: csharp
    
           public RouteConstraintBuilder(IInlineConstraintResolver inlineConstraintResolver, string displayName)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Routing.RouteConstraintBuilder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Routing.RouteConstraintBuilder.AddConstraint(System.String, System.Object)
    
        
    
        Adds a constraint instance for the given key.
    
        
        
        
        :param key: The key.
        
        :type key: System.String
        
        
        :param value: The constraint instance. Must either be a string or an instance of .
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
           public void AddConstraint(string key, object value)
    
    .. dn:method:: Microsoft.AspNet.Routing.RouteConstraintBuilder.AddResolvedConstraint(System.String, System.String)
    
        
    
        Adds a constraint for the given key, resolved by the :any:`Microsoft.AspNet.Routing.IInlineConstraintResolver`\.
    
        
        
        
        :param key: The key.
        
        :type key: System.String
        
        
        :param constraintText: The text to be resolved by .
        
        :type constraintText: System.String
    
        
        .. code-block:: csharp
    
           public void AddResolvedConstraint(string key, string constraintText)
    
    .. dn:method:: Microsoft.AspNet.Routing.RouteConstraintBuilder.Build()
    
        
    
        Builds a mapping of constraints.
    
        
        :rtype: System.Collections.Generic.IReadOnlyDictionary{System.String,Microsoft.AspNet.Routing.IRouteConstraint}
        :return: An <see cref="T:System.Collections.Generic.IReadOnlyDictionary`2" /> of the constraints.
    
        
        .. code-block:: csharp
    
           public IReadOnlyDictionary<string, IRouteConstraint> Build()
    
    .. dn:method:: Microsoft.AspNet.Routing.RouteConstraintBuilder.SetOptional(System.String)
    
        
    
        Sets the given key as optional.
    
        
        
        
        :param key: The key.
        
        :type key: System.String
    
        
        .. code-block:: csharp
    
           public void SetOptional(string key)
    

