

EnumGroupAndName Struct
=======================



.. contents:: 
   :local:



Summary
-------

An abstraction used when grouping enum values for :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata.EnumGroupedDisplayNamesAndValues`\.











Syntax
------

.. code-block:: csharp

   public struct EnumGroupAndName





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Abstractions/ModelBinding/EnumGroupAndName.cs>`_





.. dn:structure:: Microsoft.AspNet.Mvc.ModelBinding.EnumGroupAndName

Constructors
------------

.. dn:structure:: Microsoft.AspNet.Mvc.ModelBinding.EnumGroupAndName
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.EnumGroupAndName.EnumGroupAndName(System.String, System.String)
    
        
    
        Initializes a new instance of the EnumGroupAndName structure.
    
        
        
        
        :param group: The group name.
        
        :type group: System.String
        
        
        :param name: The name.
        
        :type name: System.String
    
        
        .. code-block:: csharp
    
           public EnumGroupAndName(string group, string name)
    

Properties
----------

.. dn:structure:: Microsoft.AspNet.Mvc.ModelBinding.EnumGroupAndName
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.EnumGroupAndName.Group
    
        
    
        Gets the Group name.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Group { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.EnumGroupAndName.Name
    
        
    
        Gets the name.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Name { get; }
    

