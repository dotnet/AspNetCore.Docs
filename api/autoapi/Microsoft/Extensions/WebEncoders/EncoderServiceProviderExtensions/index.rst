

EncoderServiceProviderExtensions Class
======================================



.. contents:: 
   :local:



Summary
-------

Contains extension methods for fetching encoders from an :any:`System.IServiceProvider`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.WebEncoders.EncoderServiceProviderExtensions`








Syntax
------

.. code-block:: csharp

   public class EncoderServiceProviderExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.Extensions.WebEncoders.Core/EncoderServiceProviderExtensions.cs>`_





.. dn:class:: Microsoft.Extensions.WebEncoders.EncoderServiceProviderExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.WebEncoders.EncoderServiceProviderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.WebEncoders.EncoderServiceProviderExtensions.GetHtmlEncoder(System.IServiceProvider)
    
        
    
        Retrieves an :any:`Microsoft.Extensions.WebEncoders.IHtmlEncoder` from an :any:`System.IServiceProvider`\.
    
        
        
        
        :type serviceProvider: System.IServiceProvider
        :rtype: Microsoft.Extensions.WebEncoders.IHtmlEncoder
    
        
        .. code-block:: csharp
    
           public static IHtmlEncoder GetHtmlEncoder(IServiceProvider serviceProvider)
    
    .. dn:method:: Microsoft.Extensions.WebEncoders.EncoderServiceProviderExtensions.GetJavaScriptStringEncoder(System.IServiceProvider)
    
        
    
        Retrieves an :any:`Microsoft.Extensions.WebEncoders.IJavaScriptStringEncoder` from an :any:`System.IServiceProvider`\.
    
        
        
        
        :type serviceProvider: System.IServiceProvider
        :rtype: Microsoft.Extensions.WebEncoders.IJavaScriptStringEncoder
    
        
        .. code-block:: csharp
    
           public static IJavaScriptStringEncoder GetJavaScriptStringEncoder(IServiceProvider serviceProvider)
    
    .. dn:method:: Microsoft.Extensions.WebEncoders.EncoderServiceProviderExtensions.GetUrlEncoder(System.IServiceProvider)
    
        
    
        Retrieves an :any:`Microsoft.Extensions.WebEncoders.IUrlEncoder` from an :any:`System.IServiceProvider`\.
    
        
        
        
        :type serviceProvider: System.IServiceProvider
        :rtype: Microsoft.Extensions.WebEncoders.IUrlEncoder
    
        
        .. code-block:: csharp
    
           public static IUrlEncoder GetUrlEncoder(IServiceProvider serviceProvider)
    

