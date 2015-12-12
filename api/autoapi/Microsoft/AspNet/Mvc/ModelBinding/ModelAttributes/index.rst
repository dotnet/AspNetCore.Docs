

ModelAttributes Class
=====================



.. contents:: 
   :local:



Summary
-------

Provides access to the  combined list of attributes associated a :any:`System.Type` or property.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.ModelAttributes`








Syntax
------

.. code-block:: csharp

   public class ModelAttributes





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/ModelBinding/Metadata/ModelAttributes.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.ModelAttributes

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.ModelAttributes
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.ModelAttributes.ModelAttributes(System.Collections.Generic.IEnumerable<System.Object>)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelAttributes` for a :any:`System.Type`\.
    
        
        
        
        :param typeAttributes: The set of attributes for the .
        
        :type typeAttributes: System.Collections.Generic.IEnumerable{System.Object}
    
        
        .. code-block:: csharp
    
           public ModelAttributes(IEnumerable<object> typeAttributes)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.ModelAttributes.ModelAttributes(System.Collections.Generic.IEnumerable<System.Object>, System.Collections.Generic.IEnumerable<System.Object>)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelAttributes` for a property.
    
        
        
        
        :param propertyAttributes: The set of attributes for the property.
        
        :type propertyAttributes: System.Collections.Generic.IEnumerable{System.Object}
        
        
        :param typeAttributes: The set of attributes for the property's . See .
        
        :type typeAttributes: System.Collections.Generic.IEnumerable{System.Object}
    
        
        .. code-block:: csharp
    
           public ModelAttributes(IEnumerable<object> propertyAttributes, IEnumerable<object> typeAttributes)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.ModelAttributes
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelAttributes.GetAttributesForProperty(System.Type, System.Reflection.PropertyInfo)
    
        
    
        Gets the attributes for the given ``property``.
    
        
        
        
        :param type: The  in which caller found .
        
        :type type: System.Type
        
        
        :param property: A  for which attributes need to be resolved.
        
        :type property: System.Reflection.PropertyInfo
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.ModelAttributes
        :return: A <see cref="T:Microsoft.AspNet.Mvc.ModelBinding.ModelAttributes" /> instance with the attributes of the property.
    
        
        .. code-block:: csharp
    
           public static ModelAttributes GetAttributesForProperty(Type type, PropertyInfo property)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelAttributes.GetAttributesForType(System.Type)
    
        
    
        Gets the attributes for the given ``type``.
    
        
        
        
        :param type: The  for which attributes need to be resolved.
        
        :type type: System.Type
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.ModelAttributes
        :return: A <see cref="T:Microsoft.AspNet.Mvc.ModelBinding.ModelAttributes" /> instance with the attributes of the <see cref="T:System.Type" />.
    
        
        .. code-block:: csharp
    
           public static ModelAttributes GetAttributesForType(Type type)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.ModelAttributes
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelAttributes.Attributes
    
        
    
        Gets the set of all attributes. If this instance represents the attributes for a property, the attributes
        on the property definition are before those on the property's :any:`System.Type`\.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList{System.Object}
    
        
        .. code-block:: csharp
    
           public IReadOnlyList<object> Attributes { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelAttributes.PropertyAttributes
    
        
    
        Gets the set of attributes on the property, or <c>null</c> if this instance represents the attributes
        for a :any:`System.Type`\.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList{System.Object}
    
        
        .. code-block:: csharp
    
           public IReadOnlyList<object> PropertyAttributes { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelAttributes.TypeAttributes
    
        
    
        Gets the set of attributes on the :any:`System.Type`\. If this instance represents a property,
        then :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelAttributes.TypeAttributes` contains attributes retrieved from 
        :dn:prop:`System.Reflection.PropertyInfo.PropertyType`\.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList{System.Object}
    
        
        .. code-block:: csharp
    
           public IReadOnlyList<object> TypeAttributes { get; }
    

