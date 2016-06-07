

EnumGroupAndName Struct
=======================






An abstraction used when grouping enum values for :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.EnumGroupedDisplayNamesAndValues`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ModelBinding`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public struct EnumGroupAndName








.. dn:structure:: Microsoft.AspNetCore.Mvc.ModelBinding.EnumGroupAndName
    :hidden:

.. dn:structure:: Microsoft.AspNetCore.Mvc.ModelBinding.EnumGroupAndName

Properties
----------

.. dn:structure:: Microsoft.AspNetCore.Mvc.ModelBinding.EnumGroupAndName
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.EnumGroupAndName.Group
    
        
    
        
        Gets the Group name.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Group
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.EnumGroupAndName.Name
    
        
    
        
        Gets the name.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Name
            {
                get;
            }
    

Constructors
------------

.. dn:structure:: Microsoft.AspNetCore.Mvc.ModelBinding.EnumGroupAndName
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.EnumGroupAndName.EnumGroupAndName(System.String, System.String)
    
        
    
        
        Initializes a new instance of the EnumGroupAndName structure.
    
        
    
        
        :param group: The group name.
        
        :type group: System.String
    
        
        :param name: The name.
        
        :type name: System.String
    
        
        .. code-block:: csharp
    
            public EnumGroupAndName(string group, string name)
    

