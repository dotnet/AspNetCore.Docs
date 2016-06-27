

InputFormatterResult Class
==========================






Result of a :dn:meth:`Microsoft.AspNetCore.Mvc.Formatters.IInputFormatter.ReadAsync(Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext)` operation.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Formatters`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Formatters.InputFormatterResult`








Syntax
------

.. code-block:: csharp

    public class InputFormatterResult








.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.InputFormatterResult
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.InputFormatterResult

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.InputFormatterResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.InputFormatterResult.Failure()
    
        
    
        
        Returns an :any:`Microsoft.AspNetCore.Mvc.Formatters.InputFormatterResult` indicating the :dn:meth:`Microsoft.AspNetCore.Mvc.Formatters.IInputFormatter.ReadAsync(Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext)`
        operation failed.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Formatters.InputFormatterResult
        :return: 
            An :any:`Microsoft.AspNetCore.Mvc.Formatters.InputFormatterResult` indicating the :dn:meth:`Microsoft.AspNetCore.Mvc.Formatters.IInputFormatter.ReadAsync(Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext)`
            operation failed i.e. with :dn:prop:`Microsoft.AspNetCore.Mvc.Formatters.InputFormatterResult.HasError` <code>true</code>.
    
        
        .. code-block:: csharp
    
            public static InputFormatterResult Failure()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.InputFormatterResult.FailureAsync()
    
        
    
        
        Returns a :any:`System.Threading.Tasks.Task` that on completion provides an :any:`Microsoft.AspNetCore.Mvc.Formatters.InputFormatterResult` indicating
        the :dn:meth:`Microsoft.AspNetCore.Mvc.Formatters.IInputFormatter.ReadAsync(Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext)` operation failed.
    
        
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Mvc.Formatters.InputFormatterResult<Microsoft.AspNetCore.Mvc.Formatters.InputFormatterResult>}
        :return: 
            A :any:`System.Threading.Tasks.Task` that on completion provides an :any:`Microsoft.AspNetCore.Mvc.Formatters.InputFormatterResult` indicating the 
            :dn:meth:`Microsoft.AspNetCore.Mvc.Formatters.IInputFormatter.ReadAsync(Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext)` operation failed i.e. with :dn:prop:`Microsoft.AspNetCore.Mvc.Formatters.InputFormatterResult.HasError` <code>true</code>.
    
        
        .. code-block:: csharp
    
            public static Task<InputFormatterResult> FailureAsync()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.InputFormatterResult.Success(System.Object)
    
        
    
        
        Returns an :any:`Microsoft.AspNetCore.Mvc.Formatters.InputFormatterResult` indicating the :dn:meth:`Microsoft.AspNetCore.Mvc.Formatters.IInputFormatter.ReadAsync(Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext)`
        operation was successful.
    
        
    
        
        :param model: The deserialized :any:`System.Object`\.
        
        :type model: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.Formatters.InputFormatterResult
        :return: 
            An :any:`Microsoft.AspNetCore.Mvc.Formatters.InputFormatterResult` indicating the :dn:meth:`Microsoft.AspNetCore.Mvc.Formatters.IInputFormatter.ReadAsync(Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext)`
            operation succeeded i.e. with :dn:prop:`Microsoft.AspNetCore.Mvc.Formatters.InputFormatterResult.HasError` <code>false</code>.
    
        
        .. code-block:: csharp
    
            public static InputFormatterResult Success(object model)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.InputFormatterResult.SuccessAsync(System.Object)
    
        
    
        
        Returns a :any:`System.Threading.Tasks.Task` that on completion provides an :any:`Microsoft.AspNetCore.Mvc.Formatters.InputFormatterResult` indicating
        the :dn:meth:`Microsoft.AspNetCore.Mvc.Formatters.IInputFormatter.ReadAsync(Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext)` operation was successful.
    
        
    
        
        :param model: The deserialized :any:`System.Object`\.
        
        :type model: System.Object
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Mvc.Formatters.InputFormatterResult<Microsoft.AspNetCore.Mvc.Formatters.InputFormatterResult>}
        :return: 
            A :any:`System.Threading.Tasks.Task` that on completion provides an :any:`Microsoft.AspNetCore.Mvc.Formatters.InputFormatterResult` indicating the 
            :dn:meth:`Microsoft.AspNetCore.Mvc.Formatters.IInputFormatter.ReadAsync(Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext)` operation succeeded i.e. with :dn:prop:`Microsoft.AspNetCore.Mvc.Formatters.InputFormatterResult.HasError` <code>false</code>.
    
        
        .. code-block:: csharp
    
            public static Task<InputFormatterResult> SuccessAsync(object model)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.InputFormatterResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Formatters.InputFormatterResult.HasError
    
        
    
        
        Gets an indication whether the :dn:meth:`Microsoft.AspNetCore.Mvc.Formatters.IInputFormatter.ReadAsync(Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext)` operation had an error.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool HasError { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Formatters.InputFormatterResult.Model
    
        
    
        
        Gets the deserialized :any:`System.Object`\.
    
        
        :rtype: System.Object
        :return: 
            <code>null</code> if :dn:prop:`Microsoft.AspNetCore.Mvc.Formatters.InputFormatterResult.HasError` is <code>true</code>.
    
        
        .. code-block:: csharp
    
            public object Model { get; }
    

