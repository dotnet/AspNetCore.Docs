

RequestFormReaderExtensions Class
=================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Http`
Assemblies
    * Microsoft.AspNetCore.Http

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Http.RequestFormReaderExtensions`








Syntax
------

.. code-block:: csharp

    public class RequestFormReaderExtensions








.. dn:class:: Microsoft.AspNetCore.Http.RequestFormReaderExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Http.RequestFormReaderExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Http.RequestFormReaderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.RequestFormReaderExtensions.ReadFormAsync(Microsoft.AspNetCore.Http.HttpRequest, Microsoft.AspNetCore.Http.Features.FormOptions, System.Threading.CancellationToken)
    
        
    
        
        Read the request body as a form with the given options. These options will only be used
        if the form has not already been read.
    
        
    
        
        :param request: The request.
        
        :type request: Microsoft.AspNetCore.Http.HttpRequest
    
        
        :param options: Options for reading the form.
        
        :type options: Microsoft.AspNetCore.Http.Features.FormOptions
    
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Http.IFormCollection<Microsoft.AspNetCore.Http.IFormCollection>}
        :return: The parsed form.
    
        
        .. code-block:: csharp
    
            public static Task<IFormCollection> ReadFormAsync(this HttpRequest request, FormOptions options, CancellationToken cancellationToken = null)
    

