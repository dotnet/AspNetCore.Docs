

ApiRequestFormat Class
======================






A possible format for the body of a request.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ApiExplorer`
Assemblies
    * Microsoft.AspNetCore.Mvc.ApiExplorer

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ApiExplorer.ApiRequestFormat`








Syntax
------

.. code-block:: csharp

    public class ApiRequestFormat








.. dn:class:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiRequestFormat
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiRequestFormat

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiRequestFormat
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiRequestFormat.Formatter
    
        
    
        
        The formatter used to read this request.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Formatters.IInputFormatter
    
        
        .. code-block:: csharp
    
            public IInputFormatter Formatter
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiRequestFormat.MediaType
    
        
    
        
        The media type of the request.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string MediaType
            {
                get;
                set;
            }
    

