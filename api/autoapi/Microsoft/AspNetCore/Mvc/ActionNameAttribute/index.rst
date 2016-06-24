

ActionNameAttribute Class
=========================






Specifies the name of an action.


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

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ActionNameAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ActionNameAttribute.ActionNameAttribute(System.String)
    
        
    
        
        Initializes a new :any:`Microsoft.AspNetCore.Mvc.ActionNameAttribute` instance.
    
        
    
        
        :param name: The name of the action.
        
        :type name: System.String
    
        
        .. code-block:: csharp
    
            public ActionNameAttribute(string name)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ActionNameAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ActionNameAttribute.Name
    
        
    
        
        Gets the name of the action.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Name { get; }
    

