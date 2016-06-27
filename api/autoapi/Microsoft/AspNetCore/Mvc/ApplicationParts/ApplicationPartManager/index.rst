

ApplicationPartManager Class
============================






Manages the parts and features of an MVC application.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ApplicationParts`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager`








Syntax
------

.. code-block:: csharp

    public class ApplicationPartManager








.. dn:class:: Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager.ApplicationParts
    
        
    
        
        Gets the list of :any:`Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPart`\s.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPart<Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPart>}
    
        
        .. code-block:: csharp
    
            public IList<ApplicationPart> ApplicationParts { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager.FeatureProviders
    
        
    
        
        Gets the list of :any:`Microsoft.AspNetCore.Mvc.ApplicationParts.IApplicationFeatureProvider`\s.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.ApplicationParts.IApplicationFeatureProvider<Microsoft.AspNetCore.Mvc.ApplicationParts.IApplicationFeatureProvider>}
    
        
        .. code-block:: csharp
    
            public IList<IApplicationFeatureProvider> FeatureProviders { get; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager.PopulateFeature<TFeature>(TFeature)
    
        
    
        
        Populates the given <em>feature</em> using the list of 
        :any:`Microsoft.AspNetCore.Mvc.ApplicationParts.IApplicationFeatureProvider\`1`\s configured on the 
        :any:`Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager`\.
    
        
    
        
        :param feature: The feature instance to populate.
        
        :type feature: TFeature
    
        
        .. code-block:: csharp
    
            public void PopulateFeature<TFeature>(TFeature feature)
    

