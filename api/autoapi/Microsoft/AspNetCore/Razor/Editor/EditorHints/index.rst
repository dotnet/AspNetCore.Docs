

EditorHints Enum
================






Used within :dn:field:`SpanEditHandler.EditorHints`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.Editor`
Assemblies
    * Microsoft.AspNetCore.Razor

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    [Flags]
    public enum EditorHints








.. dn:enumeration:: Microsoft.AspNetCore.Razor.Editor.EditorHints
    :hidden:

.. dn:enumeration:: Microsoft.AspNetCore.Razor.Editor.EditorHints

Fields
------

.. dn:enumeration:: Microsoft.AspNetCore.Razor.Editor.EditorHints
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Razor.Editor.EditorHints.None
    
        
    
        
        The default (Markup or Code) editor behavior for Statement completion should be used.
        Editors can always use the default behavior, even if the span is labeled with a different CompletionType.
    
        
        :rtype: Microsoft.AspNetCore.Razor.Editor.EditorHints
    
        
        .. code-block:: csharp
    
            None = 0
    
    .. dn:field:: Microsoft.AspNetCore.Razor.Editor.EditorHints.VirtualPath
    
        
    
        
        Indicates that Virtual Path completion should be used for this span if the editor supports it.
        Editors need not support this mode of completion, and will use the default ( :dn:field:`EditorHints.None`\) behavior
        if they do not support it.
    
        
        :rtype: Microsoft.AspNetCore.Razor.Editor.EditorHints
    
        
        .. code-block:: csharp
    
            VirtualPath = 1
    

