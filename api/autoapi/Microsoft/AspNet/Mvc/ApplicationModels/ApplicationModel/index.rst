

ApplicationModel Class
======================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModel`








Syntax
------

.. code-block:: csharp

   public class ApplicationModel : IPropertyModel, IFilterModel, IApiExplorerModel





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/ApplicationModels/ApplicationModel.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModel

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModel
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModel.ApplicationModel()
    
        
    
        
        .. code-block:: csharp
    
           public ApplicationModel()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModel
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModel.ApiExplorer
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Mvc.ApplicationModels.ApiExplorerModel` for the application.
    
        
        :rtype: Microsoft.AspNet.Mvc.ApplicationModels.ApiExplorerModel
    
        
        .. code-block:: csharp
    
           public ApiExplorerModel ApiExplorer { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModel.Controllers
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.ApplicationModels.ControllerModel}
    
        
        .. code-block:: csharp
    
           public IList<ControllerModel> Controllers { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModel.Filters
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.Filters.IFilterMetadata}
    
        
        .. code-block:: csharp
    
           public IList<IFilterMetadata> Filters { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModel.Properties
    
        
    
        Gets a set of properties associated with all actions.
        These properties will be copied to :dn:prop:`Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor.Properties`\.
    
        
        :rtype: System.Collections.Generic.IDictionary{System.Object,System.Object}
    
        
        .. code-block:: csharp
    
           public IDictionary<object, object> Properties { get; }
    

