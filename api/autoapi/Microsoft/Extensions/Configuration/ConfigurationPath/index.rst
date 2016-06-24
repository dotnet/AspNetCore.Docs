

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
    
        
    
        
        Combines path segments into one path.
    
        
    
        
        :param pathSegments: The path segments to combine.
        
        :type pathSegments: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
        :rtype: System.String
        :return: The combined path.
    
        
        .. code-block:: csharp
    
            public static string Combine(IEnumerable<string> pathSegments)
    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationPath.Combine(System.String[])
    
        
    
        
        Combines path segments into one path.
    
        
    
        
        :param pathSegments: The path segments to combine.
        
        :type pathSegments: System.String<System.String>[]
        :rtype: System.String
        :return: The combined path.
    
        
        .. code-block:: csharp
    
            public static string Combine(params string[] pathSegments)
    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationPath.GetParentPath(System.String)
    
        
    
        
        Extracts the path corresponding to the parent node for a given path.
    
        
    
        
        :param path: The path.
        
        :type path: System.String
        :rtype: System.String
        :return: The original path minus the last individual segment found in it. Null if the original path corresponds to a top level node.
    
        
        .. code-block:: csharp
    
            public static string GetParentPath(string path)
    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationPath.GetSectionKey(System.String)
    
        
    
        
        Extracts the last path segment from the path.
    
        
    
        
        :param path: The path.
        
        :type path: System.String
        :rtype: System.String
        :return: The last path segment of the path.
    
        
        .. code-block:: csharp
    
            public static string GetSectionKey(string path)
    

Fields
------

.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationPath
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.Extensions.Configuration.ConfigurationPath.KeyDelimiter
    
        
    
        
        The delimiter ":" used to separate individual keys in a path.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static readonly string KeyDelimiter
    

