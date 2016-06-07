

SerializableError Class
=======================






Defines a serializable container for storing ModelState information.
This information is stored as key/value pairs.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Collections.Generic.Dictionary{System.String,System.Object}`
* :dn:cls:`Microsoft.AspNetCore.Mvc.SerializableError`








Syntax
------

.. code-block:: csharp

    public sealed class SerializableError : Dictionary<string, object>, IDictionary<string, object>, ICollection<KeyValuePair<string, object>>, IDictionary, ICollection, IReadOnlyDictionary<string, object>, IReadOnlyCollection<KeyValuePair<string, object>>, IEnumerable<KeyValuePair<string, object>>, IEnumerable, ISerializable, IDeserializationCallback








.. dn:class:: Microsoft.AspNetCore.Mvc.SerializableError
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.SerializableError

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.SerializableError
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.SerializableError.SerializableError()
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Mvc.SerializableError` class.
    
        
    
        
        .. code-block:: csharp
    
            public SerializableError()
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.SerializableError.SerializableError(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary)
    
        
    
        
        Creates a new instance of :any:`Microsoft.AspNetCore.Mvc.SerializableError`\.
    
        
    
        
        :param modelState: :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry` containing the validation errors.
        
        :type modelState: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary
    
        
        .. code-block:: csharp
    
            public SerializableError(ModelStateDictionary modelState)
    

