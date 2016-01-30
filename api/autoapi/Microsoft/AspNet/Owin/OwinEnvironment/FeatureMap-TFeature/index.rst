

FeatureMap<TFeature> Class
==========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Owin.OwinEnvironment.FeatureMap`
* :dn:cls:`Microsoft.AspNet.Owin.OwinEnvironment.FeatureMap\<TFeature>`








Syntax
------

.. code-block:: csharp

   public class FeatureMap<TFeature> : OwinEnvironment.FeatureMap





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.AspNet.Owin/OwinEnvironment.cs>`_





.. dn:class:: Microsoft.AspNet.Owin.OwinEnvironment.FeatureMap<TFeature>

Constructors
------------

.. dn:class:: Microsoft.AspNet.Owin.OwinEnvironment.FeatureMap<TFeature>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Owin.OwinEnvironment.FeatureMap<TFeature>.FeatureMap(System.Func<TFeature, System.Object>)
    
        
        
        
        :type getter: System.Func{{TFeature},System.Object}
    
        
        .. code-block:: csharp
    
           public FeatureMap(Func<TFeature, object> getter)
    
    .. dn:constructor:: Microsoft.AspNet.Owin.OwinEnvironment.FeatureMap<TFeature>.FeatureMap(System.Func<TFeature, System.Object>, System.Action<TFeature, System.Object>)
    
        
        
        
        :type getter: System.Func{{TFeature},System.Object}
        
        
        :type setter: System.Action{{TFeature},System.Object}
    
        
        .. code-block:: csharp
    
           public FeatureMap(Func<TFeature, object> getter, Action<TFeature, object> setter)
    
    .. dn:constructor:: Microsoft.AspNet.Owin.OwinEnvironment.FeatureMap<TFeature>.FeatureMap(System.Func<TFeature, System.Object>, System.Func<System.Object>)
    
        
        
        
        :type getter: System.Func{{TFeature},System.Object}
        
        
        :type defaultFactory: System.Func{System.Object}
    
        
        .. code-block:: csharp
    
           public FeatureMap(Func<TFeature, object> getter, Func<object> defaultFactory)
    
    .. dn:constructor:: Microsoft.AspNet.Owin.OwinEnvironment.FeatureMap<TFeature>.FeatureMap(System.Func<TFeature, System.Object>, System.Func<System.Object>, System.Action<TFeature, System.Object>)
    
        
        
        
        :type getter: System.Func{{TFeature},System.Object}
        
        
        :type defaultFactory: System.Func{System.Object}
        
        
        :type setter: System.Action{{TFeature},System.Object}
    
        
        .. code-block:: csharp
    
           public FeatureMap(Func<TFeature, object> getter, Func<object> defaultFactory, Action<TFeature, object> setter)
    
    .. dn:constructor:: Microsoft.AspNet.Owin.OwinEnvironment.FeatureMap<TFeature>.FeatureMap(System.Func<TFeature, System.Object>, System.Func<System.Object>, System.Action<TFeature, System.Object>, System.Func<TFeature>)
    
        
        
        
        :type getter: System.Func{{TFeature},System.Object}
        
        
        :type defaultFactory: System.Func{System.Object}
        
        
        :type setter: System.Action{{TFeature},System.Object}
        
        
        :type featureFactory: System.Func{{TFeature}}
    
        
        .. code-block:: csharp
    
           public FeatureMap(Func<TFeature, object> getter, Func<object> defaultFactory, Action<TFeature, object> setter, Func<TFeature> featureFactory)
    

