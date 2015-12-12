

SourceInformation Class
=======================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Dnx.Testing.Abstractions.SourceInformation`








Syntax
------

.. code-block:: csharp

   public class SourceInformation





GitHub
------

`View on GitHub <https://github.com/aspnet/testing/blob/master/src/Microsoft.Dnx.Testing.Abstractions/SourceInformation.cs>`_





.. dn:class:: Microsoft.Dnx.Testing.Abstractions.SourceInformation

Constructors
------------

.. dn:class:: Microsoft.Dnx.Testing.Abstractions.SourceInformation
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Dnx.Testing.Abstractions.SourceInformation.SourceInformation(System.String, System.Int32)
    
        
        
        
        :type filename: System.String
        
        
        :type lineNumber: System.Int32
    
        
        .. code-block:: csharp
    
           public SourceInformation(string filename, int lineNumber)
    

Properties
----------

.. dn:class:: Microsoft.Dnx.Testing.Abstractions.SourceInformation
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Dnx.Testing.Abstractions.SourceInformation.Filename
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Filename { get; }
    
    .. dn:property:: Microsoft.Dnx.Testing.Abstractions.SourceInformation.LineNumber
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int LineNumber { get; }
    

