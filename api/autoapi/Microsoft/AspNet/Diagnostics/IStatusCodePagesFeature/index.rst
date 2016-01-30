

IStatusCodePagesFeature Interface
=================================



.. contents:: 
   :local:



Summary
-------

Represents the Status code pages feature.











Syntax
------

.. code-block:: csharp

   public interface IStatusCodePagesFeature





GitHub
------

`View on GitHub <https://github.com/aspnet/diagnostics/blob/master/src/Microsoft.AspNet.Diagnostics.Abstractions/IStatusCodePagesFeature.cs>`_





.. dn:interface:: Microsoft.AspNet.Diagnostics.IStatusCodePagesFeature

Properties
----------

.. dn:interface:: Microsoft.AspNet.Diagnostics.IStatusCodePagesFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Diagnostics.IStatusCodePagesFeature.Enabled
    
        
    
        Indicates if the status code middleware will handle responses.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool Enabled { get; set; }
    

