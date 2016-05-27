

AssemblyWrapper Class
=====================





Namespace
    :dn:ns:`Microsoft.Extensions.Localization.Internal`
Assemblies
    * Microsoft.Extensions.Localization

----

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








.. dn:class:: Microsoft.Extensions.Localization.Internal.AssemblyWrapper
    :hidden:

.. dn:class:: Microsoft.Extensions.Localization.Internal.AssemblyWrapper

Properties
----------

.. dn:class:: Microsoft.Extensions.Localization.Internal.AssemblyWrapper
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Localization.Internal.AssemblyWrapper.Assembly
    
        
        :rtype: System.Reflection.Assembly
    
        
        .. code-block:: csharp
    
            public Assembly Assembly
            {
                get;
            }
    
    .. dn:property:: Microsoft.Extensions.Localization.Internal.AssemblyWrapper.FullName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public virtual string FullName
            {
                get;
            }
    

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
    

