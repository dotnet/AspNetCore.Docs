

AttributeRouteModel Class
=========================





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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ApplicationModels.AttributeRouteModel`








Syntax
------

.. code-block:: csharp

    public class AttributeRouteModel








.. dn:class:: Microsoft.AspNetCore.Mvc.ApplicationModels.AttributeRouteModel
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ApplicationModels.AttributeRouteModel

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ApplicationModels.AttributeRouteModel
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ApplicationModels.AttributeRouteModel.AttributeRouteModel()
    
        
    
        
        .. code-block:: csharp
    
            public AttributeRouteModel()
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ApplicationModels.AttributeRouteModel.AttributeRouteModel(Microsoft.AspNetCore.Mvc.ApplicationModels.AttributeRouteModel)
    
        
    
        
        :type other: Microsoft.AspNetCore.Mvc.ApplicationModels.AttributeRouteModel
    
        
        .. code-block:: csharp
    
            public AttributeRouteModel(AttributeRouteModel other)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ApplicationModels.AttributeRouteModel.AttributeRouteModel(Microsoft.AspNetCore.Mvc.Routing.IRouteTemplateProvider)
    
        
    
        
        :type templateProvider: Microsoft.AspNetCore.Mvc.Routing.IRouteTemplateProvider
    
        
        .. code-block:: csharp
    
            public AttributeRouteModel(IRouteTemplateProvider templateProvider)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ApplicationModels.AttributeRouteModel
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.AttributeRouteModel.Attribute
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Routing.IRouteTemplateProvider
    
        
        .. code-block:: csharp
    
            public IRouteTemplateProvider Attribute { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.AttributeRouteModel.IsAbsoluteTemplate
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsAbsoluteTemplate { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.AttributeRouteModel.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Name { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.AttributeRouteModel.Order
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.Int32<System.Int32>}
    
        
        .. code-block:: csharp
    
            public int ? Order { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.AttributeRouteModel.Template
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Template { get; set; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ApplicationModels.AttributeRouteModel
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ApplicationModels.AttributeRouteModel.CombineAttributeRouteModel(Microsoft.AspNetCore.Mvc.ApplicationModels.AttributeRouteModel, Microsoft.AspNetCore.Mvc.ApplicationModels.AttributeRouteModel)
    
        
    
        
        Combines two :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.AttributeRouteModel` instances and returns
        a new :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.AttributeRouteModel` instance with the result.
    
        
    
        
        :param left: The left :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.AttributeRouteModel`\.
        
        :type left: Microsoft.AspNetCore.Mvc.ApplicationModels.AttributeRouteModel
    
        
        :param right: The right :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.AttributeRouteModel`\.
        
        :type right: Microsoft.AspNetCore.Mvc.ApplicationModels.AttributeRouteModel
        :rtype: Microsoft.AspNetCore.Mvc.ApplicationModels.AttributeRouteModel
        :return: A new instance of :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.AttributeRouteModel` that represents the
            combination of the two :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.AttributeRouteModel` instances or <code>null</code> if both
            parameters are <code>null</code>.
    
        
        .. code-block:: csharp
    
            public static AttributeRouteModel CombineAttributeRouteModel(AttributeRouteModel left, AttributeRouteModel right)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ApplicationModels.AttributeRouteModel.ReplaceTokens(System.String, System.Collections.Generic.IDictionary<System.String, System.String>)
    
        
    
        
        :type template: System.String
    
        
        :type values: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.String<System.String>}
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string ReplaceTokens(string template, IDictionary<string, string> values)
    

