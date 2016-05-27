

Enumerator Struct
=================






An enumerator for :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.AttributeDictionary`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ViewFeatures.AttributeDictionary`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public struct Enumerator : IEnumerator<KeyValuePair<string, string>>, IDisposable, IEnumerator








.. dn:structure:: Microsoft.AspNetCore.Mvc.ViewFeatures.AttributeDictionary.Enumerator
    :hidden:

.. dn:structure:: Microsoft.AspNetCore.Mvc.ViewFeatures.AttributeDictionary.Enumerator

Properties
----------

.. dn:structure:: Microsoft.AspNetCore.Mvc.ViewFeatures.AttributeDictionary.Enumerator
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.AttributeDictionary.Enumerator.Current
    
        
        :rtype: System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public KeyValuePair<string, string> Current
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.AttributeDictionary.Enumerator.System.Collections.IEnumerator.Current
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            object IEnumerator.Current
            {
                get;
            }
    

Constructors
------------

.. dn:structure:: Microsoft.AspNetCore.Mvc.ViewFeatures.AttributeDictionary.Enumerator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ViewFeatures.AttributeDictionary.Enumerator.Enumerator(Microsoft.AspNetCore.Mvc.ViewFeatures.AttributeDictionary)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.AttributeDictionary.Enumerator`\.
    
        
    
        
        :param attributes: The :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.AttributeDictionary`\.
        
        :type attributes: Microsoft.AspNetCore.Mvc.ViewFeatures.AttributeDictionary
    
        
        .. code-block:: csharp
    
            public Enumerator(AttributeDictionary attributes)
    

Methods
-------

.. dn:structure:: Microsoft.AspNetCore.Mvc.ViewFeatures.AttributeDictionary.Enumerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.AttributeDictionary.Enumerator.Dispose()
    
        
    
        
        .. code-block:: csharp
    
            public void Dispose()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.AttributeDictionary.Enumerator.MoveNext()
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool MoveNext()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.AttributeDictionary.Enumerator.Reset()
    
        
    
        
        .. code-block:: csharp
    
            public void Reset()
    

