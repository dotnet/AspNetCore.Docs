

RazorError Class
================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.RazorError`








Syntax
------

.. code-block:: csharp

   public class RazorError : IEquatable<RazorError>





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/RazorError.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.RazorError

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.RazorError
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.RazorError.RazorError()
    
        
    
        Used only for deserialization.
    
        
    
        
        .. code-block:: csharp
    
           public RazorError()
    
    .. dn:constructor:: Microsoft.AspNet.Razor.RazorError.RazorError(System.String, Microsoft.AspNet.Razor.SourceLocation, System.Int32)
    
        
        
        
        :type message: System.String
        
        
        :type location: Microsoft.AspNet.Razor.SourceLocation
        
        
        :type length: System.Int32
    
        
        .. code-block:: csharp
    
           public RazorError(string message, SourceLocation location, int length)
    
    .. dn:constructor:: Microsoft.AspNet.Razor.RazorError.RazorError(System.String, System.Int32, System.Int32, System.Int32, System.Int32)
    
        
        
        
        :type message: System.String
        
        
        :type absoluteIndex: System.Int32
        
        
        :type lineIndex: System.Int32
        
        
        :type columnIndex: System.Int32
        
        
        :type length: System.Int32
    
        
        .. code-block:: csharp
    
           public RazorError(string message, int absoluteIndex, int lineIndex, int columnIndex, int length)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.RazorError
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.RazorError.Equals(Microsoft.AspNet.Razor.RazorError)
    
        
        
        
        :type other: Microsoft.AspNet.Razor.RazorError
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Equals(RazorError other)
    
    .. dn:method:: Microsoft.AspNet.Razor.RazorError.Equals(System.Object)
    
        
        
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNet.Razor.RazorError.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int GetHashCode()
    
    .. dn:method:: Microsoft.AspNet.Razor.RazorError.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string ToString()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.RazorError
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.RazorError.Length
    
        
    
        Gets or sets the length of the erroneous text.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Length { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.RazorError.Location
    
        
    
        Gets (or sets) the start position of the erroneous text.
    
        
        :rtype: Microsoft.AspNet.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
           public SourceLocation Location { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.RazorError.Message
    
        
    
        Gets (or sets) the message describing the error.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Message { get; set; }
    

