

OperationBase Class
===================





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








Syntax
------

.. code-block:: csharp

    public class OperationBase








.. dn:class:: Microsoft.AspNetCore.JsonPatch.Operations.OperationBase
    :hidden:

.. dn:class:: Microsoft.AspNetCore.JsonPatch.Operations.OperationBase

Properties
----------

.. dn:class:: Microsoft.AspNetCore.JsonPatch.Operations.OperationBase
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.JsonPatch.Operations.OperationBase.OperationType
    
        
        :rtype: Microsoft.AspNetCore.JsonPatch.Operations.OperationType
    
        
        .. code-block:: csharp
    
            [JsonIgnore]
            public OperationType OperationType
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.JsonPatch.Operations.OperationBase.from
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            [JsonProperty("from")]
            public string from
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.JsonPatch.Operations.OperationBase.op
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            [JsonProperty("op")]
            public string op
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.JsonPatch.Operations.OperationBase.path
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            [JsonProperty("path")]
            public string path
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.JsonPatch.Operations.OperationBase
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.JsonPatch.Operations.OperationBase.OperationBase()
    
        
    
        
        .. code-block:: csharp
    
            public OperationBase()
    
    .. dn:constructor:: Microsoft.AspNetCore.JsonPatch.Operations.OperationBase.OperationBase(System.String, System.String, System.String)
    
        
    
        
        :type op: System.String
    
        
        :type path: System.String
    
        
        :type from: System.String
    
        
        .. code-block:: csharp
    
            public OperationBase(string op, string path, string from)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.JsonPatch.Operations.OperationBase
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.JsonPatch.Operations.OperationBase.ShouldSerializefrom()
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool ShouldSerializefrom()
    

