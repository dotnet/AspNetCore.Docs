

PollingFileChangeToken Class
============================





Namespace
    :dn:ns:`Microsoft.Extensions.FileProviders.Physical`
Assemblies
    * Microsoft.Extensions.FileProviders.Physical

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.FileProviders.Physical.PollingFileChangeToken`








Syntax
------

.. code-block:: csharp

    public class PollingFileChangeToken : IChangeToken








.. dn:class:: Microsoft.Extensions.FileProviders.Physical.PollingFileChangeToken
    :hidden:

.. dn:class:: Microsoft.Extensions.FileProviders.Physical.PollingFileChangeToken

Constructors
------------

.. dn:class:: Microsoft.Extensions.FileProviders.Physical.PollingFileChangeToken
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.FileProviders.Physical.PollingFileChangeToken.PollingFileChangeToken(System.IO.FileInfo)
    
        
    
        
        :type fileInfo: System.IO.FileInfo
    
        
        .. code-block:: csharp
    
            public PollingFileChangeToken(FileInfo fileInfo)
    

Properties
----------

.. dn:class:: Microsoft.Extensions.FileProviders.Physical.PollingFileChangeToken
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.FileProviders.Physical.PollingFileChangeToken.ActiveChangeCallbacks
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool ActiveChangeCallbacks { get; }
    
    .. dn:property:: Microsoft.Extensions.FileProviders.Physical.PollingFileChangeToken.HasChanged
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool HasChanged { get; }
    

Methods
-------

.. dn:class:: Microsoft.Extensions.FileProviders.Physical.PollingFileChangeToken
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.FileProviders.Physical.PollingFileChangeToken.RegisterChangeCallback(System.Action<System.Object>, System.Object)
    
        
    
        
        :type callback: System.Action<System.Action`1>{System.Object<System.Object>}
    
        
        :type state: System.Object
        :rtype: System.IDisposable
    
        
        .. code-block:: csharp
    
            public IDisposable RegisterChangeCallback(Action<object> callback, object state)
    

