

FeatureMap Class
================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Owin.OwinEnvironment`
Assemblies
    * Microsoft.AspNetCore.Owin

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Owin.OwinEnvironment.FeatureMap`








Syntax
------

.. code-block:: csharp

    public class FeatureMap








.. dn:class:: Microsoft.AspNetCore.Owin.OwinEnvironment.FeatureMap
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Owin.OwinEnvironment.FeatureMap

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Owin.OwinEnvironment.FeatureMap
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Owin.OwinEnvironment.FeatureMap.FeatureMap(System.Type, System.Func<System.Object, System.Object>)
    
        
    
        
        :type featureInterface: System.Type
    
        
        :type getter: System.Func<System.Func`2>{System.Object<System.Object>, System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public FeatureMap(Type featureInterface, Func<object, object> getter)
    
    .. dn:constructor:: Microsoft.AspNetCore.Owin.OwinEnvironment.FeatureMap.FeatureMap(System.Type, System.Func<System.Object, System.Object>, System.Action<System.Object, System.Object>)
    
        
    
        
        :type featureInterface: System.Type
    
        
        :type getter: System.Func<System.Func`2>{System.Object<System.Object>, System.Object<System.Object>}
    
        
        :type setter: System.Action<System.Action`2>{System.Object<System.Object>, System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public FeatureMap(Type featureInterface, Func<object, object> getter, Action<object, object> setter)
    
    .. dn:constructor:: Microsoft.AspNetCore.Owin.OwinEnvironment.FeatureMap.FeatureMap(System.Type, System.Func<System.Object, System.Object>, System.Func<System.Object>)
    
        
    
        
        :type featureInterface: System.Type
    
        
        :type getter: System.Func<System.Func`2>{System.Object<System.Object>, System.Object<System.Object>}
    
        
        :type defaultFactory: System.Func<System.Func`1>{System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public FeatureMap(Type featureInterface, Func<object, object> getter, Func<object> defaultFactory)
    
    .. dn:constructor:: Microsoft.AspNetCore.Owin.OwinEnvironment.FeatureMap.FeatureMap(System.Type, System.Func<System.Object, System.Object>, System.Func<System.Object>, System.Action<System.Object, System.Object>)
    
        
    
        
        :type featureInterface: System.Type
    
        
        :type getter: System.Func<System.Func`2>{System.Object<System.Object>, System.Object<System.Object>}
    
        
        :type defaultFactory: System.Func<System.Func`1>{System.Object<System.Object>}
    
        
        :type setter: System.Action<System.Action`2>{System.Object<System.Object>, System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public FeatureMap(Type featureInterface, Func<object, object> getter, Func<object> defaultFactory, Action<object, object> setter)
    
    .. dn:constructor:: Microsoft.AspNetCore.Owin.OwinEnvironment.FeatureMap.FeatureMap(System.Type, System.Func<System.Object, System.Object>, System.Func<System.Object>, System.Action<System.Object, System.Object>, System.Func<System.Object>)
    
        
    
        
        :type featureInterface: System.Type
    
        
        :type getter: System.Func<System.Func`2>{System.Object<System.Object>, System.Object<System.Object>}
    
        
        :type defaultFactory: System.Func<System.Func`1>{System.Object<System.Object>}
    
        
        :type setter: System.Action<System.Action`2>{System.Object<System.Object>, System.Object<System.Object>}
    
        
        :type featureFactory: System.Func<System.Func`1>{System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public FeatureMap(Type featureInterface, Func<object, object> getter, Func<object> defaultFactory, Action<object, object> setter, Func<object> featureFactory)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Owin.OwinEnvironment.FeatureMap
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Owin.OwinEnvironment.FeatureMap.CanSet
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool CanSet { get; }
    

