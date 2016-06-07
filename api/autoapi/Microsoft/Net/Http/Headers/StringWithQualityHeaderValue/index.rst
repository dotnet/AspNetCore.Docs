

StringWithQualityHeaderValue Class
==================================





Namespace
    :dn:ns:`Microsoft.Net.Http.Headers`
Assemblies
    * Microsoft.Net.Http.Headers

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Net.Http.Headers.StringWithQualityHeaderValue`








Syntax
------

.. code-block:: csharp

    public class StringWithQualityHeaderValue








.. dn:class:: Microsoft.Net.Http.Headers.StringWithQualityHeaderValue
    :hidden:

.. dn:class:: Microsoft.Net.Http.Headers.StringWithQualityHeaderValue

Properties
----------

.. dn:class:: Microsoft.Net.Http.Headers.StringWithQualityHeaderValue
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Net.Http.Headers.StringWithQualityHeaderValue.Quality
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.Double<System.Double>}
    
        
        .. code-block:: csharp
    
            public double ? Quality
            {
                get;
            }
    
    .. dn:property:: Microsoft.Net.Http.Headers.StringWithQualityHeaderValue.Value
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Value
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.Net.Http.Headers.StringWithQualityHeaderValue
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Net.Http.Headers.StringWithQualityHeaderValue.StringWithQualityHeaderValue(System.String)
    
        
    
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
            public StringWithQualityHeaderValue(string value)
    
    .. dn:constructor:: Microsoft.Net.Http.Headers.StringWithQualityHeaderValue.StringWithQualityHeaderValue(System.String, System.Double)
    
        
    
        
        :type value: System.String
    
        
        :type quality: System.Double
    
        
        .. code-block:: csharp
    
            public StringWithQualityHeaderValue(string value, double quality)
    

Methods
-------

.. dn:class:: Microsoft.Net.Http.Headers.StringWithQualityHeaderValue
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Net.Http.Headers.StringWithQualityHeaderValue.Equals(System.Object)
    
        
    
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.Net.Http.Headers.StringWithQualityHeaderValue.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int GetHashCode()
    
    .. dn:method:: Microsoft.Net.Http.Headers.StringWithQualityHeaderValue.Parse(System.String)
    
        
    
        
        :type input: System.String
        :rtype: Microsoft.Net.Http.Headers.StringWithQualityHeaderValue
    
        
        .. code-block:: csharp
    
            public static StringWithQualityHeaderValue Parse(string input)
    
    .. dn:method:: Microsoft.Net.Http.Headers.StringWithQualityHeaderValue.ParseList(System.Collections.Generic.IList<System.String>)
    
        
    
        
        :type input: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.Net.Http.Headers.StringWithQualityHeaderValue<Microsoft.Net.Http.Headers.StringWithQualityHeaderValue>}
    
        
        .. code-block:: csharp
    
            public static IList<StringWithQualityHeaderValue> ParseList(IList<string> input)
    
    .. dn:method:: Microsoft.Net.Http.Headers.StringWithQualityHeaderValue.ParseStrictList(System.Collections.Generic.IList<System.String>)
    
        
    
        
        :type input: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.Net.Http.Headers.StringWithQualityHeaderValue<Microsoft.Net.Http.Headers.StringWithQualityHeaderValue>}
    
        
        .. code-block:: csharp
    
            public static IList<StringWithQualityHeaderValue> ParseStrictList(IList<string> input)
    
    .. dn:method:: Microsoft.Net.Http.Headers.StringWithQualityHeaderValue.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string ToString()
    
    .. dn:method:: Microsoft.Net.Http.Headers.StringWithQualityHeaderValue.TryParse(System.String, out Microsoft.Net.Http.Headers.StringWithQualityHeaderValue)
    
        
    
        
        :type input: System.String
    
        
        :type parsedValue: Microsoft.Net.Http.Headers.StringWithQualityHeaderValue
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public static bool TryParse(string input, out StringWithQualityHeaderValue parsedValue)
    
    .. dn:method:: Microsoft.Net.Http.Headers.StringWithQualityHeaderValue.TryParseList(System.Collections.Generic.IList<System.String>, out System.Collections.Generic.IList<Microsoft.Net.Http.Headers.StringWithQualityHeaderValue>)
    
        
    
        
        :type input: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
    
        
        :type parsedValues: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.Net.Http.Headers.StringWithQualityHeaderValue<Microsoft.Net.Http.Headers.StringWithQualityHeaderValue>}
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public static bool TryParseList(IList<string> input, out IList<StringWithQualityHeaderValue> parsedValues)
    
    .. dn:method:: Microsoft.Net.Http.Headers.StringWithQualityHeaderValue.TryParseStrictList(System.Collections.Generic.IList<System.String>, out System.Collections.Generic.IList<Microsoft.Net.Http.Headers.StringWithQualityHeaderValue>)
    
        
    
        
        :type input: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
    
        
        :type parsedValues: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.Net.Http.Headers.StringWithQualityHeaderValue<Microsoft.Net.Http.Headers.StringWithQualityHeaderValue>}
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public static bool TryParseStrictList(IList<string> input, out IList<StringWithQualityHeaderValue> parsedValues)
    

