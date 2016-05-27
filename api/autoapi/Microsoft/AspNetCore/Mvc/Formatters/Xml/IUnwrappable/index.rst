

IUnwrappable Interface
======================






Defines an interface for objects to be un-wrappable after deserialization.


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

    public interface IUnwrappable








.. dn:interface:: Microsoft.AspNetCore.Mvc.Formatters.Xml.IUnwrappable
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Formatters.Xml.IUnwrappable

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Formatters.Xml.IUnwrappable
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.Xml.IUnwrappable.Unwrap(System.Type)
    
        
    
        
        Unwraps an object.
    
        
    
        
        :param declaredType: The type to which the object should be un-wrapped to.
        
        :type declaredType: System.Type
        :rtype: System.Object
        :return: The un-wrapped object.
    
        
        .. code-block:: csharp
    
            object Unwrap(Type declaredType)
    

