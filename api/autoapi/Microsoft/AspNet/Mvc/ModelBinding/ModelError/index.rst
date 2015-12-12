

ModelError Class
================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.ModelError`








Syntax
------

.. code-block:: csharp

   public class ModelError





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Abstractions/ModelBinding/ModelError.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.ModelError

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.ModelError
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.ModelError.ModelError(System.Exception)
    
        
        
        
        :type exception: System.Exception
    
        
        .. code-block:: csharp
    
           public ModelError(Exception exception)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.ModelError.ModelError(System.Exception, System.String)
    
        
        
        
        :type exception: System.Exception
        
        
        :type errorMessage: System.String
    
        
        .. code-block:: csharp
    
           public ModelError(Exception exception, string errorMessage)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.ModelError.ModelError(System.String)
    
        
        
        
        :type errorMessage: System.String
    
        
        .. code-block:: csharp
    
           public ModelError(string errorMessage)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.ModelError
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelError.ErrorMessage
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ErrorMessage { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelError.Exception
    
        
        :rtype: System.Exception
    
        
        .. code-block:: csharp
    
           public Exception Exception { get; }
    

