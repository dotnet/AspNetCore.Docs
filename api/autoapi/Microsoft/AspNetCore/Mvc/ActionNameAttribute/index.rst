

ActionNameAttribute Class
=========================





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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ActionNameAttribute`








Syntax
------

.. code-block:: csharp

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class ActionNameAttribute : Attribute, _Attribute








.. dn:class:: Microsoft.AspNetCore.Mvc.ActionNameAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ActionNameAttribute

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ActionNameAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ActionNameAttribute.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Name
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ActionNameAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ActionNameAttribute.ActionNameAttribute(System.String)
    
        
    
        
        :type name: System.String
    
        
        .. code-block:: csharp
    
            public ActionNameAttribute(string name)
    

