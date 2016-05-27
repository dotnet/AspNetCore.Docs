

SelectListItem Class
====================






Represents an item in a :any:`Microsoft.AspNetCore.Mvc.Rendering.SelectList` or :any:`Microsoft.AspNetCore.Mvc.Rendering.MultiSelectList`\.
This class is typically rendered as an HTML <pre><code><option></code></pre> element with the specified
attribute values.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Rendering`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Rendering.SelectListItem`








Syntax
------

.. code-block:: csharp

    public class SelectListItem








.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.SelectListItem

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Rendering.SelectListItem.Disabled
    
        
    
        
        Gets or sets a value that indicates whether this :any:`Microsoft.AspNetCore.Mvc.Rendering.SelectListItem` is disabled.
        This property is typically rendered as a <pre><code>disabled="disabled"</code></pre> attribute in the HTML
        <pre><code><option></code></pre> element.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Disabled
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Rendering.SelectListItem.Group
    
        
    
        
        Represents the optgroup HTML element this item is wrapped into.
        In a select list, multiple groups with the same name are supported.
        They are compared with reference equality.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.SelectListGroup
    
        
        .. code-block:: csharp
    
            public SelectListGroup Group
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Rendering.SelectListItem.Selected
    
        
    
        
        Gets or sets a value that indicates whether this :any:`Microsoft.AspNetCore.Mvc.Rendering.SelectListItem` is selected.
        This property is typically rendered as a <pre><code>selected="selected"</code></pre> attribute in the HTML
        <pre><code><option></code></pre> element.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Selected
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Rendering.SelectListItem.Text
    
        
    
        
        Gets or sets a value that indicates the display text of this :any:`Microsoft.AspNetCore.Mvc.Rendering.SelectListItem`\.
        This property is typically rendered as the inner HTML in the HTML <pre><code><option></code></pre> element.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Text
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Rendering.SelectListItem.Value
    
        
    
        
        Gets or sets a value that indicates the value of this :any:`Microsoft.AspNetCore.Mvc.Rendering.SelectListItem`\.
        This property is typically rendered as a <pre><code>value="..."</code></pre> attribute in the HTML
        <pre><code><option></code></pre> element.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Value
            {
                get;
                set;
            }
    

