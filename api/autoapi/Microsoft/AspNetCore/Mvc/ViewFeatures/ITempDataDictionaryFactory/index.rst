

ITempDataDictionaryFactory Interface
====================================






A factory which provides access to an :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionary` instance
for a request.


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

    public interface ITempDataDictionaryFactory








.. dn:interface:: Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionaryFactory
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionaryFactory

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionaryFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionaryFactory.GetTempData(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        Gets or creates an :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionary` instance for the request associated with the
        given <em>context</em>.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Http.HttpContext`\.
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionary
        :return: 
            An :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionary` instance for the request associated with the given
            <em>context</em>.
    
        
        .. code-block:: csharp
    
            ITempDataDictionary GetTempData(HttpContext context)
    

