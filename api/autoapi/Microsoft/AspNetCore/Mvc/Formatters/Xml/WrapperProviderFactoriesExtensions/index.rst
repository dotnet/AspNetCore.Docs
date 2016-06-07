

WrapperProviderFactoriesExtensions Class
========================================






Extension methods for :any:`Microsoft.AspNetCore.Mvc.Formatters.Xml.IWrapperProviderFactory`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Formatters.Xml`
Assemblies
    * Microsoft.AspNetCore.Mvc.Formatters.Xml

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Formatters.Xml.WrapperProviderFactoriesExtensions`








Syntax
------

.. code-block:: csharp

    public class WrapperProviderFactoriesExtensions








.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Xml.WrapperProviderFactoriesExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Xml.WrapperProviderFactoriesExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Xml.WrapperProviderFactoriesExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.Xml.WrapperProviderFactoriesExtensions.GetWrapperProvider(System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Mvc.Formatters.Xml.IWrapperProviderFactory>, Microsoft.AspNetCore.Mvc.Formatters.Xml.WrapperProviderContext)
    
        
    
        
        Gets an instance of :any:`Microsoft.AspNetCore.Mvc.Formatters.Xml.IWrapperProvider` for the supplied
        type.
    
        
    
        
        :param wrapperProviderFactories: A list of :any:`Microsoft.AspNetCore.Mvc.Formatters.Xml.IWrapperProviderFactory`\.
        
        :type wrapperProviderFactories: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Mvc.Formatters.Xml.IWrapperProviderFactory<Microsoft.AspNetCore.Mvc.Formatters.Xml.IWrapperProviderFactory>}
    
        
        :param wrapperProviderContext: The :any:`Microsoft.AspNetCore.Mvc.Formatters.Xml.WrapperProviderContext`\.
        
        :type wrapperProviderContext: Microsoft.AspNetCore.Mvc.Formatters.Xml.WrapperProviderContext
        :rtype: Microsoft.AspNetCore.Mvc.Formatters.Xml.IWrapperProvider
        :return: An instance of :any:`Microsoft.AspNetCore.Mvc.Formatters.Xml.IWrapperProvider` if there is a wrapping provider for the
            supplied type, else null.
    
        
        .. code-block:: csharp
    
            public static IWrapperProvider GetWrapperProvider(IEnumerable<IWrapperProviderFactory> wrapperProviderFactories, WrapperProviderContext wrapperProviderContext)
    

