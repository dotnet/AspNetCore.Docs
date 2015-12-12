

IWrapperProviderFactory Interface
=================================



.. contents:: 
   :local:



Summary
-------

Create a :any:`Microsoft.AspNet.Mvc.Formatters.Xml.IWrapperProvider` given a :any:`Microsoft.AspNet.Mvc.Formatters.Xml.WrapperProviderContext`\.











Syntax
------

.. code-block:: csharp

   public interface IWrapperProviderFactory





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Formatters.Xml/IWrapperProviderFactory.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Formatters.Xml.IWrapperProviderFactory

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.Formatters.Xml.IWrapperProviderFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.Xml.IWrapperProviderFactory.GetProvider(Microsoft.AspNet.Mvc.Formatters.Xml.WrapperProviderContext)
    
        
    
        Gets the :any:`Microsoft.AspNet.Mvc.Formatters.Xml.IWrapperProvider` for the provided context.
    
        
        
        
        :param context: The .
        
        :type context: Microsoft.AspNet.Mvc.Formatters.Xml.WrapperProviderContext
        :rtype: Microsoft.AspNet.Mvc.Formatters.Xml.IWrapperProvider
        :return: A wrapping provider if the factory decides to wrap the type, else <c>null</c>.
    
        
        .. code-block:: csharp
    
           IWrapperProvider GetProvider(WrapperProviderContext context)
    

