

RequestCulture Class
====================



.. contents:: 
   :local:



Summary
-------

Details about the culture for an :any:`Microsoft.AspNet.Http.HttpRequest`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Localization.RequestCulture`








Syntax
------

.. code-block:: csharp

   public class RequestCulture





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/localization/src/Microsoft.AspNet.Localization/RequestCulture.cs>`_





.. dn:class:: Microsoft.AspNet.Localization.RequestCulture

Constructors
------------

.. dn:class:: Microsoft.AspNet.Localization.RequestCulture
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Localization.RequestCulture.RequestCulture(System.Globalization.CultureInfo)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Localization.RequestCulture` object has its :dn:prop:`Microsoft.AspNet.Localization.RequestCulture.Culture` and :dn:prop:`Microsoft.AspNet.Localization.RequestCulture.UICulture`
        properties set to the same :any:`System.Globalization.CultureInfo` value.
    
        
        
        
        :param culture: The  for the request.
        
        :type culture: System.Globalization.CultureInfo
    
        
        .. code-block:: csharp
    
           public RequestCulture(CultureInfo culture)
    
    .. dn:constructor:: Microsoft.AspNet.Localization.RequestCulture.RequestCulture(System.Globalization.CultureInfo, System.Globalization.CultureInfo)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Localization.RequestCulture` object has its :dn:prop:`Microsoft.AspNet.Localization.RequestCulture.Culture` and :dn:prop:`Microsoft.AspNet.Localization.RequestCulture.UICulture`
        properties set to the respective :any:`System.Globalization.CultureInfo` values provided.
    
        
        
        
        :param culture: The  for the request to be used for formatting.
        
        :type culture: System.Globalization.CultureInfo
        
        
        :param uiCulture: The  for the request to be used for text, i.e. language.
        
        :type uiCulture: System.Globalization.CultureInfo
    
        
        .. code-block:: csharp
    
           public RequestCulture(CultureInfo culture, CultureInfo uiCulture)
    
    .. dn:constructor:: Microsoft.AspNet.Localization.RequestCulture.RequestCulture(System.String)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Localization.RequestCulture` object has its :dn:prop:`Microsoft.AspNet.Localization.RequestCulture.Culture` and :dn:prop:`Microsoft.AspNet.Localization.RequestCulture.UICulture`
        properties set to the same :any:`System.Globalization.CultureInfo` value.
    
        
        
        
        :param culture: The culture for the request.
        
        :type culture: System.String
    
        
        .. code-block:: csharp
    
           public RequestCulture(string culture)
    
    .. dn:constructor:: Microsoft.AspNet.Localization.RequestCulture.RequestCulture(System.String, System.String)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Localization.RequestCulture` object has its :dn:prop:`Microsoft.AspNet.Localization.RequestCulture.Culture` and :dn:prop:`Microsoft.AspNet.Localization.RequestCulture.UICulture`
        properties set to the respective :any:`System.Globalization.CultureInfo` values provided.
    
        
        
        
        :param culture: The culture for the request to be used for formatting.
        
        :type culture: System.String
        
        
        :param uiCulture: The culture for the request to be used for text, i.e. language.
        
        :type uiCulture: System.String
    
        
        .. code-block:: csharp
    
           public RequestCulture(string culture, string uiCulture)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Localization.RequestCulture
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Localization.RequestCulture.Culture
    
        
    
        Gets the :any:`System.Globalization.CultureInfo` for the request to be used for formatting.
    
        
        :rtype: System.Globalization.CultureInfo
    
        
        .. code-block:: csharp
    
           public CultureInfo Culture { get; }
    
    .. dn:property:: Microsoft.AspNet.Localization.RequestCulture.UICulture
    
        
    
        Gets the :any:`System.Globalization.CultureInfo` for the request to be used for text, i.e. language;
    
        
        :rtype: System.Globalization.CultureInfo
    
        
        .. code-block:: csharp
    
           public CultureInfo UICulture { get; }
    

