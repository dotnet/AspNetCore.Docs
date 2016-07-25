

EventId Struct
==============





Namespace
    :dn:ns:`Microsoft.Extensions.Logging`
Assemblies
    * Microsoft.Extensions.Logging.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public struct EventId








.. dn:structure:: Microsoft.Extensions.Logging.EventId
    :hidden:

.. dn:structure:: Microsoft.Extensions.Logging.EventId

Constructors
------------

.. dn:structure:: Microsoft.Extensions.Logging.EventId
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Logging.EventId.EventId(System.Int32, System.String)
    
        
    
        
        :type id: System.Int32
    
        
        :type name: System.String
    
        
        .. code-block:: csharp
    
            public EventId(int id, string name = null)
    

Properties
----------

.. dn:structure:: Microsoft.Extensions.Logging.EventId
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Logging.EventId.Id
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Id { get; }
    
    .. dn:property:: Microsoft.Extensions.Logging.EventId.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Name { get; }
    

Operators
---------

.. dn:structure:: Microsoft.Extensions.Logging.EventId
    :noindex:
    :hidden:

    
    .. dn:operator:: Microsoft.Extensions.Logging.EventId.Implicit(System.Int32 to Microsoft.Extensions.Logging.EventId)
    
        
    
        
        :type i: System.Int32
        :rtype: Microsoft.Extensions.Logging.EventId
    
        
        .. code-block:: csharp
    
            public static implicit operator EventId(int i)
    

