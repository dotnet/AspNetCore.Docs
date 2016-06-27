

ViewComponentAttribute Class
============================






Indicates the class and all subclasses are view components. Optionally specifies a view component's name. If
defining a base class for multiple view components, associate this attribute with that base.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewComponentAttribute`








Syntax
------

.. code-block:: csharp

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class ViewComponentAttribute : Attribute, _Attribute








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponentAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponentAttribute

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponentAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewComponentAttribute.Name
    
        
    
        
        Gets or sets the name of the view component. Do not supply a name in an attribute associated with a view
        component base class.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Name { get; set; }
    

