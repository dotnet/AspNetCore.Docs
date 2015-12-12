

RequestCultureFeature Class
===========================



.. contents:: 
   :local:



Summary
-------

Provides the current request's culture information.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Localization.RequestCultureFeature`








Syntax
------

.. code-block:: csharp

   public class RequestCultureFeature : IRequestCultureFeature





GitHub
------

`View on GitHub <https://github.com/aspnet/localization/blob/master/src/Microsoft.AspNet.Localization/RequestCultureFeature.cs>`_





.. dn:class:: Microsoft.AspNet.Localization.RequestCultureFeature

Constructors
------------

.. dn:class:: Microsoft.AspNet.Localization.RequestCultureFeature
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Localization.RequestCultureFeature.RequestCultureFeature(Microsoft.AspNet.Localization.RequestCulture, Microsoft.AspNet.Localization.IRequestCultureProvider)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Localization.RequestCultureFeature` with the specified :any:`Microsoft.AspNet.Localization.RequestCulture`\.
    
        
        
        
        :param requestCulture: The .
        
        :type requestCulture: Microsoft.AspNet.Localization.RequestCulture
        
        
        :param provider: The .
        
        :type provider: Microsoft.AspNet.Localization.IRequestCultureProvider
    
        
        .. code-block:: csharp
    
           public RequestCultureFeature(RequestCulture requestCulture, IRequestCultureProvider provider)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Localization.RequestCultureFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Localization.RequestCultureFeature.Provider
    
        
        :rtype: Microsoft.AspNet.Localization.IRequestCultureProvider
    
        
        .. code-block:: csharp
    
           public IRequestCultureProvider Provider { get; }
    
    .. dn:property:: Microsoft.AspNet.Localization.RequestCultureFeature.RequestCulture
    
        
        :rtype: Microsoft.AspNet.Localization.RequestCulture
    
        
        .. code-block:: csharp
    
           public RequestCulture RequestCulture { get; }
    

