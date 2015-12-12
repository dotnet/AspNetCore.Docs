

HiddenInputAttribute Class
==========================



.. contents:: 
   :local:



Summary
-------

Indicates associated property or all properties of associated type should be edited using an &lt;input&gt;
element of type "hidden".





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNet.Mvc.HiddenInputAttribute`








Syntax
------

.. code-block:: csharp

   public sealed class HiddenInputAttribute : Attribute, _Attribute





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.DataAnnotations/HiddenInputAttribute.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.HiddenInputAttribute

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.HiddenInputAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.HiddenInputAttribute.HiddenInputAttribute()
    
        
    
        Instantiates a new instance of the :any:`Microsoft.AspNet.Mvc.HiddenInputAttribute` class.
    
        
    
        
        .. code-block:: csharp
    
           public HiddenInputAttribute()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.HiddenInputAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.HiddenInputAttribute.DisplayValue
    
        
    
        Gets or sets a value indicating whether to display the value as well as provide a hidden &lt;input&gt;
        element. The default value is <c>true</c>.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool DisplayValue { get; set; }
    

