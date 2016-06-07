

CultureInfoCache Class
======================






Provides read-only cached instances of :any:`System.Globalization.CultureInfo`\.


Namespace
    :dn:ns:`Microsoft.Extensions.Globalization`
Assemblies
    * Microsoft.Extensions.Globalization.CultureInfoCache

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Globalization.CultureInfoCache`








Syntax
------

.. code-block:: csharp

    public class CultureInfoCache








.. dn:class:: Microsoft.Extensions.Globalization.CultureInfoCache
    :hidden:

.. dn:class:: Microsoft.Extensions.Globalization.CultureInfoCache

Methods
-------

.. dn:class:: Microsoft.Extensions.Globalization.CultureInfoCache
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Globalization.CultureInfoCache.GetCultureInfo(System.String, System.Collections.Generic.IList<System.Globalization.CultureInfo>)
    
        
    
        
        Gets a read-only cached :any:`System.Globalization.CultureInfo` for the specified name. Only names that exist in
        <em>supportedCultures</em> will be used.
    
        
    
        
        :param name: The culture name.
        
        :type name: System.String
    
        
        :param supportedCultures: The cultures supported by the application.
        
        :type supportedCultures: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.Globalization.CultureInfo<System.Globalization.CultureInfo>}
        :rtype: System.Globalization.CultureInfo
        :return: 
            A read-only cached :any:`System.Globalization.CultureInfo` or <code>null</code> a match wasn't found in
            <em>supportedCultures</em>.
    
        
        .. code-block:: csharp
    
            public static CultureInfo GetCultureInfo(string name, IList<CultureInfo> supportedCultures)
    

