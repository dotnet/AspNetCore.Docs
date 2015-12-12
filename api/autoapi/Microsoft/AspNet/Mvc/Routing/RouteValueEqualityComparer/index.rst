

RouteValueEqualityComparer Class
================================



.. contents:: 
   :local:



Summary
-------

An :any:`System.Collections.Generic.IEqualityComparer\`1` implementation that compares objects as-if
they were route value strings.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Routing.RouteValueEqualityComparer`








Syntax
------

.. code-block:: csharp

   public class RouteValueEqualityComparer : IEqualityComparer<object>





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/Routing/RouteValueEqualityComparer.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Routing.RouteValueEqualityComparer

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Routing.RouteValueEqualityComparer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Routing.RouteValueEqualityComparer.Equals(System.Object, System.Object)
    
        
        
        
        :type x: System.Object
        
        
        :type y: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Equals(object x, object y)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Routing.RouteValueEqualityComparer.GetHashCode(System.Object)
    
        
        
        
        :type obj: System.Object
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int GetHashCode(object obj)
    

