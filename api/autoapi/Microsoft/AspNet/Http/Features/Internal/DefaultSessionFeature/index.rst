

DefaultSessionFeature Class
===========================



.. contents:: 
   :local:



Summary
-------

This type exists only for the purpose of unit testing where the user can directly set the 
:dn:prop:`Microsoft.AspNet.Http.HttpContext.Session` property without the need for creating a :any:`Microsoft.AspNet.Http.Features.ISessionFeature`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Http.Features.Internal.DefaultSessionFeature`








Syntax
------

.. code-block:: csharp

   public class DefaultSessionFeature : ISessionFeature





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.AspNet.Http/Features/DefaultSessionFeature.cs>`_





.. dn:class:: Microsoft.AspNet.Http.Features.Internal.DefaultSessionFeature

Properties
----------

.. dn:class:: Microsoft.AspNet.Http.Features.Internal.DefaultSessionFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.Features.Internal.DefaultSessionFeature.Session
    
        
        :rtype: Microsoft.AspNet.Http.Features.ISession
    
        
        .. code-block:: csharp
    
           public ISession Session { get; set; }
    

