

DefaultControllerTypeProvider Class
===================================



.. contents:: 
   :local:



Summary
-------

A :any:`Microsoft.AspNet.Mvc.Controllers.IControllerTypeProvider` that identifies controller types from assemblies
specified by the registered :any:`Microsoft.AspNet.Mvc.Infrastructure.IAssemblyProvider`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Controllers.DefaultControllerTypeProvider`








Syntax
------

.. code-block:: csharp

   public class DefaultControllerTypeProvider : IControllerTypeProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/Controllers/DefaultControllerTypeProvider.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Controllers.DefaultControllerTypeProvider

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Controllers.DefaultControllerTypeProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Controllers.DefaultControllerTypeProvider.DefaultControllerTypeProvider(Microsoft.AspNet.Mvc.Infrastructure.IAssemblyProvider)
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Mvc.Controllers.DefaultControllerTypeProvider`\.
    
        
        
        
        :param assemblyProvider: that provides assemblies to look for
            controllers in.
        
        :type assemblyProvider: Microsoft.AspNet.Mvc.Infrastructure.IAssemblyProvider
    
        
        .. code-block:: csharp
    
           public DefaultControllerTypeProvider(IAssemblyProvider assemblyProvider)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Controllers.DefaultControllerTypeProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Controllers.DefaultControllerTypeProvider.IsController(System.Reflection.TypeInfo, System.Collections.Generic.ISet<System.Reflection.Assembly>)
    
        
    
        Returns <c>true</c> if the ``typeInfo`` is a controller. Otherwise <c>false</c>.
    
        
        
        
        :param typeInfo: The .
        
        :type typeInfo: System.Reflection.TypeInfo
        
        
        :param candidateAssemblies: The set of candidate assemblies.
        
        :type candidateAssemblies: System.Collections.Generic.ISet{System.Reflection.Assembly}
        :rtype: System.Boolean
        :return: <c>true</c> if the <paramref name="typeInfo" /> is a controller. Otherwise <c>false</c>.
    
        
        .. code-block:: csharp
    
           protected virtual bool IsController(TypeInfo typeInfo, ISet<Assembly> candidateAssemblies)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Controllers.DefaultControllerTypeProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Controllers.DefaultControllerTypeProvider.ControllerTypes
    
        
        :rtype: System.Collections.Generic.IEnumerable{System.Reflection.TypeInfo}
    
        
        .. code-block:: csharp
    
           public virtual IEnumerable<TypeInfo> ControllerTypes { get; }
    

