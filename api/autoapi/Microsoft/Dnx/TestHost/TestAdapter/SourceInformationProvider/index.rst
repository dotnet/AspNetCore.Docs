

SourceInformationProvider Class
===============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Dnx.TestHost.TestAdapter.SourceInformationProvider`








Syntax
------

.. code-block:: csharp

   public class SourceInformationProvider : ISourceInformationProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/testing/blob/master/src/Microsoft.Dnx.TestHost/TestAdapter/SourceInformationProvider.cs>`_





.. dn:class:: Microsoft.Dnx.TestHost.TestAdapter.SourceInformationProvider

Constructors
------------

.. dn:class:: Microsoft.Dnx.TestHost.TestAdapter.SourceInformationProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Dnx.TestHost.TestAdapter.SourceInformationProvider.SourceInformationProvider(Microsoft.Dnx.Compilation.IMetadataProjectReference, Microsoft.Extensions.Logging.ILogger)
    
        
        
        
        :type project: Microsoft.Dnx.Compilation.IMetadataProjectReference
        
        
        :type logger: Microsoft.Extensions.Logging.ILogger
    
        
        .. code-block:: csharp
    
           public SourceInformationProvider(IMetadataProjectReference project, ILogger logger)
    

Methods
-------

.. dn:class:: Microsoft.Dnx.TestHost.TestAdapter.SourceInformationProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Dnx.TestHost.TestAdapter.SourceInformationProvider.GetSourceInformation(System.Reflection.MethodInfo)
    
        
        
        
        :type method: System.Reflection.MethodInfo
        :rtype: Microsoft.Dnx.Testing.Abstractions.SourceInformation
    
        
        .. code-block:: csharp
    
           public SourceInformation GetSourceInformation(MethodInfo method)
    

