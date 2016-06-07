

RazorError Class
================





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
* :dn:cls:`Microsoft.AspNetCore.Razor.RazorError`








Syntax
------

.. code-block:: csharp

    public class RazorError : IEquatable<RazorError>








.. dn:class:: Microsoft.AspNetCore.Razor.RazorError
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.RazorError

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.RazorError
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.RazorError.Length
    
        
    
        
        Gets or sets the length of the erroneous text.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Length
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.RazorError.Location
    
        
    
        
        Gets (or sets) the start position of the erroneous text.
    
        
        :rtype: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
            public SourceLocation Location
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.RazorError.Message
    
        
    
        
        Gets (or sets) the message describing the error.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Message
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.RazorError
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.RazorError.RazorError()
    
        
    
        
        Used only for deserialization.
    
        
    
        
        .. code-block:: csharp
    
            public RazorError()
    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.RazorError.RazorError(System.String, Microsoft.AspNetCore.Razor.SourceLocation, System.Int32)
    
        
    
        
        :type message: System.String
    
        
        :type location: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        :type length: System.Int32
    
        
        .. code-block:: csharp
    
            public RazorError(string message, SourceLocation location, int length)
    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.RazorError.RazorError(System.String, System.Int32, System.Int32, System.Int32, System.Int32)
    
        
    
        
        :type message: System.String
    
        
        :type absoluteIndex: System.Int32
    
        
        :type lineIndex: System.Int32
    
        
        :type columnIndex: System.Int32
    
        
        :type length: System.Int32
    
        
        .. code-block:: csharp
    
            public RazorError(string message, int absoluteIndex, int lineIndex, int columnIndex, int length)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.RazorError
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.RazorError.Equals(Microsoft.AspNetCore.Razor.RazorError)
    
        
    
        
        :type other: Microsoft.AspNetCore.Razor.RazorError
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Equals(RazorError other)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.RazorError.Equals(System.Object)
    
        
    
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.RazorError.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int GetHashCode()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.RazorError.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string ToString()
    

