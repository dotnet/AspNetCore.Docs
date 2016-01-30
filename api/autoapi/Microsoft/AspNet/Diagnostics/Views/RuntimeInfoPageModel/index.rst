

RuntimeInfoPageModel Class
==========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Diagnostics.Views.RuntimeInfoPageModel`








Syntax
------

.. code-block:: csharp

   public class RuntimeInfoPageModel





GitHub
------

`View on GitHub <https://github.com/aspnet/diagnostics/blob/master/src/Microsoft.AspNet.Diagnostics/RuntimeInfo/Views/RuntimeInfoPageModel.cs>`_





.. dn:class:: Microsoft.AspNet.Diagnostics.Views.RuntimeInfoPageModel

Properties
----------

.. dn:class:: Microsoft.AspNet.Diagnostics.Views.RuntimeInfoPageModel
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Views.RuntimeInfoPageModel.OperatingSystem
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string OperatingSystem { get; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Views.RuntimeInfoPageModel.References
    
        
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.Extensions.PlatformAbstractions.Library}
    
        
        .. code-block:: csharp
    
           public IEnumerable<Library> References { get; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Views.RuntimeInfoPageModel.RuntimeArchitecture
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string RuntimeArchitecture { get; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Views.RuntimeInfoPageModel.RuntimeType
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string RuntimeType { get; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Views.RuntimeInfoPageModel.Version
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Version { get; }
    

