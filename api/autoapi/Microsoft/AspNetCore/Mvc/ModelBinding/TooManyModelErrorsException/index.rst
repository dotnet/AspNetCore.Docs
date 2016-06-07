

TooManyModelErrorsException Class
=================================






The :any:`System.Exception` that is thrown when too many model errors are encountered.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ModelBinding`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Exception`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.TooManyModelErrorsException`








Syntax
------

.. code-block:: csharp

    public class TooManyModelErrorsException : Exception, ISerializable, _Exception








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.TooManyModelErrorsException
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.TooManyModelErrorsException

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.TooManyModelErrorsException
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.TooManyModelErrorsException.TooManyModelErrorsException(System.String)
    
        
    
        
        Creates a new instance of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.TooManyModelErrorsException` with the specified
        exception <em>message</em>.
    
        
    
        
        :param message: The message that describes the error.
        
        :type message: System.String
    
        
        .. code-block:: csharp
    
            public TooManyModelErrorsException(string message)
    

