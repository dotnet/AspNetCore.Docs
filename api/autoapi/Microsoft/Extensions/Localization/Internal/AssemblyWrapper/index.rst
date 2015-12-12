

AssemblyWrapper Class
=====================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Localization.Internal.AssemblyWrapper`








Syntax
------

.. code-block:: csharp

   public class AssemblyWrapper





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/localization/src/Microsoft.Extensions.Localization/Internal/AssemblyWrapper.cs>`_





.. dn:class:: Microsoft.Extensions.Localization.Internal.AssemblyWrapper

Constructors
------------

.. dn:class:: Microsoft.Extensions.Localization.Internal.AssemblyWrapper
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Localization.Internal.AssemblyWrapper.AssemblyWrapper(System.Reflection.Assembly)
    
        
        
        
        :type assembly: System.Reflection.Assembly
    
        
        .. code-block:: csharp
    
           public AssemblyWrapper(Assembly assembly)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Localization.Internal.AssemblyWrapper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Localization.Internal.AssemblyWrapper.GetManifestResourceStream(System.String)
    
        
        
        
        :type name: System.String
        :rtype: System.IO.Stream
    
        
        .. code-block:: csharp
    
           public virtual Stream GetManifestResourceStream(string name)
    

Properties
----------

.. dn:class:: Microsoft.Extensions.Localization.Internal.AssemblyWrapper
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Localization.Internal.AssemblyWrapper.Assembly
    
        
        :rtype: System.Reflection.Assembly
    
        
        .. code-block:: csharp
    
           public Assembly Assembly { get; }
    
    .. dn:property:: Microsoft.Extensions.Localization.Internal.AssemblyWrapper.FullName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public virtual string FullName { get; }
    

