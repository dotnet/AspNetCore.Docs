

IHtmlLocalizer Interface
========================



.. contents:: 
   :local:



Summary
-------

This service does not HTML encode the resource string. It HTML encodes all arguments that are formatted in
the resource string.











Syntax
------

.. code-block:: csharp

   public interface IHtmlLocalizer : IStringLocalizer





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Localization/IHtmlLocalizer.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Localization.IHtmlLocalizer

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.Localization.IHtmlLocalizer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Localization.IHtmlLocalizer.Html(System.String)
    
        
    
        Gets the :any:`Microsoft.AspNet.Mvc.Localization.LocalizedHtmlString` resource for a specific key.
    
        
        
        
        :param key: The key to use.
        
        :type key: System.String
        :rtype: Microsoft.AspNet.Mvc.Localization.LocalizedHtmlString
        :return: The <see cref="T:Microsoft.AspNet.Mvc.Localization.LocalizedHtmlString" /> resource.
    
        
        .. code-block:: csharp
    
           LocalizedHtmlString Html(string key)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Localization.IHtmlLocalizer.Html(System.String, System.Object[])
    
        
    
        Gets the :any:`Microsoft.AspNet.Mvc.Localization.LocalizedHtmlString` resource for a specific key.
    
        
        
        
        :param key: The key to use.
        
        :type key: System.String
        
        
        :param arguments: The values to format the string with.
        
        :type arguments: System.Object[]
        :rtype: Microsoft.AspNet.Mvc.Localization.LocalizedHtmlString
        :return: The <see cref="T:Microsoft.AspNet.Mvc.Localization.LocalizedHtmlString" /> resource.
    
        
        .. code-block:: csharp
    
           LocalizedHtmlString Html(string key, params object[] arguments)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Localization.IHtmlLocalizer.WithCulture(System.Globalization.CultureInfo)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.Localization.HtmlLocalizer` for a specific :any:`System.Globalization.CultureInfo`\.
    
        
        
        
        :param culture: The  to use.
        
        :type culture: System.Globalization.CultureInfo
        :rtype: Microsoft.AspNet.Mvc.Localization.IHtmlLocalizer
        :return: A culture-specific <see cref="T:Microsoft.AspNet.Mvc.Localization.IHtmlLocalizer" />.
    
        
        .. code-block:: csharp
    
           IHtmlLocalizer WithCulture(CultureInfo culture)
    

