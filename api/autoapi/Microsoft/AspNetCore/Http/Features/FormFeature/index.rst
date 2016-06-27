

FormFeature Class
=================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Http.Features`
Assemblies
    * Microsoft.AspNetCore.Http

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Http.Features.FormFeature`








Syntax
------

.. code-block:: csharp

    public class FormFeature : IFormFeature








.. dn:class:: Microsoft.AspNetCore.Http.Features.FormFeature
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Http.Features.FormFeature

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Http.Features.FormFeature
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Http.Features.FormFeature.FormFeature(Microsoft.AspNetCore.Http.HttpRequest)
    
        
    
        
        :type request: Microsoft.AspNetCore.Http.HttpRequest
    
        
        .. code-block:: csharp
    
            public FormFeature(HttpRequest request)
    
    .. dn:constructor:: Microsoft.AspNetCore.Http.Features.FormFeature.FormFeature(Microsoft.AspNetCore.Http.HttpRequest, Microsoft.AspNetCore.Http.Features.FormOptions)
    
        
    
        
        :type request: Microsoft.AspNetCore.Http.HttpRequest
    
        
        :type options: Microsoft.AspNetCore.Http.Features.FormOptions
    
        
        .. code-block:: csharp
    
            public FormFeature(HttpRequest request, FormOptions options)
    
    .. dn:constructor:: Microsoft.AspNetCore.Http.Features.FormFeature.FormFeature(Microsoft.AspNetCore.Http.IFormCollection)
    
        
    
        
        :type form: Microsoft.AspNetCore.Http.IFormCollection
    
        
        .. code-block:: csharp
    
            public FormFeature(IFormCollection form)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Http.Features.FormFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.FormFeature.Form
    
        
        :rtype: Microsoft.AspNetCore.Http.IFormCollection
    
        
        .. code-block:: csharp
    
            public IFormCollection Form { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.FormFeature.HasFormContentType
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool HasFormContentType { get; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Http.Features.FormFeature
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.Features.FormFeature.ReadForm()
    
        
        :rtype: Microsoft.AspNetCore.Http.IFormCollection
    
        
        .. code-block:: csharp
    
            public IFormCollection ReadForm()
    
    .. dn:method:: Microsoft.AspNetCore.Http.Features.FormFeature.ReadFormAsync()
    
        
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Http.IFormCollection<Microsoft.AspNetCore.Http.IFormCollection>}
    
        
        .. code-block:: csharp
    
            public Task<IFormCollection> ReadFormAsync()
    
    .. dn:method:: Microsoft.AspNetCore.Http.Features.FormFeature.ReadFormAsync(System.Threading.CancellationToken)
    
        
    
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Http.IFormCollection<Microsoft.AspNetCore.Http.IFormCollection>}
    
        
        .. code-block:: csharp
    
            public Task<IFormCollection> ReadFormAsync(CancellationToken cancellationToken)
    

