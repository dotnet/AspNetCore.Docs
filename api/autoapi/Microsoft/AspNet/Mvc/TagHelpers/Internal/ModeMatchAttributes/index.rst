

ModeMatchAttributes Class
=========================



.. contents:: 
   :local:



Summary
-------

Static creation methods for :any:`Microsoft.AspNet.Mvc.TagHelpers.Internal.ModeMatchAttributes\`1`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.TagHelpers.Internal.ModeMatchAttributes`








Syntax
------

.. code-block:: csharp

   public class ModeMatchAttributes





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.TagHelpers/Internal/ModeMatchAttributes.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.Internal.ModeMatchAttributes

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.Internal.ModeMatchAttributes
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.TagHelpers.Internal.ModeMatchAttributes.Create<TMode>(TMode, System.Collections.Generic.IEnumerable<System.String>)
    
        
    
        Creates an :any:`Microsoft.AspNet.Mvc.TagHelpers.Internal.ModeMatchAttributes\`1`\.
    
        
        
        
        :type mode: {TMode}
        
        
        :type presentAttributes: System.Collections.Generic.IEnumerable{System.String}
        :rtype: Microsoft.AspNet.Mvc.TagHelpers.Internal.ModeMatchAttributes{{TMode}}
    
        
        .. code-block:: csharp
    
           public static ModeMatchAttributes<TMode> Create<TMode>(TMode mode, IEnumerable<string> presentAttributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.TagHelpers.Internal.ModeMatchAttributes.Create<TMode>(TMode, System.Collections.Generic.IEnumerable<System.String>, System.Collections.Generic.IEnumerable<System.String>)
    
        
    
        Creates an :any:`Microsoft.AspNet.Mvc.TagHelpers.Internal.ModeMatchAttributes\`1`\.
    
        
        
        
        :type mode: {TMode}
        
        
        :type presentAttributes: System.Collections.Generic.IEnumerable{System.String}
        
        
        :type missingAttributes: System.Collections.Generic.IEnumerable{System.String}
        :rtype: Microsoft.AspNet.Mvc.TagHelpers.Internal.ModeMatchAttributes{{TMode}}
    
        
        .. code-block:: csharp
    
           public static ModeMatchAttributes<TMode> Create<TMode>(TMode mode, IEnumerable<string> presentAttributes, IEnumerable<string> missingAttributes)
    

