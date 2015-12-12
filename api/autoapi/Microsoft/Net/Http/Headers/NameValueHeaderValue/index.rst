

NameValueHeaderValue Class
==========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Net.Http.Headers.NameValueHeaderValue`








Syntax
------

.. code-block:: csharp

   public class NameValueHeaderValue





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.Net.Http.Headers/NameValueHeaderValue.cs>`_





.. dn:class:: Microsoft.Net.Http.Headers.NameValueHeaderValue

Constructors
------------

.. dn:class:: Microsoft.Net.Http.Headers.NameValueHeaderValue
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Net.Http.Headers.NameValueHeaderValue.NameValueHeaderValue(System.String)
    
        
        
        
        :type name: System.String
    
        
        .. code-block:: csharp
    
           public NameValueHeaderValue(string name)
    
    .. dn:constructor:: Microsoft.Net.Http.Headers.NameValueHeaderValue.NameValueHeaderValue(System.String, System.String)
    
        
        
        
        :type name: System.String
        
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
           public NameValueHeaderValue(string name, string value)
    

Methods
-------

.. dn:class:: Microsoft.Net.Http.Headers.NameValueHeaderValue
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Net.Http.Headers.NameValueHeaderValue.Copy()
    
        
    
        Provides a copy of this object without the cost of re-validating the values.
    
        
        :rtype: Microsoft.Net.Http.Headers.NameValueHeaderValue
        :return: A copy.
    
        
        .. code-block:: csharp
    
           public NameValueHeaderValue Copy()
    
    .. dn:method:: Microsoft.Net.Http.Headers.NameValueHeaderValue.CopyAsReadOnly()
    
        
        :rtype: Microsoft.Net.Http.Headers.NameValueHeaderValue
    
        
        .. code-block:: csharp
    
           public NameValueHeaderValue CopyAsReadOnly()
    
    .. dn:method:: Microsoft.Net.Http.Headers.NameValueHeaderValue.Equals(System.Object)
    
        
        
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.Net.Http.Headers.NameValueHeaderValue.Find(System.Collections.Generic.ICollection<Microsoft.Net.Http.Headers.NameValueHeaderValue>, System.String)
    
        
        
        
        :type values: System.Collections.Generic.ICollection{Microsoft.Net.Http.Headers.NameValueHeaderValue}
        
        
        :type name: System.String
        :rtype: Microsoft.Net.Http.Headers.NameValueHeaderValue
    
        
        .. code-block:: csharp
    
           public static NameValueHeaderValue Find(ICollection<NameValueHeaderValue> values, string name)
    
    .. dn:method:: Microsoft.Net.Http.Headers.NameValueHeaderValue.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int GetHashCode()
    
    .. dn:method:: Microsoft.Net.Http.Headers.NameValueHeaderValue.Parse(System.String)
    
        
        
        
        :type input: System.String
        :rtype: Microsoft.Net.Http.Headers.NameValueHeaderValue
    
        
        .. code-block:: csharp
    
           public static NameValueHeaderValue Parse(string input)
    
    .. dn:method:: Microsoft.Net.Http.Headers.NameValueHeaderValue.ParseList(System.Collections.Generic.IList<System.String>)
    
        
        
        
        :type input: System.Collections.Generic.IList{System.String}
        :rtype: System.Collections.Generic.IList{Microsoft.Net.Http.Headers.NameValueHeaderValue}
    
        
        .. code-block:: csharp
    
           public static IList<NameValueHeaderValue> ParseList(IList<string> input)
    
    .. dn:method:: Microsoft.Net.Http.Headers.NameValueHeaderValue.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string ToString()
    
    .. dn:method:: Microsoft.Net.Http.Headers.NameValueHeaderValue.TryParse(System.String, out Microsoft.Net.Http.Headers.NameValueHeaderValue)
    
        
        
        
        :type input: System.String
        
        
        :type parsedValue: Microsoft.Net.Http.Headers.NameValueHeaderValue
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public static bool TryParse(string input, out NameValueHeaderValue parsedValue)
    
    .. dn:method:: Microsoft.Net.Http.Headers.NameValueHeaderValue.TryParseList(System.Collections.Generic.IList<System.String>, out System.Collections.Generic.IList<Microsoft.Net.Http.Headers.NameValueHeaderValue>)
    
        
        
        
        :type input: System.Collections.Generic.IList{System.String}
        
        
        :type parsedValues: System.Collections.Generic.IList{Microsoft.Net.Http.Headers.NameValueHeaderValue}
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public static bool TryParseList(IList<string> input, out IList<NameValueHeaderValue> parsedValues)
    

Properties
----------

.. dn:class:: Microsoft.Net.Http.Headers.NameValueHeaderValue
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Net.Http.Headers.NameValueHeaderValue.IsReadOnly
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsReadOnly { get; }
    
    .. dn:property:: Microsoft.Net.Http.Headers.NameValueHeaderValue.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Name { get; }
    
    .. dn:property:: Microsoft.Net.Http.Headers.NameValueHeaderValue.Value
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Value { get; set; }
    

