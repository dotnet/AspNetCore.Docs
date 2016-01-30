

IOutputFormatter Interface
==========================



.. contents:: 
   :local:



Summary
-------

Writes an object to the output stream.











Syntax
------

.. code-block:: csharp

   public interface IOutputFormatter





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Abstractions/Formatters/IOutputFormatter.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Formatters.IOutputFormatter

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.Formatters.IOutputFormatter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.IOutputFormatter.CanWriteResult(Microsoft.AspNet.Mvc.Formatters.OutputFormatterCanWriteContext)
    
        
    
        Determines whether this :any:`Microsoft.AspNet.Mvc.Formatters.IOutputFormatter` can serialize
        an object of the specified type.
    
        
        
        
        :param context: The formatter context associated with the call.
        
        :type context: Microsoft.AspNet.Mvc.Formatters.OutputFormatterCanWriteContext
        :rtype: System.Boolean
        :return: Returns <c>true</c> if the formatter can write the response; <c>false</c> otherwise.
    
        
        .. code-block:: csharp
    
           bool CanWriteResult(OutputFormatterCanWriteContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.IOutputFormatter.WriteAsync(Microsoft.AspNet.Mvc.Formatters.OutputFormatterWriteContext)
    
        
    
        Writes the object represented by ``context``'s Object property.
    
        
        
        
        :param context: The formatter context associated with the call.
        
        :type context: Microsoft.AspNet.Mvc.Formatters.OutputFormatterWriteContext
        :rtype: System.Threading.Tasks.Task
        :return: A Task that serializes the value to the <paramref name="context" />'s response message.
    
        
        .. code-block:: csharp
    
           Task WriteAsync(OutputFormatterWriteContext context)
    

