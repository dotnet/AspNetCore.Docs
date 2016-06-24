

ConfigurationKeyComparer Class
==============================






IComparer implementation used to order configuration keys.


Namespace
    :dn:ns:`Microsoft.Extensions.Configuration`
Assemblies
    * Microsoft.Extensions.Configuration

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Configuration.ConfigurationKeyComparer`








Syntax
------

.. code-block:: csharp

    public class ConfigurationKeyComparer : IComparer<string>








.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationKeyComparer
    :hidden:

.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationKeyComparer

Methods
-------

.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationKeyComparer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationKeyComparer.Compare(System.String, System.String)
    
        
    
        
        Compares two strings.
    
        
    
        
        :param x: First string.
        
        :type x: System.String
    
        
        :param y: Second string.
        
        :type y: System.String
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Compare(string x, string y)
    

Properties
----------

.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationKeyComparer
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Configuration.ConfigurationKeyComparer.Instance
    
        
    
        
        The default instance.
    
        
        :rtype: Microsoft.Extensions.Configuration.ConfigurationKeyComparer
    
        
        .. code-block:: csharp
    
            public static ConfigurationKeyComparer Instance { get; }
    

