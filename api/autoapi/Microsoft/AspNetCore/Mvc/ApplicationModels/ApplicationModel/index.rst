

ApplicationModel Class
======================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ApplicationModels`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModel`








Syntax
------

.. code-block:: csharp

    [DebuggerDisplay("ApplicationModel: Controllers: {Controllers.Count}, Filters: {Filters.Count}")]
    public class ApplicationModel : IPropertyModel, IFilterModel, IApiExplorerModel








.. dn:class:: Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModel
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModel

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModel
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModel.ApiExplorer
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.ApiExplorerModel` for the application.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ApplicationModels.ApiExplorerModel
    
        
        .. code-block:: csharp
    
            public ApiExplorerModel ApiExplorer
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModel.Controllers
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.ApplicationModels.ControllerModel<Microsoft.AspNetCore.Mvc.ApplicationModels.ControllerModel>}
    
        
        .. code-block:: csharp
    
            public IList<ControllerModel> Controllers
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModel.Filters
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata<Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata>}
    
        
        .. code-block:: csharp
    
            public IList<IFilterMetadata> Filters
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModel.Properties
    
        
    
        
        Gets a set of properties associated with all actions.
        These properties will be copied to :dn:prop:`Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor.Properties`\.
    
        
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.Object<System.Object>, System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public IDictionary<object, object> Properties
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModel
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModel.ApplicationModel()
    
        
    
        
        .. code-block:: csharp
    
            public ApplicationModel()
    

