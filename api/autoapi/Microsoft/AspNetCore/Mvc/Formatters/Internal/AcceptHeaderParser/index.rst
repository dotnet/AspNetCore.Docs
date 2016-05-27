

AcceptHeaderParser Class
========================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Formatters.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Formatters.Internal.AcceptHeaderParser`








Syntax
------

.. code-block:: csharp

    public class AcceptHeaderParser








.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Internal.AcceptHeaderParser
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Internal.AcceptHeaderParser

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Internal.AcceptHeaderParser
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.Internal.AcceptHeaderParser.ParseAcceptHeader(System.Collections.Generic.IList<System.String>)
    
        
    
        
        :type acceptHeaders: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.Formatters.Internal.MediaTypeSegmentWithQuality<Microsoft.AspNetCore.Mvc.Formatters.Internal.MediaTypeSegmentWithQuality>}
    
        
        .. code-block:: csharp
    
            public static IList<MediaTypeSegmentWithQuality> ParseAcceptHeader(IList<string> acceptHeaders)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.Internal.AcceptHeaderParser.ParseAcceptHeader(System.Collections.Generic.IList<System.String>, System.Collections.Generic.IList<Microsoft.AspNetCore.Mvc.Formatters.Internal.MediaTypeSegmentWithQuality>)
    
        
    
        
        :type acceptHeaders: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
    
        
        :type parsedValues: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.Formatters.Internal.MediaTypeSegmentWithQuality<Microsoft.AspNetCore.Mvc.Formatters.Internal.MediaTypeSegmentWithQuality>}
    
        
        .. code-block:: csharp
    
            public static void ParseAcceptHeader(IList<string> acceptHeaders, IList<MediaTypeSegmentWithQuality> parsedValues)
    

