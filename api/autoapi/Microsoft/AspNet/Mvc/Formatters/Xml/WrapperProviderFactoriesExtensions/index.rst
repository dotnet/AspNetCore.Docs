

WrapperProviderFactoriesExtensions Class
========================================



.. contents:: 
   :local:



Summary
-------

Extension methods for :any:`Microsoft.AspNet.Mvc.Formatters.Xml.IWrapperProviderFactory`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Formatters.Xml.WrapperProviderFactoriesExtensions`








Syntax
------

.. code-block:: csharp

   public class WrapperProviderFactoriesExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Formatters.Xml/WrapperProviderFactoriesExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Formatters.Xml.WrapperProviderFactoriesExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.Xml.WrapperProviderFactoriesExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.Xml.WrapperProviderFactoriesExtensions.GetWrapperProvider(System.Collections.Generic.IEnumerable<Microsoft.AspNet.Mvc.Formatters.Xml.IWrapperProviderFactory>, Microsoft.AspNet.Mvc.Formatters.Xml.WrapperProviderContext)
    
        
    
        Gets an instance of :any:`Microsoft.AspNet.Mvc.Formatters.Xml.IWrapperProvider` for the supplied
        type.
    
        
        
        
        :param wrapperProviderFactories: A list of .
        
        :type wrapperProviderFactories: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.Formatters.Xml.IWrapperProviderFactory}
        
        
        :param wrapperProviderContext: The .
        
        :type wrapperProviderContext: Microsoft.AspNet.Mvc.Formatters.Xml.WrapperProviderContext
        :rtype: Microsoft.AspNet.Mvc.Formatters.Xml.IWrapperProvider
        :return: An instance of <see cref="T:Microsoft.AspNet.Mvc.Formatters.Xml.IWrapperProvider" /> if there is a wrapping provider for the
            supplied type, else null.
    
        
        .. code-block:: csharp
    
           public static IWrapperProvider GetWrapperProvider(IEnumerable<IWrapperProviderFactory> wrapperProviderFactories, WrapperProviderContext wrapperProviderContext)
    

