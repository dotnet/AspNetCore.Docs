

SerializableErrorWrapperProviderFactory Class
=============================================






Creates an :any:`Microsoft.AspNetCore.Mvc.Formatters.Xml.IWrapperProvider` for the type :any:`Microsoft.AspNetCore.Mvc.SerializableError`\.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Formatters.Xml.SerializableErrorWrapperProviderFactory`








Syntax
------

.. code-block:: csharp

    public class SerializableErrorWrapperProviderFactory : IWrapperProviderFactory








.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Xml.SerializableErrorWrapperProviderFactory
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Xml.SerializableErrorWrapperProviderFactory

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Xml.SerializableErrorWrapperProviderFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.Xml.SerializableErrorWrapperProviderFactory.GetProvider(Microsoft.AspNetCore.Mvc.Formatters.Xml.WrapperProviderContext)
    
        
    
        
        Creates an instance of :any:`Microsoft.AspNetCore.Mvc.Formatters.Xml.SerializableErrorWrapperProvider` if the provided
        <em>context</em>'s :dn:prop:`Microsoft.AspNetCore.Mvc.Formatters.Xml.WrapperProviderContext.DeclaredType` is 
        :any:`Microsoft.AspNetCore.Mvc.SerializableError`\.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.Formatters.Xml.WrapperProviderContext`\.
        
        :type context: Microsoft.AspNetCore.Mvc.Formatters.Xml.WrapperProviderContext
        :rtype: Microsoft.AspNetCore.Mvc.Formatters.Xml.IWrapperProvider
        :return: 
            An instance of :any:`Microsoft.AspNetCore.Mvc.Formatters.Xml.SerializableErrorWrapperProvider` if the provided <em>context</em>'s 
            :dn:prop:`Microsoft.AspNetCore.Mvc.Formatters.Xml.WrapperProviderContext.DeclaredType` is 
            :any:`Microsoft.AspNetCore.Mvc.SerializableError`\; otherwise <code>null</code>.
    
        
        .. code-block:: csharp
    
            public IWrapperProvider GetProvider(WrapperProviderContext context)
    

