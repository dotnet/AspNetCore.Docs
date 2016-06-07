

RequestCulture Class
====================






Details about the culture for an :any:`Microsoft.AspNetCore.Http.HttpRequest`\.


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
* :dn:cls:`Microsoft.AspNetCore.Localization.RequestCulture`








Syntax
------

.. code-block:: csharp

    public class RequestCulture








.. dn:class:: Microsoft.AspNetCore.Localization.RequestCulture
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Localization.RequestCulture

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Localization.RequestCulture
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Localization.RequestCulture.Culture
    
        
    
        
        Gets the :any:`System.Globalization.CultureInfo` for the request to be used for formatting.
    
        
        :rtype: System.Globalization.CultureInfo
    
        
        .. code-block:: csharp
    
            public CultureInfo Culture
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Localization.RequestCulture.UICulture
    
        
    
        
        Gets the :any:`System.Globalization.CultureInfo` for the request to be used for text, i.e. language;
    
        
        :rtype: System.Globalization.CultureInfo
    
        
        .. code-block:: csharp
    
            public CultureInfo UICulture
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Localization.RequestCulture
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Localization.RequestCulture.RequestCulture(System.Globalization.CultureInfo)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Localization.RequestCulture` object has its :dn:prop:`Microsoft.AspNetCore.Localization.RequestCulture.Culture` and :dn:prop:`Microsoft.AspNetCore.Localization.RequestCulture.UICulture`
        properties set to the same :any:`System.Globalization.CultureInfo` value.
    
        
    
        
        :param culture: The :any:`System.Globalization.CultureInfo` for the request.
        
        :type culture: System.Globalization.CultureInfo
    
        
        .. code-block:: csharp
    
            public RequestCulture(CultureInfo culture)
    
    .. dn:constructor:: Microsoft.AspNetCore.Localization.RequestCulture.RequestCulture(System.Globalization.CultureInfo, System.Globalization.CultureInfo)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Localization.RequestCulture` object has its :dn:prop:`Microsoft.AspNetCore.Localization.RequestCulture.Culture` and :dn:prop:`Microsoft.AspNetCore.Localization.RequestCulture.UICulture`
        properties set to the respective :any:`System.Globalization.CultureInfo` values provided.
    
        
    
        
        :param culture: The :any:`System.Globalization.CultureInfo` for the request to be used for formatting.
        
        :type culture: System.Globalization.CultureInfo
    
        
        :param uiCulture: The :any:`System.Globalization.CultureInfo` for the request to be used for text, i.e. language.
        
        :type uiCulture: System.Globalization.CultureInfo
    
        
        .. code-block:: csharp
    
            public RequestCulture(CultureInfo culture, CultureInfo uiCulture)
    
    .. dn:constructor:: Microsoft.AspNetCore.Localization.RequestCulture.RequestCulture(System.String)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Localization.RequestCulture` object has its :dn:prop:`Microsoft.AspNetCore.Localization.RequestCulture.Culture` and :dn:prop:`Microsoft.AspNetCore.Localization.RequestCulture.UICulture`
        properties set to the same :any:`System.Globalization.CultureInfo` value.
    
        
    
        
        :param culture: The culture for the request.
        
        :type culture: System.String
    
        
        .. code-block:: csharp
    
            public RequestCulture(string culture)
    
    .. dn:constructor:: Microsoft.AspNetCore.Localization.RequestCulture.RequestCulture(System.String, System.String)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Localization.RequestCulture` object has its :dn:prop:`Microsoft.AspNetCore.Localization.RequestCulture.Culture` and :dn:prop:`Microsoft.AspNetCore.Localization.RequestCulture.UICulture`
        properties set to the respective :any:`System.Globalization.CultureInfo` values provided.
    
        
    
        
        :param culture: The culture for the request to be used for formatting.
        
        :type culture: System.String
    
        
        :param uiCulture: The culture for the request to be used for text, i.e. language.
        
        :type uiCulture: System.String
    
        
        .. code-block:: csharp
    
            public RequestCulture(string culture, string uiCulture)
    

