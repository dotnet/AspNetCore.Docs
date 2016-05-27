

Operation<TModel> Class
=======================





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
* :dn:cls:`Microsoft.AspNetCore.JsonPatch.Operations.Operation\<TModel>`








Syntax
------

.. code-block:: csharp

    public class Operation<TModel> : Operation where TModel : class








.. dn:class:: Microsoft.AspNetCore.JsonPatch.Operations.Operation`1
    :hidden:

.. dn:class:: Microsoft.AspNetCore.JsonPatch.Operations.Operation<TModel>

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.JsonPatch.Operations.Operation<TModel>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.JsonPatch.Operations.Operation<TModel>.Operation()
    
        
    
        
        .. code-block:: csharp
    
            public Operation()
    
    .. dn:constructor:: Microsoft.AspNetCore.JsonPatch.Operations.Operation<TModel>.Operation(System.String, System.String, System.String)
    
        
    
        
        :type op: System.String
    
        
        :type path: System.String
    
        
        :type from: System.String
    
        
        .. code-block:: csharp
    
            public Operation(string op, string path, string from)
    
    .. dn:constructor:: Microsoft.AspNetCore.JsonPatch.Operations.Operation<TModel>.Operation(System.String, System.String, System.String, System.Object)
    
        
    
        
        :type op: System.String
    
        
        :type path: System.String
    
        
        :type from: System.String
    
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
            public Operation(string op, string path, string from, object value)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.JsonPatch.Operations.Operation<TModel>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.JsonPatch.Operations.Operation<TModel>.Apply(TModel, Microsoft.AspNetCore.JsonPatch.Adapters.IObjectAdapter)
    
        
    
        
        :type objectToApplyTo: TModel
    
        
        :type adapter: Microsoft.AspNetCore.JsonPatch.Adapters.IObjectAdapter
    
        
        .. code-block:: csharp
    
            public void Apply(TModel objectToApplyTo, IObjectAdapter adapter)
    

