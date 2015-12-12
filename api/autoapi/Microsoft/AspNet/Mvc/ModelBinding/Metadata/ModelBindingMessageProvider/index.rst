

ModelBindingMessageProvider Class
=================================



.. contents:: 
   :local:



Summary
-------

Read / write :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.IModelBindingMessageProvider` implementation.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelBindingMessageProvider`








Syntax
------

.. code-block:: csharp

   public class ModelBindingMessageProvider : IModelBindingMessageProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/ModelBinding/Metadata/ModelBindingMessageProvider.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelBindingMessageProvider

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelBindingMessageProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelBindingMessageProvider.ModelBindingMessageProvider()
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelBindingMessageProvider` class.
    
        
    
        
        .. code-block:: csharp
    
           public ModelBindingMessageProvider()
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelBindingMessageProvider.ModelBindingMessageProvider(Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelBindingMessageProvider)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelBindingMessageProvider` class based on
        ``originalProvider``.
    
        
        
        
        :param originalProvider: The  to duplicate.
        
        :type originalProvider: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelBindingMessageProvider
    
        
        .. code-block:: csharp
    
           public ModelBindingMessageProvider(ModelBindingMessageProvider originalProvider)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelBindingMessageProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelBindingMessageProvider.MissingBindRequiredValueAccessor
    
        
        :rtype: System.Func{System.String,System.String}
    
        
        .. code-block:: csharp
    
           public Func<string, string> MissingBindRequiredValueAccessor { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelBindingMessageProvider.MissingKeyOrValueAccessor
    
        
        :rtype: System.Func{System.String}
    
        
        .. code-block:: csharp
    
           public Func<string> MissingKeyOrValueAccessor { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.Metadata.ModelBindingMessageProvider.ValueMustNotBeNullAccessor
    
        
        :rtype: System.Func{System.String,System.String}
    
        
        .. code-block:: csharp
    
           public Func<string, string> ValueMustNotBeNullAccessor { get; set; }
    

