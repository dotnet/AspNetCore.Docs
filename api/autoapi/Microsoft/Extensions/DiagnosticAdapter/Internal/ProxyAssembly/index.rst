

ProxyAssembly Class
===================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyAssembly`








Syntax
------

.. code-block:: csharp

   public class ProxyAssembly





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/eventnotification/src/Microsoft.Extensions.DiagnosticAdapter/Internal/ProxyAssembly.cs>`_





.. dn:class:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyAssembly

Methods
-------

.. dn:class:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyAssembly
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyAssembly.DefineType(System.String, System.Reflection.TypeAttributes, System.Type, System.Type[])
    
        
        
        
        :type name: System.String
        
        
        :type attributes: System.Reflection.TypeAttributes
        
        
        :type baseType: System.Type
        
        
        :type interfaces: System.Type[]
        :rtype: System.Reflection.Emit.TypeBuilder
    
        
        .. code-block:: csharp
    
           public static TypeBuilder DefineType(string name, TypeAttributes attributes, Type baseType, Type[] interfaces)
    

