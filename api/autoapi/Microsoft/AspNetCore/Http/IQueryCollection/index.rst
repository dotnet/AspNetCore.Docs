

IQueryCollection Interface
==========================






    Represents the HttpRequest query string collection


Namespace
    :dn:ns:`Microsoft.AspNetCore.Http`
Assemblies
    * Microsoft.AspNetCore.Http.Features

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IQueryCollection : IEnumerable<KeyValuePair<string, StringValues>>, IEnumerable








.. dn:interface:: Microsoft.AspNetCore.Http.IQueryCollection
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Http.IQueryCollection

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Http.IQueryCollection
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.IQueryCollection.ContainsKey(System.String)
    
        
    
        
            Determines whether the :any:`Microsoft.AspNetCore.Http.IQueryCollection` contains an element
            with the specified key.
    
        
    
        
        :param key: 
            The key to locate in the :any:`Microsoft.AspNetCore.Http.IQueryCollection`\.
        
        :type key: System.String
        :rtype: System.Boolean
        :return: 
                true if the :any:`Microsoft.AspNetCore.Http.IQueryCollection` contains an element with
                the key; otherwise, false.
    
        
        .. code-block:: csharp
    
            bool ContainsKey(string key)
    
    .. dn:method:: Microsoft.AspNetCore.Http.IQueryCollection.TryGetValue(System.String, out Microsoft.Extensions.Primitives.StringValues)
    
        
    
        
           Gets the value associated with the specified key.
    
        
    
        
        :param key: 
                The key of the value to get.
        
        :type key: System.String
    
        
        :param value: 
                The key of the value to get.
                When this method returns, the value associated with the specified key, if the
                key is found; otherwise, the default value for the type of the value parameter.
                This parameter is passed uninitialized.
        
        :type value: Microsoft.Extensions.Primitives.StringValues
        :rtype: System.Boolean
        :return: 
               true if the object that implements :any:`Microsoft.AspNetCore.Http.IQueryCollection` contains
                an element with the specified key; otherwise, false.
    
        
        .. code-block:: csharp
    
            bool TryGetValue(string key, out StringValues value)
    

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Http.IQueryCollection
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.IQueryCollection.Count
    
        
    
        
            Gets the number of elements contained in the :any:`Microsoft.AspNetCore.Http.IQueryCollection`\.
    
        
        :rtype: System.Int32
        :return: 
                The number of elements contained in the :any:`Microsoft.AspNetCore.Http.IQueryCollection`\.
    
        
        .. code-block:: csharp
    
            int Count { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.IQueryCollection.Item[System.String]
    
        
    
        
            Gets the value with the specified key.
    
        
    
        
        :param key: 
                The key of the value to get.
        
        :type key: System.String
        :rtype: Microsoft.Extensions.Primitives.StringValues
        :return: 
                The element with the specified key, or <code>StringValues.Empty</code> if the key is not present.
    
        
        .. code-block:: csharp
    
            StringValues this[string key] { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.IQueryCollection.Keys
    
        
    
        
            Gets an :any:`System.Collections.Generic.ICollection\`1` containing the keys of the 
            :any:`Microsoft.AspNetCore.Http.IQueryCollection`\.
    
        
        :rtype: System.Collections.Generic.ICollection<System.Collections.Generic.ICollection`1>{System.String<System.String>}
        :return: 
                An :any:`System.Collections.Generic.ICollection\`1` containing the keys of the object
                that implements :any:`Microsoft.AspNetCore.Http.IQueryCollection`\.
    
        
        .. code-block:: csharp
    
            ICollection<string> Keys { get; }
    

