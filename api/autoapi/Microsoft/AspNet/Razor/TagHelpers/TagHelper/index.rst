

TagHelper Class
===============



.. contents:: 
   :local:



Summary
-------

Class used to filter matching HTML elements.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.TagHelpers.TagHelper`








Syntax
------

.. code-block:: csharp

   public abstract class TagHelper : ITagHelper





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor.Runtime/TagHelpers/TagHelper.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.TagHelpers.TagHelper

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.TagHelpers.TagHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.TagHelpers.TagHelper.Init(Microsoft.AspNet.Razor.TagHelpers.TagHelperContext)
    
        
        
        
        :type context: Microsoft.AspNet.Razor.TagHelpers.TagHelperContext
    
        
        .. code-block:: csharp
    
           public virtual void Init(TagHelperContext context)
    
    .. dn:method:: Microsoft.AspNet.Razor.TagHelpers.TagHelper.Process(Microsoft.AspNet.Razor.TagHelpers.TagHelperContext, Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput)
    
        
    
        Synchronously executes the :any:`Microsoft.AspNet.Razor.TagHelpers.TagHelper` with the given ``context`` and
        ``output``.
    
        
        
        
        :param context: Contains information associated with the current HTML tag.
        
        :type context: Microsoft.AspNet.Razor.TagHelpers.TagHelperContext
        
        
        :param output: A stateful HTML element used to generate an HTML tag.
        
        :type output: Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput
    
        
        .. code-block:: csharp
    
           public virtual void Process(TagHelperContext context, TagHelperOutput output)
    
    .. dn:method:: Microsoft.AspNet.Razor.TagHelpers.TagHelper.ProcessAsync(Microsoft.AspNet.Razor.TagHelpers.TagHelperContext, Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput)
    
        
    
        Asynchronously executes the :any:`Microsoft.AspNet.Razor.TagHelpers.TagHelper` with the given ``context`` and
        ``output``.
    
        
        
        
        :param context: Contains information associated with the current HTML tag.
        
        :type context: Microsoft.AspNet.Razor.TagHelpers.TagHelperContext
        
        
        :param output: A stateful HTML element used to generate an HTML tag.
        
        :type output: Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput
        :rtype: System.Threading.Tasks.Task
        :return: A <see cref="T:System.Threading.Tasks.Task" /> that on completion updates the <paramref name="output" />.
    
        
        .. code-block:: csharp
    
           public virtual Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.TagHelpers.TagHelper
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.TagHelpers.TagHelper.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public virtual int Order { get; }
    

