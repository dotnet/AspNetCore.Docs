

SerializableError Class
=======================



.. contents:: 
   :local:



Summary
-------

Defines a serializable container for storing ModelState information.
This information is stored as key/value pairs.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Collections.Generic.Dictionary{System.String,System.Object}`
* :dn:cls:`Microsoft.AspNet.Mvc.SerializableError`








Syntax
------

.. code-block:: csharp

   public sealed class SerializableError : Dictionary<string, object>, IDictionary<string, object>, ICollection<KeyValuePair<string, object>>, IDictionary, ICollection, IReadOnlyDictionary<string, object>, IReadOnlyCollection<KeyValuePair<string, object>>, IEnumerable<KeyValuePair<string, object>>, IEnumerable, ISerializable, IDeserializationCallback





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/SerializableError.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.SerializableError

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.SerializableError
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.SerializableError.SerializableError()
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Mvc.SerializableError` class.
    
        
    
        
        .. code-block:: csharp
    
           public SerializableError()
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.SerializableError.SerializableError(Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary)
    
        
    
        Creates a new instance of :any:`Microsoft.AspNet.Mvc.SerializableError`\.
    
        
        
        
        :param modelState: containing the validation errors.
        
        :type modelState: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary
    
        
        .. code-block:: csharp
    
           public SerializableError(ModelStateDictionary modelState)
    

