

WrapperProviderContext Class
============================



.. contents:: 
   :local:



Summary
-------

The context used by an :any:`Microsoft.AspNet.Mvc.Formatters.Xml.IWrapperProvider` to wrap or un-wrap types.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Formatters.Xml.WrapperProviderContext`








Syntax
------

.. code-block:: csharp

   public class WrapperProviderContext





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Formatters.Xml/WrapperProviderContext.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Formatters.Xml.WrapperProviderContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.Xml.WrapperProviderContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Formatters.Xml.WrapperProviderContext.WrapperProviderContext(System.Type, System.Boolean)
    
        
    
        Initializes a :any:`Microsoft.AspNet.Mvc.Formatters.Xml.WrapperProviderContext`\.
    
        
        
        
        :param declaredType: The declared type of the object that needs to be wrapped.
        
        :type declaredType: System.Type
        
        
        :param isSerialization: if the wrapper provider is invoked during
            serialization, otherwise .
        
        :type isSerialization: System.Boolean
    
        
        .. code-block:: csharp
    
           public WrapperProviderContext(Type declaredType, bool isSerialization)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.Xml.WrapperProviderContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Formatters.Xml.WrapperProviderContext.DeclaredType
    
        
    
        The declared type which could be wrapped/un-wrapped by a different type
        during serialization or de-serializatoin.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
           public Type DeclaredType { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Formatters.Xml.WrapperProviderContext.IsSerialization
    
        
    
        <see langword="true" /> if a wrapper provider is invoked during serialization,
        <see langword="false" /> otherwise.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsSerialization { get; }
    

