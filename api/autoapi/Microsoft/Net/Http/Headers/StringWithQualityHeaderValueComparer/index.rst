

StringWithQualityHeaderValueComparer Class
==========================================



.. contents:: 
   :local:



Summary
-------

Implementation of :any:`System.Collections.Generic.IComparer\`1` that can compare content negotiation header fields
based on their quality values (a.k.a q-values). This applies to values used in accept-charset,
accept-encoding, accept-language and related header fields with similar syntax rules. See 
:any:`Microsoft.Net.Http.Headers.MediaTypeHeaderValueComparer` for a comparer for media type
q-values.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Net.Http.Headers.StringWithQualityHeaderValueComparer`








Syntax
------

.. code-block:: csharp

   public class StringWithQualityHeaderValueComparer : IComparer<StringWithQualityHeaderValue>





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.Net.Http.Headers/StringWithQualityHeaderValueComparer.cs>`_





.. dn:class:: Microsoft.Net.Http.Headers.StringWithQualityHeaderValueComparer

Methods
-------

.. dn:class:: Microsoft.Net.Http.Headers.StringWithQualityHeaderValueComparer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Net.Http.Headers.StringWithQualityHeaderValueComparer.Compare(Microsoft.Net.Http.Headers.StringWithQualityHeaderValue, Microsoft.Net.Http.Headers.StringWithQualityHeaderValue)
    
        
    
        Compares two :any:`Microsoft.Net.Http.Headers.StringWithQualityHeaderValue` based on their quality value
        (a.k.a their "q-value").
        Values with identical q-values are considered equal (i.e the result is 0) with the exception of wild-card
        values (i.e. a value of "*") which are considered less than non-wild-card values. This allows to sort
        a sequence of :any:`Microsoft.Net.Http.Headers.StringWithQualityHeaderValue` following their q-values ending up with any
        wild-cards at the end.
    
        
        
        
        :param stringWithQuality1: The first value to compare.
        
        :type stringWithQuality1: Microsoft.Net.Http.Headers.StringWithQualityHeaderValue
        
        
        :param stringWithQuality2: The second value to compare
        
        :type stringWithQuality2: Microsoft.Net.Http.Headers.StringWithQualityHeaderValue
        :rtype: System.Int32
        :return: The result of the comparison.
    
        
        .. code-block:: csharp
    
           public int Compare(StringWithQualityHeaderValue stringWithQuality1, StringWithQualityHeaderValue stringWithQuality2)
    

Properties
----------

.. dn:class:: Microsoft.Net.Http.Headers.StringWithQualityHeaderValueComparer
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Net.Http.Headers.StringWithQualityHeaderValueComparer.QualityComparer
    
        
        :rtype: Microsoft.Net.Http.Headers.StringWithQualityHeaderValueComparer
    
        
        .. code-block:: csharp
    
           public static StringWithQualityHeaderValueComparer QualityComparer { get; }
    

