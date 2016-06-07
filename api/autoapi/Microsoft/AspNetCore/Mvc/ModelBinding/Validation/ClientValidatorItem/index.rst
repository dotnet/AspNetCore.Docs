

ClientValidatorItem Class
=========================






Used to associate validators with :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientValidatorItem.ValidatorMetadata` instances
as part of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientValidatorProviderContext`\. An :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IClientModelValidator` should
inspect :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientValidatorProviderContext.Results` and set :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientValidatorItem.Validator` and
:dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientValidatorItem.IsReusable` as appropriate.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientValidatorItem`








Syntax
------

.. code-block:: csharp

    public class ClientValidatorItem








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientValidatorItem
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientValidatorItem

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientValidatorItem
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientValidatorItem.IsReusable
    
        
    
        
        Gets or sets a value indicating whether or not :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientValidatorItem.Validator` can be reused across requests.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsReusable
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientValidatorItem.Validator
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IClientModelValidator`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IClientModelValidator
    
        
        .. code-block:: csharp
    
            public IClientModelValidator Validator
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientValidatorItem.ValidatorMetadata
    
        
    
        
        Gets the metadata associated with the :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientValidatorItem.Validator`\.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public object ValidatorMetadata
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientValidatorItem
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientValidatorItem.ClientValidatorItem()
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientValidatorItem`\.
    
        
    
        
        .. code-block:: csharp
    
            public ClientValidatorItem()
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientValidatorItem.ClientValidatorItem(System.Object)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientValidatorItem`\.
    
        
    
        
        :param validatorMetadata: The :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ClientValidatorItem.ValidatorMetadata`\.
        
        :type validatorMetadata: System.Object
    
        
        .. code-block:: csharp
    
            public ClientValidatorItem(object validatorMetadata)
    

