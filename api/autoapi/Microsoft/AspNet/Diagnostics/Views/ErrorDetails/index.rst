

ErrorDetails Class
==================



.. contents:: 
   :local:



Summary
-------

Contains details for individual exception messages.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Diagnostics.Views.ErrorDetails`








Syntax
------

.. code-block:: csharp

   public class ErrorDetails





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/diagnostics/src/Microsoft.AspNet.Diagnostics/DeveloperExceptionPage/Views/ErrorDetails.cs>`_





.. dn:class:: Microsoft.AspNet.Diagnostics.Views.ErrorDetails

Properties
----------

.. dn:class:: Microsoft.AspNet.Diagnostics.Views.ErrorDetails
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Views.ErrorDetails.Error
    
        
    
        An individual exception
    
        
        :rtype: System.Exception
    
        
        .. code-block:: csharp
    
           public Exception Error { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Views.ErrorDetails.StackFrames
    
        
    
        The generated stack frames
    
        
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Diagnostics.Views.StackFrame}
    
        
        .. code-block:: csharp
    
           public IEnumerable<StackFrame> StackFrames { get; set; }
    

