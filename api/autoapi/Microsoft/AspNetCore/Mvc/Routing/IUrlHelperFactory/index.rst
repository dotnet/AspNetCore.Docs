

IUrlHelperFactory Interface
===========================






A factory for creating :any:`Microsoft.AspNetCore.Mvc.IUrlHelper` instances.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Routing`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IUrlHelperFactory








.. dn:interface:: Microsoft.AspNetCore.Mvc.Routing.IUrlHelperFactory
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Routing.IUrlHelperFactory

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Routing.IUrlHelperFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Routing.IUrlHelperFactory.GetUrlHelper(Microsoft.AspNetCore.Mvc.ActionContext)
    
        
    
        
        Gets an :any:`Microsoft.AspNetCore.Mvc.IUrlHelper` for the request associated with <em>context</em>.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.ActionContext` associated with the current request.
        
        :type context: Microsoft.AspNetCore.Mvc.ActionContext
        :rtype: Microsoft.AspNetCore.Mvc.IUrlHelper
        :return: An :any:`Microsoft.AspNetCore.Mvc.IUrlHelper` for the request associated with <em>context</em>
    
        
        .. code-block:: csharp
    
            IUrlHelper GetUrlHelper(ActionContext context)
    

