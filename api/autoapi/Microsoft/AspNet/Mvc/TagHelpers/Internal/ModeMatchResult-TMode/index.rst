

ModeMatchResult<TMode> Class
============================



.. contents:: 
   :local:



Summary
-------

Result of determining the mode an :any:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper` will run in.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.TagHelpers.Internal.ModeMatchResult\<TMode>`








Syntax
------

.. code-block:: csharp

   public class ModeMatchResult<TMode>





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.TagHelpers/Internal/ModeMatchResult.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.Internal.ModeMatchResult<TMode>

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.Internal.ModeMatchResult<TMode>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.TagHelpers.Internal.ModeMatchResult<TMode>.LogDetails<TTagHelper>(Microsoft.Extensions.Logging.ILogger, TTagHelper, System.String, System.String)
    
        
    
        Logs the details of the :any:`Microsoft.AspNet.Mvc.TagHelpers.Internal.ModeMatchResult\`1`\.
    
        
        
        
        :param logger: The .
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        
        
        :param tagHelper: The .
        
        :type tagHelper: {TTagHelper}
        
        
        :param uniqueId: The value of .
        
        :type uniqueId: System.String
        
        
        :param viewPath: The path to the view the  is on.
        
        :type viewPath: System.String
    
        
        .. code-block:: csharp
    
           public void LogDetails<TTagHelper>(ILogger logger, TTagHelper tagHelper, string uniqueId, string viewPath)where TTagHelper : ITagHelper
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.Internal.ModeMatchResult<TMode>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.Internal.ModeMatchResult<TMode>.FullMatches
    
        
    
        Modes that had all attributes present.
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.TagHelpers.Internal.ModeMatchAttributes{{TMode}}}
    
        
        .. code-block:: csharp
    
           public IList<ModeMatchAttributes<TMode>> FullMatches { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.Internal.ModeMatchResult<TMode>.PartialMatches
    
        
    
        Modes that were missing attributes but had at least one attribute present.
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.TagHelpers.Internal.ModeMatchAttributes{{TMode}}}
    
        
        .. code-block:: csharp
    
           public IList<ModeMatchAttributes<TMode>> PartialMatches { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.Internal.ModeMatchResult<TMode>.PartiallyMatchedAttributes
    
        
    
        Attributes that are present in at least one mode in :dn:prop:`Microsoft.AspNet.Mvc.TagHelpers.Internal.ModeMatchResult\`1.PartialMatches`\, but in no modes in 
        :dn:prop:`Microsoft.AspNet.Mvc.TagHelpers.Internal.ModeMatchResult\`1.FullMatches`\.
    
        
        :rtype: System.Collections.Generic.IList{System.String}
    
        
        .. code-block:: csharp
    
           public IList<string> PartiallyMatchedAttributes { get; }
    

