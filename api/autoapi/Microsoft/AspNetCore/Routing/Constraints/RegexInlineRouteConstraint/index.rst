

RegexInlineRouteConstraint Class
================================






Represents a regex constraint which can be used as an inlineConstraint.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Routing.Constraints`
Assemblies
    * Microsoft.AspNetCore.Routing

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Routing.Constraints.RegexRouteConstraint`
* :dn:cls:`Microsoft.AspNetCore.Routing.Constraints.RegexInlineRouteConstraint`








Syntax
------

.. code-block:: csharp

    public class RegexInlineRouteConstraint : RegexRouteConstraint, IRouteConstraint








.. dn:class:: Microsoft.AspNetCore.Routing.Constraints.RegexInlineRouteConstraint
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Routing.Constraints.RegexInlineRouteConstraint

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Routing.Constraints.RegexInlineRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Routing.Constraints.RegexInlineRouteConstraint.RegexInlineRouteConstraint(System.String)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Routing.Constraints.RegexInlineRouteConstraint` class.
    
        
    
        
        :param regexPattern: The regular expression pattern to match.
        
        :type regexPattern: System.String
    
        
        .. code-block:: csharp
    
            public RegexInlineRouteConstraint(string regexPattern)
    

