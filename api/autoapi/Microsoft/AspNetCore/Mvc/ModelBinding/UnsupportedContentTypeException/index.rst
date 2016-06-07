

UnsupportedContentTypeException Class
=====================================






The :any:`System.Exception` that is added to model state when a model binder for the body of the request is
unable to understand the request content type header.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ModelBinding`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Exception`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.UnsupportedContentTypeException`








Syntax
------

.. code-block:: csharp

    public class UnsupportedContentTypeException : Exception, ISerializable, _Exception








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.UnsupportedContentTypeException
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.UnsupportedContentTypeException

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.UnsupportedContentTypeException
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.UnsupportedContentTypeException.UnsupportedContentTypeException(System.String)
    
        
    
        
        Creates a new instance of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.UnsupportedContentTypeException` with the specified
        exception <em>message</em>.
    
        
    
        
        :param message: The message that describes the error.
        
        :type message: System.String
    
        
        .. code-block:: csharp
    
            public UnsupportedContentTypeException(string message)
    

