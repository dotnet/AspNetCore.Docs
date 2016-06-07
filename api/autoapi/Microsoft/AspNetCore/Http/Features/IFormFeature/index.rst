

IFormFeature Interface
======================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Http.Features`
Assemblies
    * Microsoft.AspNetCore.Http.Features

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IFormFeature








.. dn:interface:: Microsoft.AspNetCore.Http.Features.IFormFeature
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Http.Features.IFormFeature

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Http.Features.IFormFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.IFormFeature.Form
    
        
    
        
        The parsed form, if any.
    
        
        :rtype: Microsoft.AspNetCore.Http.IFormCollection
    
        
        .. code-block:: csharp
    
            IFormCollection Form
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.IFormFeature.HasFormContentType
    
        
    
        
        Indicates if the request has a supported form content-type.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            bool HasFormContentType
            {
                get;
            }
    

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Http.Features.IFormFeature
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.Features.IFormFeature.ReadForm()
    
        
    
        
        Parses the request body as a form.
    
        
        :rtype: Microsoft.AspNetCore.Http.IFormCollection
    
        
        .. code-block:: csharp
    
            IFormCollection ReadForm()
    
    .. dn:method:: Microsoft.AspNetCore.Http.Features.IFormFeature.ReadFormAsync(System.Threading.CancellationToken)
    
        
    
        
        Parses the request body as a form.
    
        
    
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Http.IFormCollection<Microsoft.AspNetCore.Http.IFormCollection>}
    
        
        .. code-block:: csharp
    
            Task<IFormCollection> ReadFormAsync(CancellationToken cancellationToken)
    

