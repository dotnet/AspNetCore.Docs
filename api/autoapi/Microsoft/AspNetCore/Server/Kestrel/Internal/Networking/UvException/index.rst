

UvException Class
=================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Kestrel.Internal.Networking`
Assemblies
    * Microsoft.AspNetCore.Server.Kestrel

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Exception`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Internal.Networking.UvException`








Syntax
------

.. code-block:: csharp

    public class UvException : Exception, ISerializable, _Exception








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Networking.UvException
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Networking.UvException

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Networking.UvException
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Internal.Networking.UvException.UvException(System.String, System.Int32)
    
        
    
        
        :type message: System.String
    
        
        :type statusCode: System.Int32
    
        
        .. code-block:: csharp
    
            public UvException(string message, int statusCode)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Networking.UvException
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.Networking.UvException.StatusCode
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int StatusCode { get; }
    

