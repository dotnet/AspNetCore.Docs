

IWrapperProviderFactory Interface
=================================






Create a :any:`Microsoft.AspNetCore.Mvc.Formatters.Xml.IWrapperProvider` given a :any:`Microsoft.AspNetCore.Mvc.Formatters.Xml.WrapperProviderContext`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Formatters.Xml`
Assemblies
    * Microsoft.AspNetCore.Mvc.Formatters.Xml

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IWrapperProviderFactory








.. dn:interface:: Microsoft.AspNetCore.Mvc.Formatters.Xml.IWrapperProviderFactory
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Formatters.Xml.IWrapperProviderFactory

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Formatters.Xml.IWrapperProviderFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.Xml.IWrapperProviderFactory.GetProvider(Microsoft.AspNetCore.Mvc.Formatters.Xml.WrapperProviderContext)
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.Formatters.Xml.IWrapperProvider` for the provided context.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.Formatters.Xml.WrapperProviderContext`\.
        
        :type context: Microsoft.AspNetCore.Mvc.Formatters.Xml.WrapperProviderContext
        :rtype: Microsoft.AspNetCore.Mvc.Formatters.Xml.IWrapperProvider
        :return: A wrapping provider if the factory decides to wrap the type, else <code>null</code>.
    
        
        .. code-block:: csharp
    
            IWrapperProvider GetProvider(WrapperProviderContext context)
    

