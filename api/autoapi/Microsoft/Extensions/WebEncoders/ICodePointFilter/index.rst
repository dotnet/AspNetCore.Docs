

ICodePointFilter Interface
==========================



.. contents:: 
   :local:



Summary
-------

Represents a filter which allows only certain Unicode code points through.











Syntax
------

.. code-block:: csharp

   public interface ICodePointFilter





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.Extensions.WebEncoders.Core/ICodePointFilter.cs>`_





.. dn:interface:: Microsoft.Extensions.WebEncoders.ICodePointFilter

Methods
-------

.. dn:interface:: Microsoft.Extensions.WebEncoders.ICodePointFilter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.WebEncoders.ICodePointFilter.GetAllowedCodePoints()
    
        
    
        Gets an enumeration of all allowed code points.
    
        
        :rtype: System.Collections.Generic.IEnumerable{System.Int32}
    
        
        .. code-block:: csharp
    
           IEnumerable<int> GetAllowedCodePoints()
    

