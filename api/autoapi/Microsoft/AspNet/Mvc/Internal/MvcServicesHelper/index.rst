

MvcServicesHelper Class
=======================



.. contents:: 
   :local:



Summary
-------

Helper class which contains MvcServices related helpers.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Internal.MvcServicesHelper`








Syntax
------

.. code-block:: csharp

   public class MvcServicesHelper





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/Internal/MvcServicesHelper.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Internal.MvcServicesHelper

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Internal.MvcServicesHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Internal.MvcServicesHelper.ThrowIfMvcNotRegistered(System.IServiceProvider)
    
        
    
        Throws InvalidOperationException when MvcMarkerService is not present
        in the list of services.
    
        
        
        
        :param services: The list of services.
        
        :type services: System.IServiceProvider
    
        
        .. code-block:: csharp
    
           public static void ThrowIfMvcNotRegistered(IServiceProvider services)
    

