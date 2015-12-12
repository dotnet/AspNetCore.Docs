

IBufferedTextWriter Interface
=============================



.. contents:: 
   :local:



Summary
-------

Specifies the contracts for a :any:`System.IO.TextWriter` that buffers its content.











Syntax
------

.. code-block:: csharp

   public interface IBufferedTextWriter





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.PageExecutionInstrumentation.Interfaces/IBufferedTextWriter.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Razor.IBufferedTextWriter

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.Razor.IBufferedTextWriter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.IBufferedTextWriter.CopyTo(System.IO.TextWriter)
    
        
    
        Copies the buffered content to the ``writer``.
    
        
        
        
        :param writer: The  to copy the contents to.
        
        :type writer: System.IO.TextWriter
    
        
        .. code-block:: csharp
    
           void CopyTo(TextWriter writer)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.IBufferedTextWriter.CopyToAsync(System.IO.TextWriter)
    
        
    
        Asynchronously copies the buffered content to the ``writer``.
    
        
        
        
        :param writer: The  to copy the contents to.
        
        :type writer: System.IO.TextWriter
        :rtype: System.Threading.Tasks.Task
        :return: A <see cref="T:System.Threading.Tasks.Task" /> representing the copy operation.
    
        
        .. code-block:: csharp
    
           Task CopyToAsync(TextWriter writer)
    

Properties
----------

.. dn:interface:: Microsoft.AspNet.Mvc.Razor.IBufferedTextWriter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.IBufferedTextWriter.IsBuffering
    
        
    
        Gets a flag that determines if content is currently being buffered.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool IsBuffering { get; }
    

