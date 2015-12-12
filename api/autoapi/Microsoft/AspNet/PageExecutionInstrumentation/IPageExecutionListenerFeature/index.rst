

IPageExecutionListenerFeature Interface
=======================================



.. contents:: 
   :local:



Summary
-------

Specifies the contracts for a HTTP feature that provides the context to instrument a web page.











Syntax
------

.. code-block:: csharp

   public interface IPageExecutionListenerFeature





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.PageExecutionInstrumentation.Interfaces/IPageExecutionListenerFeature.cs>`_





.. dn:interface:: Microsoft.AspNet.PageExecutionInstrumentation.IPageExecutionListenerFeature

Methods
-------

.. dn:interface:: Microsoft.AspNet.PageExecutionInstrumentation.IPageExecutionListenerFeature
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.PageExecutionInstrumentation.IPageExecutionListenerFeature.DecorateWriter(System.IO.TextWriter)
    
        
    
        Decorates the :any:`System.IO.TextWriter` used by web page instances to
        write the result to.
    
        
        
        
        :param writer: The output  for the web page.
        
        :type writer: System.IO.TextWriter
        :rtype: System.IO.TextWriter
        :return: A <see cref="T:System.IO.TextWriter" /> that wraps <paramref name="writer" />.
    
        
        .. code-block:: csharp
    
           TextWriter DecorateWriter(TextWriter writer)
    
    .. dn:method:: Microsoft.AspNet.PageExecutionInstrumentation.IPageExecutionListenerFeature.GetContext(System.String, System.IO.TextWriter)
    
        
    
        Creates a :any:`Microsoft.AspNet.PageExecutionInstrumentation.IPageExecutionContext` for the specified ``sourceFilePath``.
    
        
        
        
        :param sourceFilePath: The path of the page.
        
        :type sourceFilePath: System.String
        
        
        :param writer: The  obtained from .
        
        :type writer: System.IO.TextWriter
        :rtype: Microsoft.AspNet.PageExecutionInstrumentation.IPageExecutionContext
        :return: The <see cref="T:Microsoft.AspNet.PageExecutionInstrumentation.IPageExecutionContext" />.
    
        
        .. code-block:: csharp
    
           IPageExecutionContext GetContext(string sourceFilePath, TextWriter writer)
    

