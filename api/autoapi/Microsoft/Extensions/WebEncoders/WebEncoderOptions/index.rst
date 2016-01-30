

WebEncoderOptions Class
=======================



.. contents:: 
   :local:



Summary
-------

Specifies options common to all three encoders (HtmlEncode, JavaScriptStringEncode, UrlEncode).





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.WebEncoders.WebEncoderOptions`








Syntax
------

.. code-block:: csharp

   public sealed class WebEncoderOptions





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.Extensions.WebEncoders.Core/WebEncoderOptions.cs>`_





.. dn:class:: Microsoft.Extensions.WebEncoders.WebEncoderOptions

Properties
----------

.. dn:class:: Microsoft.Extensions.WebEncoders.WebEncoderOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.WebEncoders.WebEncoderOptions.CodePointFilter
    
        
    
        Specifies which code points are allowed to be represented unescaped by the encoders.
    
        
        :rtype: Microsoft.Extensions.WebEncoders.ICodePointFilter
    
        
        .. code-block:: csharp
    
           public ICodePointFilter CodePointFilter { get; set; }
    

