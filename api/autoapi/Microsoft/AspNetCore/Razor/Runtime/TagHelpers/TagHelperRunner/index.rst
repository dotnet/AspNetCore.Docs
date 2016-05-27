

TagHelperRunner Class
=====================






A class used to run :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper`\s.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.Runtime.TagHelpers`
Assemblies
    * Microsoft.AspNetCore.Razor.Runtime

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner`








Syntax
------

.. code-block:: csharp

    public class TagHelperRunner








.. dn:class:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner.RunAsync(Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext)
    
        
    
        
        Calls the :dn:meth:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper.ProcessAsync(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext,Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput)` method on :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper`\s.
    
        
    
        
        :param executionContext: Contains information associated with running :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper`\s.
            
        
        :type executionContext: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext
        :rtype: System.Threading.Tasks.Task
        :return: Resulting :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput` from processing all of the
            <em>executionContext</em>'s :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper`\s.
    
        
        .. code-block:: csharp
    
            public Task RunAsync(TagHelperExecutionContext executionContext)
    

