

AttributeValue Class
====================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Diagnostics.Views.AttributeValue`








Syntax
------

.. code-block:: csharp

   public class AttributeValue





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/diagnostics/src/Microsoft.AspNet.Diagnostics/Views/AttributeValue.cs>`_





.. dn:class:: Microsoft.AspNet.Diagnostics.Views.AttributeValue

Constructors
------------

.. dn:class:: Microsoft.AspNet.Diagnostics.Views.AttributeValue
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Diagnostics.Views.AttributeValue.AttributeValue(System.String, System.Object, System.Boolean)
    
        
        
        
        :type prefix: System.String
        
        
        :type value: System.Object
        
        
        :type literal: System.Boolean
    
        
        .. code-block:: csharp
    
           public AttributeValue(string prefix, object value, bool literal)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Diagnostics.Views.AttributeValue
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Diagnostics.Views.AttributeValue.FromTuple(System.Tuple<System.String, System.Object, System.Boolean>)
    
        
        
        
        :type value: System.Tuple{System.String,System.Object,System.Boolean}
        :rtype: Microsoft.AspNet.Diagnostics.Views.AttributeValue
    
        
        .. code-block:: csharp
    
           public static AttributeValue FromTuple(Tuple<string, object, bool> value)
    
    .. dn:method:: Microsoft.AspNet.Diagnostics.Views.AttributeValue.FromTuple(System.Tuple<System.String, System.String, System.Boolean>)
    
        
        
        
        :type value: System.Tuple{System.String,System.String,System.Boolean}
        :rtype: Microsoft.AspNet.Diagnostics.Views.AttributeValue
    
        
        .. code-block:: csharp
    
           public static AttributeValue FromTuple(Tuple<string, string, bool> value)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Diagnostics.Views.AttributeValue
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Views.AttributeValue.Literal
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Literal { get; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Views.AttributeValue.Prefix
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Prefix { get; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Views.AttributeValue.Value
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public object Value { get; }
    

