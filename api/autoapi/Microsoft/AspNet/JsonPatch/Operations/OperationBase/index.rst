

OperationBase Class
===================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.JsonPatch.Operations.OperationBase`








Syntax
------

.. code-block:: csharp

   public class OperationBase





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/jsonpatch/src/Microsoft.AspNet.JsonPatch/Operations/OperationBase.cs>`_





.. dn:class:: Microsoft.AspNet.JsonPatch.Operations.OperationBase

Constructors
------------

.. dn:class:: Microsoft.AspNet.JsonPatch.Operations.OperationBase
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.JsonPatch.Operations.OperationBase.OperationBase()
    
        
    
        
        .. code-block:: csharp
    
           public OperationBase()
    
    .. dn:constructor:: Microsoft.AspNet.JsonPatch.Operations.OperationBase.OperationBase(System.String, System.String, System.String)
    
        
        
        
        :type op: System.String
        
        
        :type path: System.String
        
        
        :type from: System.String
    
        
        .. code-block:: csharp
    
           public OperationBase(string op, string path, string from)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.JsonPatch.Operations.OperationBase
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.JsonPatch.Operations.OperationBase.ShouldSerializefrom()
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool ShouldSerializefrom()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.JsonPatch.Operations.OperationBase
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.JsonPatch.Operations.OperationBase.OperationType
    
        
        :rtype: Microsoft.AspNet.JsonPatch.Operations.OperationType
    
        
        .. code-block:: csharp
    
           public OperationType OperationType { get; }
    
    .. dn:property:: Microsoft.AspNet.JsonPatch.Operations.OperationBase.from
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string from { get; set; }
    
    .. dn:property:: Microsoft.AspNet.JsonPatch.Operations.OperationBase.op
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string op { get; set; }
    
    .. dn:property:: Microsoft.AspNet.JsonPatch.Operations.OperationBase.path
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string path { get; set; }
    

