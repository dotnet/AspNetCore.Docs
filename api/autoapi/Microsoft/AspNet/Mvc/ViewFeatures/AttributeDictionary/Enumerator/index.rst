

Enumerator Struct
=================



.. contents:: 
   :local:



Summary
-------

An enumerator for :any:`Microsoft.AspNet.Mvc.ViewFeatures.AttributeDictionary`\.











Syntax
------

.. code-block:: csharp

   public struct Enumerator : IEnumerator<KeyValuePair<string, string>>, IDisposable, IEnumerator





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewFeatures/AttributeDictionary.cs>`_





.. dn:structure:: Microsoft.AspNet.Mvc.ViewFeatures.AttributeDictionary.Enumerator

Constructors
------------

.. dn:structure:: Microsoft.AspNet.Mvc.ViewFeatures.AttributeDictionary.Enumerator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ViewFeatures.AttributeDictionary.Enumerator.Enumerator(Microsoft.AspNet.Mvc.ViewFeatures.AttributeDictionary)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.ViewFeatures.AttributeDictionary.Enumerator`\.
    
        
        
        
        :param attributes: The .
        
        :type attributes: Microsoft.AspNet.Mvc.ViewFeatures.AttributeDictionary
    
        
        .. code-block:: csharp
    
           public Enumerator(AttributeDictionary attributes)
    

Methods
-------

.. dn:structure:: Microsoft.AspNet.Mvc.ViewFeatures.AttributeDictionary.Enumerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.AttributeDictionary.Enumerator.Dispose()
    
        
    
        
        .. code-block:: csharp
    
           public void Dispose()
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.AttributeDictionary.Enumerator.MoveNext()
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool MoveNext()
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.AttributeDictionary.Enumerator.Reset()
    
        
    
        
        .. code-block:: csharp
    
           public void Reset()
    

Properties
----------

.. dn:structure:: Microsoft.AspNet.Mvc.ViewFeatures.AttributeDictionary.Enumerator
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewFeatures.AttributeDictionary.Enumerator.Current
    
        
        :rtype: System.Collections.Generic.KeyValuePair{System.String,System.String}
    
        
        .. code-block:: csharp
    
           public KeyValuePair<string, string> Current { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewFeatures.AttributeDictionary.Enumerator.System.Collections.IEnumerator.Current
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           object IEnumerator.Current { get; }
    

