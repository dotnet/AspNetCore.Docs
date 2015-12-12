

SelectList Class
================



.. contents:: 
   :local:



Summary
-------

Represents a list that lets users select a single item.
This class is typically rendered as an HTML <code>&lt;select&gt;</code> element with the specified collection
of :any:`Microsoft.AspNet.Mvc.Rendering.SelectListItem` objects.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Rendering.MultiSelectList`
* :dn:cls:`Microsoft.AspNet.Mvc.Rendering.SelectList`








Syntax
------

.. code-block:: csharp

   public class SelectList : MultiSelectList, IEnumerable<SelectListItem>, IEnumerable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.ViewFeatures/Rendering/SelectList.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Rendering.SelectList

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Rendering.SelectList
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Rendering.SelectList.SelectList(System.Collections.IEnumerable)
    
        
        
        
        :type items: System.Collections.IEnumerable
    
        
        .. code-block:: csharp
    
           public SelectList(IEnumerable items)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Rendering.SelectList.SelectList(System.Collections.IEnumerable, System.Object)
    
        
        
        
        :type items: System.Collections.IEnumerable
        
        
        :type selectedValue: System.Object
    
        
        .. code-block:: csharp
    
           public SelectList(IEnumerable items, object selectedValue)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Rendering.SelectList.SelectList(System.Collections.IEnumerable, System.String, System.String)
    
        
        
        
        :type items: System.Collections.IEnumerable
        
        
        :type dataValueField: System.String
        
        
        :type dataTextField: System.String
    
        
        .. code-block:: csharp
    
           public SelectList(IEnumerable items, string dataValueField, string dataTextField)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Rendering.SelectList.SelectList(System.Collections.IEnumerable, System.String, System.String, System.Object)
    
        
        
        
        :type items: System.Collections.IEnumerable
        
        
        :type dataValueField: System.String
        
        
        :type dataTextField: System.String
        
        
        :type selectedValue: System.Object
    
        
        .. code-block:: csharp
    
           public SelectList(IEnumerable items, string dataValueField, string dataTextField, object selectedValue)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Rendering.SelectList.SelectList(System.Collections.IEnumerable, System.String, System.String, System.Object, System.String)
    
        
    
        Initializes a new instance of the SelectList class by using the specified items for the list,
        the data value field, the data text field, a selected value, and the data group field.
    
        
        
        
        :param items: The items used to build each  of the list.
        
        :type items: System.Collections.IEnumerable
        
        
        :param dataValueField: The data value field. Used to match the Value property of the corresponding
            .
        
        :type dataValueField: System.String
        
        
        :param dataTextField: The data text field. Used to match the Text property of the corresponding
            .
        
        :type dataTextField: System.String
        
        
        :param selectedValue: The selected values. Used to match the Selected property of the corresponding
            .
        
        :type selectedValue: System.Object
        
        
        :param dataGroupField: The data group field. Used to match the Group property of the corresponding
            .
        
        :type dataGroupField: System.String
    
        
        .. code-block:: csharp
    
           public SelectList(IEnumerable items, string dataValueField, string dataTextField, object selectedValue, string dataGroupField)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Rendering.SelectList
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Rendering.SelectList.SelectedValue
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public object SelectedValue { get; }
    

