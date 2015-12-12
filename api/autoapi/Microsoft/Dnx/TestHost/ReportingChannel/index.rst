

ReportingChannel Class
======================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Dnx.TestHost.ReportingChannel`








Syntax
------

.. code-block:: csharp

   public class ReportingChannel : IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/testing/blob/master/src/Microsoft.Dnx.TestHost/ReportingChannel.cs>`_





.. dn:class:: Microsoft.Dnx.TestHost.ReportingChannel

Methods
-------

.. dn:class:: Microsoft.Dnx.TestHost.ReportingChannel
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Dnx.TestHost.ReportingChannel.Dispose()
    
        
    
        
        .. code-block:: csharp
    
           public void Dispose()
    
    .. dn:method:: Microsoft.Dnx.TestHost.ReportingChannel.ListenOn(System.Int32)
    
        
        
        
        :type port: System.Int32
        :rtype: Microsoft.Dnx.TestHost.ReportingChannel
    
        
        .. code-block:: csharp
    
           public static ReportingChannel ListenOn(int port)
    
    .. dn:method:: Microsoft.Dnx.TestHost.ReportingChannel.Send(Microsoft.Dnx.TestHost.Message)
    
        
        
        
        :type message: Microsoft.Dnx.TestHost.Message
    
        
        .. code-block:: csharp
    
           public void Send(Message message)
    
    .. dn:method:: Microsoft.Dnx.TestHost.ReportingChannel.SendError(System.Exception)
    
        
        
        
        :type ex: System.Exception
    
        
        .. code-block:: csharp
    
           public void SendError(Exception ex)
    
    .. dn:method:: Microsoft.Dnx.TestHost.ReportingChannel.SendError(System.String)
    
        
        
        
        :type error: System.String
    
        
        .. code-block:: csharp
    
           public void SendError(string error)
    

Properties
----------

.. dn:class:: Microsoft.Dnx.TestHost.ReportingChannel
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Dnx.TestHost.ReportingChannel.ReadQueue
    
        
        :rtype: System.Collections.Concurrent.BlockingCollection{Microsoft.Dnx.TestHost.Message}
    
        
        .. code-block:: csharp
    
           public BlockingCollection<Message> ReadQueue { get; }
    
    .. dn:property:: Microsoft.Dnx.TestHost.ReportingChannel.Socket
    
        
        :rtype: System.Net.Sockets.Socket
    
        
        .. code-block:: csharp
    
           public Socket Socket { get; }
    

