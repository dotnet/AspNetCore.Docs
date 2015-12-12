

PartialParseResult Enum
=======================



.. contents:: 
   :local:



Summary
-------

The result of attempting an incremental parse











Syntax
------

.. code-block:: csharp

   public enum PartialParseResult





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor/PartialParseResult.cs>`_





.. dn:enumeration:: Microsoft.AspNet.Razor.PartialParseResult

Fields
------

.. dn:enumeration:: Microsoft.AspNet.Razor.PartialParseResult
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Razor.PartialParseResult.Accepted
    
        
    
        Indicates that the edit was accepted and has been added to the parse tree
    
        
    
        
        .. code-block:: csharp
    
           Accepted = 2
    
    .. dn:field:: Microsoft.AspNet.Razor.PartialParseResult.AutoCompleteBlock
    
        
    
        Indicates that the edit requires an auto completion to occur
    
        
    
        
        .. code-block:: csharp
    
           AutoCompleteBlock = 16
    
    .. dn:field:: Microsoft.AspNet.Razor.PartialParseResult.Provisional
    
        
    
        Indicates that the edit was accepted, but that a reparse should be forced when idle time is available
        since the edit may be misclassified
    
        
    
        
        .. code-block:: csharp
    
           Provisional = 4
    
    .. dn:field:: Microsoft.AspNet.Razor.PartialParseResult.Rejected
    
        
    
        Indicates that the edit could not be accepted and that a reparse is underway.
    
        
    
        
        .. code-block:: csharp
    
           Rejected = 1
    
    .. dn:field:: Microsoft.AspNet.Razor.PartialParseResult.SpanContextChanged
    
        
    
        Indicates that the edit caused a change in the span's context and that if any statement completions were active prior to starting this
        partial parse, they should be reinitialized.
    
        
    
        
        .. code-block:: csharp
    
           SpanContextChanged = 8
    

