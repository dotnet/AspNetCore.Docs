

TagHelperRequiredAttributeNameComparison Enum
=============================================






Acceptable :dn:prop:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeDescriptor.Name` comparison modes.


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

    public enum TagHelperRequiredAttributeNameComparison








.. dn:enumeration:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeNameComparison
    :hidden:

.. dn:enumeration:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeNameComparison

Fields
------

.. dn:enumeration:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeNameComparison
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeNameComparison.FullMatch
    
        
    
        
        HTML attribute name case insensitively matches :dn:prop:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeDescriptor.Name`\.
    
        
        :rtype: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeNameComparison
    
        
        .. code-block:: csharp
    
            FullMatch = 0
    
    .. dn:field:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeNameComparison.PrefixMatch
    
        
    
        
        HTML attribute name case insensitively starts with :dn:prop:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeDescriptor.Name`\.
    
        
        :rtype: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeNameComparison
    
        
        .. code-block:: csharp
    
            PrefixMatch = 1
    

