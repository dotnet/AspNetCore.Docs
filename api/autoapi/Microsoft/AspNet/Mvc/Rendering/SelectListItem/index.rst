

SelectListItem Class
====================



.. contents:: 
   :local:



Summary
-------

Represents an item in a :any:`Microsoft.AspNet.Mvc.Rendering.SelectList` or :any:`Microsoft.AspNet.Mvc.Rendering.MultiSelectList`\.
This class is typically rendered as an HTML <code>&lt;option&gt;</code> element with the specified
attribute values.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Rendering.SelectListItem`








Syntax
------

.. code-block:: csharp

   public class SelectListItem





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.ViewFeatures/Rendering/SelectListItem.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Rendering.SelectListItem

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Rendering.SelectListItem
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Rendering.SelectListItem.Disabled
    
        
    
        Gets or sets a value that indicates whether this :any:`Microsoft.AspNet.Mvc.Rendering.SelectListItem` is disabled.
        This property is typically rendered as a <code>disabled="disabled"</code> attribute in the HTML
        <code>&lt;option&gt;</code> element.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Disabled { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Rendering.SelectListItem.Group
    
        
    
        Represents the optgroup HTML element this item is wrapped into.
        In a select list, multiple groups with the same name are supported.
        They are compared with reference equality.
    
        
        :rtype: Microsoft.AspNet.Mvc.Rendering.SelectListGroup
    
        
        .. code-block:: csharp
    
           public SelectListGroup Group { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Rendering.SelectListItem.Selected
    
        
    
        Gets or sets a value that indicates whether this :any:`Microsoft.AspNet.Mvc.Rendering.SelectListItem` is selected.
        This property is typically rendered as a <code>selected="selected"</code> attribute in the HTML
        <code>&lt;option&gt;</code> element.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Selected { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Rendering.SelectListItem.Text
    
        
    
        Gets or sets a value that indicates the display text of this :any:`Microsoft.AspNet.Mvc.Rendering.SelectListItem`\.
        This property is typically rendered as the inner HTML in the HTML <code>&lt;option&gt;</code> element.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Text { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Rendering.SelectListItem.Value
    
        
    
        Gets or sets a value that indicates the value of this :any:`Microsoft.AspNet.Mvc.Rendering.SelectListItem`\.
        This property is typically rendered as a <code>value="..."</code> attribute in the HTML
        <code>&lt;option&gt;</code> element.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Value { get; set; }
    

