

AntiforgerySerializationContextPooledObjectPolicy Class
=======================================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Antiforgery.Internal`
Assemblies
    * Microsoft.AspNetCore.Antiforgery

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Antiforgery.Internal.AntiforgerySerializationContextPooledObjectPolicy`








Syntax
------

.. code-block:: csharp

    public class AntiforgerySerializationContextPooledObjectPolicy : IPooledObjectPolicy<AntiforgerySerializationContext>








.. dn:class:: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgerySerializationContextPooledObjectPolicy
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgerySerializationContextPooledObjectPolicy

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgerySerializationContextPooledObjectPolicy
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgerySerializationContextPooledObjectPolicy.Create()
    
        
        :rtype: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgerySerializationContext
    
        
        .. code-block:: csharp
    
            public AntiforgerySerializationContext Create()
    
    .. dn:method:: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgerySerializationContextPooledObjectPolicy.Return(Microsoft.AspNetCore.Antiforgery.Internal.AntiforgerySerializationContext)
    
        
    
        
        :type obj: Microsoft.AspNetCore.Antiforgery.Internal.AntiforgerySerializationContext
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Return(AntiforgerySerializationContext obj)
    

