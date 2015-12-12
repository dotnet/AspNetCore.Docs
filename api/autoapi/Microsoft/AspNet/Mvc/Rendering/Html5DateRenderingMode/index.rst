

Html5DateRenderingMode Enum
===========================



.. contents:: 
   :local:



Summary
-------

Controls the value-rendering method For HTML5 input elements of types such as date, time, datetime and
datetime-local.











Syntax
------

.. code-block:: csharp

   public enum Html5DateRenderingMode





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.ViewFeatures/Rendering/Html5DateRenderingMode.cs>`_





.. dn:enumeration:: Microsoft.AspNet.Mvc.Rendering.Html5DateRenderingMode

Fields
------

.. dn:enumeration:: Microsoft.AspNet.Mvc.Rendering.Html5DateRenderingMode
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Mvc.Rendering.Html5DateRenderingMode.CurrentCulture
    
        
    
        Render date and time values according to the current culture's ToString behavior.
    
        
    
        
        .. code-block:: csharp
    
           CurrentCulture = 0
    
    .. dn:field:: Microsoft.AspNet.Mvc.Rendering.Html5DateRenderingMode.Rfc3339
    
        
    
        Render date and time values as Rfc3339 compliant strings to support HTML5 date and time types of input
        elements.
    
        
    
        
        .. code-block:: csharp
    
           Rfc3339 = 1
    

