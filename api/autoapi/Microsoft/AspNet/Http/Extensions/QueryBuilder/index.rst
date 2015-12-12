

QueryBuilder Class
==================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Http.Extensions.QueryBuilder`








Syntax
------

.. code-block:: csharp

   public class QueryBuilder : IEnumerable<KeyValuePair<string, string>>, IEnumerable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.Http.Extensions/QueryBuilder.cs>`_





.. dn:class:: Microsoft.AspNet.Http.Extensions.QueryBuilder

Constructors
------------

.. dn:class:: Microsoft.AspNet.Http.Extensions.QueryBuilder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Http.Extensions.QueryBuilder.QueryBuilder()
    
        
    
        
        .. code-block:: csharp
    
           public QueryBuilder()
    
    .. dn:constructor:: Microsoft.AspNet.Http.Extensions.QueryBuilder.QueryBuilder(System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<System.String, System.String>>)
    
        
        
        
        :type parameters: System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{System.String,System.String}}
    
        
        .. code-block:: csharp
    
           public QueryBuilder(IEnumerable<KeyValuePair<string, string>> parameters)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Http.Extensions.QueryBuilder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.Extensions.QueryBuilder.Add(System.String, System.Collections.Generic.IEnumerable<System.String>)
    
        
        
        
        :type key: System.String
        
        
        :type values: System.Collections.Generic.IEnumerable{System.String}
    
        
        .. code-block:: csharp
    
           public void Add(string key, IEnumerable<string> values)
    
    .. dn:method:: Microsoft.AspNet.Http.Extensions.QueryBuilder.Add(System.String, System.String)
    
        
        
        
        :type key: System.String
        
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
           public void Add(string key, string value)
    
    .. dn:method:: Microsoft.AspNet.Http.Extensions.QueryBuilder.Equals(System.Object)
    
        
        
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNet.Http.Extensions.QueryBuilder.GetEnumerator()
    
        
        :rtype: System.Collections.Generic.IEnumerator{System.Collections.Generic.KeyValuePair{System.String,System.String}}
    
        
        .. code-block:: csharp
    
           public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
    
    .. dn:method:: Microsoft.AspNet.Http.Extensions.QueryBuilder.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int GetHashCode()
    
    .. dn:method:: Microsoft.AspNet.Http.Extensions.QueryBuilder.System.Collections.IEnumerable.GetEnumerator()
    
        
        :rtype: System.Collections.IEnumerator
    
        
        .. code-block:: csharp
    
           IEnumerator IEnumerable.GetEnumerator()
    
    .. dn:method:: Microsoft.AspNet.Http.Extensions.QueryBuilder.ToQueryString()
    
        
        :rtype: Microsoft.AspNet.Http.QueryString
    
        
        .. code-block:: csharp
    
           public QueryString ToQueryString()
    
    .. dn:method:: Microsoft.AspNet.Http.Extensions.QueryBuilder.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string ToString()
    

