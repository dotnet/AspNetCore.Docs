

Html5DateRenderingMode Enum
===========================






Controls the value-rendering method For HTML5 input elements of types such as date, time, datetime and
datetime-local.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Rendering`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public enum Html5DateRenderingMode








.. dn:enumeration:: Microsoft.AspNetCore.Mvc.Rendering.Html5DateRenderingMode
    :hidden:

.. dn:enumeration:: Microsoft.AspNetCore.Mvc.Rendering.Html5DateRenderingMode

Fields
------

.. dn:enumeration:: Microsoft.AspNetCore.Mvc.Rendering.Html5DateRenderingMode
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Mvc.Rendering.Html5DateRenderingMode.CurrentCulture
    
        
    
        
        Render date and time values according to the current culture's ToString behavior.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.Html5DateRenderingMode
    
        
        .. code-block:: csharp
    
            CurrentCulture = 1
    
    .. dn:field:: Microsoft.AspNetCore.Mvc.Rendering.Html5DateRenderingMode.Rfc3339
    
        
    
        
        Render date and time values as Rfc3339 compliant strings to support HTML5 date and time types of input
        elements.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.Html5DateRenderingMode
    
        
        .. code-block:: csharp
    
            Rfc3339 = 0
    

