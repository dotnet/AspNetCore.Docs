

PatternTestResult Struct
========================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public struct PatternTestResult





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/filesystem/src/Microsoft.Extensions.FileSystemGlobbing/Internal/PatternTestResult.cs>`_





.. dn:structure:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternTestResult

Methods
-------

.. dn:structure:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternTestResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternTestResult.Success(System.String)
    
        
        
        
        :type stem: System.String
        :rtype: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternTestResult
    
        
        .. code-block:: csharp
    
           public static PatternTestResult Success(string stem)
    

Fields
------

.. dn:structure:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternTestResult
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternTestResult.Failed
    
        
    
        
        .. code-block:: csharp
    
           public static readonly PatternTestResult Failed
    

Properties
----------

.. dn:structure:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternTestResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternTestResult.IsSuccessful
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsSuccessful { get; }
    
    .. dn:property:: Microsoft.Extensions.FileSystemGlobbing.Internal.PatternTestResult.Stem
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Stem { get; }
    

