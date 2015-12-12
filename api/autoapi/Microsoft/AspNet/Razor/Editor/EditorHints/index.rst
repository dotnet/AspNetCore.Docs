

EditorHints Enum
================



.. contents:: 
   :local:



Summary
-------

Used within :dn:field:`SpanEditHandler.EditorHints`\.











Syntax
------

.. code-block:: csharp

   public enum EditorHints





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor/Editor/EditorHints.cs>`_





.. dn:enumeration:: Microsoft.AspNet.Razor.Editor.EditorHints

Fields
------

.. dn:enumeration:: Microsoft.AspNet.Razor.Editor.EditorHints
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Razor.Editor.EditorHints.None
    
        
    
        The default (Markup or Code) editor behavior for Statement completion should be used.
        Editors can always use the default behavior, even if the span is labeled with a different CompletionType.
    
        
    
        
        .. code-block:: csharp
    
           None = 0
    
    .. dn:field:: Microsoft.AspNet.Razor.Editor.EditorHints.VirtualPath
    
        
    
        Indicates that Virtual Path completion should be used for this span if the editor supports it.
        Editors need not support this mode of completion, and will use the default ( :dn:field:`EditorHints.None`\) behavior
        if they do not support it.
    
        
    
        
        .. code-block:: csharp
    
           VirtualPath = 1
    

