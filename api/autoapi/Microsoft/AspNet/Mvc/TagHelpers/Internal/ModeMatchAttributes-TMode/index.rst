

ModeMatchAttributes<TMode> Class
================================



.. contents:: 
   :local:



Summary
-------

A mapping of a :any:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper` mode to its missing and present attributes.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.TagHelpers.Internal.ModeMatchAttributes\<TMode>`








Syntax
------

.. code-block:: csharp

   public class ModeMatchAttributes<TMode>





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.TagHelpers/Internal/ModeMatchAttributesOfT.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.Internal.ModeMatchAttributes<TMode>

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.Internal.ModeMatchAttributes<TMode>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.Internal.ModeMatchAttributes<TMode>.MissingAttributes
    
        
    
        The names of attributes that were missing in this match.
    
        
        :rtype: System.Collections.Generic.IEnumerable{System.String}
    
        
        .. code-block:: csharp
    
           public IEnumerable<string> MissingAttributes { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.Internal.ModeMatchAttributes<TMode>.Mode
    
        
    
        The :any:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper`\'s mode.
    
        
        :rtype: {TMode}
    
        
        .. code-block:: csharp
    
           public TMode Mode { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.Internal.ModeMatchAttributes<TMode>.PresentAttributes
    
        
    
        The names of attributes that were present in this match.
    
        
        :rtype: System.Collections.Generic.IEnumerable{System.String}
    
        
        .. code-block:: csharp
    
           public IEnumerable<string> PresentAttributes { get; set; }
    

