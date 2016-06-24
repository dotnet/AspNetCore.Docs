

HiddenInputAttribute Class
==========================






Indicates associated property or all properties of associated type should be edited using an <input>
element of type "hidden".


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc`
Assemblies
    * Microsoft.AspNetCore.Mvc.DataAnnotations

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNetCore.Mvc.HiddenInputAttribute`








Syntax
------

.. code-block:: csharp

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class HiddenInputAttribute : Attribute, _Attribute








.. dn:class:: Microsoft.AspNetCore.Mvc.HiddenInputAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.HiddenInputAttribute

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.HiddenInputAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.HiddenInputAttribute.HiddenInputAttribute()
    
        
    
        
        Instantiates a new instance of the :any:`Microsoft.AspNetCore.Mvc.HiddenInputAttribute` class.
    
        
    
        
        .. code-block:: csharp
    
            public HiddenInputAttribute()
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.HiddenInputAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.HiddenInputAttribute.DisplayValue
    
        
    
        
        Gets or sets a value indicating whether to display the value as well as provide a hidden <input>
        element. The default value is <code>true</code>.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool DisplayValue { get; set; }
    

