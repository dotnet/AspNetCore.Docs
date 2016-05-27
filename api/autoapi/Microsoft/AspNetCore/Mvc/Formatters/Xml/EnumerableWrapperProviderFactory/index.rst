

EnumerableWrapperProviderFactory Class
======================================






Creates an :any:`Microsoft.AspNetCore.Mvc.Formatters.Xml.EnumerableWrapperProvider` for interface types implementing the
:any:`System.Collections.Generic.IEnumerable\`1` type.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Formatters.Xml.EnumerableWrapperProviderFactory`








Syntax
------

.. code-block:: csharp

    public class EnumerableWrapperProviderFactory : IWrapperProviderFactory








.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Xml.EnumerableWrapperProviderFactory
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Xml.EnumerableWrapperProviderFactory

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Xml.EnumerableWrapperProviderFactory
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Formatters.Xml.EnumerableWrapperProviderFactory.EnumerableWrapperProviderFactory(System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Mvc.Formatters.Xml.IWrapperProviderFactory>)
    
        
    
        
        Initializes an :any:`Microsoft.AspNetCore.Mvc.Formatters.Xml.EnumerableWrapperProviderFactory` with a list
        :any:`Microsoft.AspNetCore.Mvc.Formatters.Xml.IWrapperProviderFactory`\.
    
        
    
        
        :param wrapperProviderFactories: List of :any:`Microsoft.AspNetCore.Mvc.Formatters.Xml.IWrapperProviderFactory`\.
        
        :type wrapperProviderFactories: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Mvc.Formatters.Xml.IWrapperProviderFactory<Microsoft.AspNetCore.Mvc.Formatters.Xml.IWrapperProviderFactory>}
    
        
        .. code-block:: csharp
    
            public EnumerableWrapperProviderFactory(IEnumerable<IWrapperProviderFactory> wrapperProviderFactories)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Xml.EnumerableWrapperProviderFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.Xml.EnumerableWrapperProviderFactory.GetProvider(Microsoft.AspNetCore.Mvc.Formatters.Xml.WrapperProviderContext)
    
        
    
        
        Gets an :any:`Microsoft.AspNetCore.Mvc.Formatters.Xml.EnumerableWrapperProvider` for the provided context.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.Formatters.Xml.WrapperProviderContext`\.
        
        :type context: Microsoft.AspNetCore.Mvc.Formatters.Xml.WrapperProviderContext
        :rtype: Microsoft.AspNetCore.Mvc.Formatters.Xml.IWrapperProvider
        :return: An instance of :any:`Microsoft.AspNetCore.Mvc.Formatters.Xml.EnumerableWrapperProvider` if the declared type is
            an interface and implements :any:`System.Collections.Generic.IEnumerable\`1`\.
    
        
        .. code-block:: csharp
    
            public IWrapperProvider GetProvider(WrapperProviderContext context)
    

