

IInputFormatter Interface
=========================






Reads an object from the request body.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Formatters`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IInputFormatter








.. dn:interface:: Microsoft.AspNetCore.Mvc.Formatters.IInputFormatter
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Formatters.IInputFormatter

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Formatters.IInputFormatter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.IInputFormatter.CanRead(Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext)
    
        
    
        
        Determines whether this :any:`Microsoft.AspNetCore.Mvc.Formatters.IInputFormatter` can deserialize an object of the
        <em>context</em>'s :dn:prop:`Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext.ModelType`\.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext`\.
        
        :type context: Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext
        :rtype: System.Boolean
        :return: 
            <code>true</code> if this :any:`Microsoft.AspNetCore.Mvc.Formatters.IInputFormatter` can deserialize an object of the
            <em>context</em>'s :dn:prop:`Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext.ModelType`\. <code>false</code> otherwise.
    
        
        .. code-block:: csharp
    
            bool CanRead(InputFormatterContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.IInputFormatter.ReadAsync(Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext)
    
        
    
        
        Reads an object from the request body.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext`\.
        
        :type context: Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Mvc.Formatters.InputFormatterResult<Microsoft.AspNetCore.Mvc.Formatters.InputFormatterResult>}
        :return: A :any:`System.Threading.Tasks.Task` that on completion deserializes the request body.
    
        
        .. code-block:: csharp
    
            Task<InputFormatterResult> ReadAsync(InputFormatterContext context)
    

