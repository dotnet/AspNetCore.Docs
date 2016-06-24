

ProviderCultureResult Class
===========================






Details about the cultures obtained from :any:`Microsoft.AspNetCore.Localization.IRequestCultureProvider`\.


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
* :dn:cls:`Microsoft.AspNetCore.Localization.ProviderCultureResult`








Syntax
------

.. code-block:: csharp

    public class ProviderCultureResult








.. dn:class:: Microsoft.AspNetCore.Localization.ProviderCultureResult
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Localization.ProviderCultureResult

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Localization.ProviderCultureResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Localization.ProviderCultureResult.ProviderCultureResult(System.Collections.Generic.IList<System.String>)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Localization.ProviderCultureResult` object that has its :dn:prop:`Microsoft.AspNetCore.Localization.ProviderCultureResult.Cultures` and 
        :dn:prop:`Microsoft.AspNetCore.Localization.ProviderCultureResult.UICultures` properties set to the same culture value.
    
        
    
        
        :param cultures: The list of cultures to be used for formatting, text, i.e. language.
        
        :type cultures: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public ProviderCultureResult(IList<string> cultures)
    
    .. dn:constructor:: Microsoft.AspNetCore.Localization.ProviderCultureResult.ProviderCultureResult(System.Collections.Generic.IList<System.String>, System.Collections.Generic.IList<System.String>)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Localization.ProviderCultureResult` object has its :dn:prop:`Microsoft.AspNetCore.Localization.ProviderCultureResult.Cultures` and 
        :dn:prop:`Microsoft.AspNetCore.Localization.ProviderCultureResult.UICultures` properties set to the respective culture values provided.
    
        
    
        
        :param cultures: The list of cultures to be used for formatting.
        
        :type cultures: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
    
        
        :param uiCultures: The list of ui cultures to be used for text, i.e. language.
        
        :type uiCultures: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public ProviderCultureResult(IList<string> cultures, IList<string> uiCultures)
    
    .. dn:constructor:: Microsoft.AspNetCore.Localization.ProviderCultureResult.ProviderCultureResult(System.String)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Localization.ProviderCultureResult` object that has its :dn:prop:`Microsoft.AspNetCore.Localization.ProviderCultureResult.Cultures` and 
        :dn:prop:`Microsoft.AspNetCore.Localization.ProviderCultureResult.UICultures` properties set to the same culture value.
    
        
    
        
        :param culture: The name of the culture to be used for formatting, text, i.e. language.
        
        :type culture: System.String
    
        
        .. code-block:: csharp
    
            public ProviderCultureResult(string culture)
    
    .. dn:constructor:: Microsoft.AspNetCore.Localization.ProviderCultureResult.ProviderCultureResult(System.String, System.String)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Localization.ProviderCultureResult` object has its :dn:prop:`Microsoft.AspNetCore.Localization.ProviderCultureResult.Cultures` and 
        :dn:prop:`Microsoft.AspNetCore.Localization.ProviderCultureResult.UICultures` properties set to the respective culture values provided.
    
        
    
        
        :param culture: The name of the culture to be used for formatting.
        
        :type culture: System.String
    
        
        :param uiCulture: The name of the ui culture to be used for text, i.e. language.
        
        :type uiCulture: System.String
    
        
        .. code-block:: csharp
    
            public ProviderCultureResult(string culture, string uiCulture)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Localization.ProviderCultureResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Localization.ProviderCultureResult.Cultures
    
        
    
        
        Gets the list of cultures to be used for formatting.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IList<string> Cultures { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Localization.ProviderCultureResult.UICultures
    
        
    
        
        Gets the list of ui cultures to be used for text, i.e. language;
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IList<string> UICultures { get; }
    

