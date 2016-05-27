

ErrorSink Class
===============






Used to manage :any:`Microsoft.AspNetCore.Razor.RazorError`\s encountered during the Razor parsing phase.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor`
Assemblies
    * Microsoft.AspNetCore.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.ErrorSink`








Syntax
------

.. code-block:: csharp

    public class ErrorSink








.. dn:class:: Microsoft.AspNetCore.Razor.ErrorSink
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.ErrorSink

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.ErrorSink
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.ErrorSink.Errors
    
        
    
        
        :any:`Microsoft.AspNetCore.Razor.RazorError`\s collected.
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Razor.RazorError<Microsoft.AspNetCore.Razor.RazorError>}
    
        
        .. code-block:: csharp
    
            public IEnumerable<RazorError> Errors
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.ErrorSink
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.ErrorSink.ErrorSink()
    
        
    
        
        Instantiates a new instance of :any:`Microsoft.AspNetCore.Razor.ErrorSink`\.
    
        
    
        
        .. code-block:: csharp
    
            public ErrorSink()
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.ErrorSink
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.ErrorSink.OnError(Microsoft.AspNetCore.Razor.RazorError)
    
        
    
        
        Tracks the given <em>error</em>.
    
        
    
        
        :param error: The :any:`Microsoft.AspNetCore.Razor.RazorError` to track.
        
        :type error: Microsoft.AspNetCore.Razor.RazorError
    
        
        .. code-block:: csharp
    
            public void OnError(RazorError error)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.ErrorSink.OnError(Microsoft.AspNetCore.Razor.SourceLocation, System.String, System.Int32)
    
        
    
        
        Creates and tracks a new :any:`Microsoft.AspNetCore.Razor.RazorError`\.
    
        
    
        
        :param location: :any:`Microsoft.AspNetCore.Razor.SourceLocation` of the error.
        
        :type location: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        :param message: A message describing the error.
        
        :type message: System.String
    
        
        :param length: The length of the error.
        
        :type length: System.Int32
    
        
        .. code-block:: csharp
    
            public void OnError(SourceLocation location, string message, int length)
    

