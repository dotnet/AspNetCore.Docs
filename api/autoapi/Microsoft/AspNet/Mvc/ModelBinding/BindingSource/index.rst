

BindingSource Class
===================



.. contents:: 
   :local:



Summary
-------

A metadata object representing a source of data for model binding.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.BindingSource`








Syntax
------

.. code-block:: csharp

   public class BindingSource : IEquatable<BindingSource>





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Abstractions/ModelBinding/BindingSource.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.BindingSource

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.BindingSource
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.BindingSource.BindingSource(System.String, System.String, System.Boolean, System.Boolean)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.ModelBinding.BindingSource`\.
    
        
        
        
        :param id: The id, a unique identifier.
        
        :type id: System.String
        
        
        :param displayName: The display name.
        
        :type displayName: System.String
        
        
        :param isGreedy: A value indicating whether or not the source is greedy.
        
        :type isGreedy: System.Boolean
        
        
        :param isFromRequest: A value indicating whether or not the data comes from the HTTP request.
        
        :type isFromRequest: System.Boolean
    
        
        .. code-block:: csharp
    
           public BindingSource(string id, string displayName, bool isGreedy, bool isFromRequest)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.BindingSource
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.BindingSource.CanAcceptDataFrom(Microsoft.AspNet.Mvc.ModelBinding.BindingSource)
    
        
    
        Gets a value indicating whether or not the :any:`Microsoft.AspNet.Mvc.ModelBinding.BindingSource` can accept
        data from ``bindingSource``.
    
        
        
        
        :param bindingSource: The  to consider as input.
        
        :type bindingSource: Microsoft.AspNet.Mvc.ModelBinding.BindingSource
        :rtype: System.Boolean
        :return: <c>True</c> if the source is compatible, otherwise <c>false</c>.
    
        
        .. code-block:: csharp
    
           public virtual bool CanAcceptDataFrom(BindingSource bindingSource)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.BindingSource.Equals(Microsoft.AspNet.Mvc.ModelBinding.BindingSource)
    
        
        
        
        :type other: Microsoft.AspNet.Mvc.ModelBinding.BindingSource
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Equals(BindingSource other)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.BindingSource.Equals(System.Object)
    
        
        
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.BindingSource.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int GetHashCode()
    

Fields
------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.BindingSource
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Mvc.ModelBinding.BindingSource.Body
    
        
    
        A :any:`Microsoft.AspNet.Mvc.ModelBinding.BindingSource` for the request body.
    
        
    
        
        .. code-block:: csharp
    
           public static readonly BindingSource Body
    
    .. dn:field:: Microsoft.AspNet.Mvc.ModelBinding.BindingSource.Custom
    
        
    
        A :any:`Microsoft.AspNet.Mvc.ModelBinding.BindingSource` for a custom model binder (unknown data source).
    
        
    
        
        .. code-block:: csharp
    
           public static readonly BindingSource Custom
    
    .. dn:field:: Microsoft.AspNet.Mvc.ModelBinding.BindingSource.Form
    
        
    
        A :any:`Microsoft.AspNet.Mvc.ModelBinding.BindingSource` for the request form-data.
    
        
    
        
        .. code-block:: csharp
    
           public static readonly BindingSource Form
    
    .. dn:field:: Microsoft.AspNet.Mvc.ModelBinding.BindingSource.Header
    
        
    
        A :any:`Microsoft.AspNet.Mvc.ModelBinding.BindingSource` for the request headers.
    
        
    
        
        .. code-block:: csharp
    
           public static readonly BindingSource Header
    
    .. dn:field:: Microsoft.AspNet.Mvc.ModelBinding.BindingSource.ModelBinding
    
        
    
        A :any:`Microsoft.AspNet.Mvc.ModelBinding.BindingSource` for model binding. Includes form-data, query-string
        and route data from the request.
    
        
    
        
        .. code-block:: csharp
    
           public static readonly BindingSource ModelBinding
    
    .. dn:field:: Microsoft.AspNet.Mvc.ModelBinding.BindingSource.Path
    
        
    
        A :any:`Microsoft.AspNet.Mvc.ModelBinding.BindingSource` for the request url path.
    
        
    
        
        .. code-block:: csharp
    
           public static readonly BindingSource Path
    
    .. dn:field:: Microsoft.AspNet.Mvc.ModelBinding.BindingSource.Query
    
        
    
        A :any:`Microsoft.AspNet.Mvc.ModelBinding.BindingSource` for the request query-string.
    
        
    
        
        .. code-block:: csharp
    
           public static readonly BindingSource Query
    
    .. dn:field:: Microsoft.AspNet.Mvc.ModelBinding.BindingSource.Services
    
        
    
        A :any:`Microsoft.AspNet.Mvc.ModelBinding.BindingSource` for request services.
    
        
    
        
        .. code-block:: csharp
    
           public static readonly BindingSource Services
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.BindingSource
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.BindingSource.DisplayName
    
        
    
        Gets the display name for the source.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string DisplayName { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.BindingSource.Id
    
        
    
        Gets the unique identifier for the source. Sources are compared based on their Id.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Id { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.BindingSource.IsFromRequest
    
        
    
        Gets a value indicating whether or not the binding source uses input from the current HTTP request.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsFromRequest { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.BindingSource.IsGreedy
    
        
    
        Gets a value indicating whether or not a source is greedy. A greedy source will bind a model in
        a single operation, and will not decompose the model into sub-properties.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsGreedy { get; }
    

