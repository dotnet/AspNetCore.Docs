

FeatureMap Class
================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Owin.OwinEnvironment.FeatureMap`








Syntax
------

.. code-block:: csharp

   public class FeatureMap





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.Owin/OwinEnvironment.cs>`_





.. dn:class:: Microsoft.AspNet.Owin.OwinEnvironment.FeatureMap

Constructors
------------

.. dn:class:: Microsoft.AspNet.Owin.OwinEnvironment.FeatureMap
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Owin.OwinEnvironment.FeatureMap.FeatureMap(System.Type, System.Func<System.Object, System.Object>)
    
        
        
        
        :type featureInterface: System.Type
        
        
        :type getter: System.Func{System.Object,System.Object}
    
        
        .. code-block:: csharp
    
           public FeatureMap(Type featureInterface, Func<object, object> getter)
    
    .. dn:constructor:: Microsoft.AspNet.Owin.OwinEnvironment.FeatureMap.FeatureMap(System.Type, System.Func<System.Object, System.Object>, System.Action<System.Object, System.Object>)
    
        
        
        
        :type featureInterface: System.Type
        
        
        :type getter: System.Func{System.Object,System.Object}
        
        
        :type setter: System.Action{System.Object,System.Object}
    
        
        .. code-block:: csharp
    
           public FeatureMap(Type featureInterface, Func<object, object> getter, Action<object, object> setter)
    
    .. dn:constructor:: Microsoft.AspNet.Owin.OwinEnvironment.FeatureMap.FeatureMap(System.Type, System.Func<System.Object, System.Object>, System.Func<System.Object>)
    
        
        
        
        :type featureInterface: System.Type
        
        
        :type getter: System.Func{System.Object,System.Object}
        
        
        :type defaultFactory: System.Func{System.Object}
    
        
        .. code-block:: csharp
    
           public FeatureMap(Type featureInterface, Func<object, object> getter, Func<object> defaultFactory)
    
    .. dn:constructor:: Microsoft.AspNet.Owin.OwinEnvironment.FeatureMap.FeatureMap(System.Type, System.Func<System.Object, System.Object>, System.Func<System.Object>, System.Action<System.Object, System.Object>)
    
        
        
        
        :type featureInterface: System.Type
        
        
        :type getter: System.Func{System.Object,System.Object}
        
        
        :type defaultFactory: System.Func{System.Object}
        
        
        :type setter: System.Action{System.Object,System.Object}
    
        
        .. code-block:: csharp
    
           public FeatureMap(Type featureInterface, Func<object, object> getter, Func<object> defaultFactory, Action<object, object> setter)
    
    .. dn:constructor:: Microsoft.AspNet.Owin.OwinEnvironment.FeatureMap.FeatureMap(System.Type, System.Func<System.Object, System.Object>, System.Func<System.Object>, System.Action<System.Object, System.Object>, System.Func<System.Object>)
    
        
        
        
        :type featureInterface: System.Type
        
        
        :type getter: System.Func{System.Object,System.Object}
        
        
        :type defaultFactory: System.Func{System.Object}
        
        
        :type setter: System.Action{System.Object,System.Object}
        
        
        :type featureFactory: System.Func{System.Object}
    
        
        .. code-block:: csharp
    
           public FeatureMap(Type featureInterface, Func<object, object> getter, Func<object> defaultFactory, Action<object, object> setter, Func<object> featureFactory)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Owin.OwinEnvironment.FeatureMap
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Owin.OwinEnvironment.FeatureMap.CanSet
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool CanSet { get; }
    

