

TagHelperRunner Class
=====================



.. contents:: 
   :local:



Summary
-------

A class used to run :any:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper`\s.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperRunner`








Syntax
------

.. code-block:: csharp

   public class TagHelperRunner





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor.Runtime/Runtime/TagHelpers/TagHelperRunner.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperRunner

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperRunner
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperRunner.RunAsync(Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperExecutionContext)
    
        
    
        Calls the :dn:meth:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper.ProcessAsync(Microsoft.AspNet.Razor.TagHelpers.TagHelperContext,Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput)` method on :any:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper`\s.
    
        
        
        
        :param executionContext: Contains information associated with running s.
        
        :type executionContext: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperExecutionContext
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput}
        :return: Resulting <see cref="T:Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput" /> from processing all of the
            <paramref name="executionContext" />'s <see cref="T:Microsoft.AspNet.Razor.TagHelpers.ITagHelper" />s.
    
        
        .. code-block:: csharp
    
           public Task<TagHelperOutput> RunAsync(TagHelperExecutionContext executionContext)
    

