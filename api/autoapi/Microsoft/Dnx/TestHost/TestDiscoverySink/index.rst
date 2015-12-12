

TestDiscoverySink Class
=======================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Dnx.TestHost.TestDiscoverySink`








Syntax
------

.. code-block:: csharp

   public class TestDiscoverySink : ITestDiscoverySink





GitHub
------

`View on GitHub <https://github.com/aspnet/testing/blob/master/src/Microsoft.Dnx.TestHost/TestAdapter/TestDiscoverySink.cs>`_





.. dn:class:: Microsoft.Dnx.TestHost.TestDiscoverySink

Constructors
------------

.. dn:class:: Microsoft.Dnx.TestHost.TestDiscoverySink
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Dnx.TestHost.TestDiscoverySink.TestDiscoverySink(Microsoft.Dnx.TestHost.ReportingChannel)
    
        
        
        
        :type channel: Microsoft.Dnx.TestHost.ReportingChannel
    
        
        .. code-block:: csharp
    
           public TestDiscoverySink(ReportingChannel channel)
    

Methods
-------

.. dn:class:: Microsoft.Dnx.TestHost.TestDiscoverySink
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Dnx.TestHost.TestDiscoverySink.SendTest(Microsoft.Dnx.Testing.Abstractions.Test)
    
        
        
        
        :type test: Microsoft.Dnx.Testing.Abstractions.Test
    
        
        .. code-block:: csharp
    
           public void SendTest(Test test)
    

