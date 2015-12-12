

IInputFormatter Interface
=========================



.. contents:: 
   :local:



Summary
-------

Reads an object from the request body.











Syntax
------

.. code-block:: csharp

   public interface IInputFormatter





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Abstractions/Formatters/IInputFormatter.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Formatters.IInputFormatter

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.Formatters.IInputFormatter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.IInputFormatter.CanRead(Microsoft.AspNet.Mvc.Formatters.InputFormatterContext)
    
        
    
        Determines whether this :any:`Microsoft.AspNet.Mvc.Formatters.IInputFormatter` can deserialize an object of the
        ``context``'s :dn:prop:`Microsoft.AspNet.Mvc.Formatters.InputFormatterContext.ModelType`\.
    
        
        
        
        :param context: The .
        
        :type context: Microsoft.AspNet.Mvc.Formatters.InputFormatterContext
        :rtype: System.Boolean
        :return: <c>true</c> if this <see cref="T:Microsoft.AspNet.Mvc.Formatters.IInputFormatter" /> can deserialize an object of the
            <paramref name="context" />'s <see cref="P:Microsoft.AspNet.Mvc.Formatters.InputFormatterContext.ModelType" />. <c>false</c> otherwise.
    
        
        .. code-block:: csharp
    
           bool CanRead(InputFormatterContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.IInputFormatter.ReadAsync(Microsoft.AspNet.Mvc.Formatters.InputFormatterContext)
    
        
    
        Reads an object from the request body.
    
        
        
        
        :param context: The .
        
        :type context: Microsoft.AspNet.Mvc.Formatters.InputFormatterContext
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Mvc.Formatters.InputFormatterResult}
        :return: A <see cref="T:System.Threading.Tasks.Task" /> that on completion deserializes the request body.
    
        
        .. code-block:: csharp
    
           Task<InputFormatterResult> ReadAsync(InputFormatterContext context)
    

