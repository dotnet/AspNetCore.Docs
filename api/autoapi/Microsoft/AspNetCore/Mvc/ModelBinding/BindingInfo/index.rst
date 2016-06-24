

BindingInfo Class
=================






Binding info which represents metadata associated to an action parameter.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.BindingInfo`








Syntax
------

.. code-block:: csharp

    public class BindingInfo








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingInfo
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingInfo

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingInfo
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingInfo.BindingInfo()
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ModelBinding.BindingInfo`\.
    
        
    
        
        .. code-block:: csharp
    
            public BindingInfo()
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingInfo.BindingInfo(Microsoft.AspNetCore.Mvc.ModelBinding.BindingInfo)
    
        
    
        
        Creates a copy of a :any:`Microsoft.AspNetCore.Mvc.ModelBinding.BindingInfo`\.
    
        
    
        
        :param other: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.BindingInfo` to copy.
        
        :type other: Microsoft.AspNetCore.Mvc.ModelBinding.BindingInfo
    
        
        .. code-block:: csharp
    
            public BindingInfo(BindingInfo other)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingInfo
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingInfo.BinderModelName
    
        
    
        
        Gets or sets the binder model name.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string BinderModelName { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingInfo.BinderType
    
        
    
        
        Gets or sets the :any:`System.Type` of the model binder used to bind the model.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
            public Type BinderType { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingInfo.BindingSource
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource
    
        
        .. code-block:: csharp
    
            public BindingSource BindingSource { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingInfo.PropertyFilterProvider
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IPropertyFilterProvider`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.IPropertyFilterProvider
    
        
        .. code-block:: csharp
    
            public IPropertyFilterProvider PropertyFilterProvider { get; set; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingInfo
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingInfo.GetBindingInfo(System.Collections.Generic.IEnumerable<System.Object>)
    
        
    
        
        Constructs a new instance of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.BindingInfo` from the given <em>attributes</em>.
    
        
    
        
        :param attributes: A collection of attributes which are used to construct :any:`Microsoft.AspNetCore.Mvc.ModelBinding.BindingInfo`
        
        :type attributes: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.Object<System.Object>}
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.BindingInfo
        :return: A new instance of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.BindingInfo`\.
    
        
        .. code-block:: csharp
    
            public static BindingInfo GetBindingInfo(IEnumerable<object> attributes)
    

