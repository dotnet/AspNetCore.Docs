

TagHelper Class
===============






Class used to filter matching HTML elements.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.TagHelpers`
Assemblies
    * Microsoft.AspNetCore.Razor.Runtime

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelper`








Syntax
------

.. code-block:: csharp

    public abstract class TagHelper : ITagHelper








.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelper
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelper

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelper.Init(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext
    
        
        .. code-block:: csharp
    
            public virtual void Init(TagHelperContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelper.Process(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext, Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput)
    
        
    
        
        Synchronously executes the :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelper` with the given <em>context</em> and
        <em>output</em>.
    
        
    
        
        :param context: Contains information associated with the current HTML tag.
        
        :type context: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext
    
        
        :param output: A stateful HTML element used to generate an HTML tag.
        
        :type output: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput
    
        
        .. code-block:: csharp
    
            public virtual void Process(TagHelperContext context, TagHelperOutput output)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelper.ProcessAsync(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext, Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput)
    
        
    
        
        Asynchronously executes the :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelper` with the given <em>context</em> and
        <em>output</em>.
    
        
    
        
        :param context: Contains information associated with the current HTML tag.
        
        :type context: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext
    
        
        :param output: A stateful HTML element used to generate an HTML tag.
        
        :type output: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput
        :rtype: System.Threading.Tasks.Task
        :return: A :any:`System.Threading.Tasks.Task` that on completion updates the <em>output</em>.
    
        
        .. code-block:: csharp
    
            public virtual Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelper
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelper.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public virtual int Order { get; }
    

