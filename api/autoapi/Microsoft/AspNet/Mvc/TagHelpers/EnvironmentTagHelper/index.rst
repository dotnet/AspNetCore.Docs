

EnvironmentTagHelper Class
==========================



.. contents:: 
   :local:



Summary
-------

:any:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper` implementation targeting &lt;environment&gt; elements that conditionally renders
content based on the current value of :dn:prop:`Microsoft.AspNet.Hosting.IHostingEnvironment.EnvironmentName`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.TagHelpers.TagHelper`
* :dn:cls:`Microsoft.AspNet.Mvc.TagHelpers.EnvironmentTagHelper`








Syntax
------

.. code-block:: csharp

   public class EnvironmentTagHelper : TagHelper, ITagHelper





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.TagHelpers/EnvironmentTagHelper.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.EnvironmentTagHelper

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.EnvironmentTagHelper
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.TagHelpers.EnvironmentTagHelper.EnvironmentTagHelper(Microsoft.AspNet.Hosting.IHostingEnvironment)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.TagHelpers.EnvironmentTagHelper`\.
    
        
        
        
        :param hostingEnvironment: The .
        
        :type hostingEnvironment: Microsoft.AspNet.Hosting.IHostingEnvironment
    
        
        .. code-block:: csharp
    
           public EnvironmentTagHelper(IHostingEnvironment hostingEnvironment)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.EnvironmentTagHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.TagHelpers.EnvironmentTagHelper.Process(Microsoft.AspNet.Razor.TagHelpers.TagHelperContext, Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput)
    
        
        
        
        :type context: Microsoft.AspNet.Razor.TagHelpers.TagHelperContext
        
        
        :type output: Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput
    
        
        .. code-block:: csharp
    
           public override void Process(TagHelperContext context, TagHelperOutput output)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.EnvironmentTagHelper
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.EnvironmentTagHelper.HostingEnvironment
    
        
        :rtype: Microsoft.AspNet.Hosting.IHostingEnvironment
    
        
        .. code-block:: csharp
    
           protected IHostingEnvironment HostingEnvironment { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.EnvironmentTagHelper.Names
    
        
    
        A comma separated list of environment names in which the content should be rendered.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Names { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.EnvironmentTagHelper.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int Order { get; }
    

