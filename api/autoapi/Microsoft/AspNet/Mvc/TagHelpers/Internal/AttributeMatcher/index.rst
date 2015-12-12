

AttributeMatcher Class
======================



.. contents:: 
   :local:



Summary
-------

Methods for determining how an :any:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper` should run based on the attributes that were specified.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.TagHelpers.Internal.AttributeMatcher`








Syntax
------

.. code-block:: csharp

   public class AttributeMatcher





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.TagHelpers/Internal/AttributeMatcher.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.Internal.AttributeMatcher

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.Internal.AttributeMatcher
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.TagHelpers.Internal.AttributeMatcher.DetermineMode<TMode>(Microsoft.AspNet.Razor.TagHelpers.TagHelperContext, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Mvc.TagHelpers.Internal.ModeAttributes<TMode>>)
    
        
    
        Determines the modes a :any:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper` can run in based on which modes have all their required
        attributes present, non null, non empty, and non whitepsace.
    
        
        
        
        :param context: The .
        
        :type context: Microsoft.AspNet.Razor.TagHelpers.TagHelperContext
        
        
        :param modeInfos: The modes and their required attributes.
        
        :type modeInfos: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.TagHelpers.Internal.ModeAttributes{{TMode}}}
        :rtype: Microsoft.AspNet.Mvc.TagHelpers.Internal.ModeMatchResult{{TMode}}
        :return: The <see cref="T:Microsoft.AspNet.Mvc.TagHelpers.Internal.ModeMatchResult`1" />.
    
        
        .. code-block:: csharp
    
           public static ModeMatchResult<TMode> DetermineMode<TMode>(TagHelperContext context, IEnumerable<ModeAttributes<TMode>> modeInfos)
    

