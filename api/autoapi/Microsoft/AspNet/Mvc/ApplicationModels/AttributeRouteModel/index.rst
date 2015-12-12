

AttributeRouteModel Class
=========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ApplicationModels.AttributeRouteModel`








Syntax
------

.. code-block:: csharp

   public class AttributeRouteModel





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/ApplicationModels/AttributeRouteModel.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ApplicationModels.AttributeRouteModel

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ApplicationModels.AttributeRouteModel
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ApplicationModels.AttributeRouteModel.AttributeRouteModel()
    
        
    
        
        .. code-block:: csharp
    
           public AttributeRouteModel()
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ApplicationModels.AttributeRouteModel.AttributeRouteModel(Microsoft.AspNet.Mvc.ApplicationModels.AttributeRouteModel)
    
        
        
        
        :type other: Microsoft.AspNet.Mvc.ApplicationModels.AttributeRouteModel
    
        
        .. code-block:: csharp
    
           public AttributeRouteModel(AttributeRouteModel other)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ApplicationModels.AttributeRouteModel.AttributeRouteModel(Microsoft.AspNet.Mvc.Infrastructure.IRouteTemplateProvider)
    
        
        
        
        :type templateProvider: Microsoft.AspNet.Mvc.Infrastructure.IRouteTemplateProvider
    
        
        .. code-block:: csharp
    
           public AttributeRouteModel(IRouteTemplateProvider templateProvider)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ApplicationModels.AttributeRouteModel
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ApplicationModels.AttributeRouteModel.CombineAttributeRouteModel(Microsoft.AspNet.Mvc.ApplicationModels.AttributeRouteModel, Microsoft.AspNet.Mvc.ApplicationModels.AttributeRouteModel)
    
        
    
        Combines two :any:`Microsoft.AspNet.Mvc.ApplicationModels.AttributeRouteModel` instances and returns
        a new :any:`Microsoft.AspNet.Mvc.ApplicationModels.AttributeRouteModel` instance with the result.
    
        
        
        
        :param left: The left .
        
        :type left: Microsoft.AspNet.Mvc.ApplicationModels.AttributeRouteModel
        
        
        :param right: The right .
        
        :type right: Microsoft.AspNet.Mvc.ApplicationModels.AttributeRouteModel
        :rtype: Microsoft.AspNet.Mvc.ApplicationModels.AttributeRouteModel
        :return: A new instance of <see cref="T:Microsoft.AspNet.Mvc.ApplicationModels.AttributeRouteModel" /> that represents the
            combination of the two <see cref="T:Microsoft.AspNet.Mvc.ApplicationModels.AttributeRouteModel" /> instances or <c>null</c> if both
            parameters are <c>null</c>.
    
        
        .. code-block:: csharp
    
           public static AttributeRouteModel CombineAttributeRouteModel(AttributeRouteModel left, AttributeRouteModel right)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ApplicationModels.AttributeRouteModel.ReplaceTokens(System.String, System.Collections.Generic.IDictionary<System.String, System.Object>)
    
        
        
        
        :type template: System.String
        
        
        :type values: System.Collections.Generic.IDictionary{System.String,System.Object}
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public static string ReplaceTokens(string template, IDictionary<string, object> values)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ApplicationModels.AttributeRouteModel
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.AttributeRouteModel.Attribute
    
        
        :rtype: Microsoft.AspNet.Mvc.Infrastructure.IRouteTemplateProvider
    
        
        .. code-block:: csharp
    
           public IRouteTemplateProvider Attribute { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.AttributeRouteModel.IsAbsoluteTemplate
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsAbsoluteTemplate { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.AttributeRouteModel.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Name { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.AttributeRouteModel.Order
    
        
        :rtype: System.Nullable{System.Int32}
    
        
        .. code-block:: csharp
    
           public int ? Order { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.AttributeRouteModel.Template
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Template { get; set; }
    

