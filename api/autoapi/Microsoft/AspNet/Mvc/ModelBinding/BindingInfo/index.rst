

BindingInfo Class
=================



.. contents:: 
   :local:



Summary
-------

Binding info which represents metadata associated to an action parameter.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.BindingInfo`








Syntax
------

.. code-block:: csharp

   public class BindingInfo





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Abstractions/ModelBinding/BindingInfo.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.BindingInfo

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.BindingInfo
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.BindingInfo.BindingInfo()
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.ModelBinding.BindingInfo`\.
    
        
    
        
        .. code-block:: csharp
    
           public BindingInfo()
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.BindingInfo.BindingInfo(Microsoft.AspNet.Mvc.ModelBinding.BindingInfo)
    
        
    
        Creates a copy of a :any:`Microsoft.AspNet.Mvc.ModelBinding.BindingInfo`\.
    
        
        
        
        :param other: The  to copy.
        
        :type other: Microsoft.AspNet.Mvc.ModelBinding.BindingInfo
    
        
        .. code-block:: csharp
    
           public BindingInfo(BindingInfo other)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.BindingInfo
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.BindingInfo.GetBindingInfo(System.Collections.Generic.IEnumerable<System.Object>)
    
        
    
        Constructs a new instance of :any:`Microsoft.AspNet.Mvc.ModelBinding.BindingInfo` from the given ``attributes``.
    
        
        
        
        :param attributes: A collection of attributes which are used to construct
        
        :type attributes: System.Collections.Generic.IEnumerable{System.Object}
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.BindingInfo
        :return: A new instance of <see cref="T:Microsoft.AspNet.Mvc.ModelBinding.BindingInfo" />.
    
        
        .. code-block:: csharp
    
           public static BindingInfo GetBindingInfo(IEnumerable<object> attributes)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.BindingInfo
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.BindingInfo.BinderModelName
    
        
    
        Gets or sets the binder model name.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string BinderModelName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.BindingInfo.BinderType
    
        
    
        Gets or sets the :any:`System.Type` of the model binder used to bind the model.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
           public Type BinderType { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.BindingInfo.BindingSource
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Mvc.ModelBinding.BindingSource`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.BindingSource
    
        
        .. code-block:: csharp
    
           public BindingSource BindingSource { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.BindingInfo.PropertyBindingPredicateProvider
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Mvc.ModelBinding.IPropertyBindingPredicateProvider`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.IPropertyBindingPredicateProvider
    
        
        .. code-block:: csharp
    
           public IPropertyBindingPredicateProvider PropertyBindingPredicateProvider { get; set; }
    

