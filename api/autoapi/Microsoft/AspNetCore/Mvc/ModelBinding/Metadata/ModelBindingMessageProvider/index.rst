

ModelBindingMessageProvider Class
=================================






Read / write :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.IModelBindingMessageProvider` implementation.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelBindingMessageProvider`








Syntax
------

.. code-block:: csharp

    public class ModelBindingMessageProvider : IModelBindingMessageProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelBindingMessageProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelBindingMessageProvider

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelBindingMessageProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelBindingMessageProvider.ModelBindingMessageProvider()
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelBindingMessageProvider` class.
    
        
    
        
        .. code-block:: csharp
    
            public ModelBindingMessageProvider()
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelBindingMessageProvider.ModelBindingMessageProvider(Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelBindingMessageProvider)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelBindingMessageProvider` class based on
        <em>originalProvider</em>.
    
        
    
        
        :param originalProvider: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelBindingMessageProvider` to duplicate.
        
        :type originalProvider: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelBindingMessageProvider
    
        
        .. code-block:: csharp
    
            public ModelBindingMessageProvider(ModelBindingMessageProvider originalProvider)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelBindingMessageProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelBindingMessageProvider.AttemptedValueIsInvalidAccessor
    
        
        :rtype: System.Func<System.Func`3>{System.String<System.String>, System.String<System.String>, System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public Func<string, string, string> AttemptedValueIsInvalidAccessor { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelBindingMessageProvider.MissingBindRequiredValueAccessor
    
        
        :rtype: System.Func<System.Func`2>{System.String<System.String>, System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public Func<string, string> MissingBindRequiredValueAccessor { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelBindingMessageProvider.MissingKeyOrValueAccessor
    
        
        :rtype: System.Func<System.Func`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public Func<string> MissingKeyOrValueAccessor { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelBindingMessageProvider.UnknownValueIsInvalidAccessor
    
        
        :rtype: System.Func<System.Func`2>{System.String<System.String>, System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public Func<string, string> UnknownValueIsInvalidAccessor { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelBindingMessageProvider.ValueIsInvalidAccessor
    
        
        :rtype: System.Func<System.Func`2>{System.String<System.String>, System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public Func<string, string> ValueIsInvalidAccessor { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelBindingMessageProvider.ValueMustBeANumberAccessor
    
        
        :rtype: System.Func<System.Func`2>{System.String<System.String>, System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public Func<string, string> ValueMustBeANumberAccessor { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.ModelBindingMessageProvider.ValueMustNotBeNullAccessor
    
        
        :rtype: System.Func<System.Func`2>{System.String<System.String>, System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public Func<string, string> ValueMustNotBeNullAccessor { get; set; }
    

