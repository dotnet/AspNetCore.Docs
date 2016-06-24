

BaseTwitterContext Class
========================






Base class for other Twitter contexts.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication.Twitter`
Assemblies
    * Microsoft.AspNetCore.Authentication.Twitter

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Authentication.BaseContext`
* :dn:cls:`Microsoft.AspNetCore.Authentication.Twitter.BaseTwitterContext`








Syntax
------

.. code-block:: csharp

    public class BaseTwitterContext : BaseContext








.. dn:class:: Microsoft.AspNetCore.Authentication.Twitter.BaseTwitterContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.Twitter.BaseTwitterContext

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authentication.Twitter.BaseTwitterContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authentication.Twitter.BaseTwitterContext.BaseTwitterContext(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Builder.TwitterOptions)
    
        
    
        
        Initializes a :any:`Microsoft.AspNetCore.Authentication.Twitter.BaseTwitterContext`
    
        
    
        
        :param context: The HTTP environment
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        :param options: The options for Twitter
        
        :type options: Microsoft.AspNetCore.Builder.TwitterOptions
    
        
        .. code-block:: csharp
    
            public BaseTwitterContext(HttpContext context, TwitterOptions options)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authentication.Twitter.BaseTwitterContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authentication.Twitter.BaseTwitterContext.Options
    
        
        :rtype: Microsoft.AspNetCore.Builder.TwitterOptions
    
        
        .. code-block:: csharp
    
            public TwitterOptions Options { get; }
    

