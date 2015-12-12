

CreatedResult Class
===================



.. contents:: 
   :local:



Summary
-------

An :any:`Microsoft.AspNet.Mvc.ActionResult` that returns a Created (201) response with a Location header.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ActionResult`
* :dn:cls:`Microsoft.AspNet.Mvc.ObjectResult`
* :dn:cls:`Microsoft.AspNet.Mvc.CreatedResult`








Syntax
------

.. code-block:: csharp

   public class CreatedResult : ObjectResult, IActionResult





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/CreatedResult.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.CreatedResult

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.CreatedResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.CreatedResult.CreatedResult(System.String, System.Object)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Mvc.CreatedResult` class with the values
        provided.
    
        
        
        
        :param location: The location at which the content has been created.
        
        :type location: System.String
        
        
        :param value: The value to format in the entity body.
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
           public CreatedResult(string location, object value)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.CreatedResult.CreatedResult(System.Uri, System.Object)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Mvc.CreatedResult` class with the values
        provided.
    
        
        
        
        :param location: The location at which the content has been created.
        
        :type location: System.Uri
        
        
        :param value: The value to format in the entity body.
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
           public CreatedResult(Uri location, object value)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.CreatedResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.CreatedResult.OnFormatting(Microsoft.AspNet.Mvc.ActionContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ActionContext
    
        
        .. code-block:: csharp
    
           public override void OnFormatting(ActionContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.CreatedResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.CreatedResult.Location
    
        
    
        Gets or sets the location at which the content has been created.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Location { get; set; }
    

