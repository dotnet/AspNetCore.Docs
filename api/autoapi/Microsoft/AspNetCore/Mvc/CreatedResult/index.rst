

CreatedResult Class
===================






An :any:`Microsoft.AspNetCore.Mvc.ActionResult` that returns a Created (201) response with a Location header.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ActionResult`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ObjectResult`
* :dn:cls:`Microsoft.AspNetCore.Mvc.CreatedResult`








Syntax
------

.. code-block:: csharp

    public class CreatedResult : ObjectResult, IActionResult








.. dn:class:: Microsoft.AspNetCore.Mvc.CreatedResult
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.CreatedResult

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.CreatedResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.CreatedResult.Location
    
        
    
        
        Gets or sets the location at which the content has been created.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Location
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.CreatedResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.CreatedResult.CreatedResult(System.String, System.Object)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Mvc.CreatedResult` class with the values
        provided.
    
        
    
        
        :param location: The location at which the content has been created.
        
        :type location: System.String
    
        
        :param value: The value to format in the entity body.
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
            public CreatedResult(string location, object value)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.CreatedResult.CreatedResult(System.Uri, System.Object)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Mvc.CreatedResult` class with the values
        provided.
    
        
    
        
        :param location: The location at which the content has been created.
        
        :type location: System.Uri
    
        
        :param value: The value to format in the entity body.
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
            public CreatedResult(Uri location, object value)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.CreatedResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.CreatedResult.OnFormatting(Microsoft.AspNetCore.Mvc.ActionContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        .. code-block:: csharp
    
            public override void OnFormatting(ActionContext context)
    

