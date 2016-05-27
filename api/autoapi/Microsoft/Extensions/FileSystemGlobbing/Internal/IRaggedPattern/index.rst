

IRaggedPattern Interface
========================





Namespace
    :dn:ns:`Microsoft.Extensions.FileSystemGlobbing.Internal`
Assemblies
    * Microsoft.Extensions.FileSystemGlobbing

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IRaggedPattern : IPattern








.. dn:interface:: Microsoft.Extensions.FileSystemGlobbing.Internal.IRaggedPattern
    :hidden:

.. dn:interface:: Microsoft.Extensions.FileSystemGlobbing.Internal.IRaggedPattern

Properties
----------

.. dn:interface:: Microsoft.Extensions.FileSystemGlobbing.Internal.IRaggedPattern
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.FileSystemGlobbing.Internal.IRaggedPattern.Contains
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.Extensions.FileSystemGlobbing.Internal.IPathSegment<Microsoft.Extensions.FileSystemGlobbing.Internal.IPathSegment>}}
    
        
        .. code-block:: csharp
    
            IList<IList<IPathSegment>> Contains
            {
                get;
            }
    
    .. dn:property:: Microsoft.Extensions.FileSystemGlobbing.Internal.IRaggedPattern.EndsWith
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.Extensions.FileSystemGlobbing.Internal.IPathSegment<Microsoft.Extensions.FileSystemGlobbing.Internal.IPathSegment>}
    
        
        .. code-block:: csharp
    
            IList<IPathSegment> EndsWith
            {
                get;
            }
    
    .. dn:property:: Microsoft.Extensions.FileSystemGlobbing.Internal.IRaggedPattern.Segments
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.Extensions.FileSystemGlobbing.Internal.IPathSegment<Microsoft.Extensions.FileSystemGlobbing.Internal.IPathSegment>}
    
        
        .. code-block:: csharp
    
            IList<IPathSegment> Segments
            {
                get;
            }
    
    .. dn:property:: Microsoft.Extensions.FileSystemGlobbing.Internal.IRaggedPattern.StartsWith
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.Extensions.FileSystemGlobbing.Internal.IPathSegment<Microsoft.Extensions.FileSystemGlobbing.Internal.IPathSegment>}
    
        
        .. code-block:: csharp
    
            IList<IPathSegment> StartsWith
            {
                get;
            }
    

