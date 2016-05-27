

RemoteAttribute Class
=====================






A :any:`System.ComponentModel.DataAnnotations.ValidationAttribute` which configures Unobtrusive validation to send an Ajax request to the
web site. The invoked action should return JSON indicating whether the value is valid.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`System.ComponentModel.DataAnnotations.ValidationAttribute`
* :dn:cls:`Microsoft.AspNetCore.Mvc.RemoteAttribute`








Syntax
------

.. code-block:: csharp

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class RemoteAttribute : ValidationAttribute, _Attribute, IClientModelValidator








.. dn:class:: Microsoft.AspNetCore.Mvc.RemoteAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.RemoteAttribute

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.RemoteAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.RemoteAttribute.AdditionalFields
    
        
    
        
        Gets or sets the comma-separated names of fields the client should include in a validation request.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string AdditionalFields
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.RemoteAttribute.HttpMethod
    
        
    
        
        Gets or sets the HTTP method (<code>"Get"</code> or <code>"Post"</code>) client should use when sending a validation
        request.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string HttpMethod
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.RemoteAttribute.RouteData
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Routing.RouteValueDictionary` used when generating the URL where client should send a
        validation request.
    
        
        :rtype: Microsoft.AspNetCore.Routing.RouteValueDictionary
    
        
        .. code-block:: csharp
    
            protected RouteValueDictionary RouteData
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.RemoteAttribute.RouteName
    
        
    
        
        Gets or sets the route name used when generating the URL where client should send a validation request.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            protected string RouteName
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.RemoteAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.RemoteAttribute.RemoteAttribute()
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Mvc.RemoteAttribute` class.
    
        
    
        
        .. code-block:: csharp
    
            protected RemoteAttribute()
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.RemoteAttribute.RemoteAttribute(System.String)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Mvc.RemoteAttribute` class.
    
        
    
        
        :param routeName: 
            The route name used when generating the URL where client should send a validation request.
        
        :type routeName: System.String
    
        
        .. code-block:: csharp
    
            public RemoteAttribute(string routeName)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.RemoteAttribute.RemoteAttribute(System.String, System.String)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Mvc.RemoteAttribute` class.
    
        
    
        
        :param action: 
            The action name used when generating the URL where client should send a validation request.
        
        :type action: System.String
    
        
        :param controller: 
            The controller name used when generating the URL where client should send a validation request.
        
        :type controller: System.String
    
        
        .. code-block:: csharp
    
            public RemoteAttribute(string action, string controller)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.RemoteAttribute.RemoteAttribute(System.String, System.String, System.String)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Mvc.RemoteAttribute` class.
    
        
    
        
        :param action: 
            The action name used when generating the URL where client should send a validation request.
        
        :type action: System.String
    
        
        :param controller: 
            The controller name used when generating the URL where client should send a validation request.
        
        :type controller: System.String
    
        
        :param areaName: The name of the area containing the <em>controller</em>.
        
        :type areaName: System.String
    
        
        .. code-block:: csharp
    
            public RemoteAttribute(string action, string controller, string areaName)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.RemoteAttribute
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.RemoteAttribute.AddValidation(Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientModelValidationContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientModelValidationContext
    
        
        .. code-block:: csharp
    
            public virtual void AddValidation(ClientModelValidationContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.RemoteAttribute.FormatAdditionalFieldsForClientValidation(System.String)
    
        
    
        
        Formats <em>property</em> and :dn:prop:`Microsoft.AspNetCore.Mvc.RemoteAttribute.AdditionalFields` for use in generated HTML.
    
        
    
        
        :param property: 
            Name of the property associated with this :any:`Microsoft.AspNetCore.Mvc.RemoteAttribute` instance.
        
        :type property: System.String
        :rtype: System.String
        :return: Comma-separated names of fields the client should include in a validation request.
    
        
        .. code-block:: csharp
    
            public string FormatAdditionalFieldsForClientValidation(string property)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.RemoteAttribute.FormatErrorMessage(System.String)
    
        
    
        
        :type name: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string FormatErrorMessage(string name)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.RemoteAttribute.FormatPropertyForClientValidation(System.String)
    
        
    
        
        Formats <em>property</em> for use in generated HTML.
    
        
    
        
        :param property: One field name the client should include in a validation request.
        
        :type property: System.String
        :rtype: System.String
        :return: Name of a field the client should include in a validation request.
    
        
        .. code-block:: csharp
    
            public static string FormatPropertyForClientValidation(string property)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.RemoteAttribute.GetUrl(Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientModelValidationContext)
    
        
    
        
        Returns the URL where the client should send a validation request.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientModelValidationContext` used to generate the URL.
        
        :type context: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientModelValidationContext
        :rtype: System.String
        :return: The URL where the client should send a validation request.
    
        
        .. code-block:: csharp
    
            protected virtual string GetUrl(ClientModelValidationContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.RemoteAttribute.IsValid(System.Object)
    
        
    
        
        :type value: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool IsValid(object value)
    

