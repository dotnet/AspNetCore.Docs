

RegexInlineRouteConstraint Class
================================



.. contents:: 
   :local:



Summary
-------

Represents a regex constraint which can be used as an inlineConstraint.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Routing.Constraints.RegexRouteConstraint`
* :dn:cls:`Microsoft.AspNet.Routing.Constraints.RegexInlineRouteConstraint`








Syntax
------

.. code-block:: csharp

   public class RegexInlineRouteConstraint : RegexRouteConstraint, IRouteConstraint





GitHub
------

`View on GitHub <https://github.com/aspnet/routing/blob/master/src/Microsoft.AspNet.Routing/Constraints/RegexInlineRouteConstraint.cs>`_





.. dn:class:: Microsoft.AspNet.Routing.Constraints.RegexInlineRouteConstraint

Constructors
------------

.. dn:class:: Microsoft.AspNet.Routing.Constraints.RegexInlineRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Routing.Constraints.RegexInlineRouteConstraint.RegexInlineRouteConstraint(System.String)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Routing.Constraints.RegexInlineRouteConstraint` class.
    
        
        
        
        :param regexPattern: The regular expression pattern to match.
        
        :type regexPattern: System.String
    
        
        .. code-block:: csharp
    
           public RegexInlineRouteConstraint(string regexPattern)
    

