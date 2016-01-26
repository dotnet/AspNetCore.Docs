

ConfigurationProvider Class
===========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Configuration.ConfigurationProvider`








Syntax
------

.. code-block:: csharp

   public abstract class ConfigurationProvider : IConfigurationProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/configuration/blob/master/src/Microsoft.Extensions.Configuration/ConfigurationProvider.cs>`_





.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationProvider

Constructors
------------

.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Configuration.ConfigurationProvider.ConfigurationProvider()
    
        
    
        
        .. code-block:: csharp
    
           protected ConfigurationProvider()
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationProvider.GetChildKeys(System.Collections.Generic.IEnumerable<System.String>, System.String, System.String)
    
        
        
        
        :type earlierKeys: System.Collections.Generic.IEnumerable{System.String}
        
        
        :type parentPath: System.String
        
        
        :type delimiter: System.String
        :rtype: System.Collections.Generic.IEnumerable{System.String}
    
        
        .. code-block:: csharp
    
           public virtual IEnumerable<string> GetChildKeys(IEnumerable<string> earlierKeys, string parentPath, string delimiter)
    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationProvider.Load()
    
        
    
        
        .. code-block:: csharp
    
           public virtual void Load()
    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationProvider.Set(System.String, System.String)
    
        
        
        
        :type key: System.String
        
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
           public virtual void Set(string key, string value)
    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationProvider.TryGet(System.String, out System.String)
    
        
        
        
        :type key: System.String
        
        
        :type value: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public virtual bool TryGet(string key, out string value)
    

Properties
----------

.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Configuration.ConfigurationProvider.Data
    
        
        :rtype: System.Collections.Generic.IDictionary{System.String,System.String}
    
        
        .. code-block:: csharp
    
           protected IDictionary<string, string> Data { get; set; }
    

