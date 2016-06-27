

ViewComponentDescriptor Class
=============================






A descriptor for a view component.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ViewComponents`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentDescriptor`








Syntax
------

.. code-block:: csharp

    [DebuggerDisplay("{DisplayName}")]
    public class ViewComponentDescriptor








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentDescriptor
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentDescriptor

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentDescriptor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentDescriptor.ViewComponentDescriptor()
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentDescriptor`\.
    
        
    
        
        .. code-block:: csharp
    
            public ViewComponentDescriptor()
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentDescriptor
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentDescriptor.DisplayName
    
        
    
        
        Gets or sets the display name of the view component.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string DisplayName { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentDescriptor.FullName
    
        
    
        
        Gets or sets the full name.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string FullName { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentDescriptor.Id
    
        
    
        
        Gets or set the generated unique identifier for this :any:`Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentDescriptor`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Id { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentDescriptor.MethodInfo
    
        
    
        
        Gets or sets the :any:`System.Reflection.MethodInfo` to invoke.
    
        
        :rtype: System.Reflection.MethodInfo
    
        
        .. code-block:: csharp
    
            public MethodInfo MethodInfo { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentDescriptor.ShortName
    
        
    
        
        Gets or sets the short name.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ShortName { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentDescriptor.TypeInfo
    
        
    
        
        Gets or sets the :any:`System.Reflection.TypeInfo`\.
    
        
        :rtype: System.Reflection.TypeInfo
    
        
        .. code-block:: csharp
    
            public TypeInfo TypeInfo { get; set; }
    

