

AssemblyPart Class
==================






An :any:`Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPart` backed by an :dn:prop:`Microsoft.AspNetCore.Mvc.ApplicationParts.AssemblyPart.Assembly`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ApplicationParts`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPart`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ApplicationParts.AssemblyPart`








Syntax
------

.. code-block:: csharp

    public class AssemblyPart : ApplicationPart, IApplicationPartTypeProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.ApplicationParts.AssemblyPart
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ApplicationParts.AssemblyPart

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ApplicationParts.AssemblyPart
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationParts.AssemblyPart.Assembly
    
        
    
        
        Gets the :dn:prop:`Microsoft.AspNetCore.Mvc.ApplicationParts.AssemblyPart.Assembly` of the :any:`Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPart`\.
    
        
        :rtype: System.Reflection.Assembly
    
        
        .. code-block:: csharp
    
            public Assembly Assembly
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationParts.AssemblyPart.Name
    
        
    
        
        Gets the name of the :any:`Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPart`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string Name
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationParts.AssemblyPart.Types
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.Reflection.TypeInfo<System.Reflection.TypeInfo>}
    
        
        .. code-block:: csharp
    
            public IEnumerable<TypeInfo> Types
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ApplicationParts.AssemblyPart
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ApplicationParts.AssemblyPart.AssemblyPart(System.Reflection.Assembly)
    
        
    
        
        Initalizes a new :any:`Microsoft.AspNetCore.Mvc.ApplicationParts.AssemblyPart` instance.
    
        
    
        
        :type assembly: System.Reflection.Assembly
    
        
        .. code-block:: csharp
    
            public AssemblyPart(Assembly assembly)
    

