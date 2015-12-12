

PartialModeMatchLogValues<TMode> Class
======================================



.. contents:: 
   :local:



Summary
-------

Log values for :any:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper` instances that opt out of
processing due to missing attributes for one of several possible modes.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.TagHelpers.Internal.PartialModeMatchLogValues\<TMode>`








Syntax
------

.. code-block:: csharp

   public class PartialModeMatchLogValues<TMode> : ILogValues





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.TagHelpers/Internal/PartialModeMatchLogValuesOfT.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.Internal.PartialModeMatchLogValues<TMode>

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.Internal.PartialModeMatchLogValues<TMode>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.TagHelpers.Internal.PartialModeMatchLogValues<TMode>.PartialModeMatchLogValues(System.String, System.String, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Mvc.TagHelpers.Internal.ModeMatchAttributes<TMode>>)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.TagHelpers.Internal.PartialModeMatchLogValues\`1`\.
    
        
        
        
        :param uniqueId: The unique ID of the HTML element this message applies to.
        
        :type uniqueId: System.String
        
        
        :param viewPath: The path to the view.
        
        :type viewPath: System.String
        
        
        :param partialMatches: The set of modes with partial required attributes.
        
        :type partialMatches: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.TagHelpers.Internal.ModeMatchAttributes{{TMode}}}
    
        
        .. code-block:: csharp
    
           public PartialModeMatchLogValues(string uniqueId, string viewPath, IEnumerable<ModeMatchAttributes<TMode>> partialMatches)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.Internal.PartialModeMatchLogValues<TMode>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.TagHelpers.Internal.PartialModeMatchLogValues<TMode>.GetValues()
    
        
        :rtype: System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{System.String,System.Object}}
    
        
        .. code-block:: csharp
    
           public IEnumerable<KeyValuePair<string, object>> GetValues()
    
    .. dn:method:: Microsoft.AspNet.Mvc.TagHelpers.Internal.PartialModeMatchLogValues<TMode>.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string ToString()
    

