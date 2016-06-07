

TagHelperRequiredAttributeValueComparison Enum
==============================================






Acceptable :dn:prop:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeDescriptor.Value` comparison modes.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers`
Assemblies
    * Microsoft.AspNetCore.Razor

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public enum TagHelperRequiredAttributeValueComparison








.. dn:enumeration:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeValueComparison
    :hidden:

.. dn:enumeration:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeValueComparison

Fields
------

.. dn:enumeration:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeValueComparison
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeValueComparison.FullMatch
    
        
    
        
        HTML attribute value case sensitively matches :dn:prop:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeDescriptor.Value`\.
    
        
        :rtype: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeValueComparison
    
        
        .. code-block:: csharp
    
            FullMatch = 1
    
    .. dn:field:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeValueComparison.None
    
        
    
        
        HTML attribute value always matches :dn:prop:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeDescriptor.Value`\.
    
        
        :rtype: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeValueComparison
    
        
        .. code-block:: csharp
    
            None = 0
    
    .. dn:field:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeValueComparison.PrefixMatch
    
        
    
        
        HTML attribute value case sensitively starts with :dn:prop:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeDescriptor.Value`\.
    
        
        :rtype: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeValueComparison
    
        
        .. code-block:: csharp
    
            PrefixMatch = 2
    
    .. dn:field:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeValueComparison.SuffixMatch
    
        
    
        
        HTML attribute value case sensitively ends with :dn:prop:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeDescriptor.Value`\.
    
        
        :rtype: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeValueComparison
    
        
        .. code-block:: csharp
    
            SuffixMatch = 3
    

