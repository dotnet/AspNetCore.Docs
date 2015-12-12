

Operation<TModel> Class
=======================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.JsonPatch.Operations.OperationBase`
* :dn:cls:`Microsoft.AspNet.JsonPatch.Operations.Operation`
* :dn:cls:`Microsoft.AspNet.JsonPatch.Operations.Operation\<TModel>`








Syntax
------

.. code-block:: csharp

   public class Operation<TModel> : Operation where TModel : class





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/jsonpatch/src/Microsoft.AspNet.JsonPatch/Operations/OperationOfT.cs>`_





.. dn:class:: Microsoft.AspNet.JsonPatch.Operations.Operation<TModel>

Constructors
------------

.. dn:class:: Microsoft.AspNet.JsonPatch.Operations.Operation<TModel>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.JsonPatch.Operations.Operation<TModel>.Operation()
    
        
    
        
        .. code-block:: csharp
    
           public Operation()
    
    .. dn:constructor:: Microsoft.AspNet.JsonPatch.Operations.Operation<TModel>.Operation(System.String, System.String, System.String)
    
        
        
        
        :type op: System.String
        
        
        :type path: System.String
        
        
        :type from: System.String
    
        
        .. code-block:: csharp
    
           public Operation(string op, string path, string from)
    
    .. dn:constructor:: Microsoft.AspNet.JsonPatch.Operations.Operation<TModel>.Operation(System.String, System.String, System.String, System.Object)
    
        
        
        
        :type op: System.String
        
        
        :type path: System.String
        
        
        :type from: System.String
        
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
           public Operation(string op, string path, string from, object value)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.JsonPatch.Operations.Operation<TModel>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.JsonPatch.Operations.Operation<TModel>.Apply(TModel, Microsoft.AspNet.JsonPatch.Adapters.IObjectAdapter)
    
        
        
        
        :type objectToApplyTo: {TModel}
        
        
        :type adapter: Microsoft.AspNet.JsonPatch.Adapters.IObjectAdapter
    
        
        .. code-block:: csharp
    
           public void Apply(TModel objectToApplyTo, IObjectAdapter adapter)
    

