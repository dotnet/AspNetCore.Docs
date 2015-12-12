

PatternContext<TFrame> Class
============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContext\<TFrame>`








Syntax
------

.. code-block:: csharp

   public abstract class PatternContext<TFrame> : IPatternContext





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/filesystem/src/Microsoft.Extensions.FileSystemGlobbing/Internal/PatternContexts/PatternContext.cs>`_





.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContext<TFrame>

Methods
-------

.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContext<TFrame>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContext<TFrame>.Declare(System.Action<Microsoft.Extensions.FileSystemGlobbing.Internal.IPathSegment, System.Boolean>)
    
        
        
        
        :type declare: System.Action{Microsoft.Extensions.FileSystemGlobbing.Internal.IPathSegment,System.Boolean}
    
        
        .. code-block:: csharp
    
           public virtual void Declare(Action<IPathSegment, bool> declare)
    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContext<TFrame>.IsStackEmpty()
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           protected bool IsStackEmpty()
    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContext<TFrame>.PopDirectory()
    
        
    
        
        .. code-block:: csharp
    
           public void PopDirectory()
    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContext<TFrame>.PushDataFrame(TFrame)
    
        
        
        
        :type frame: {TFrame}
    
        
        .. code-block:: csharp
    
           protected void PushDataFrame(TFrame frame)
    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContext<TFrame>.PushDirectory(Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoBase)
    
        
        
        
        :type directory: Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoBase
    
        
        .. code-block:: csharp
    
           public abstract void PushDirectory(DirectoryInfoBase directory)
    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContext<TFrame>.Test(Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoBase)
    
        
        
        
        :type directory: Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoBase
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public abstract bool Test(DirectoryInfoBase directory)
    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContext<TFrame>.Test(Microsoft.Extensions.FileSystemGlobbing.Abstractions.FileInfoBase)
    
        
        
        
        :type file: Microsoft.Extensions.FileSystemGlobbing.Abstractions.FileInfoBase
        :rtype: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternTestResult
    
        
        .. code-block:: csharp
    
           public abstract PatternTestResult Test(FileInfoBase file)
    

Fields
------

.. dn:class:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContext<TFrame>
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts.PatternContext<TFrame>.Frame
    
        
    
        
        .. code-block:: csharp
    
           protected TFrame Frame
    

