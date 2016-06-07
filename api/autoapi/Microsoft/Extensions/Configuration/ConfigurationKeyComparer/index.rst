

ConfigurationKeyComparer Class
==============================





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

Properties
----------

.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationKeyComparer
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Configuration.ConfigurationKeyComparer.Instance
    
        
        :rtype: Microsoft.Extensions.Configuration.ConfigurationKeyComparer
    
        
        .. code-block:: csharp
    
            public static ConfigurationKeyComparer Instance
            {
                get;
            }
    

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
    

