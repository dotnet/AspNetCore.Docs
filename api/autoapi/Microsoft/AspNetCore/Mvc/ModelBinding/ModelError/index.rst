

ModelError Class
================





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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelError`








Syntax
------

.. code-block:: csharp

    public class ModelError








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelError
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelError

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelError
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelError.ErrorMessage
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ErrorMessage
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelError.Exception
    
        
        :rtype: System.Exception
    
        
        .. code-block:: csharp
    
            public Exception Exception
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelError
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelError.ModelError(System.Exception)
    
        
    
        
        :type exception: System.Exception
    
        
        .. code-block:: csharp
    
            public ModelError(Exception exception)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelError.ModelError(System.Exception, System.String)
    
        
    
        
        :type exception: System.Exception
    
        
        :type errorMessage: System.String
    
        
        .. code-block:: csharp
    
            public ModelError(Exception exception, string errorMessage)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelError.ModelError(System.String)
    
        
    
        
        :type errorMessage: System.String
    
        
        .. code-block:: csharp
    
            public ModelError(string errorMessage)
    

