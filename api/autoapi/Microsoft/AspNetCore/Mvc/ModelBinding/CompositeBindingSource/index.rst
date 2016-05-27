

CompositeBindingSource Class
============================






A :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.CompositeBindingSource.BindingSources` which can repesent multiple value-provider data sources.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ModelBinding`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.CompositeBindingSource`








Syntax
------

.. code-block:: csharp

    public class CompositeBindingSource : BindingSource, IEquatable<BindingSource>








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.CompositeBindingSource
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.CompositeBindingSource

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.CompositeBindingSource
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.CompositeBindingSource.BindingSources
    
        
    
        
        Gets the set of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource` entries.
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource<Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource>}
    
        
        .. code-block:: csharp
    
            public IEnumerable<BindingSource> BindingSources
            {
                get;
            }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.CompositeBindingSource
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.CompositeBindingSource.CanAcceptDataFrom(Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource)
    
        
    
        
        :type bindingSource: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool CanAcceptDataFrom(BindingSource bindingSource)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.CompositeBindingSource.Create(System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource>, System.String)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ModelBinding.CompositeBindingSource`\.
    
        
    
        
        :param bindingSources: 
            The set of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource` entries.
            Must be value-provider sources and user input.
        
        :type bindingSources: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource<Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource>}
    
        
        :param displayName: The display name for the composite source.
        
        :type displayName: System.String
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.CompositeBindingSource
        :return: A :any:`Microsoft.AspNetCore.Mvc.ModelBinding.CompositeBindingSource`\.
    
        
        .. code-block:: csharp
    
            public static CompositeBindingSource Create(IEnumerable<BindingSource> bindingSources, string displayName)
    

