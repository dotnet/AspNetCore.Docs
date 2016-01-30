

ViewComponentDescriptor Class
=============================



.. contents:: 
   :local:



Summary
-------

A descriptor for a View Component.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ViewComponents.ViewComponentDescriptor`








Syntax
------

.. code-block:: csharp

   public class ViewComponentDescriptor





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewComponents/ViewComponentDescriptor.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentDescriptor

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentDescriptor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentDescriptor.ViewComponentDescriptor()
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.ViewComponents.ViewComponentDescriptor`\.
    
        
    
        
        .. code-block:: csharp
    
           public ViewComponentDescriptor()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentDescriptor
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentDescriptor.DisplayName
    
        
    
        Gets or sets the display name of the View Component.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string DisplayName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentDescriptor.FullName
    
        
    
        Gets or sets the full name.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string FullName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentDescriptor.Id
    
        
    
        Gets or set the generated unique identifier for this :any:`Microsoft.AspNet.Mvc.ViewComponents.ViewComponentDescriptor`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Id { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentDescriptor.ShortName
    
        
    
        Gets or sets the short name.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ShortName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentDescriptor.Type
    
        
    
        Gets or sets the :dn:prop:`Microsoft.AspNet.Mvc.ViewComponents.ViewComponentDescriptor.Type`\.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
           public Type Type { get; set; }
    

