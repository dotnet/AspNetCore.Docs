

JsonViewComponentResult Class
=============================



.. contents:: 
   :local:



Summary
-------

An :any:`Microsoft.AspNet.Mvc.IViewComponentResult` which renders JSON text when executed.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ViewComponents.JsonViewComponentResult`








Syntax
------

.. code-block:: csharp

   public class JsonViewComponentResult : IViewComponentResult





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewComponents/JsonViewComponentResult.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ViewComponents.JsonViewComponentResult

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ViewComponents.JsonViewComponentResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ViewComponents.JsonViewComponentResult.JsonViewComponentResult(System.Object)
    
        
    
        Initializes a new :any:`Microsoft.AspNet.Mvc.ViewComponents.JsonViewComponentResult`\.
    
        
        
        
        :param value: The value to format as JSON text.
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
           public JsonViewComponentResult(object value)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ViewComponents.JsonViewComponentResult.JsonViewComponentResult(System.Object, Newtonsoft.Json.JsonSerializerSettings)
    
        
    
        Initializes a new :any:`Microsoft.AspNet.Mvc.ViewComponents.JsonViewComponentResult`\.
    
        
        
        
        :param value: The value to format as JSON text.
        
        :type value: System.Object
        
        
        :param serializerSettings: The  to be used by
            the formatter.
        
        :type serializerSettings: Newtonsoft.Json.JsonSerializerSettings
    
        
        .. code-block:: csharp
    
           public JsonViewComponentResult(object value, JsonSerializerSettings serializerSettings)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ViewComponents.JsonViewComponentResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewComponents.JsonViewComponentResult.Execute(Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext)
    
        
    
        Renders JSON text to the output.
    
        
        
        
        :param context: The .
        
        :type context: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext
    
        
        .. code-block:: csharp
    
           public void Execute(ViewComponentContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewComponents.JsonViewComponentResult.ExecuteAsync(Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext)
    
        
    
        Renders JSON text to the output.
    
        
        
        
        :param context: The .
        
        :type context: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext
        :rtype: System.Threading.Tasks.Task
        :return: A completed <see cref="T:System.Threading.Tasks.Task" />.
    
        
        .. code-block:: csharp
    
           public Task ExecuteAsync(ViewComponentContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ViewComponents.JsonViewComponentResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewComponents.JsonViewComponentResult.Value
    
        
    
        Gets the value.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public object Value { get; }
    

