

ValidationHelpers Class
=======================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ViewFeatures.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ValidationHelpers`








Syntax
------

.. code-block:: csharp

    public class ValidationHelpers








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ValidationHelpers
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ValidationHelpers

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ValidationHelpers
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ValidationHelpers.GetModelErrorMessageOrDefault(Microsoft.AspNetCore.Mvc.ModelBinding.ModelError)
    
        
    
        
        :type modelError: Microsoft.AspNetCore.Mvc.ModelBinding.ModelError
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string GetModelErrorMessageOrDefault(ModelError modelError)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ValidationHelpers.GetModelErrorMessageOrDefault(Microsoft.AspNetCore.Mvc.ModelBinding.ModelError, Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry, Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer)
    
        
    
        
        :type modelError: Microsoft.AspNetCore.Mvc.ModelBinding.ModelError
    
        
        :type containingEntry: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry
    
        
        :type modelExplorer: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string GetModelErrorMessageOrDefault(ModelError modelError, ModelStateEntry containingEntry, ModelExplorer modelExplorer)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ValidationHelpers.GetModelStateList(Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary, System.Boolean)
    
        
    
        
        :type viewData: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary
    
        
        :type excludePropertyErrors: System.Boolean
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry<Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry>}
    
        
        .. code-block:: csharp
    
            public static IList<ModelStateEntry> GetModelStateList(ViewDataDictionary viewData, bool excludePropertyErrors)
    

