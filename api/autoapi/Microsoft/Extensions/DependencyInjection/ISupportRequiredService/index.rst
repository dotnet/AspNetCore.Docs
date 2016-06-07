

ISupportRequiredService Interface
=================================






Optional contract used by :dn:meth:`Microsoft.Extensions.DependencyInjection.ServiceProviderExtensions.GetRequiredService\`\`1(System.IServiceProvider)`
to resolve services if supported by :any:`System.IServiceProvider`\.


Namespace
    :dn:ns:`Microsoft.Extensions.DependencyInjection`
Assemblies
    * Microsoft.Extensions.DependencyInjection.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface ISupportRequiredService








.. dn:interface:: Microsoft.Extensions.DependencyInjection.ISupportRequiredService
    :hidden:

.. dn:interface:: Microsoft.Extensions.DependencyInjection.ISupportRequiredService

Methods
-------

.. dn:interface:: Microsoft.Extensions.DependencyInjection.ISupportRequiredService
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ISupportRequiredService.GetRequiredService(System.Type)
    
        
    
        
        Gets service of type <em>serviceType</em> from the :any:`System.IServiceProvider` implementing
        this interface.
    
        
    
        
        :param serviceType: An object that specifies the type of service object to get.
        
        :type serviceType: System.Type
        :rtype: System.Object
        :return: A service object of type <em>serviceType</em>.
            Throws an exception if the :any:`System.IServiceProvider` cannot create the object.
    
        
        .. code-block:: csharp
    
            object GetRequiredService(Type serviceType)
    

