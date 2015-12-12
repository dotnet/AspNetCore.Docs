

ConfigurationKeyComparer Class
==============================



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





GitHub
------

`View on GitHub <https://github.com/aspnet/configuration/blob/master/src/Microsoft.Extensions.Configuration/ConfigurationKeyComparer.cs>`_





.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationKeyComparer

Methods
-------

.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationKeyComparer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationKeyComparer.Compare(System.String, System.String)
    
        
        
        
        :type x: System.String
        
        
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
    
        
        :rtype: Microsoft.Extensions.Configuration.ConfigurationKeyComparer
    
        
        .. code-block:: csharp
    
           public static ConfigurationKeyComparer Instance { get; }
    

