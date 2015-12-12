

IPatternContext Interface
=========================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IPatternContext





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/filesystem/src/Microsoft.Extensions.FileSystemGlobbing/Internal/IPatternContext.cs>`_





.. dn:interface:: Microsoft.Extensions.FileSystemGlobbing.Internal.IPatternContext

Methods
-------

.. dn:interface:: Microsoft.Extensions.FileSystemGlobbing.Internal.IPatternContext
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.Internal.IPatternContext.Declare(System.Action<Microsoft.Extensions.FileSystemGlobbing.Internal.IPathSegment, System.Boolean>)
    
        
        
        
        :type onDeclare: System.Action{Microsoft.Extensions.FileSystemGlobbing.Internal.IPathSegment,System.Boolean}
    
        
        .. code-block:: csharp
    
           void Declare(Action<IPathSegment, bool> onDeclare)
    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.Internal.IPatternContext.PopDirectory()
    
        
    
        
        .. code-block:: csharp
    
           void PopDirectory()
    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.Internal.IPatternContext.PushDirectory(Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoBase)
    
        
        
        
        :type directory: Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoBase
    
        
        .. code-block:: csharp
    
           void PushDirectory(DirectoryInfoBase directory)
    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.Internal.IPatternContext.Test(Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoBase)
    
        
        
        
        :type directory: Microsoft.Extensions.FileSystemGlobbing.Abstractions.DirectoryInfoBase
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool Test(DirectoryInfoBase directory)
    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.Internal.IPatternContext.Test(Microsoft.Extensions.FileSystemGlobbing.Abstractions.FileInfoBase)
    
        
        
        
        :type file: Microsoft.Extensions.FileSystemGlobbing.Abstractions.FileInfoBase
        :rtype: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternTestResult
    
        
        .. code-block:: csharp
    
           PatternTestResult Test(FileInfoBase file)
    

