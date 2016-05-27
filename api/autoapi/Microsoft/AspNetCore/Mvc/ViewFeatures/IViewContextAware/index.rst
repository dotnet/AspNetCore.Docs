

IViewContextAware Interface
===========================






Contract for contextualizing a property activated by a view with the :any:`Microsoft.AspNetCore.Mvc.Rendering.ViewContext`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ViewFeatures`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IViewContextAware








.. dn:interface:: Microsoft.AspNetCore.Mvc.ViewFeatures.IViewContextAware
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.ViewFeatures.IViewContextAware

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ViewFeatures.IViewContextAware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.IViewContextAware.Contextualize(Microsoft.AspNetCore.Mvc.Rendering.ViewContext)
    
        
    
        
        Contextualizes the instance with the specified <em>viewContext</em>.
    
        
    
        
        :param viewContext: The :any:`Microsoft.AspNetCore.Mvc.Rendering.ViewContext`\.
        
        :type viewContext: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        .. code-block:: csharp
    
            void Contextualize(ViewContext viewContext)
    

