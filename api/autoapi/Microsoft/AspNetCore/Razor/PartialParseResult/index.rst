

PartialParseResult Enum
=======================






The result of attempting an incremental parse


Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor`
Assemblies
    * Microsoft.AspNetCore.Razor

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    [Flags]
    public enum PartialParseResult








.. dn:enumeration:: Microsoft.AspNetCore.Razor.PartialParseResult
    :hidden:

.. dn:enumeration:: Microsoft.AspNetCore.Razor.PartialParseResult

Fields
------

.. dn:enumeration:: Microsoft.AspNetCore.Razor.PartialParseResult
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Razor.PartialParseResult.Accepted
    
        
    
        
        Indicates that the edit was accepted and has been added to the parse tree
    
        
        :rtype: Microsoft.AspNetCore.Razor.PartialParseResult
    
        
        .. code-block:: csharp
    
            Accepted = 2
    
    .. dn:field:: Microsoft.AspNetCore.Razor.PartialParseResult.AutoCompleteBlock
    
        
    
        
        Indicates that the edit requires an auto completion to occur
    
        
        :rtype: Microsoft.AspNetCore.Razor.PartialParseResult
    
        
        .. code-block:: csharp
    
            AutoCompleteBlock = 16
    
    .. dn:field:: Microsoft.AspNetCore.Razor.PartialParseResult.Provisional
    
        
    
        
        Indicates that the edit was accepted, but that a reparse should be forced when idle time is available
        since the edit may be misclassified
    
        
        :rtype: Microsoft.AspNetCore.Razor.PartialParseResult
    
        
        .. code-block:: csharp
    
            Provisional = 4
    
    .. dn:field:: Microsoft.AspNetCore.Razor.PartialParseResult.Rejected
    
        
    
        
        Indicates that the edit could not be accepted and that a reparse is underway.
    
        
        :rtype: Microsoft.AspNetCore.Razor.PartialParseResult
    
        
        .. code-block:: csharp
    
            Rejected = 1
    
    .. dn:field:: Microsoft.AspNetCore.Razor.PartialParseResult.SpanContextChanged
    
        
    
        
        Indicates that the edit caused a change in the span's context and that if any statement completions were active prior to starting this
        partial parse, they should be reinitialized.
    
        
        :rtype: Microsoft.AspNetCore.Razor.PartialParseResult
    
        
        .. code-block:: csharp
    
            SpanContextChanged = 8
    

