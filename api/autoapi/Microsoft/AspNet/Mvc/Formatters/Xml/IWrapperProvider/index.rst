

IWrapperProvider Interface
==========================



.. contents:: 
   :local:



Summary
-------

Defines an interface for wrapping objects for serialization or deserialization into xml.











Syntax
------

.. code-block:: csharp

   public interface IWrapperProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Formatters.Xml/IWrapperProvider.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Formatters.Xml.IWrapperProvider

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.Formatters.Xml.IWrapperProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.Xml.IWrapperProvider.Wrap(System.Object)
    
        
    
        Wraps the given object to the wrapping type provided by :dn:prop:`Microsoft.AspNet.Mvc.Formatters.Xml.IWrapperProvider.WrappingType`\.
    
        
        
        
        :param original: The original non-wrapped object.
        
        :type original: System.Object
        :rtype: System.Object
        :return: Returns a wrapped object.
    
        
        .. code-block:: csharp
    
           object Wrap(object original)
    

Properties
----------

.. dn:interface:: Microsoft.AspNet.Mvc.Formatters.Xml.IWrapperProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Formatters.Xml.IWrapperProvider.WrappingType
    
        
    
        Gets the wrapping type.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
           Type WrappingType { get; }
    

