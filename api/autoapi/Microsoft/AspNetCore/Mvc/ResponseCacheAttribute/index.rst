

ResponseCacheAttribute Class
============================






Specifies the parameters necessary for setting appropriate headers in response caching.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ResponseCacheAttribute`








Syntax
------

.. code-block:: csharp

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class ResponseCacheAttribute : Attribute, _Attribute, IFilterFactory, IOrderedFilter, IFilterMetadata








.. dn:class:: Microsoft.AspNetCore.Mvc.ResponseCacheAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ResponseCacheAttribute

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ResponseCacheAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ResponseCacheAttribute.CacheProfileName
    
        
    
        
        Gets or sets the value of the cache profile name.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string CacheProfileName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ResponseCacheAttribute.Duration
    
        
    
        
        Gets or sets the duration in seconds for which the response is cached.
        This sets "max-age" in "Cache-control" header.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Duration
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ResponseCacheAttribute.IsReusable
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsReusable
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ResponseCacheAttribute.Location
    
        
    
        
        Gets or sets the location where the data from a particular URL must be cached.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ResponseCacheLocation
    
        
        .. code-block:: csharp
    
            public ResponseCacheLocation Location
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ResponseCacheAttribute.NoStore
    
        
    
        
        Gets or sets the value which determines whether the data should be stored or not.
        When set to <xref uid="langword_csharp_true" name="true" href=""></xref>, it sets "Cache-control" header to "no-store".
        Ignores the "Location" parameter for values other than "None".
        Ignores the "duration" parameter.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool NoStore
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ResponseCacheAttribute.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Order
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ResponseCacheAttribute.VaryByHeader
    
        
    
        
        Gets or sets the value for the Vary response header.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string VaryByHeader
            {
                get;
                set;
            }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ResponseCacheAttribute
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ResponseCacheAttribute.CreateInstance(System.IServiceProvider)
    
        
    
        
        :type serviceProvider: System.IServiceProvider
        :rtype: Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata
    
        
        .. code-block:: csharp
    
            public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
    

