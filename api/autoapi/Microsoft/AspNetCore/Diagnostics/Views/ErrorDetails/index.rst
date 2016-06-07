

ErrorDetails Class
==================






Contains details for individual exception messages.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Diagnostics.Views`
Assemblies
    * Microsoft.AspNetCore.Diagnostics

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Diagnostics.Views.ErrorDetails`








Syntax
------

.. code-block:: csharp

    public class ErrorDetails








.. dn:class:: Microsoft.AspNetCore.Diagnostics.Views.ErrorDetails
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Diagnostics.Views.ErrorDetails

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.Views.ErrorDetails
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.Views.ErrorDetails.Error
    
        
    
        
        An individual exception
    
        
        :rtype: System.Exception
    
        
        .. code-block:: csharp
    
            public Exception Error
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.Views.ErrorDetails.StackFrames
    
        
    
        
        The generated stack frames
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Diagnostics.Views.StackFrame<Microsoft.AspNetCore.Diagnostics.Views.StackFrame>}
    
        
        .. code-block:: csharp
    
            public IEnumerable<StackFrame> StackFrames
            {
                get;
                set;
            }
    

