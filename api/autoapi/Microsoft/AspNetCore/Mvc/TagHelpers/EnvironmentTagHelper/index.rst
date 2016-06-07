

EnvironmentTagHelper Class
==========================






:any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper` implementation targeting <environment> elements that conditionally renders
content based on the current value of :dn:prop:`Microsoft.AspNetCore.Hosting.IHostingEnvironment.EnvironmentName`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.TagHelpers`
Assemblies
    * Microsoft.AspNetCore.Mvc.TagHelpers

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelper`
* :dn:cls:`Microsoft.AspNetCore.Mvc.TagHelpers.EnvironmentTagHelper`








Syntax
------

.. code-block:: csharp

    public class EnvironmentTagHelper : TagHelper, ITagHelper








.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.EnvironmentTagHelper
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.EnvironmentTagHelper

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.EnvironmentTagHelper
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.EnvironmentTagHelper.HostingEnvironment
    
        
        :rtype: Microsoft.AspNetCore.Hosting.IHostingEnvironment
    
        
        .. code-block:: csharp
    
            protected IHostingEnvironment HostingEnvironment
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.EnvironmentTagHelper.Names
    
        
    
        
        A comma separated list of environment names in which the content should be rendered.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Names
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.EnvironmentTagHelper.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int Order
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.EnvironmentTagHelper
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.TagHelpers.EnvironmentTagHelper.EnvironmentTagHelper(Microsoft.AspNetCore.Hosting.IHostingEnvironment)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.TagHelpers.EnvironmentTagHelper`\.
    
        
    
        
        :param hostingEnvironment: The :any:`Microsoft.AspNetCore.Hosting.IHostingEnvironment`\.
        
        :type hostingEnvironment: Microsoft.AspNetCore.Hosting.IHostingEnvironment
    
        
        .. code-block:: csharp
    
            public EnvironmentTagHelper(IHostingEnvironment hostingEnvironment)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.EnvironmentTagHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.TagHelpers.EnvironmentTagHelper.Process(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext, Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput)
    
        
    
        
        :type context: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext
    
        
        :type output: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput
    
        
        .. code-block:: csharp
    
            public override void Process(TagHelperContext context, TagHelperOutput output)
    

