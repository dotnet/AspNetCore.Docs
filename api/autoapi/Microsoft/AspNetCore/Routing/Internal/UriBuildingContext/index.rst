

UriBuildingContext Class
========================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Routing.Internal`
Assemblies
    * Microsoft.AspNetCore.Routing

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Routing.Internal.UriBuildingContext`








Syntax
------

.. code-block:: csharp

    [DebuggerDisplay("{DebuggerToString(),nq}")]
    public class UriBuildingContext








.. dn:class:: Microsoft.AspNetCore.Routing.Internal.UriBuildingContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Routing.Internal.UriBuildingContext

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Routing.Internal.UriBuildingContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Routing.Internal.UriBuildingContext.UriBuildingContext(System.Text.Encodings.Web.UrlEncoder)
    
        
    
        
        :type urlEncoder: System.Text.Encodings.Web.UrlEncoder
    
        
        .. code-block:: csharp
    
            public UriBuildingContext(UrlEncoder urlEncoder)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Routing.Internal.UriBuildingContext
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Routing.Internal.UriBuildingContext.Accept(System.String)
    
        
    
        
        :type value: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Accept(string value)
    
    .. dn:method:: Microsoft.AspNetCore.Routing.Internal.UriBuildingContext.Buffer(System.String)
    
        
    
        
        :type value: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Buffer(string value)
    
    .. dn:method:: Microsoft.AspNetCore.Routing.Internal.UriBuildingContext.Clear()
    
        
    
        
        .. code-block:: csharp
    
            public void Clear()
    
    .. dn:method:: Microsoft.AspNetCore.Routing.Internal.UriBuildingContext.EndSegment()
    
        
    
        
        .. code-block:: csharp
    
            public void EndSegment()
    
    .. dn:method:: Microsoft.AspNetCore.Routing.Internal.UriBuildingContext.Remove(System.String)
    
        
    
        
        :type literal: System.String
    
        
        .. code-block:: csharp
    
            public void Remove(string literal)
    
    .. dn:method:: Microsoft.AspNetCore.Routing.Internal.UriBuildingContext.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string ToString()
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Routing.Internal.UriBuildingContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Routing.Internal.UriBuildingContext.BufferState
    
        
        :rtype: Microsoft.AspNetCore.Routing.Internal.SegmentState
    
        
        .. code-block:: csharp
    
            public SegmentState BufferState { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Internal.UriBuildingContext.UriState
    
        
        :rtype: Microsoft.AspNetCore.Routing.Internal.SegmentState
    
        
        .. code-block:: csharp
    
            public SegmentState UriState { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Internal.UriBuildingContext.Writer
    
        
        :rtype: System.IO.TextWriter
    
        
        .. code-block:: csharp
    
            public TextWriter Writer { get; }
    

