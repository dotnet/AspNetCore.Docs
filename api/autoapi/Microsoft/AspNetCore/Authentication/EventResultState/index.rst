

EventResultState Enum
=====================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication`
Assemblies
    * Microsoft.AspNetCore.Authentication

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public enum EventResultState








.. dn:enumeration:: Microsoft.AspNetCore.Authentication.EventResultState
    :hidden:

.. dn:enumeration:: Microsoft.AspNetCore.Authentication.EventResultState

Fields
------

.. dn:enumeration:: Microsoft.AspNetCore.Authentication.EventResultState
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Authentication.EventResultState.Continue
    
        
    
        
        Continue with normal processing.
    
        
        :rtype: Microsoft.AspNetCore.Authentication.EventResultState
    
        
        .. code-block:: csharp
    
            Continue = 0
    
    .. dn:field:: Microsoft.AspNetCore.Authentication.EventResultState.HandledResponse
    
        
    
        
        Discontinue all processing for this request.
    
        
        :rtype: Microsoft.AspNetCore.Authentication.EventResultState
    
        
        .. code-block:: csharp
    
            HandledResponse = 2
    
    .. dn:field:: Microsoft.AspNetCore.Authentication.EventResultState.Skipped
    
        
    
        
        Discontinue processing the request in the current middleware and pass control to the next one.
    
        
        :rtype: Microsoft.AspNetCore.Authentication.EventResultState
    
        
        .. code-block:: csharp
    
            Skipped = 1
    

