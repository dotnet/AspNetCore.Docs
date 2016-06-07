

ValidatorItem Class
===================






Used to associate validators with :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidatorItem.ValidatorMetadata` instances
as part of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidatorProviderContext`\. An :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidator` should
inspect :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ModelValidatorProviderContext.Results` and set :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidatorItem.Validator` and
:dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidatorItem.IsReusable` as appropriate.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidatorItem`








Syntax
------

.. code-block:: csharp

    public class ValidatorItem








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidatorItem
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidatorItem

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidatorItem
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidatorItem.IsReusable
    
        
    
        
        Gets or sets a value indicating whether or not :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidatorItem.Validator` can be reused across requests.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsReusable
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidatorItem.Validator
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidator`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidator
    
        
        .. code-block:: csharp
    
            public IModelValidator Validator
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidatorItem.ValidatorMetadata
    
        
    
        
        Gets the metadata associated with the :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidatorItem.Validator`\.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public object ValidatorMetadata
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidatorItem
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidatorItem.ValidatorItem()
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidatorItem`\.
    
        
    
        
        .. code-block:: csharp
    
            public ValidatorItem()
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidatorItem.ValidatorItem(System.Object)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidatorItem`\.
    
        
    
        
        :param validatorMetadata: The :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidatorItem.ValidatorMetadata`\.
        
        :type validatorMetadata: System.Object
    
        
        .. code-block:: csharp
    
            public ValidatorItem(object validatorMetadata)
    

