

CompositeBindingSource Class
============================



.. contents:: 
   :local:



Summary
-------

A :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.CompositeBindingSource.BindingSources` which can repesent multiple value-provider data sources.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.BindingSource`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.CompositeBindingSource`








Syntax
------

.. code-block:: csharp

   public class CompositeBindingSource : BindingSource, IEquatable<BindingSource>





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Abstractions/ModelBinding/CompositeBindingSource.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.CompositeBindingSource

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.CompositeBindingSource
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.CompositeBindingSource.CanAcceptDataFrom(Microsoft.AspNet.Mvc.ModelBinding.BindingSource)
    
        
        
        
        :type bindingSource: Microsoft.AspNet.Mvc.ModelBinding.BindingSource
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool CanAcceptDataFrom(BindingSource bindingSource)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.CompositeBindingSource.Create(System.Collections.Generic.IEnumerable<Microsoft.AspNet.Mvc.ModelBinding.BindingSource>, System.String)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.ModelBinding.CompositeBindingSource`\.
    
        
        
        
        :param bindingSources: The set of  entries.
            Must be value-provider sources and user input.
        
        :type bindingSources: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.ModelBinding.BindingSource}
        
        
        :param displayName: The display name for the composite source.
        
        :type displayName: System.String
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.CompositeBindingSource
        :return: A <see cref="T:Microsoft.AspNet.Mvc.ModelBinding.CompositeBindingSource" />.
    
        
        .. code-block:: csharp
    
           public static CompositeBindingSource Create(IEnumerable<BindingSource> bindingSources, string displayName)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.CompositeBindingSource
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.CompositeBindingSource.BindingSources
    
        
    
        Gets the set of :any:`Microsoft.AspNet.Mvc.ModelBinding.BindingSource` entries.
    
        
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.ModelBinding.BindingSource}
    
        
        .. code-block:: csharp
    
           public IEnumerable<BindingSource> BindingSources { get; }
    

