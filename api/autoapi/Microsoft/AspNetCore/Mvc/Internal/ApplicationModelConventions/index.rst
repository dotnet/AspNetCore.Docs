

ApplicationModelConventions Class
=================================






Applies conventions to a :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModel`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.ApplicationModelConventions`








Syntax
------

.. code-block:: csharp

    public class ApplicationModelConventions








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ApplicationModelConventions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ApplicationModelConventions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ApplicationModelConventions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.ApplicationModelConventions.ApplyConventions(Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModel, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Mvc.ApplicationModels.IApplicationModelConvention>)
    
        
    
        
        Applies conventions to a :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModel`\.
    
        
    
        
        :param applicationModel: The :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModel`\.
        
        :type applicationModel: Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModel
    
        
        :param conventions: The set of conventions.
        
        :type conventions: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Mvc.ApplicationModels.IApplicationModelConvention<Microsoft.AspNetCore.Mvc.ApplicationModels.IApplicationModelConvention>}
    
        
        .. code-block:: csharp
    
            public static void ApplyConventions(ApplicationModel applicationModel, IEnumerable<IApplicationModelConvention> conventions)
    

