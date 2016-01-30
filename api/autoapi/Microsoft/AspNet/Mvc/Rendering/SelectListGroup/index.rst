

SelectListGroup Class
=====================



.. contents:: 
   :local:



Summary
-------

Represents the optgroup HTML element and its attributes.
In a select list, multiple groups with the same name are supported.
They are compared with reference equality.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Rendering.SelectListGroup`








Syntax
------

.. code-block:: csharp

   public class SelectListGroup





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ViewFeatures/Rendering/SelectListGroup.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Rendering.SelectListGroup

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Rendering.SelectListGroup
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Rendering.SelectListGroup.Disabled
    
        
    
        Gets or sets a value that indicates whether this :any:`Microsoft.AspNet.Mvc.Rendering.SelectListGroup` is disabled.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Disabled { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Rendering.SelectListGroup.Name
    
        
    
        Represents the value of the optgroup's label.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Name { get; set; }
    

