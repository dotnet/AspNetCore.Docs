

DistributedCacheTagHelperFormatter Class
========================================






Implements :any:`Microsoft.AspNetCore.Mvc.TagHelpers.Cache.IDistributedCacheTagHelperFormatter` by serializing the content
in UTF8.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.TagHelpers.Cache`
Assemblies
    * Microsoft.AspNetCore.Mvc.TagHelpers

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.TagHelpers.Cache.DistributedCacheTagHelperFormatter`








Syntax
------

.. code-block:: csharp

    public class DistributedCacheTagHelperFormatter : IDistributedCacheTagHelperFormatter








.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.Cache.DistributedCacheTagHelperFormatter
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.Cache.DistributedCacheTagHelperFormatter

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.Cache.DistributedCacheTagHelperFormatter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.TagHelpers.Cache.DistributedCacheTagHelperFormatter.DeserializeAsync(System.Byte[])
    
        
    
        
        :type value: System.Byte<System.Byte>[]
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Html.HtmlString<Microsoft.AspNetCore.Html.HtmlString>}
    
        
        .. code-block:: csharp
    
            public Task<HtmlString> DeserializeAsync(byte[] value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.TagHelpers.Cache.DistributedCacheTagHelperFormatter.SerializeAsync(Microsoft.AspNetCore.Mvc.TagHelpers.Cache.DistributedCacheTagHelperFormattingContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.TagHelpers.Cache.DistributedCacheTagHelperFormattingContext
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Byte<System.Byte>[]}
    
        
        .. code-block:: csharp
    
            public Task<byte[]> SerializeAsync(DistributedCacheTagHelperFormattingContext context)
    

