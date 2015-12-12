

ModeAttributes<TMode> Class
===========================



.. contents:: 
   :local:



Summary
-------

A mapping of a :any:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper` mode to its required attributes.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.TagHelpers.Internal.ModeAttributes\<TMode>`








Syntax
------

.. code-block:: csharp

   public class ModeAttributes<TMode>





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.TagHelpers/Internal/ModeAttributesOfT.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.Internal.ModeAttributes<TMode>

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.Internal.ModeAttributes<TMode>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.Internal.ModeAttributes<TMode>.Attributes
    
        
    
        The names of attributes required for this mode.
    
        
        :rtype: System.Collections.Generic.IEnumerable{System.String}
    
        
        .. code-block:: csharp
    
           public IEnumerable<string> Attributes { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.Internal.ModeAttributes<TMode>.Mode
    
        
    
        The :any:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper`\'s mode.
    
        
        :rtype: {TMode}
    
        
        .. code-block:: csharp
    
           public TMode Mode { get; set; }
    

