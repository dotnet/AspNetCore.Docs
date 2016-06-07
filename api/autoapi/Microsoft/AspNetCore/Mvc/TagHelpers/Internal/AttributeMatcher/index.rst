

AttributeMatcher Class
======================






Methods for determining how an :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper` should run based on the attributes that were specified.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.TagHelpers.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.TagHelpers

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.TagHelpers.Internal.AttributeMatcher`








Syntax
------

.. code-block:: csharp

    public class AttributeMatcher








.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.Internal.AttributeMatcher
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.Internal.AttributeMatcher

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.Internal.AttributeMatcher
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.TagHelpers.Internal.AttributeMatcher.TryDetermineMode<TMode>(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext, System.Collections.Generic.IReadOnlyList<Microsoft.AspNetCore.Mvc.TagHelpers.Internal.ModeAttributes<TMode>>, System.Func<TMode, TMode, System.Int32>, out TMode)
    
        
    
        
        Determines the most effective mode a :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper` can run in based on which modes have
        all their required attributes present.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext`\.
        
        :type context: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext
    
        
        :param modeInfos: The modes and their required attributes.
        
        :type modeInfos: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Mvc.TagHelpers.Internal.ModeAttributes<Microsoft.AspNetCore.Mvc.TagHelpers.Internal.ModeAttributes`1>{TMode}}
    
        
        :param compare: A comparer delegate.
        
        :type compare: System.Func<System.Func`3>{TMode, TMode, System.Int32<System.Int32>}
    
        
        :param result: The resulting most effective mode.
        
        :type result: TMode
        :rtype: System.Boolean
        :return: <code>true</code> if a mode was determined, otherwise <code>false</code>.
    
        
        .. code-block:: csharp
    
            public static bool TryDetermineMode<TMode>(TagHelperContext context, IReadOnlyList<ModeAttributes<TMode>> modeInfos, Func<TMode, TMode, int> compare, out TMode result)
    

