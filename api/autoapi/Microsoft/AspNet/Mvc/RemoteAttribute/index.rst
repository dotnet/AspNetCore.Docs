

RemoteAttribute Class
=====================



.. contents:: 
   :local:



Summary
-------

A :any:`System.ComponentModel.DataAnnotations.ValidationAttribute` which configures Unobtrusive validation to send an Ajax request to the
web site. The invoked action should return JSON indicating whether the value is valid.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`System.ComponentModel.DataAnnotations.ValidationAttribute`
* :dn:cls:`Microsoft.AspNet.Mvc.RemoteAttribute`








Syntax
------

.. code-block:: csharp

   public class RemoteAttribute : ValidationAttribute, _Attribute, IClientModelValidator





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ViewFeatures/RemoteAttribute.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.RemoteAttribute

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.RemoteAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.RemoteAttribute.RemoteAttribute()
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Mvc.RemoteAttribute` class.
    
        
    
        
        .. code-block:: csharp
    
           protected RemoteAttribute()
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.RemoteAttribute.RemoteAttribute(System.String)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Mvc.RemoteAttribute` class.
    
        
        
        
        :param routeName: The route name used when generating the URL where client should send a validation request.
        
        :type routeName: System.String
    
        
        .. code-block:: csharp
    
           public RemoteAttribute(string routeName)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.RemoteAttribute.RemoteAttribute(System.String, System.String)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Mvc.RemoteAttribute` class.
    
        
        
        
        :param action: The action name used when generating the URL where client should send a validation request.
        
        :type action: System.String
        
        
        :param controller: The controller name used when generating the URL where client should send a validation request.
        
        :type controller: System.String
    
        
        .. code-block:: csharp
    
           public RemoteAttribute(string action, string controller)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.RemoteAttribute.RemoteAttribute(System.String, System.String, System.String)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Mvc.RemoteAttribute` class.
    
        
        
        
        :param action: The action name used when generating the URL where client should send a validation request.
        
        :type action: System.String
        
        
        :param controller: The controller name used when generating the URL where client should send a validation request.
        
        :type controller: System.String
        
        
        :param areaName: The name of the area containing the .
        
        :type areaName: System.String
    
        
        .. code-block:: csharp
    
           public RemoteAttribute(string action, string controller, string areaName)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.RemoteAttribute
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.RemoteAttribute.FormatAdditionalFieldsForClientValidation(System.String)
    
        
    
        Formats ``property`` and :dn:prop:`Microsoft.AspNet.Mvc.RemoteAttribute.AdditionalFields` for use in generated HTML.
    
        
        
        
        :param property: Name of the property associated with this  instance.
        
        :type property: System.String
        :rtype: System.String
        :return: Comma-separated names of fields the client should include in a validation request.
    
        
        .. code-block:: csharp
    
           public string FormatAdditionalFieldsForClientValidation(string property)
    
    .. dn:method:: Microsoft.AspNet.Mvc.RemoteAttribute.FormatErrorMessage(System.String)
    
        
        
        
        :type name: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string FormatErrorMessage(string name)
    
    .. dn:method:: Microsoft.AspNet.Mvc.RemoteAttribute.FormatPropertyForClientValidation(System.String)
    
        
    
        Formats ``property`` for use in generated HTML.
    
        
        
        
        :param property: One field name the client should include in a validation request.
        
        :type property: System.String
        :rtype: System.String
        :return: Name of a field the client should include in a validation request.
    
        
        .. code-block:: csharp
    
           public static string FormatPropertyForClientValidation(string property)
    
    .. dn:method:: Microsoft.AspNet.Mvc.RemoteAttribute.GetClientValidationRules(Microsoft.AspNet.Mvc.ModelBinding.Validation.ClientModelValidationContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ModelBinding.Validation.ClientModelValidationContext
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelClientValidationRule}
    
        
        .. code-block:: csharp
    
           public virtual IEnumerable<ModelClientValidationRule> GetClientValidationRules(ClientModelValidationContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.RemoteAttribute.GetUrl(Microsoft.AspNet.Mvc.ModelBinding.Validation.ClientModelValidationContext)
    
        
    
        Returns the URL where the client should send a validation request.
    
        
        
        
        :param context: The  used to generate the URL.
        
        :type context: Microsoft.AspNet.Mvc.ModelBinding.Validation.ClientModelValidationContext
        :rtype: System.String
        :return: The URL where the client should send a validation request.
    
        
        .. code-block:: csharp
    
           protected virtual string GetUrl(ClientModelValidationContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.RemoteAttribute.IsValid(System.Object)
    
        
        
        
        :type value: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool IsValid(object value)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.RemoteAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.RemoteAttribute.AdditionalFields
    
        
    
        Gets or sets the comma-separated names of fields the client should include in a validation request.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string AdditionalFields { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.RemoteAttribute.HttpMethod
    
        
    
        Gets or sets the HTTP method (<c>"Get"</c> or <c>"Post"</c>) client should use when sending a validation
        request.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string HttpMethod { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.RemoteAttribute.RouteData
    
        
    
        Gets the :any:`Microsoft.AspNet.Routing.RouteValueDictionary` used when generating the URL where client should send a
        validation request.
    
        
        :rtype: Microsoft.AspNet.Routing.RouteValueDictionary
    
        
        .. code-block:: csharp
    
           protected RouteValueDictionary RouteData { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.RemoteAttribute.RouteName
    
        
    
        Gets or sets the route name used when generating the URL where client should send a validation request.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           protected string RouteName { get; set; }
    

