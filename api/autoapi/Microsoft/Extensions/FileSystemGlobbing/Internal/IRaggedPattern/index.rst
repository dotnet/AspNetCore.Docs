

IRaggedPattern Interface
========================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IRaggedPattern : IPattern





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/filesystem/src/Microsoft.Extensions.FileSystemGlobbing/Internal/IRaggedPattern.cs>`_





.. dn:interface:: Microsoft.Extensions.FileSystemGlobbing.Internal.IRaggedPattern

Properties
----------

.. dn:interface:: Microsoft.Extensions.FileSystemGlobbing.Internal.IRaggedPattern
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.FileSystemGlobbing.Internal.IRaggedPattern.Contains
    
        
        :rtype: System.Collections.Generic.IList{System.Collections.Generic.IList{Microsoft.Extensions.FileSystemGlobbing.Internal.IPathSegment}}
    
        
        .. code-block:: csharp
    
           IList<IList<IPathSegment>> Contains { get; }
    
    .. dn:property:: Microsoft.Extensions.FileSystemGlobbing.Internal.IRaggedPattern.EndsWith
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.Extensions.FileSystemGlobbing.Internal.IPathSegment}
    
        
        .. code-block:: csharp
    
           IList<IPathSegment> EndsWith { get; }
    
    .. dn:property:: Microsoft.Extensions.FileSystemGlobbing.Internal.IRaggedPattern.Segments
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.Extensions.FileSystemGlobbing.Internal.IPathSegment}
    
        
        .. code-block:: csharp
    
           IList<IPathSegment> Segments { get; }
    
    .. dn:property:: Microsoft.Extensions.FileSystemGlobbing.Internal.IRaggedPattern.StartsWith
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.Extensions.FileSystemGlobbing.Internal.IPathSegment}
    
        
        .. code-block:: csharp
    
           IList<IPathSegment> StartsWith { get; }
    

