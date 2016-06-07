

IRequestCultureFeature Interface
================================






Represents the feature that provides the current request's culture information.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Localization`
Assemblies
    * Microsoft.AspNetCore.Localization

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IRequestCultureFeature








.. dn:interface:: Microsoft.AspNetCore.Localization.IRequestCultureFeature
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Localization.IRequestCultureFeature

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Localization.IRequestCultureFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Localization.IRequestCultureFeature.Provider
    
        
    
        
        The :any:`Microsoft.AspNetCore.Localization.IRequestCultureProvider` that determined the request's culture information.
        If the value is <code>null</code> then no provider was used and the request's culture was set to the value of
        :dn:prop:`Microsoft.AspNetCore.Builder.RequestLocalizationOptions.DefaultRequestCulture`\.
    
        
        :rtype: Microsoft.AspNetCore.Localization.IRequestCultureProvider
    
        
        .. code-block:: csharp
    
            IRequestCultureProvider Provider
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Localization.IRequestCultureFeature.RequestCulture
    
        
    
        
        The :any:`Microsoft.AspNetCore.Localization.RequestCulture` of the request.
    
        
        :rtype: Microsoft.AspNetCore.Localization.RequestCulture
    
        
        .. code-block:: csharp
    
            RequestCulture RequestCulture
            {
                get;
            }
    

