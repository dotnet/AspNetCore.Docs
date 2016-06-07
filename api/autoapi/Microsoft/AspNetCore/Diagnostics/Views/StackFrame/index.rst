

StackFrame Class
================






Detailed exception stack information used to generate a view


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
* :dn:cls:`Microsoft.AspNetCore.Diagnostics.Views.StackFrame`








Syntax
------

.. code-block:: csharp

    public class StackFrame








.. dn:class:: Microsoft.AspNetCore.Diagnostics.Views.StackFrame
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Diagnostics.Views.StackFrame

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.Views.StackFrame
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.Views.StackFrame.ContextCode
    
        
    
        
        Line(s) of code responsible for the error.
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IEnumerable<string> ContextCode
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.Views.StackFrame.ErrorDetails
    
        
    
        
        Specific error details for this stack frame.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ErrorDetails
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.Views.StackFrame.File
    
        
    
        
        File containing the instruction
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string File
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.Views.StackFrame.Function
    
        
    
        
        Function containing instruction
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Function
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.Views.StackFrame.Line
    
        
    
        
        The line number of the instruction
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Line
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.Views.StackFrame.PostContextCode
    
        
    
        
        Lines of code after the actual error line(s).
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IEnumerable<string> PostContextCode
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.Views.StackFrame.PreContextCode
    
        
    
        
        Lines of code before the actual error line(s).
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IEnumerable<string> PreContextCode
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.Views.StackFrame.PreContextLine
    
        
    
        
        The line preceeding the frame line
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int PreContextLine
            {
                get;
                set;
            }
    

