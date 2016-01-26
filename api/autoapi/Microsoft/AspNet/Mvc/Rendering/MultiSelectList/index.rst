

MultiSelectList Class
=====================



.. contents:: 
   :local:



Summary
-------

Represents a list that lets users select multiple items.
This class is typically rendered as an HTML <code>&lt;select multiple="multiple"&gt;</code> element with the specified collection
of :any:`Microsoft.AspNet.Mvc.Rendering.SelectListItem` objects.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Rendering.MultiSelectList`








Syntax
------

.. code-block:: csharp

   public class MultiSelectList : IEnumerable<SelectListItem>, IEnumerable





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ViewFeatures/Rendering/MultiSelectList.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Rendering.MultiSelectList

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Rendering.MultiSelectList
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Rendering.MultiSelectList.MultiSelectList(System.Collections.IEnumerable)
    
        
        
        
        :type items: System.Collections.IEnumerable
    
        
        .. code-block:: csharp
    
           public MultiSelectList(IEnumerable items)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Rendering.MultiSelectList.MultiSelectList(System.Collections.IEnumerable, System.Collections.IEnumerable)
    
        
        
        
        :type items: System.Collections.IEnumerable
        
        
        :type selectedValues: System.Collections.IEnumerable
    
        
        .. code-block:: csharp
    
           public MultiSelectList(IEnumerable items, IEnumerable selectedValues)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Rendering.MultiSelectList.MultiSelectList(System.Collections.IEnumerable, System.String, System.String)
    
        
        
        
        :type items: System.Collections.IEnumerable
        
        
        :type dataValueField: System.String
        
        
        :type dataTextField: System.String
    
        
        .. code-block:: csharp
    
           public MultiSelectList(IEnumerable items, string dataValueField, string dataTextField)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Rendering.MultiSelectList.MultiSelectList(System.Collections.IEnumerable, System.String, System.String, System.Collections.IEnumerable)
    
        
        
        
        :type items: System.Collections.IEnumerable
        
        
        :type dataValueField: System.String
        
        
        :type dataTextField: System.String
        
        
        :type selectedValues: System.Collections.IEnumerable
    
        
        .. code-block:: csharp
    
           public MultiSelectList(IEnumerable items, string dataValueField, string dataTextField, IEnumerable selectedValues)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Rendering.MultiSelectList.MultiSelectList(System.Collections.IEnumerable, System.String, System.String, System.Collections.IEnumerable, System.String)
    
        
    
        Initializes a new instance of the MultiSelectList class by using the items to include in the list,
        the data value field, the data text field, the selected values, and the data group field.
    
        
        
        
        :param items: The items used to build each  of the list.
        
        :type items: System.Collections.IEnumerable
        
        
        :param dataValueField: The data value field. Used to match the Value property of the corresponding
            .
        
        :type dataValueField: System.String
        
        
        :param dataTextField: The data text field. Used to match the Text property of the corresponding
            .
        
        :type dataTextField: System.String
        
        
        :param selectedValues: The selected values field. Used to match the Selected property of the
            corresponding .
        
        :type selectedValues: System.Collections.IEnumerable
        
        
        :param dataGroupField: The data group field. Used to match the Group property of the corresponding
            .
        
        :type dataGroupField: System.String
    
        
        .. code-block:: csharp
    
           public MultiSelectList(IEnumerable items, string dataValueField, string dataTextField, IEnumerable selectedValues, string dataGroupField)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Rendering.MultiSelectList
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.MultiSelectList.GetEnumerator()
    
        
        :rtype: System.Collections.Generic.IEnumerator{Microsoft.AspNet.Mvc.Rendering.SelectListItem}
    
        
        .. code-block:: csharp
    
           public virtual IEnumerator<SelectListItem> GetEnumerator()
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.MultiSelectList.System.Collections.IEnumerable.GetEnumerator()
    
        
        :rtype: System.Collections.IEnumerator
    
        
        .. code-block:: csharp
    
           IEnumerator IEnumerable.GetEnumerator()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Rendering.MultiSelectList
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Rendering.MultiSelectList.DataGroupField
    
        
    
        Gets or sets the data group field.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string DataGroupField { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Rendering.MultiSelectList.DataTextField
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string DataTextField { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Rendering.MultiSelectList.DataValueField
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string DataValueField { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Rendering.MultiSelectList.Items
    
        
        :rtype: System.Collections.IEnumerable
    
        
        .. code-block:: csharp
    
           public IEnumerable Items { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Rendering.MultiSelectList.SelectedValues
    
        
        :rtype: System.Collections.IEnumerable
    
        
        .. code-block:: csharp
    
           public IEnumerable SelectedValues { get; }
    

