

ITagHelper Interface
====================






Contract used to filter matching HTML elements.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.TagHelpers`
Assemblies
    * Microsoft.AspNetCore.Razor.Runtime

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface ITagHelper








.. dn:interface:: Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper.Init(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext)
    
        
    
        
        Initializes the :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper` with the given <em>context</em>. Additions to 
        :dn:prop:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext.Items` should be done within this method to ensure they're added prior to
        executing the children.
    
        
    
        
        :param context: Contains information associated with the current HTML tag.
        
        :type context: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext
    
        
        .. code-block:: csharp
    
            void Init(TagHelperContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper.ProcessAsync(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext, Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput)
    
        
    
        
        Asynchronously executes the :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper` with the given <em>context</em> and
        <em>output</em>.
    
        
    
        
        :param context: Contains information associated with the current HTML tag.
        
        :type context: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext
    
        
        :param output: A stateful HTML element used to generate an HTML tag.
        
        :type output: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput
        :rtype: System.Threading.Tasks.Task
        :return: A :any:`System.Threading.Tasks.Task` that on completion updates the <em>output</em>.
    
        
        .. code-block:: csharp
    
            Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper.Order
    
        
    
        
        When a set of :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper` s are executed, their :dn:meth:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper.Init(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext)`\'s
        are first invoked in the specified :dn:prop:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper.Order`\; then their 
        :dn:meth:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper.ProcessAsync(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext,Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput)`\'s are invoked in the specified 
        :dn:prop:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper.Order`\. Lower values are executed first.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            int Order { get; }
    

