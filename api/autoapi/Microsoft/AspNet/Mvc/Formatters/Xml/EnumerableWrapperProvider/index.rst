

EnumerableWrapperProvider Class
===============================



.. contents:: 
   :local:



Summary
-------

Provides a :any:`Microsoft.AspNet.Mvc.Formatters.Xml.IWrapperProvider` for interface types which implement 
:any:`System.Collections.Generic.IEnumerable\`1`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Formatters.Xml.EnumerableWrapperProvider`








Syntax
------

.. code-block:: csharp

   public class EnumerableWrapperProvider : IWrapperProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Formatters.Xml/EnumerableWrapperProvider.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Formatters.Xml.EnumerableWrapperProvider

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.Xml.EnumerableWrapperProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Formatters.Xml.EnumerableWrapperProvider.EnumerableWrapperProvider(System.Type, Microsoft.AspNet.Mvc.Formatters.Xml.IWrapperProvider)
    
        
    
        Initializes an instance of :any:`Microsoft.AspNet.Mvc.Formatters.Xml.EnumerableWrapperProvider`\.
    
        
        
        
        :param sourceEnumerableOfT: Type of the original
            that is being wrapped.
        
        :type sourceEnumerableOfT: System.Type
        
        
        :param elementWrapperProvider: The  for the element type.
            Can be null.
        
        :type elementWrapperProvider: Microsoft.AspNet.Mvc.Formatters.Xml.IWrapperProvider
    
        
        .. code-block:: csharp
    
           public EnumerableWrapperProvider(Type sourceEnumerableOfT, IWrapperProvider elementWrapperProvider)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.Xml.EnumerableWrapperProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.Xml.EnumerableWrapperProvider.Wrap(System.Object)
    
        
        
        
        :type original: System.Object
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public object Wrap(object original)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.Xml.EnumerableWrapperProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Formatters.Xml.EnumerableWrapperProvider.WrappingType
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
           public Type WrappingType { get; }
    

