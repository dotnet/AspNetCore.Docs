

ITempDataDictionary Interface
=============================






Represents a set of data that persists only from one request to the next.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ViewFeatures`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface ITempDataDictionary : IDictionary<string, object>, ICollection<KeyValuePair<string, object>>, IEnumerable<KeyValuePair<string, object>>, IEnumerable








.. dn:interface:: Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionary
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionary

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionary
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionary.Keep()
    
        
    
        
        Marks all keys in the dictionary for retention.
    
        
    
        
        .. code-block:: csharp
    
            void Keep()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionary.Keep(System.String)
    
        
    
        
        Marks the specified key in the dictionary for retention.
    
        
    
        
        :param key: The key to retain in the dictionary.
        
        :type key: System.String
    
        
        .. code-block:: csharp
    
            void Keep(string key)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionary.Load()
    
        
    
        
        Loads the dictionary by using the registered :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataProvider`\.
    
        
    
        
        .. code-block:: csharp
    
            void Load()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionary.Peek(System.String)
    
        
    
        
        Returns an object that contains the element that is associated with the specified key,
        without marking the key for deletion.
    
        
    
        
        :param key: The key of the element to return.
        
        :type key: System.String
        :rtype: System.Object
        :return: An object that contains the element that is associated with the specified key.
    
        
        .. code-block:: csharp
    
            object Peek(string key)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionary.Save()
    
        
    
        
        Saves the dictionary by using the registered :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataProvider`\.
    
        
    
        
        .. code-block:: csharp
    
            void Save()
    

