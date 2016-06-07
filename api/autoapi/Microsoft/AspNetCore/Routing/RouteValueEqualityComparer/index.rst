

RouteValueEqualityComparer Class
================================






An :any:`System.Collections.Generic.IEqualityComparer\`1` implementation that compares objects as-if
they were route value strings.


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
* :dn:cls:`Microsoft.AspNetCore.Routing.RouteValueEqualityComparer`








Syntax
------

.. code-block:: csharp

    public class RouteValueEqualityComparer : IEqualityComparer<object>








.. dn:class:: Microsoft.AspNetCore.Routing.RouteValueEqualityComparer
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Routing.RouteValueEqualityComparer

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Routing.RouteValueEqualityComparer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Routing.RouteValueEqualityComparer.Equals(System.Object, System.Object)
    
        
    
        
        :type x: System.Object
    
        
        :type y: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Equals(object x, object y)
    
    .. dn:method:: Microsoft.AspNetCore.Routing.RouteValueEqualityComparer.GetHashCode(System.Object)
    
        
    
        
        :type obj: System.Object
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int GetHashCode(object obj)
    

