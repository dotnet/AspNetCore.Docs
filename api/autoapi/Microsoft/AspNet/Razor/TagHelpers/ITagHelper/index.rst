

ITagHelper Interface
====================



.. contents:: 
   :local:



Summary
-------

Contract used to filter matching HTML elements.











Syntax
------

.. code-block:: csharp

   public interface ITagHelper





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor.Runtime/TagHelpers/ITagHelper.cs>`_





.. dn:interface:: Microsoft.AspNet.Razor.TagHelpers.ITagHelper

Methods
-------

.. dn:interface:: Microsoft.AspNet.Razor.TagHelpers.ITagHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.TagHelpers.ITagHelper.Init(Microsoft.AspNet.Razor.TagHelpers.TagHelperContext)
    
        
    
        Initializes the :any:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper` with the given ``context``. Additions to 
        :dn:prop:`Microsoft.AspNet.Razor.TagHelpers.TagHelperContext.Items` should be done within this method to ensure they're added prior to
        executing the children.
    
        
        
        
        :param context: Contains information associated with the current HTML tag.
        
        :type context: Microsoft.AspNet.Razor.TagHelpers.TagHelperContext
    
        
        .. code-block:: csharp
    
           void Init(TagHelperContext context)
    
    .. dn:method:: Microsoft.AspNet.Razor.TagHelpers.ITagHelper.ProcessAsync(Microsoft.AspNet.Razor.TagHelpers.TagHelperContext, Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput)
    
        
    
        Asynchronously executes the :any:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper` with the given ``context`` and
        ``output``.
    
        
        
        
        :param context: Contains information associated with the current HTML tag.
        
        :type context: Microsoft.AspNet.Razor.TagHelpers.TagHelperContext
        
        
        :param output: A stateful HTML element used to generate an HTML tag.
        
        :type output: Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput
        :rtype: System.Threading.Tasks.Task
        :return: A <see cref="T:System.Threading.Tasks.Task" /> that on completion updates the <paramref name="output" />.
    
        
        .. code-block:: csharp
    
           Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    

Properties
----------

.. dn:interface:: Microsoft.AspNet.Razor.TagHelpers.ITagHelper
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.TagHelpers.ITagHelper.Order
    
        
    
        When a set of :any:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper` s are executed, their :dn:meth:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper.Init(Microsoft.AspNet.Razor.TagHelpers.TagHelperContext)`\'s
        are first invoked in the specified :dn:prop:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper.Order`\; then their 
        :dn:meth:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper.ProcessAsync(Microsoft.AspNet.Razor.TagHelpers.TagHelperContext,Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput)`\'s are invoked in the specified 
        :dn:prop:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper.Order`\. Lower values are executed first.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           int Order { get; }
    

