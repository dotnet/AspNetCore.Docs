

ViewDataInfo Class
==================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ViewFeatures`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataInfo`








Syntax
------

.. code-block:: csharp

    public class ViewDataInfo








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataInfo
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataInfo

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataInfo
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataInfo.ViewDataInfo(System.Object, System.Object)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataInfo` class with info about a 
        :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary` lookup which has already been evaluated.
    
        
    
        
        :type container: System.Object
    
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
            public ViewDataInfo(object container, object value)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataInfo.ViewDataInfo(System.Object, System.Reflection.PropertyInfo, System.Func<System.Object>)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataInfo` class with info about a 
        :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary` lookup which is evaluated when :dn:prop:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataInfo.Value` is read.
    
        
    
        
        :type container: System.Object
    
        
        :type propertyInfo: System.Reflection.PropertyInfo
    
        
        :type valueAccessor: System.Func<System.Func`1>{System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public ViewDataInfo(object container, PropertyInfo propertyInfo, Func<object> valueAccessor)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataInfo
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataInfo.Container
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public object Container { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataInfo.PropertyInfo
    
        
        :rtype: System.Reflection.PropertyInfo
    
        
        .. code-block:: csharp
    
            public PropertyInfo PropertyInfo { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataInfo.Value
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public object Value { get; set; }
    

