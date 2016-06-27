

SelectListGroup Class
=====================






Represents the optgroup HTML element and its attributes.
In a select list, multiple groups with the same name are supported.
They are compared with reference equality.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Rendering`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Rendering.SelectListGroup`








Syntax
------

.. code-block:: csharp

    public class SelectListGroup








.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.SelectListGroup
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.SelectListGroup

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.SelectListGroup
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Rendering.SelectListGroup.Disabled
    
        
    
        
        Gets or sets a value that indicates whether this :any:`Microsoft.AspNetCore.Mvc.Rendering.SelectListGroup` is disabled.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Disabled { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Rendering.SelectListGroup.Name
    
        
    
        
        Represents the value of the optgroup's label.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Name { get; set; }
    

