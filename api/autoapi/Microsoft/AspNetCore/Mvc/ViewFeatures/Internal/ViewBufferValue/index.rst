

ViewBufferValue Struct
======================






Encapsulates a string or :any:`Microsoft.AspNetCore.Html.IHtmlContent` value.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ViewFeatures.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    [DebuggerDisplay("{DebuggerToString()}")]
    public struct ViewBufferValue








.. dn:structure:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferValue
    :hidden:

.. dn:structure:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferValue

Constructors
------------

.. dn:structure:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferValue
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferValue.ViewBufferValue(Microsoft.AspNetCore.Html.IHtmlContent)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferValue` with a :any:`Microsoft.AspNetCore.Html.IHtmlContent` value.
    
        
    
        
        :param content: The :any:`Microsoft.AspNetCore.Html.IHtmlContent`\.
        
        :type content: Microsoft.AspNetCore.Html.IHtmlContent
    
        
        .. code-block:: csharp
    
            public ViewBufferValue(IHtmlContent content)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferValue.ViewBufferValue(System.String)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferValue` with a <code>string</code> value.
    
        
    
        
        :param value: The value.
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
            public ViewBufferValue(string value)
    

Properties
----------

.. dn:structure:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferValue
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferValue.Value
    
        
    
        
        Gets the value.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public object Value { get; }
    

