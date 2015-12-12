

IPageExecutionContext Interface
===============================



.. contents:: 
   :local:



Summary
-------

Specifies the contracts for a execution context that instruments web page execution.











Syntax
------

.. code-block:: csharp

   public interface IPageExecutionContext





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.PageExecutionInstrumentation.Interfaces/IPageExecutionContext.cs>`_





.. dn:interface:: Microsoft.AspNet.PageExecutionInstrumentation.IPageExecutionContext

Methods
-------

.. dn:interface:: Microsoft.AspNet.PageExecutionInstrumentation.IPageExecutionContext
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.PageExecutionInstrumentation.IPageExecutionContext.BeginContext(System.Int32, System.Int32, System.Boolean)
    
        
    
        Invoked at the start of a write operation.
    
        
        
        
        :param position: The absolute character position of the expression or text in the Razor file.
        
        :type position: System.Int32
        
        
        :param length: The character length of the expression or text in the Razor file.
        
        :type length: System.Int32
        
        
        :param isLiteral: A flag that indicates if the operation is for a literal text and not for a
            language expression.
        
        :type isLiteral: System.Boolean
    
        
        .. code-block:: csharp
    
           void BeginContext(int position, int length, bool isLiteral)
    
    .. dn:method:: Microsoft.AspNet.PageExecutionInstrumentation.IPageExecutionContext.EndContext()
    
        
    
        Invoked at the end of a write operation.
    
        
    
        
        .. code-block:: csharp
    
           void EndContext()
    

