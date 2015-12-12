

IUnwrappable Interface
======================



.. contents:: 
   :local:



Summary
-------

Defines an interface for objects to be un-wrappable after deserialization.











Syntax
------

.. code-block:: csharp

   public interface IUnwrappable





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Formatters.Xml/IUnwrappable.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Formatters.Xml.IUnwrappable

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.Formatters.Xml.IUnwrappable
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.Xml.IUnwrappable.Unwrap(System.Type)
    
        
    
        Unwraps an object.
    
        
        
        
        :param declaredType: The type to which the object should be un-wrapped to.
        
        :type declaredType: System.Type
        :rtype: System.Object
        :return: The un-wrapped object.
    
        
        .. code-block:: csharp
    
           object Unwrap(Type declaredType)
    

