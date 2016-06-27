

IDistributedCacheTagHelperFormatter Interface
=============================================






An implementation of this interface provides a service to
serialize html fragments for being store by :any:`Microsoft.AspNetCore.Mvc.TagHelpers.Cache.IDistributedCacheTagHelperStorage`


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.TagHelpers.Cache`
Assemblies
    * Microsoft.AspNetCore.Mvc.TagHelpers

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IDistributedCacheTagHelperFormatter








.. dn:interface:: Microsoft.AspNetCore.Mvc.TagHelpers.Cache.IDistributedCacheTagHelperFormatter
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.TagHelpers.Cache.IDistributedCacheTagHelperFormatter

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.TagHelpers.Cache.IDistributedCacheTagHelperFormatter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.TagHelpers.Cache.IDistributedCacheTagHelperFormatter.DeserializeAsync(System.Byte[])
    
        
    
        
        Deserialize some html content.
    
        
    
        
        :param value: The value to deserialize.
        
        :type value: System.Byte<System.Byte>[]
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Html.HtmlString<Microsoft.AspNetCore.Html.HtmlString>}
        :return: The deserialized content, <returns>null</returns> otherwise.
    
        
        .. code-block:: csharp
    
            Task<HtmlString> DeserializeAsync(byte[] value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.TagHelpers.Cache.IDistributedCacheTagHelperFormatter.SerializeAsync(Microsoft.AspNetCore.Mvc.TagHelpers.Cache.DistributedCacheTagHelperFormattingContext)
    
        
    
        
        Serializes some html content.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.TagHelpers.Cache.DistributedCacheTagHelperFormattingContext` to serialize.
        
        :type context: Microsoft.AspNetCore.Mvc.TagHelpers.Cache.DistributedCacheTagHelperFormattingContext
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Byte<System.Byte>[]}
        :return: The serialized result.
    
        
        .. code-block:: csharp
    
            Task<byte[]> SerializeAsync(DistributedCacheTagHelperFormattingContext context)
    

