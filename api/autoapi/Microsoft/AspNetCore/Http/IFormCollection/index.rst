

IFormCollection Interface
=========================






Represents the parsed form values sent with the HttpRequest.


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

    public interface IFormCollection : IEnumerable<KeyValuePair<string, StringValues>>, IEnumerable








.. dn:interface:: Microsoft.AspNetCore.Http.IFormCollection
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Http.IFormCollection

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Http.IFormCollection
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.IFormCollection.Count
    
        
    
        
            Gets the number of elements contained in the :any:`Microsoft.AspNetCore.Http.IFormCollection`\.
    
        
        :rtype: System.Int32
        :return: 
                The number of elements contained in the :any:`Microsoft.AspNetCore.Http.IFormCollection`\.
    
        
        .. code-block:: csharp
    
            int Count
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.IFormCollection.Files
    
        
    
        
        The file collection sent with the request.
    
        
        :rtype: Microsoft.AspNetCore.Http.IFormFileCollection
        :return: The files included with the request.
    
        
        .. code-block:: csharp
    
            IFormFileCollection Files
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.IFormCollection.Item[System.String]
    
        
    
        
            Gets the value with the specified key.
    
        
    
        
        :param key: 
                The key of the value to get.
        
        :type key: System.String
        :rtype: Microsoft.Extensions.Primitives.StringValues
        :return: 
                The element with the specified key, or <code>StringValues.Empty</code> if the key is not present.
    
        
        .. code-block:: csharp
    
            StringValues this[string key]
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.IFormCollection.Keys
    
        
    
        
            Gets an :any:`System.Collections.Generic.ICollection\`1` containing the keys of the
            :any:`Microsoft.AspNetCore.Http.IFormCollection`\.
    
        
        :rtype: System.Collections.Generic.ICollection<System.Collections.Generic.ICollection`1>{System.String<System.String>}
        :return: 
                An :any:`System.Collections.Generic.ICollection\`1` containing the keys of the object
                that implements :any:`Microsoft.AspNetCore.Http.IFormCollection`\.
    
        
        .. code-block:: csharp
    
            ICollection<string> Keys
            {
                get;
            }
    

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Http.IFormCollection
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.IFormCollection.ContainsKey(System.String)
    
        
    
        
            Determines whether the :any:`Microsoft.AspNetCore.Http.IFormCollection` contains an element
            with the specified key.
    
        
    
        
        :param key: 
            The key to locate in the :any:`Microsoft.AspNetCore.Http.IFormCollection`\.
        
        :type key: System.String
        :rtype: System.Boolean
        :return: 
                true if the :any:`Microsoft.AspNetCore.Http.IFormCollection` contains an element with
                the key; otherwise, false.
    
        
        .. code-block:: csharp
    
            bool ContainsKey(string key)
    
    .. dn:method:: Microsoft.AspNetCore.Http.IFormCollection.TryGetValue(System.String, out Microsoft.Extensions.Primitives.StringValues)
    
        
    
        
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
               true if the object that implements :any:`Microsoft.AspNetCore.Http.IFormCollection` contains
                an element with the specified key; otherwise, false.
    
        
        .. code-block:: csharp
    
            bool TryGetValue(string key, out StringValues value)
    

