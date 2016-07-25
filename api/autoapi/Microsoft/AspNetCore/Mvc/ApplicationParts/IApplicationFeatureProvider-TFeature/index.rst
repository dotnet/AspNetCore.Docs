

IApplicationFeatureProvider<TFeature> Interface
===============================================






A provider for a given <em>TFeature</em> feature.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ApplicationParts`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IApplicationFeatureProvider<TFeature> : IApplicationFeatureProvider








.. dn:interface:: Microsoft.AspNetCore.Mvc.ApplicationParts.IApplicationFeatureProvider`1
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.ApplicationParts.IApplicationFeatureProvider<TFeature>

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ApplicationParts.IApplicationFeatureProvider<TFeature>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ApplicationParts.IApplicationFeatureProvider<TFeature>.PopulateFeature(System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPart>, TFeature)
    
        
    
        
        Updates the <em>feature</em> intance.
    
        
    
        
        :param parts: The list of :any:`Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPart`\s of the
            application.
        
        :type parts: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPart<Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPart>}
    
        
        :param feature: The feature instance to populate.
        
        :type feature: TFeature
    
        
        .. code-block:: csharp
    
            void PopulateFeature(IEnumerable<ApplicationPart> parts, TFeature feature)
    

