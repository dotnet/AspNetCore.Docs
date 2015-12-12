

TooManyModelErrorsException Class
=================================



.. contents:: 
   :local:



Summary
-------

The :any:`System.Exception` that is thrown when too many model errors are encountered.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Exception`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.TooManyModelErrorsException`








Syntax
------

.. code-block:: csharp

   public class TooManyModelErrorsException : Exception, ISerializable, _Exception





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Abstractions/ModelBinding/TooManyModelErrorsException.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.TooManyModelErrorsException

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.TooManyModelErrorsException
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.TooManyModelErrorsException.TooManyModelErrorsException(System.String)
    
        
    
        Creates a new instance of :any:`Microsoft.AspNet.Mvc.ModelBinding.TooManyModelErrorsException` with the specified
        exception ``message``.
    
        
        
        
        :param message: The message that describes the error.
        
        :type message: System.String
    
        
        .. code-block:: csharp
    
           public TooManyModelErrorsException(string message)
    

