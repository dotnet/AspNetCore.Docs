

IRequestCookieCollection Interface
==================================






Represents the HttpRequest cookie collection


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

    public interface IRequestCookieCollection : IEnumerable<KeyValuePair<string, string>>, IEnumerable








.. dn:interface:: Microsoft.AspNetCore.Http.IRequestCookieCollection
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Http.IRequestCookieCollection

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Http.IRequestCookieCollection
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.IRequestCookieCollection.Count
    
        
    
        
            Gets the number of elements contained in the :any:`Microsoft.AspNetCore.Http.IRequestCookieCollection`\.
    
        
        :rtype: System.Int32
        :return: 
                The number of elements contained in the :any:`Microsoft.AspNetCore.Http.IRequestCookieCollection`\.
    
        
        .. code-block:: csharp
    
            int Count
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.IRequestCookieCollection.Item[System.String]
    
        
    
        
            Gets the value with the specified key.
    
        
    
        
        :param key: 
                The key of the value to get.
        
        :type key: System.String
        :rtype: System.String
        :return: 
                The element with the specified key, or <code>string.Empty</code> if the key is not present.
    
        
        .. code-block:: csharp
    
            string this[string key]
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.IRequestCookieCollection.Keys
    
        
    
        
            Gets an :any:`System.Collections.Generic.ICollection\`1` containing the keys of the
            :any:`Microsoft.AspNetCore.Http.IRequestCookieCollection`\.
    
        
        :rtype: System.Collections.Generic.ICollection<System.Collections.Generic.ICollection`1>{System.String<System.String>}
        :return: 
                An :any:`System.Collections.Generic.ICollection\`1` containing the keys of the object
                that implements :any:`Microsoft.AspNetCore.Http.IRequestCookieCollection`\.
    
        
        .. code-block:: csharp
    
            ICollection<string> Keys
            {
                get;
            }
    

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Http.IRequestCookieCollection
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.IRequestCookieCollection.ContainsKey(System.String)
    
        
    
        
            Determines whether the :any:`Microsoft.AspNetCore.Http.IRequestCookieCollection` contains an element
            with the specified key.
    
        
    
        
        :param key: 
            The key to locate in the :any:`Microsoft.AspNetCore.Http.IRequestCookieCollection`\.
        
        :type key: System.String
        :rtype: System.Boolean
        :return: 
                true if the :any:`Microsoft.AspNetCore.Http.IRequestCookieCollection` contains an element with
                the key; otherwise, false.
    
        
        .. code-block:: csharp
    
            bool ContainsKey(string key)
    
    .. dn:method:: Microsoft.AspNetCore.Http.IRequestCookieCollection.TryGetValue(System.String, out System.String)
    
        
    
        
           Gets the value associated with the specified key.
    
        
    
        
        :param key: 
                The key of the value to get.
        
        :type key: System.String
    
        
        :param value: 
                The key of the value to get.
                When this method returns, the value associated with the specified key, if the
                key is found; otherwise, the default value for the type of the value parameter.
                This parameter is passed uninitialized.
        
        :type value: System.String
        :rtype: System.Boolean
        :return: 
               true if the object that implements :any:`Microsoft.AspNetCore.Http.IRequestCookieCollection` contains
                an element with the specified key; otherwise, false.
    
        
        .. code-block:: csharp
    
            bool TryGetValue(string key, out string value)
    

