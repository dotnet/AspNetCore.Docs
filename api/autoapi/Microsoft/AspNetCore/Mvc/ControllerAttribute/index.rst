

ControllerAttribute Class
=========================






Indicates that the type and any derived types that this attribute is applied to
are considered a controller by the default controller discovery mechanism, unless 
:any:`Microsoft.AspNetCore.Mvc.NonControllerAttribute` is applied to any type in the hierarchy.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ControllerAttribute`








Syntax
------

.. code-block:: csharp

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class ControllerAttribute : Attribute, _Attribute








.. dn:class:: Microsoft.AspNetCore.Mvc.ControllerAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ControllerAttribute

