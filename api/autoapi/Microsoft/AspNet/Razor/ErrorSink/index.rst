

ErrorSink Class
===============



.. contents:: 
   :local:



Summary
-------

Used to manage :any:`Microsoft.AspNet.Razor.RazorError`\s encountered during the Razor parsing phase.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.ErrorSink`








Syntax
------

.. code-block:: csharp

   public class ErrorSink





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor/ErrorSink.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.ErrorSink

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.ErrorSink
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.ErrorSink.ErrorSink()
    
        
    
        Instantiates a new instance of :any:`Microsoft.AspNet.Razor.ErrorSink`\.
    
        
    
        
        .. code-block:: csharp
    
           public ErrorSink()
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.ErrorSink
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.ErrorSink.OnError(Microsoft.AspNet.Razor.RazorError)
    
        
    
        Tracks the given ``error``.
    
        
        
        
        :param error: The  to track.
        
        :type error: Microsoft.AspNet.Razor.RazorError
    
        
        .. code-block:: csharp
    
           public void OnError(RazorError error)
    
    .. dn:method:: Microsoft.AspNet.Razor.ErrorSink.OnError(Microsoft.AspNet.Razor.SourceLocation, System.String, System.Int32)
    
        
    
        Creates and tracks a new :any:`Microsoft.AspNet.Razor.RazorError`\.
    
        
        
        
        :param location: of the error.
        
        :type location: Microsoft.AspNet.Razor.SourceLocation
        
        
        :param message: A message describing the error.
        
        :type message: System.String
        
        
        :param length: The length of the error.
        
        :type length: System.Int32
    
        
        .. code-block:: csharp
    
           public void OnError(SourceLocation location, string message, int length)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.ErrorSink
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.ErrorSink.Errors
    
        
    
        :any:`Microsoft.AspNet.Razor.RazorError`\s collected.
    
        
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.RazorError}
    
        
        .. code-block:: csharp
    
           public IEnumerable<RazorError> Errors { get; }
    

