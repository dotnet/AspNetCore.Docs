

AmbiguousActionException Class
==============================



.. contents:: 
   :local:



Summary
-------

An exception which indicates multiple matches in action selection.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Exception`
* :dn:cls:`System.SystemException`
* :dn:cls:`System.InvalidOperationException`
* :dn:cls:`Microsoft.AspNet.Mvc.Infrastructure.AmbiguousActionException`








Syntax
------

.. code-block:: csharp

   public class AmbiguousActionException : InvalidOperationException, ISerializable, _Exception





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/Infrastructure/AmbiguousActionException.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Infrastructure.AmbiguousActionException

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Infrastructure.AmbiguousActionException
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Infrastructure.AmbiguousActionException.AmbiguousActionException(System.String)
    
        
        
        
        :type message: System.String
    
        
        .. code-block:: csharp
    
           public AmbiguousActionException(string message)
    

