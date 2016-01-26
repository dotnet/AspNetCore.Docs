

LogValuesAssert Class
=====================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Logging.Testing.LogValuesAssert`








Syntax
------

.. code-block:: csharp

   public class LogValuesAssert





GitHub
------

`View on GitHub <https://github.com/aspnet/logging/blob/master/src/Microsoft.Extensions.Logging.Testing/LogValuesAssert.cs>`_





.. dn:class:: Microsoft.Extensions.Logging.Testing.LogValuesAssert

Methods
-------

.. dn:class:: Microsoft.Extensions.Logging.Testing.LogValuesAssert
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.Testing.LogValuesAssert.Contains(System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<System.String, System.Object>>, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<System.String, System.Object>>)
    
        
    
        Asserts that all the expected values are present in the actual values by ignoring
        the order of values.
    
        
        
        
        :param expectedValues: Expected subset of values
        
        :type expectedValues: System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{System.String,System.Object}}
        
        
        :param actualValues: Actual set of values
        
        :type actualValues: System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{System.String,System.Object}}
    
        
        .. code-block:: csharp
    
           public static void Contains(IEnumerable<KeyValuePair<string, object>> expectedValues, IEnumerable<KeyValuePair<string, object>> actualValues)
    
    .. dn:method:: Microsoft.Extensions.Logging.Testing.LogValuesAssert.Contains(System.String, System.Object, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<System.String, System.Object>>)
    
        
    
        Asserts that the given key and value are present in the actual values.
    
        
        
        
        :param key: The key of the item to be found.
        
        :type key: System.String
        
        
        :param value: The value of the item to be found.
        
        :type value: System.Object
        
        
        :param actualValues: The actual values.
        
        :type actualValues: System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{System.String,System.Object}}
    
        
        .. code-block:: csharp
    
           public static void Contains(string key, object value, IEnumerable<KeyValuePair<string, object>> actualValues)
    

