

KeyValueAccumulator Class
=========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.WebUtilities.KeyValueAccumulator`








Syntax
------

.. code-block:: csharp

   public class KeyValueAccumulator





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.AspNet.WebUtilities/KeyValueAccumulator.cs>`_





.. dn:class:: Microsoft.AspNet.WebUtilities.KeyValueAccumulator

Constructors
------------

.. dn:class:: Microsoft.AspNet.WebUtilities.KeyValueAccumulator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.WebUtilities.KeyValueAccumulator.KeyValueAccumulator()
    
        
    
        
        .. code-block:: csharp
    
           public KeyValueAccumulator()
    

Methods
-------

.. dn:class:: Microsoft.AspNet.WebUtilities.KeyValueAccumulator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.WebUtilities.KeyValueAccumulator.Append(System.String, System.String)
    
        
        
        
        :type key: System.String
        
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
           public void Append(string key, string value)
    
    .. dn:method:: Microsoft.AspNet.WebUtilities.KeyValueAccumulator.GetResults()
    
        
        :rtype: System.Collections.Generic.IDictionary{System.String,Microsoft.Extensions.Primitives.StringValues}
    
        
        .. code-block:: csharp
    
           public IDictionary<string, StringValues> GetResults()
    

