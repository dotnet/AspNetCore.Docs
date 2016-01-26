

FormFeature Class
=================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Http.Features.Internal.FormFeature`








Syntax
------

.. code-block:: csharp

   public class FormFeature : IFormFeature





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.AspNet.Http/Features/FormFeature.cs>`_





.. dn:class:: Microsoft.AspNet.Http.Features.Internal.FormFeature

Constructors
------------

.. dn:class:: Microsoft.AspNet.Http.Features.Internal.FormFeature
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Http.Features.Internal.FormFeature.FormFeature(Microsoft.AspNet.Http.HttpRequest)
    
        
        
        
        :type request: Microsoft.AspNet.Http.HttpRequest
    
        
        .. code-block:: csharp
    
           public FormFeature(HttpRequest request)
    
    .. dn:constructor:: Microsoft.AspNet.Http.Features.Internal.FormFeature.FormFeature(Microsoft.AspNet.Http.IFormCollection)
    
        
        
        
        :type form: Microsoft.AspNet.Http.IFormCollection
    
        
        .. code-block:: csharp
    
           public FormFeature(IFormCollection form)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Http.Features.Internal.FormFeature
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.Features.Internal.FormFeature.ReadForm()
    
        
        :rtype: Microsoft.AspNet.Http.IFormCollection
    
        
        .. code-block:: csharp
    
           public IFormCollection ReadForm()
    
    .. dn:method:: Microsoft.AspNet.Http.Features.Internal.FormFeature.ReadFormAsync(System.Threading.CancellationToken)
    
        
        
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Http.IFormCollection}
    
        
        .. code-block:: csharp
    
           public Task<IFormCollection> ReadFormAsync(CancellationToken cancellationToken)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Http.Features.Internal.FormFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.Features.Internal.FormFeature.Form
    
        
        :rtype: Microsoft.AspNet.Http.IFormCollection
    
        
        .. code-block:: csharp
    
           public IFormCollection Form { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Features.Internal.FormFeature.HasFormContentType
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool HasFormContentType { get; }
    

