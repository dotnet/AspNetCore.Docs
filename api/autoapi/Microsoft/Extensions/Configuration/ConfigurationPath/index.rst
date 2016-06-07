

ConfigurationPath Class
=======================






Utility methods and constants for manipulating Configuration paths


Namespace
    :dn:ns:`Microsoft.Extensions.Configuration`
Assemblies
    * Microsoft.Extensions.Configuration.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Configuration.ConfigurationPath`








Syntax
------

.. code-block:: csharp

    public class ConfigurationPath








.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationPath
    :hidden:

.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationPath

Methods
-------

.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationPath
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationPath.Combine(System.Collections.Generic.IEnumerable<System.String>)
    
        
    
        
        :type pathSegements: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string Combine(IEnumerable<string> pathSegements)
    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationPath.Combine(System.String[])
    
        
    
        
        :type pathSegements: System.String<System.String>[]
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string Combine(params string[] pathSegements)
    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationPath.GetParentPath(System.String)
    
        
    
        
        :type path: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string GetParentPath(string path)
    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationPath.GetSectionKey(System.String)
    
        
    
        
        :type path: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string GetSectionKey(string path)
    

Fields
------

.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationPath
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.Extensions.Configuration.ConfigurationPath.KeyDelimiter
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static readonly string KeyDelimiter
    

