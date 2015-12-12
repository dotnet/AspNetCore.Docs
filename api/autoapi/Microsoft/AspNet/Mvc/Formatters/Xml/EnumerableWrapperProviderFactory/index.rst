

EnumerableWrapperProviderFactory Class
======================================



.. contents:: 
   :local:



Summary
-------

Creates an :any:`Microsoft.AspNet.Mvc.Formatters.Xml.EnumerableWrapperProvider` for interface types implementing the 
:any:`System.Collections.Generic.IEnumerable\`1` type.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Formatters.Xml.EnumerableWrapperProviderFactory`








Syntax
------

.. code-block:: csharp

   public class EnumerableWrapperProviderFactory : IWrapperProviderFactory





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Formatters.Xml/EnumerableWrapperProviderFactory.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Formatters.Xml.EnumerableWrapperProviderFactory

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.Xml.EnumerableWrapperProviderFactory
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Formatters.Xml.EnumerableWrapperProviderFactory.EnumerableWrapperProviderFactory(System.Collections.Generic.IEnumerable<Microsoft.AspNet.Mvc.Formatters.Xml.IWrapperProviderFactory>)
    
        
    
        Initializes an :any:`Microsoft.AspNet.Mvc.Formatters.Xml.EnumerableWrapperProviderFactory` with a list 
        :any:`Microsoft.AspNet.Mvc.Formatters.Xml.IWrapperProviderFactory`\.
    
        
        
        
        :param wrapperProviderFactories: List of .
        
        :type wrapperProviderFactories: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.Formatters.Xml.IWrapperProviderFactory}
    
        
        .. code-block:: csharp
    
           public EnumerableWrapperProviderFactory(IEnumerable<IWrapperProviderFactory> wrapperProviderFactories)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.Xml.EnumerableWrapperProviderFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.Xml.EnumerableWrapperProviderFactory.GetProvider(Microsoft.AspNet.Mvc.Formatters.Xml.WrapperProviderContext)
    
        
    
        Gets an :any:`Microsoft.AspNet.Mvc.Formatters.Xml.EnumerableWrapperProvider` for the provided context.
    
        
        
        
        :param context: The .
        
        :type context: Microsoft.AspNet.Mvc.Formatters.Xml.WrapperProviderContext
        :rtype: Microsoft.AspNet.Mvc.Formatters.Xml.IWrapperProvider
        :return: An instance of <see cref="T:Microsoft.AspNet.Mvc.Formatters.Xml.EnumerableWrapperProvider" /> if the declared type is
            an interface and implements <see cref="T:System.Collections.Generic.IEnumerable`1" />.
    
        
        .. code-block:: csharp
    
           public IWrapperProvider GetProvider(WrapperProviderContext context)
    

