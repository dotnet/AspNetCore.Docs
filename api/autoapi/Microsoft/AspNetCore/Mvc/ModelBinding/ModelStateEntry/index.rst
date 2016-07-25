

ModelStateEntry Class
=====================






An entry in a :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ModelBinding`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry`








Syntax
------

.. code-block:: csharp

    public abstract class ModelStateEntry








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry.AttemptedValue
    
        
    
        
        Gets the set of values contained in :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry.RawValue`\, joined into a comma-separated string.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string AttemptedValue { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry.Children
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry` values for sub-properties.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry<Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry>}
    
        
        .. code-block:: csharp
    
            public abstract IReadOnlyList<ModelStateEntry> Children { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry.Errors
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelErrorCollection` for this entry.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelErrorCollection
    
        
        .. code-block:: csharp
    
            public ModelErrorCollection Errors { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry.IsContainerNode
    
        
    
        
        Gets a value that determines if the current instance of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry` is a container node.
        Container nodes represent prefix nodes that aren't explicitly added to the 
        :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary`\.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public abstract bool IsContainerNode { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry.RawValue
    
        
    
        
        Gets the raw value from the request associated with this entry.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public object RawValue { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry.ValidationState
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState` for this entry.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState
    
        
        .. code-block:: csharp
    
            public ModelValidationState ValidationState { get; set; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry.GetModelStateForProperty(System.String)
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry` for a sub-property with the specified <em>propertyName</em>.
    
        
    
        
        :param propertyName: The property name to lookup.
        
        :type propertyName: System.String
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry
        :return: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry` if a sub-property was found; otherwise <code>null</code>.
    
        
        .. code-block:: csharp
    
            public abstract ModelStateEntry GetModelStateForProperty(string propertyName)
    

