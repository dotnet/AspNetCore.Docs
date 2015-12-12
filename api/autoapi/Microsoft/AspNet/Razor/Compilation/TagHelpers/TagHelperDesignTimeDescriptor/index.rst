

TagHelperDesignTimeDescriptor Class
===================================



.. contents:: 
   :local:



Summary
-------

A metadata class containing design time information about a tag helper.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDesignTimeDescriptor`








Syntax
------

.. code-block:: csharp

   public class TagHelperDesignTimeDescriptor





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor/Compilation/TagHelpers/TagHelperDesignTimeDescriptor.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDesignTimeDescriptor

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDesignTimeDescriptor
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDesignTimeDescriptor.OutputElementHint
    
        
    
        The HTML element a tag helper may output.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string OutputElementHint { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDesignTimeDescriptor.Remarks
    
        
    
        Remarks about how to use a tag helper.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Remarks { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDesignTimeDescriptor.Summary
    
        
    
        A summary of how to use a tag helper.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Summary { get; set; }
    

