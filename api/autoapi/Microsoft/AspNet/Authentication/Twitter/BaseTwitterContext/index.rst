

BaseTwitterContext Class
========================



.. contents:: 
   :local:



Summary
-------

Base class for other Twitter contexts.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.BaseContext`
* :dn:cls:`Microsoft.AspNet.Authentication.Twitter.BaseTwitterContext`








Syntax
------

.. code-block:: csharp

   public class BaseTwitterContext : BaseContext





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authentication.Twitter/Events/BaseTwitterContext.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.Twitter.BaseTwitterContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authentication.Twitter.BaseTwitterContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authentication.Twitter.BaseTwitterContext.BaseTwitterContext(Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Authentication.Twitter.TwitterOptions)
    
        
    
        Initializes a :any:`Microsoft.AspNet.Authentication.Twitter.BaseTwitterContext`
    
        
        
        
        :param context: The HTTP environment
        
        :type context: Microsoft.AspNet.Http.HttpContext
        
        
        :param options: The options for Twitter
        
        :type options: Microsoft.AspNet.Authentication.Twitter.TwitterOptions
    
        
        .. code-block:: csharp
    
           public BaseTwitterContext(HttpContext context, TwitterOptions options)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.Twitter.BaseTwitterContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.Twitter.BaseTwitterContext.Options
    
        
        :rtype: Microsoft.AspNet.Authentication.Twitter.TwitterOptions
    
        
        .. code-block:: csharp
    
           public TwitterOptions Options { get; }
    

