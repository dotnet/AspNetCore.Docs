

TagHelperDesignTimeDescriptor Class
===================================






A metadata class containing design time information about a tag helper.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers`
Assemblies
    * Microsoft.AspNetCore.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDesignTimeDescriptor`








Syntax
------

.. code-block:: csharp

    public class TagHelperDesignTimeDescriptor








.. dn:class:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDesignTimeDescriptor
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDesignTimeDescriptor

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDesignTimeDescriptor
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDesignTimeDescriptor.OutputElementHint
    
        
    
        
        The HTML element a tag helper may output.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string OutputElementHint { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDesignTimeDescriptor.Remarks
    
        
    
        
        Remarks about how to use a tag helper.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Remarks { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDesignTimeDescriptor.Summary
    
        
    
        
        A summary of how to use a tag helper.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Summary { get; set; }
    

