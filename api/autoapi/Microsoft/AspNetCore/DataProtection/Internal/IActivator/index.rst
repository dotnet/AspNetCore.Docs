

IActivator Interface
====================






An interface into :dn:meth:`System.Activator.CreateInstance\`\`1` that also supports
limited dependency injection (of :any:`System.IServiceProvider`\).


Namespace
    :dn:ns:`Microsoft.AspNetCore.DataProtection.Internal`
Assemblies
    * Microsoft.AspNetCore.DataProtection

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IActivator








.. dn:interface:: Microsoft.AspNetCore.DataProtection.Internal.IActivator
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.DataProtection.Internal.IActivator

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.DataProtection.Internal.IActivator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.Internal.IActivator.CreateInstance(System.Type, System.String)
    
        
    
        
        Creates an instance of <em>implementationTypeName</em> and ensures
        that it is assignable to <em>expectedBaseType</em>.
    
        
    
        
        :type expectedBaseType: System.Type
    
        
        :type implementationTypeName: System.String
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            object CreateInstance(Type expectedBaseType, string implementationTypeName)
    

