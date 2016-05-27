

IOutputFormatter Interface
==========================






Writes an object to the output stream.


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

    public interface IOutputFormatter








.. dn:interface:: Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter.CanWriteResult(Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterCanWriteContext)
    
        
    
        
        Determines whether this :any:`Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter` can serialize
        an object of the specified type.
    
        
    
        
        :param context: The formatter context associated with the call.
        
        :type context: Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterCanWriteContext
        :rtype: System.Boolean
        :return: Returns <code>true</code> if the formatter can write the response; <code>false</code> otherwise.
    
        
        .. code-block:: csharp
    
            bool CanWriteResult(OutputFormatterCanWriteContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter.WriteAsync(Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext)
    
        
    
        
        Writes the object represented by <em>context</em>'s Object property.
    
        
    
        
        :param context: The formatter context associated with the call.
        
        :type context: Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext
        :rtype: System.Threading.Tasks.Task
        :return: A Task that serializes the value to the <em>context</em>'s response message.
    
        
        .. code-block:: csharp
    
            Task WriteAsync(OutputFormatterWriteContext context)
    

