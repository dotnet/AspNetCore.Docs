

AttributeValue Class
====================





Namespace
    :dn:ns:`Microsoft.AspNetCore.DiagnosticsViewPage.Views`
Assemblies
    * Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.DiagnosticsViewPage.Views.AttributeValue`








Syntax
------

.. code-block:: csharp

    public class AttributeValue








.. dn:class:: Microsoft.AspNetCore.DiagnosticsViewPage.Views.AttributeValue
    :hidden:

.. dn:class:: Microsoft.AspNetCore.DiagnosticsViewPage.Views.AttributeValue

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.DiagnosticsViewPage.Views.AttributeValue
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.DiagnosticsViewPage.Views.AttributeValue.AttributeValue(System.String, System.Object, System.Boolean)
    
        
    
        
        :type prefix: System.String
    
        
        :type value: System.Object
    
        
        :type literal: System.Boolean
    
        
        .. code-block:: csharp
    
            public AttributeValue(string prefix, object value, bool literal)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.DiagnosticsViewPage.Views.AttributeValue
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.DiagnosticsViewPage.Views.AttributeValue.FromTuple(System.Tuple<System.String, System.Object, System.Boolean>)
    
        
    
        
        :type value: System.Tuple<System.Tuple`3>{System.String<System.String>, System.Object<System.Object>, System.Boolean<System.Boolean>}
        :rtype: Microsoft.AspNetCore.DiagnosticsViewPage.Views.AttributeValue
    
        
        .. code-block:: csharp
    
            public static AttributeValue FromTuple(Tuple<string, object, bool> value)
    
    .. dn:method:: Microsoft.AspNetCore.DiagnosticsViewPage.Views.AttributeValue.FromTuple(System.Tuple<System.String, System.String, System.Boolean>)
    
        
    
        
        :type value: System.Tuple<System.Tuple`3>{System.String<System.String>, System.String<System.String>, System.Boolean<System.Boolean>}
        :rtype: Microsoft.AspNetCore.DiagnosticsViewPage.Views.AttributeValue
    
        
        .. code-block:: csharp
    
            public static AttributeValue FromTuple(Tuple<string, string, bool> value)
    

Operators
---------

.. dn:class:: Microsoft.AspNetCore.DiagnosticsViewPage.Views.AttributeValue
    :noindex:
    :hidden:

    
    .. dn:operator:: Microsoft.AspNetCore.DiagnosticsViewPage.Views.AttributeValue.Implicit(System.Tuple<System.String, System.Object, System.Boolean> to Microsoft.AspNetCore.DiagnosticsViewPage.Views.AttributeValue)
    
        
    
        
        :type value: System.Tuple<System.Tuple`3>{System.String<System.String>, System.Object<System.Object>, System.Boolean<System.Boolean>}
        :rtype: Microsoft.AspNetCore.DiagnosticsViewPage.Views.AttributeValue
    
        
        .. code-block:: csharp
    
            public static implicit operator AttributeValue(Tuple<string, object, bool> value)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.DiagnosticsViewPage.Views.AttributeValue
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.DiagnosticsViewPage.Views.AttributeValue.Literal
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Literal { get; }
    
    .. dn:property:: Microsoft.AspNetCore.DiagnosticsViewPage.Views.AttributeValue.Prefix
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Prefix { get; }
    
    .. dn:property:: Microsoft.AspNetCore.DiagnosticsViewPage.Views.AttributeValue.Value
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public object Value { get; }
    

