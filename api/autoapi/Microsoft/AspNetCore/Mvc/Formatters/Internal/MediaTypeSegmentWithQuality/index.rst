

MediaTypeSegmentWithQuality Struct
==================================






A media type with its associated quality.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Formatters.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public struct MediaTypeSegmentWithQuality








.. dn:structure:: Microsoft.AspNetCore.Mvc.Formatters.Internal.MediaTypeSegmentWithQuality
    :hidden:

.. dn:structure:: Microsoft.AspNetCore.Mvc.Formatters.Internal.MediaTypeSegmentWithQuality

Constructors
------------

.. dn:structure:: Microsoft.AspNetCore.Mvc.Formatters.Internal.MediaTypeSegmentWithQuality
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Formatters.Internal.MediaTypeSegmentWithQuality.MediaTypeSegmentWithQuality(Microsoft.Extensions.Primitives.StringSegment, System.Double)
    
        
    
        
        Initializes an instance of :any:`Microsoft.AspNetCore.Mvc.Formatters.Internal.MediaTypeSegmentWithQuality`\.
    
        
    
        
        :param mediaType: The :any:`Microsoft.Extensions.Primitives.StringSegment` containing the media type.
        
        :type mediaType: Microsoft.Extensions.Primitives.StringSegment
    
        
        :param quality: The quality parameter of the media type or 1 in the case it does not exist.
        
        :type quality: System.Double
    
        
        .. code-block:: csharp
    
            public MediaTypeSegmentWithQuality(StringSegment mediaType, double quality)
    

Properties
----------

.. dn:structure:: Microsoft.AspNetCore.Mvc.Formatters.Internal.MediaTypeSegmentWithQuality
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Formatters.Internal.MediaTypeSegmentWithQuality.MediaType
    
        
    
        
        Gets the media type of this :any:`Microsoft.AspNetCore.Mvc.Formatters.Internal.MediaTypeSegmentWithQuality`\.
    
        
        :rtype: Microsoft.Extensions.Primitives.StringSegment
    
        
        .. code-block:: csharp
    
            public StringSegment MediaType { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Formatters.Internal.MediaTypeSegmentWithQuality.Quality
    
        
    
        
        Gets the quality of this :any:`Microsoft.AspNetCore.Mvc.Formatters.Internal.MediaTypeSegmentWithQuality`\.
    
        
        :rtype: System.Double
    
        
        .. code-block:: csharp
    
            public double Quality { get; }
    

Methods
-------

.. dn:structure:: Microsoft.AspNetCore.Mvc.Formatters.Internal.MediaTypeSegmentWithQuality
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.Internal.MediaTypeSegmentWithQuality.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string ToString()
    

