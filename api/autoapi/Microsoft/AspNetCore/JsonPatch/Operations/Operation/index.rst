

Operation Class
===============





Namespace
    :dn:ns:`Microsoft.AspNetCore.JsonPatch.Operations`
Assemblies
    * Microsoft.AspNetCore.JsonPatch

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.JsonPatch.Operations.OperationBase`
* :dn:cls:`Microsoft.AspNetCore.JsonPatch.Operations.Operation`








Syntax
------

.. code-block:: csharp

    public class Operation : OperationBase








.. dn:class:: Microsoft.AspNetCore.JsonPatch.Operations.Operation
    :hidden:

.. dn:class:: Microsoft.AspNetCore.JsonPatch.Operations.Operation

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.JsonPatch.Operations.Operation
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.JsonPatch.Operations.Operation.Operation()
    
        
    
        
        .. code-block:: csharp
    
            public Operation()
    
    .. dn:constructor:: Microsoft.AspNetCore.JsonPatch.Operations.Operation.Operation(System.String, System.String, System.String)
    
        
    
        
        :type op: System.String
    
        
        :type path: System.String
    
        
        :type from: System.String
    
        
        .. code-block:: csharp
    
            public Operation(string op, string path, string from)
    
    .. dn:constructor:: Microsoft.AspNetCore.JsonPatch.Operations.Operation.Operation(System.String, System.String, System.String, System.Object)
    
        
    
        
        :type op: System.String
    
        
        :type path: System.String
    
        
        :type from: System.String
    
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
            public Operation(string op, string path, string from, object value)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.JsonPatch.Operations.Operation
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.JsonPatch.Operations.Operation.Apply(System.Object, Microsoft.AspNetCore.JsonPatch.Adapters.IObjectAdapter)
    
        
    
        
        :type objectToApplyTo: System.Object
    
        
        :type adapter: Microsoft.AspNetCore.JsonPatch.Adapters.IObjectAdapter
    
        
        .. code-block:: csharp
    
            public void Apply(object objectToApplyTo, IObjectAdapter adapter)
    
    .. dn:method:: Microsoft.AspNetCore.JsonPatch.Operations.Operation.ShouldSerializevalue()
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool ShouldSerializevalue()
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.JsonPatch.Operations.Operation
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.JsonPatch.Operations.Operation.value
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            [JsonProperty("value")]
            public object value { get; set; }
    

