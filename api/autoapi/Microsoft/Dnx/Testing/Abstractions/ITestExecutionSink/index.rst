

ITestExecutionSink Interface
============================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface ITestExecutionSink





GitHub
------

`View on GitHub <https://github.com/aspnet/testing/blob/master/src/Microsoft.Dnx.Testing.Abstractions/ITestExecutionSink.cs>`_





.. dn:interface:: Microsoft.Dnx.Testing.Abstractions.ITestExecutionSink

Methods
-------

.. dn:interface:: Microsoft.Dnx.Testing.Abstractions.ITestExecutionSink
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Dnx.Testing.Abstractions.ITestExecutionSink.RecordResult(Microsoft.Dnx.Testing.Abstractions.TestResult)
    
        
        
        
        :type testResult: Microsoft.Dnx.Testing.Abstractions.TestResult
    
        
        .. code-block:: csharp
    
           void RecordResult(TestResult testResult)
    
    .. dn:method:: Microsoft.Dnx.Testing.Abstractions.ITestExecutionSink.RecordStart(Microsoft.Dnx.Testing.Abstractions.Test)
    
        
        
        
        :type test: Microsoft.Dnx.Testing.Abstractions.Test
    
        
        .. code-block:: csharp
    
           void RecordStart(Test test)
    

