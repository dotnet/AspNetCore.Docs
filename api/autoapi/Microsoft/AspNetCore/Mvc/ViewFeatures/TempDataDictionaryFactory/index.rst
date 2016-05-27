

TempDataDictionaryFactory Class
===============================






A default implementation of :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionaryFactory`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ViewFeatures`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewFeatures.TempDataDictionaryFactory`








Syntax
------

.. code-block:: csharp

    public class TempDataDictionaryFactory : ITempDataDictionaryFactory








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.TempDataDictionaryFactory
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.TempDataDictionaryFactory

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.TempDataDictionaryFactory
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ViewFeatures.TempDataDictionaryFactory.TempDataDictionaryFactory(Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataProvider)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.TempDataDictionaryFactory`\.
    
        
    
        
        :param provider: The :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataProvider`\.
        
        :type provider: Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataProvider
    
        
        .. code-block:: csharp
    
            public TempDataDictionaryFactory(ITempDataProvider provider)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.TempDataDictionaryFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.TempDataDictionaryFactory.GetTempData(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionary
    
        
        .. code-block:: csharp
    
            public ITempDataDictionary GetTempData(HttpContext context)
    

