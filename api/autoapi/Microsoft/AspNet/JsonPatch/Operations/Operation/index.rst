

Operation Class
===============



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.JsonPatch.Operations.OperationBase`
* :dn:cls:`Microsoft.AspNet.JsonPatch.Operations.Operation`








Syntax
------

.. code-block:: csharp

   public class Operation : OperationBase





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/jsonpatch/src/Microsoft.AspNet.JsonPatch/Operations/Operation.cs>`_





.. dn:class:: Microsoft.AspNet.JsonPatch.Operations.Operation

Constructors
------------

.. dn:class:: Microsoft.AspNet.JsonPatch.Operations.Operation
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.JsonPatch.Operations.Operation.Operation()
    
        
    
        
        .. code-block:: csharp
    
           public Operation()
    
    .. dn:constructor:: Microsoft.AspNet.JsonPatch.Operations.Operation.Operation(System.String, System.String, System.String)
    
        
        
        
        :type op: System.String
        
        
        :type path: System.String
        
        
        :type from: System.String
    
        
        .. code-block:: csharp
    
           public Operation(string op, string path, string from)
    
    .. dn:constructor:: Microsoft.AspNet.JsonPatch.Operations.Operation.Operation(System.String, System.String, System.String, System.Object)
    
        
        
        
        :type op: System.String
        
        
        :type path: System.String
        
        
        :type from: System.String
        
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
           public Operation(string op, string path, string from, object value)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.JsonPatch.Operations.Operation
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.JsonPatch.Operations.Operation.Apply(System.Object, Microsoft.AspNet.JsonPatch.Adapters.IObjectAdapter)
    
        
        
        
        :type objectToApplyTo: System.Object
        
        
        :type adapter: Microsoft.AspNet.JsonPatch.Adapters.IObjectAdapter
    
        
        .. code-block:: csharp
    
           public void Apply(object objectToApplyTo, IObjectAdapter adapter)
    
    .. dn:method:: Microsoft.AspNet.JsonPatch.Operations.Operation.ShouldSerializevalue()
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool ShouldSerializevalue()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.JsonPatch.Operations.Operation
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.JsonPatch.Operations.Operation.value
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public object value { get; set; }
    

