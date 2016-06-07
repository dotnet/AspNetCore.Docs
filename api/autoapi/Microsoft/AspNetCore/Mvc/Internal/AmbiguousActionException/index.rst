

AmbiguousActionException Class
==============================






An exception which indicates multiple matches in action selection.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Exception`
* :dn:cls:`System.SystemException`
* :dn:cls:`System.InvalidOperationException`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.AmbiguousActionException`








Syntax
------

.. code-block:: csharp

    [Serializable]
    public class AmbiguousActionException : InvalidOperationException, ISerializable, _Exception








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.AmbiguousActionException
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.AmbiguousActionException

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.AmbiguousActionException
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Internal.AmbiguousActionException.AmbiguousActionException(System.Runtime.Serialization.SerializationInfo, System.Runtime.Serialization.StreamingContext)
    
        
    
        
        :type info: System.Runtime.Serialization.SerializationInfo
    
        
        :type context: System.Runtime.Serialization.StreamingContext
    
        
        .. code-block:: csharp
    
            protected AmbiguousActionException(SerializationInfo info, StreamingContext context)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Internal.AmbiguousActionException.AmbiguousActionException(System.String)
    
        
    
        
        :type message: System.String
    
        
        .. code-block:: csharp
    
            public AmbiguousActionException(string message)
    

