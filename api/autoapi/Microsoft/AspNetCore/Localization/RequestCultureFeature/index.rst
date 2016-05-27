

RequestCultureFeature Class
===========================






Provides the current request's culture information.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Localization`
Assemblies
    * Microsoft.AspNetCore.Localization

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Localization.RequestCultureFeature`








Syntax
------

.. code-block:: csharp

    public class RequestCultureFeature : IRequestCultureFeature








.. dn:class:: Microsoft.AspNetCore.Localization.RequestCultureFeature
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Localization.RequestCultureFeature

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Localization.RequestCultureFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Localization.RequestCultureFeature.Provider
    
        
        :rtype: Microsoft.AspNetCore.Localization.IRequestCultureProvider
    
        
        .. code-block:: csharp
    
            public IRequestCultureProvider Provider
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Localization.RequestCultureFeature.RequestCulture
    
        
        :rtype: Microsoft.AspNetCore.Localization.RequestCulture
    
        
        .. code-block:: csharp
    
            public RequestCulture RequestCulture
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Localization.RequestCultureFeature
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Localization.RequestCultureFeature.RequestCultureFeature(Microsoft.AspNetCore.Localization.RequestCulture, Microsoft.AspNetCore.Localization.IRequestCultureProvider)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Localization.RequestCultureFeature` with the specified :any:`Microsoft.AspNetCore.Localization.RequestCulture`\.
    
        
    
        
        :param requestCulture: The :any:`Microsoft.AspNetCore.Localization.RequestCulture`\.
        
        :type requestCulture: Microsoft.AspNetCore.Localization.RequestCulture
    
        
        :param provider: The :any:`Microsoft.AspNetCore.Localization.IRequestCultureProvider`\.
        
        :type provider: Microsoft.AspNetCore.Localization.IRequestCultureProvider
    
        
        .. code-block:: csharp
    
            public RequestCultureFeature(RequestCulture requestCulture, IRequestCultureProvider provider)
    

