

CultureInfoCache Class
======================



.. contents:: 
   :local:



Summary
-------

Provides read-only cached instances of :any:`System.Globalization.CultureInfo`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Globalization.CultureInfoCache`








Syntax
------

.. code-block:: csharp

   public class CultureInfoCache





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/localization/src/Microsoft.Extensions.Globalization.CultureInfoCache/CultureInfoCache.cs>`_





.. dn:class:: Microsoft.Extensions.Globalization.CultureInfoCache

Methods
-------

.. dn:class:: Microsoft.Extensions.Globalization.CultureInfoCache
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Globalization.CultureInfoCache.GetCultureInfo(System.String, System.Collections.Generic.IList<System.Globalization.CultureInfo>)
    
        
    
        Gets a read-only cached :any:`System.Globalization.CultureInfo` for the specified name. Only names that exist in
        ``supportedCultures`` will be used.
    
        
        
        
        :param name: The culture name.
        
        :type name: System.String
        
        
        :param supportedCultures: The cultures supported by the application.
        
        :type supportedCultures: System.Collections.Generic.IList{System.Globalization.CultureInfo}
        :rtype: System.Globalization.CultureInfo
        :return: A read-only cached <see cref="T:System.Globalization.CultureInfo" /> or <c>null</c> a match wasn't found in
            <paramref name="supportedCultures" />.
    
        
        .. code-block:: csharp
    
           public static CultureInfo GetCultureInfo(string name, IList<CultureInfo> supportedCultures)
    

