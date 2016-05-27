

KeyValueAccumulator Struct
==========================





Namespace
    :dn:ns:`Microsoft.AspNetCore.WebUtilities`
Assemblies
    * Microsoft.AspNetCore.WebUtilities

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public struct KeyValueAccumulator








.. dn:structure:: Microsoft.AspNetCore.WebUtilities.KeyValueAccumulator
    :hidden:

.. dn:structure:: Microsoft.AspNetCore.WebUtilities.KeyValueAccumulator

Properties
----------

.. dn:structure:: Microsoft.AspNetCore.WebUtilities.KeyValueAccumulator
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.WebUtilities.KeyValueAccumulator.Count
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Count
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.WebUtilities.KeyValueAccumulator.HasValues
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool HasValues
            {
                get;
            }
    

Methods
-------

.. dn:structure:: Microsoft.AspNetCore.WebUtilities.KeyValueAccumulator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.WebUtilities.KeyValueAccumulator.Append(System.String, System.String)
    
        
    
        
        :type key: System.String
    
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
            public void Append(string key, string value)
    
    .. dn:method:: Microsoft.AspNetCore.WebUtilities.KeyValueAccumulator.GetResults()
    
        
        :rtype: System.Collections.Generic.Dictionary<System.Collections.Generic.Dictionary`2>{System.String<System.String>, Microsoft.Extensions.Primitives.StringValues<Microsoft.Extensions.Primitives.StringValues>}
    
        
        .. code-block:: csharp
    
            public Dictionary<string, StringValues> GetResults()
    

