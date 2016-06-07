

BindingSource Class
===================






A metadata object representing a source of data for model binding.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ModelBinding`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource`








Syntax
------

.. code-block:: csharp

    [DebuggerDisplay("Source: {DisplayName}")]
    public class BindingSource : IEquatable<BindingSource>








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource.DisplayName
    
        
    
        
        Gets the display name for the source.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string DisplayName
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource.Id
    
        
    
        
        Gets the unique identifier for the source. Sources are compared based on their Id.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Id
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource.IsFromRequest
    
        
    
        
        Gets a value indicating whether or not the binding source uses input from the current HTTP request.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsFromRequest
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource.IsGreedy
    
        
    
        
        Gets a value indicating whether or not a source is greedy. A greedy source will bind a model in
        a single operation, and will not decompose the model into sub-properties.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsGreedy
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource.BindingSource(System.String, System.String, System.Boolean, System.Boolean)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource`\.
    
        
    
        
        :param id: The id, a unique identifier.
        
        :type id: System.String
    
        
        :param displayName: The display name.
        
        :type displayName: System.String
    
        
        :param isGreedy: A value indicating whether or not the source is greedy.
        
        :type isGreedy: System.Boolean
    
        
        :param isFromRequest: 
            A value indicating whether or not the data comes from the HTTP request.
        
        :type isFromRequest: System.Boolean
    
        
        .. code-block:: csharp
    
            public BindingSource(string id, string displayName, bool isGreedy, bool isFromRequest)
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource.Body
    
        
    
        
        A :any:`Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource` for the request body.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource
    
        
        .. code-block:: csharp
    
            public static readonly BindingSource Body
    
    .. dn:field:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource.Custom
    
        
    
        
        A :any:`Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource` for a custom model binder (unknown data source).
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource
    
        
        .. code-block:: csharp
    
            public static readonly BindingSource Custom
    
    .. dn:field:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource.Form
    
        
    
        
        A :any:`Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource` for the request form-data.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource
    
        
        .. code-block:: csharp
    
            public static readonly BindingSource Form
    
    .. dn:field:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource.Header
    
        
    
        
        A :any:`Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource` for the request headers.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource
    
        
        .. code-block:: csharp
    
            public static readonly BindingSource Header
    
    .. dn:field:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource.ModelBinding
    
        
    
        
        A :any:`Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource` for model binding. Includes form-data, query-string
        and route data from the request.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource
    
        
        .. code-block:: csharp
    
            public static readonly BindingSource ModelBinding
    
    .. dn:field:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource.Path
    
        
    
        
        A :any:`Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource` for the request url path.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource
    
        
        .. code-block:: csharp
    
            public static readonly BindingSource Path
    
    .. dn:field:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource.Query
    
        
    
        
        A :any:`Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource` for the request query-string.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource
    
        
        .. code-block:: csharp
    
            public static readonly BindingSource Query
    
    .. dn:field:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource.Services
    
        
    
        
        A :any:`Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource` for request services.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource
    
        
        .. code-block:: csharp
    
            public static readonly BindingSource Services
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource.CanAcceptDataFrom(Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource)
    
        
    
        
        Gets a value indicating whether or not the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource` can accept
        data from <em>bindingSource</em>.
    
        
    
        
        :param bindingSource: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource` to consider as input.
        
        :type bindingSource: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource
        :rtype: System.Boolean
        :return: <code>True</code> if the source is compatible, otherwise <code>false</code>.
    
        
        .. code-block:: csharp
    
            public virtual bool CanAcceptDataFrom(BindingSource bindingSource)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource.Equals(Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource)
    
        
    
        
        :type other: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Equals(BindingSource other)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource.Equals(System.Object)
    
        
    
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int GetHashCode()
    

