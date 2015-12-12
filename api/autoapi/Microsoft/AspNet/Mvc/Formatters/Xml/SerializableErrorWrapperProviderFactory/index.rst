

SerializableErrorWrapperProviderFactory Class
=============================================



.. contents:: 
   :local:



Summary
-------

Creates an :any:`Microsoft.AspNet.Mvc.Formatters.Xml.IWrapperProvider` for the type :any:`Microsoft.AspNet.Mvc.SerializableError`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Formatters.Xml.SerializableErrorWrapperProviderFactory`








Syntax
------

.. code-block:: csharp

   public class SerializableErrorWrapperProviderFactory : IWrapperProviderFactory





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Formatters.Xml/SerializableErrorWrapperProviderFactory.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Formatters.Xml.SerializableErrorWrapperProviderFactory

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.Xml.SerializableErrorWrapperProviderFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.Xml.SerializableErrorWrapperProviderFactory.GetProvider(Microsoft.AspNet.Mvc.Formatters.Xml.WrapperProviderContext)
    
        
    
        Creates an instance of :any:`Microsoft.AspNet.Mvc.Formatters.Xml.SerializableErrorWrapperProvider` if the provided
        ``context``'s :dn:prop:`Microsoft.AspNet.Mvc.Formatters.Xml.WrapperProviderContext.DeclaredType` is 
        :any:`Microsoft.AspNet.Mvc.SerializableError`\.
    
        
        
        
        :param context: The .
        
        :type context: Microsoft.AspNet.Mvc.Formatters.Xml.WrapperProviderContext
        :rtype: Microsoft.AspNet.Mvc.Formatters.Xml.IWrapperProvider
        :return: An instance of <see cref="T:Microsoft.AspNet.Mvc.Formatters.Xml.SerializableErrorWrapperProvider" /> if the provided <paramref name="context" />'s
            <see cref="P:Microsoft.AspNet.Mvc.Formatters.Xml.WrapperProviderContext.DeclaredType" /> is
            <see cref="T:Microsoft.AspNet.Mvc.SerializableError" />; otherwise <c>null</c>.
    
        
        .. code-block:: csharp
    
           public IWrapperProvider GetProvider(WrapperProviderContext context)
    

