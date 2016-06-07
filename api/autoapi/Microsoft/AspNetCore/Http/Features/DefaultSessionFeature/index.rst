

DefaultSessionFeature Class
===========================






This type exists only for the purpose of unit testing where the user can directly set the
:dn:prop:`Microsoft.AspNetCore.Http.HttpContext.Session` property without the need for creating a :any:`Microsoft.AspNetCore.Http.Features.ISessionFeature`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Http.Features`
Assemblies
    * Microsoft.AspNetCore.Http

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Http.Features.DefaultSessionFeature`








Syntax
------

.. code-block:: csharp

    public class DefaultSessionFeature : ISessionFeature








.. dn:class:: Microsoft.AspNetCore.Http.Features.DefaultSessionFeature
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Http.Features.DefaultSessionFeature

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Http.Features.DefaultSessionFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.DefaultSessionFeature.Session
    
        
        :rtype: Microsoft.AspNetCore.Http.ISession
    
        
        .. code-block:: csharp
    
            public ISession Session
            {
                get;
                set;
            }
    

