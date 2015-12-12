

IPattern Interface
==================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IPattern





GitHub
------

`View on GitHub <https://github.com/aspnet/filesystem/blob/master/src/Microsoft.Extensions.FileSystemGlobbing/Internal/IPattern.cs>`_





.. dn:interface:: Microsoft.Extensions.FileSystemGlobbing.Internal.IPattern

Methods
-------

.. dn:interface:: Microsoft.Extensions.FileSystemGlobbing.Internal.IPattern
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.Internal.IPattern.CreatePatternContextForExclude()
    
        
        :rtype: Microsoft.Extensions.FileSystemGlobbing.Internal.IPatternContext
    
        
        .. code-block:: csharp
    
           IPatternContext CreatePatternContextForExclude()
    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.Internal.IPattern.CreatePatternContextForInclude()
    
        
        :rtype: Microsoft.Extensions.FileSystemGlobbing.Internal.IPatternContext
    
        
        .. code-block:: csharp
    
           IPatternContext CreatePatternContextForInclude()
    

