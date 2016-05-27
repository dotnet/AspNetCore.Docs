

IViewBufferScope Interface
==========================






Creates and manages the lifetime of :any:`ViewBufferValue[]` instances.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ViewFeatures.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IViewBufferScope








.. dn:interface:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.IViewBufferScope
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.IViewBufferScope

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.IViewBufferScope
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.IViewBufferScope.CreateWriter(System.IO.TextWriter)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.PagedBufferedTextWriter` that will delegate to the provided
        <em>writer</em>.
    
        
    
        
        :param writer: The :any:`System.IO.TextWriter`\.
        
        :type writer: System.IO.TextWriter
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.PagedBufferedTextWriter
        :return: A :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.PagedBufferedTextWriter`\.
    
        
        .. code-block:: csharp
    
            PagedBufferedTextWriter CreateWriter(TextWriter writer)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.IViewBufferScope.GetPage(System.Int32)
    
        
    
        
        Gets a :any:`ViewBufferValue[]`\.
    
        
    
        
        :param pageSize: The minimum size of the segment.
        
        :type pageSize: System.Int32
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferValue<Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferValue>[]
        :return: The :any:`ViewBufferValue[]`\.
    
        
        .. code-block:: csharp
    
            ViewBufferValue[] GetPage(int pageSize)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.IViewBufferScope.ReturnSegment(Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferValue[])
    
        
    
        
        Returns a :any:`ViewBufferValue[]` that can be reused.
    
        
    
        
        :param segment: The :any:`ViewBufferValue[]`\.
        
        :type segment: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferValue<Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferValue>[]
    
        
        .. code-block:: csharp
    
            void ReturnSegment(ViewBufferValue[] segment)
    

