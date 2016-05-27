

IFormatFilter Interface
=======================






A filter that produces the desired content type for the request.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Formatters.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IFormatFilter : IFilterMetadata








.. dn:interface:: Microsoft.AspNetCore.Mvc.Formatters.Internal.IFormatFilter
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Formatters.Internal.IFormatFilter

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Formatters.Internal.IFormatFilter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.Internal.IFormatFilter.GetFormat(Microsoft.AspNetCore.Mvc.ActionContext)
    
        
    
        
        Gets the format value for the request associated with the provided :any:`Microsoft.AspNetCore.Mvc.ActionContext`\.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.ActionContext` associated with the current request.
        
        :type context: Microsoft.AspNetCore.Mvc.ActionContext
        :rtype: System.String
        :return: A format value, or <code>null</code> if a format cannot be determined for the request.
    
        
        .. code-block:: csharp
    
            string GetFormat(ActionContext context)
    

