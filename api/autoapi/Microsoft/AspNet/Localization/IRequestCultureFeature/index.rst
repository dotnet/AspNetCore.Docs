

IRequestCultureFeature Interface
================================



.. contents:: 
   :local:



Summary
-------

Represents the feature that provides the current request's culture information.











Syntax
------

.. code-block:: csharp

   public interface IRequestCultureFeature





GitHub
------

`View on GitHub <https://github.com/aspnet/localization/blob/master/src/Microsoft.AspNet.Localization/IRequestCultureFeature.cs>`_





.. dn:interface:: Microsoft.AspNet.Localization.IRequestCultureFeature

Properties
----------

.. dn:interface:: Microsoft.AspNet.Localization.IRequestCultureFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Localization.IRequestCultureFeature.Provider
    
        
    
        The :any:`Microsoft.AspNet.Localization.IRequestCultureProvider` that determined the request's culture information.
        If the value is <c>null</c> then no provider was used and the request's culture was set to the value of 
        RequestLocalizationOptions.DefaultRequestCulture\.
    
        
        :rtype: Microsoft.AspNet.Localization.IRequestCultureProvider
    
        
        .. code-block:: csharp
    
           IRequestCultureProvider Provider { get; }
    
    .. dn:property:: Microsoft.AspNet.Localization.IRequestCultureFeature.RequestCulture
    
        
    
        The :any:`Microsoft.AspNet.Localization.RequestCulture` of the request.
    
        
        :rtype: Microsoft.AspNet.Localization.RequestCulture
    
        
        .. code-block:: csharp
    
           RequestCulture RequestCulture { get; }
    

