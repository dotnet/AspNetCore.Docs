

ModelMetadataTypeAttribute Class
================================






This attribute specifies the metadata class to associate with a data model class.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelMetadataTypeAttribute`








Syntax
------

.. code-block:: csharp

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class ModelMetadataTypeAttribute : Attribute, _Attribute








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelMetadataTypeAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelMetadataTypeAttribute

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelMetadataTypeAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelMetadataTypeAttribute.ModelMetadataTypeAttribute(System.Type)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Mvc.ModelMetadataTypeAttribute` class.
    
        
    
        
        :param type: The type of metadata class that is associated with a data model class.
        
        :type type: System.Type
    
        
        .. code-block:: csharp
    
            public ModelMetadataTypeAttribute(Type type)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelMetadataTypeAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelMetadataTypeAttribute.MetadataType
    
        
    
        
        Gets the type of metadata class that is associated with a data model class.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
            public Type MetadataType { get; }
    

