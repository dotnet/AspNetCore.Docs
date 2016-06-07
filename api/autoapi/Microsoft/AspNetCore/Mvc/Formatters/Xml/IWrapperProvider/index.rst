

IWrapperProvider Interface
==========================






Defines an interface for wrapping objects for serialization or deserialization into xml.


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

    public interface IWrapperProvider








.. dn:interface:: Microsoft.AspNetCore.Mvc.Formatters.Xml.IWrapperProvider
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Formatters.Xml.IWrapperProvider

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Formatters.Xml.IWrapperProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Formatters.Xml.IWrapperProvider.WrappingType
    
        
    
        
        Gets the wrapping type.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
            Type WrappingType
            {
                get;
            }
    

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Formatters.Xml.IWrapperProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.Xml.IWrapperProvider.Wrap(System.Object)
    
        
    
        
        Wraps the given object to the wrapping type provided by :dn:prop:`Microsoft.AspNetCore.Mvc.Formatters.Xml.IWrapperProvider.WrappingType`\.
    
        
    
        
        :param original: The original non-wrapped object.
        
        :type original: System.Object
        :rtype: System.Object
        :return: Returns a wrapped object.
    
        
        .. code-block:: csharp
    
            object Wrap(object original)
    

