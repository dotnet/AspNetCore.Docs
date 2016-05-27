

FeatureMap<TFeature> Class
==========================





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
* :dn:cls:`Microsoft.AspNetCore.Owin.OwinEnvironment.FeatureMap\<TFeature>`








Syntax
------

.. code-block:: csharp

    public class FeatureMap<TFeature> : OwinEnvironment.FeatureMap








.. dn:class:: Microsoft.AspNetCore.Owin.OwinEnvironment.FeatureMap`1
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Owin.OwinEnvironment.FeatureMap<TFeature>

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Owin.OwinEnvironment.FeatureMap<TFeature>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Owin.OwinEnvironment.FeatureMap<TFeature>.FeatureMap(System.Func<TFeature, System.Object>)
    
        
    
        
        :type getter: System.Func<System.Func`2>{TFeature, System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public FeatureMap(Func<TFeature, object> getter)
    
    .. dn:constructor:: Microsoft.AspNetCore.Owin.OwinEnvironment.FeatureMap<TFeature>.FeatureMap(System.Func<TFeature, System.Object>, System.Action<TFeature, System.Object>)
    
        
    
        
        :type getter: System.Func<System.Func`2>{TFeature, System.Object<System.Object>}
    
        
        :type setter: System.Action<System.Action`2>{TFeature, System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public FeatureMap(Func<TFeature, object> getter, Action<TFeature, object> setter)
    
    .. dn:constructor:: Microsoft.AspNetCore.Owin.OwinEnvironment.FeatureMap<TFeature>.FeatureMap(System.Func<TFeature, System.Object>, System.Func<System.Object>)
    
        
    
        
        :type getter: System.Func<System.Func`2>{TFeature, System.Object<System.Object>}
    
        
        :type defaultFactory: System.Func<System.Func`1>{System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public FeatureMap(Func<TFeature, object> getter, Func<object> defaultFactory)
    
    .. dn:constructor:: Microsoft.AspNetCore.Owin.OwinEnvironment.FeatureMap<TFeature>.FeatureMap(System.Func<TFeature, System.Object>, System.Func<System.Object>, System.Action<TFeature, System.Object>)
    
        
    
        
        :type getter: System.Func<System.Func`2>{TFeature, System.Object<System.Object>}
    
        
        :type defaultFactory: System.Func<System.Func`1>{System.Object<System.Object>}
    
        
        :type setter: System.Action<System.Action`2>{TFeature, System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public FeatureMap(Func<TFeature, object> getter, Func<object> defaultFactory, Action<TFeature, object> setter)
    
    .. dn:constructor:: Microsoft.AspNetCore.Owin.OwinEnvironment.FeatureMap<TFeature>.FeatureMap(System.Func<TFeature, System.Object>, System.Func<System.Object>, System.Action<TFeature, System.Object>, System.Func<TFeature>)
    
        
    
        
        :type getter: System.Func<System.Func`2>{TFeature, System.Object<System.Object>}
    
        
        :type defaultFactory: System.Func<System.Func`1>{System.Object<System.Object>}
    
        
        :type setter: System.Action<System.Action`2>{TFeature, System.Object<System.Object>}
    
        
        :type featureFactory: System.Func<System.Func`1>{TFeature}
    
        
        .. code-block:: csharp
    
            public FeatureMap(Func<TFeature, object> getter, Func<object> defaultFactory, Action<TFeature, object> setter, Func<TFeature> featureFactory)
    

