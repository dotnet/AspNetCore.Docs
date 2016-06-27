

ModelAttributes Class
=====================






Provides access to the  combined list of attributes associated a :any:`System.Type` or property.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ModelBinding`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelAttributes`








Syntax
------

.. code-block:: csharp

    public class ModelAttributes








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelAttributes
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelAttributes

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelAttributes
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelAttributes.ModelAttributes(System.Collections.Generic.IEnumerable<System.Object>)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelAttributes` for a :any:`System.Type`\.
    
        
    
        
        :param typeAttributes: The set of attributes for the :any:`System.Type`\.
        
        :type typeAttributes: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public ModelAttributes(IEnumerable<object> typeAttributes)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelAttributes.ModelAttributes(System.Collections.Generic.IEnumerable<System.Object>, System.Collections.Generic.IEnumerable<System.Object>)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelAttributes` for a property.
    
        
    
        
        :param propertyAttributes: The set of attributes for the property.
        
        :type propertyAttributes: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.Object<System.Object>}
    
        
        :param typeAttributes: 
            The set of attributes for the property's :any:`System.Type`\. See :dn:prop:`System.Reflection.PropertyInfo.PropertyType`\.
        
        :type typeAttributes: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public ModelAttributes(IEnumerable<object> propertyAttributes, IEnumerable<object> typeAttributes)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelAttributes
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelAttributes.Attributes
    
        
    
        
        Gets the set of all attributes. If this instance represents the attributes for a property, the attributes
        on the property definition are before those on the property's :any:`System.Type`\.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public IReadOnlyList<object> Attributes { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelAttributes.PropertyAttributes
    
        
    
        
        Gets the set of attributes on the property, or <code>null</code> if this instance represents the attributes
        for a :any:`System.Type`\.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public IReadOnlyList<object> PropertyAttributes { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelAttributes.TypeAttributes
    
        
    
        
        Gets the set of attributes on the :any:`System.Type`\. If this instance represents a property,
        then :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelAttributes.TypeAttributes` contains attributes retrieved from 
        :dn:prop:`System.Reflection.PropertyInfo.PropertyType`\.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public IReadOnlyList<object> TypeAttributes { get; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelAttributes
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelAttributes.GetAttributesForProperty(System.Type, System.Reflection.PropertyInfo)
    
        
    
        
        Gets the attributes for the given <em>property</em>.
    
        
    
        
        :param type: The :any:`System.Type` in which caller found <em>property</em>.
        
        :type type: System.Type
    
        
        :param property: A :any:`System.Reflection.PropertyInfo` for which attributes need to be resolved.
        
        :type property: System.Reflection.PropertyInfo
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelAttributes
        :return: A :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelAttributes` instance with the attributes of the property.
    
        
        .. code-block:: csharp
    
            public static ModelAttributes GetAttributesForProperty(Type type, PropertyInfo property)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelAttributes.GetAttributesForType(System.Type)
    
        
    
        
        Gets the attributes for the given <em>type</em>.
    
        
    
        
        :param type: The :any:`System.Type` for which attributes need to be resolved.
        
        :type type: System.Type
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelAttributes
        :return: A :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelAttributes` instance with the attributes of the :any:`System.Type`\.
    
        
        .. code-block:: csharp
    
            public static ModelAttributes GetAttributesForType(Type type)
    

