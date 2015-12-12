

ModelMetadataTypeAttribute Class
================================



.. contents:: 
   :local:



Summary
-------

This attribute specifies the metadata class to associate with a data model class.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelMetadataTypeAttribute`








Syntax
------

.. code-block:: csharp

   public class ModelMetadataTypeAttribute : Attribute, _Attribute





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/ModelMetadataTypeAttribute.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelMetadataTypeAttribute

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ModelMetadataTypeAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelMetadataTypeAttribute.ModelMetadataTypeAttribute(System.Type)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Mvc.ModelMetadataTypeAttribute` class.
    
        
        
        
        :param type: The type of metadata class that is associated with a data model class.
        
        :type type: System.Type
    
        
        .. code-block:: csharp
    
           public ModelMetadataTypeAttribute(Type type)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ModelMetadataTypeAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelMetadataTypeAttribute.MetadataType
    
        
    
        Gets the type of metadata class that is associated with a data model class.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
           public Type MetadataType { get; }
    

