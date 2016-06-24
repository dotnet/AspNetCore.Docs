

SelectList Class
================






Represents a list that lets users select a single item.
This class is typically rendered as an HTML <pre><code><select></code></pre> element with the specified collection
of :any:`Microsoft.AspNetCore.Mvc.Rendering.SelectListItem` objects.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Rendering.MultiSelectList`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Rendering.SelectList`








Syntax
------

.. code-block:: csharp

    public class SelectList : MultiSelectList, IEnumerable<SelectListItem>, IEnumerable








.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.SelectList
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.SelectList

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.SelectList
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Rendering.SelectList.SelectList(System.Collections.IEnumerable)
    
        
    
        
        :type items: System.Collections.IEnumerable
    
        
        .. code-block:: csharp
    
            public SelectList(IEnumerable items)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Rendering.SelectList.SelectList(System.Collections.IEnumerable, System.Object)
    
        
    
        
        :type items: System.Collections.IEnumerable
    
        
        :type selectedValue: System.Object
    
        
        .. code-block:: csharp
    
            public SelectList(IEnumerable items, object selectedValue)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Rendering.SelectList.SelectList(System.Collections.IEnumerable, System.String, System.String)
    
        
    
        
        :type items: System.Collections.IEnumerable
    
        
        :type dataValueField: System.String
    
        
        :type dataTextField: System.String
    
        
        .. code-block:: csharp
    
            public SelectList(IEnumerable items, string dataValueField, string dataTextField)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Rendering.SelectList.SelectList(System.Collections.IEnumerable, System.String, System.String, System.Object)
    
        
    
        
        :type items: System.Collections.IEnumerable
    
        
        :type dataValueField: System.String
    
        
        :type dataTextField: System.String
    
        
        :type selectedValue: System.Object
    
        
        .. code-block:: csharp
    
            public SelectList(IEnumerable items, string dataValueField, string dataTextField, object selectedValue)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Rendering.SelectList.SelectList(System.Collections.IEnumerable, System.String, System.String, System.Object, System.String)
    
        
    
        
        Initializes a new instance of the SelectList class by using the specified items for the list,
        the data value field, the data text field, a selected value, and the data group field.
    
        
    
        
        :param items: The items used to build each :any:`Microsoft.AspNetCore.Mvc.Rendering.SelectListItem` of the list.
        
        :type items: System.Collections.IEnumerable
    
        
        :param dataValueField: The data value field. Used to match the Value property of the corresponding 
            :any:`Microsoft.AspNetCore.Mvc.Rendering.SelectListItem`\.
        
        :type dataValueField: System.String
    
        
        :param dataTextField: The data text field. Used to match the Text property of the corresponding 
            :any:`Microsoft.AspNetCore.Mvc.Rendering.SelectListItem`\.
        
        :type dataTextField: System.String
    
        
        :param selectedValue: The selected values. Used to match the Selected property of the corresponding 
            :any:`Microsoft.AspNetCore.Mvc.Rendering.SelectListItem`\.
        
        :type selectedValue: System.Object
    
        
        :param dataGroupField: The data group field. Used to match the Group property of the corresponding 
            :any:`Microsoft.AspNetCore.Mvc.Rendering.SelectListItem`\.
        
        :type dataGroupField: System.String
    
        
        .. code-block:: csharp
    
            public SelectList(IEnumerable items, string dataValueField, string dataTextField, object selectedValue, string dataGroupField)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.SelectList
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Rendering.SelectList.SelectedValue
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public object SelectedValue { get; }
    

