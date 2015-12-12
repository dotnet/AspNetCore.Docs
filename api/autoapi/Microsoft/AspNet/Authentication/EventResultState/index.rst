

EventResultState Enum
=====================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public enum EventResultState





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authentication/Events/EventResultState.cs>`_





.. dn:enumeration:: Microsoft.AspNet.Authentication.EventResultState

Fields
------

.. dn:enumeration:: Microsoft.AspNet.Authentication.EventResultState
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Authentication.EventResultState.Continue
    
        
    
        Continue with normal processing.
    
        
    
        
        .. code-block:: csharp
    
           Continue = 0
    
    .. dn:field:: Microsoft.AspNet.Authentication.EventResultState.HandledResponse
    
        
    
        Discontinue all processing for this request.
    
        
    
        
        .. code-block:: csharp
    
           HandledResponse = 2
    
    .. dn:field:: Microsoft.AspNet.Authentication.EventResultState.Skipped
    
        
    
        Discontinue processing the request in the current middleware and pass control to the next one.
    
        
    
        
        .. code-block:: csharp
    
           Skipped = 1
    

