

InputFormatterResult Class
==========================



.. contents:: 
   :local:



Summary
-------

Result of a :dn:meth:`Microsoft.AspNet.Mvc.Formatters.IInputFormatter.ReadAsync(Microsoft.AspNet.Mvc.Formatters.InputFormatterContext)` operation.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Formatters.InputFormatterResult`








Syntax
------

.. code-block:: csharp

   public class InputFormatterResult





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Abstractions/Formatters/InputFormatterResult.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Formatters.InputFormatterResult

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.InputFormatterResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.InputFormatterResult.Failure()
    
        
    
        Returns an :any:`Microsoft.AspNet.Mvc.Formatters.InputFormatterResult` indicating the :dn:meth:`Microsoft.AspNet.Mvc.Formatters.IInputFormatter.ReadAsync(Microsoft.AspNet.Mvc.Formatters.InputFormatterContext)`
        operation failed.
    
        
        :rtype: Microsoft.AspNet.Mvc.Formatters.InputFormatterResult
        :return: An <see cref="T:Microsoft.AspNet.Mvc.Formatters.InputFormatterResult" /> indicating the <see cref="M:Microsoft.AspNet.Mvc.Formatters.IInputFormatter.ReadAsync(Microsoft.AspNet.Mvc.Formatters.InputFormatterContext)" />
            operation failed i.e. with <see cref="P:Microsoft.AspNet.Mvc.Formatters.InputFormatterResult.HasError" /><c>true</c>.
    
        
        .. code-block:: csharp
    
           public static InputFormatterResult Failure()
    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.InputFormatterResult.FailureAsync()
    
        
    
        Returns a :any:`System.Threading.Tasks.Task` that on completion provides an :any:`Microsoft.AspNet.Mvc.Formatters.InputFormatterResult` indicating
        the :dn:meth:`Microsoft.AspNet.Mvc.Formatters.IInputFormatter.ReadAsync(Microsoft.AspNet.Mvc.Formatters.InputFormatterContext)` operation failed.
    
        
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Mvc.Formatters.InputFormatterResult}
        :return: A <see cref="T:System.Threading.Tasks.Task" /> that on completion provides an <see cref="T:Microsoft.AspNet.Mvc.Formatters.InputFormatterResult" /> indicating the
            <see cref="M:Microsoft.AspNet.Mvc.Formatters.IInputFormatter.ReadAsync(Microsoft.AspNet.Mvc.Formatters.InputFormatterContext)" /> operation failed i.e. with <see cref="P:Microsoft.AspNet.Mvc.Formatters.InputFormatterResult.HasError" /><c>true</c>.
    
        
        .. code-block:: csharp
    
           public static Task<InputFormatterResult> FailureAsync()
    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.InputFormatterResult.Success(System.Object)
    
        
    
        Returns an :any:`Microsoft.AspNet.Mvc.Formatters.InputFormatterResult` indicating the :dn:meth:`Microsoft.AspNet.Mvc.Formatters.IInputFormatter.ReadAsync(Microsoft.AspNet.Mvc.Formatters.InputFormatterContext)`
        operation was successful.
    
        
        
        
        :param model: The deserialized .
        
        :type model: System.Object
        :rtype: Microsoft.AspNet.Mvc.Formatters.InputFormatterResult
        :return: An <see cref="T:Microsoft.AspNet.Mvc.Formatters.InputFormatterResult" /> indicating the <see cref="M:Microsoft.AspNet.Mvc.Formatters.IInputFormatter.ReadAsync(Microsoft.AspNet.Mvc.Formatters.InputFormatterContext)" />
            operation succeeded i.e. with <see cref="P:Microsoft.AspNet.Mvc.Formatters.InputFormatterResult.HasError" /><c>false</c>.
    
        
        .. code-block:: csharp
    
           public static InputFormatterResult Success(object model)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.InputFormatterResult.SuccessAsync(System.Object)
    
        
    
        Returns a :any:`System.Threading.Tasks.Task` that on completion provides an :any:`Microsoft.AspNet.Mvc.Formatters.InputFormatterResult` indicating
        the :dn:meth:`Microsoft.AspNet.Mvc.Formatters.IInputFormatter.ReadAsync(Microsoft.AspNet.Mvc.Formatters.InputFormatterContext)` operation was successful.
    
        
        
        
        :param model: The deserialized .
        
        :type model: System.Object
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Mvc.Formatters.InputFormatterResult}
        :return: A <see cref="T:System.Threading.Tasks.Task" /> that on completion provides an <see cref="T:Microsoft.AspNet.Mvc.Formatters.InputFormatterResult" /> indicating the
            <see cref="M:Microsoft.AspNet.Mvc.Formatters.IInputFormatter.ReadAsync(Microsoft.AspNet.Mvc.Formatters.InputFormatterContext)" /> operation succeeded i.e. with <see cref="P:Microsoft.AspNet.Mvc.Formatters.InputFormatterResult.HasError" /><c>false</c>.
    
        
        .. code-block:: csharp
    
           public static Task<InputFormatterResult> SuccessAsync(object model)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.InputFormatterResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Formatters.InputFormatterResult.HasError
    
        
    
        Gets an indication whether the :dn:meth:`Microsoft.AspNet.Mvc.Formatters.IInputFormatter.ReadAsync(Microsoft.AspNet.Mvc.Formatters.InputFormatterContext)` operation had an error.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool HasError { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Formatters.InputFormatterResult.Model
    
        
    
        Gets the deserialized :any:`System.Object`\.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public object Model { get; }
    

