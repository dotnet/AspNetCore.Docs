

TestExecutionSink Class
=======================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Dnx.TestHost.TestExecutionSink`








Syntax
------

.. code-block:: csharp

   public class TestExecutionSink : ITestExecutionSink





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/testing/src/Microsoft.Dnx.TestHost/TestAdapter/TestExecutionSink.cs>`_





.. dn:class:: Microsoft.Dnx.TestHost.TestExecutionSink

Constructors
------------

.. dn:class:: Microsoft.Dnx.TestHost.TestExecutionSink
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Dnx.TestHost.TestExecutionSink.TestExecutionSink(Microsoft.Dnx.TestHost.ReportingChannel)
    
        
        
        
        :type channel: Microsoft.Dnx.TestHost.ReportingChannel
    
        
        .. code-block:: csharp
    
           public TestExecutionSink(ReportingChannel channel)
    

Methods
-------

.. dn:class:: Microsoft.Dnx.TestHost.TestExecutionSink
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Dnx.TestHost.TestExecutionSink.RecordResult(Microsoft.Dnx.Testing.Abstractions.TestResult)
    
        
        
        
        :type testResult: Microsoft.Dnx.Testing.Abstractions.TestResult
    
        
        .. code-block:: csharp
    
           public void RecordResult(TestResult testResult)
    
    .. dn:method:: Microsoft.Dnx.TestHost.TestExecutionSink.RecordStart(Microsoft.Dnx.Testing.Abstractions.Test)
    
        
        
        
        :type test: Microsoft.Dnx.Testing.Abstractions.Test
    
        
        .. code-block:: csharp
    
           public void RecordStart(Test test)
    

