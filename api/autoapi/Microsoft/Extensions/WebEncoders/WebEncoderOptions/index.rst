

WebEncoderOptions Class
=======================






Specifies options common to all three encoders (HtmlEncode, JavaScriptEncode, UrlEncode).


Namespace
    :dn:ns:`Microsoft.Extensions.WebEncoders`
Assemblies
    * Microsoft.Extensions.WebEncoders

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.WebEncoders.WebEncoderOptions`








Syntax
------

.. code-block:: csharp

    public sealed class WebEncoderOptions








.. dn:class:: Microsoft.Extensions.WebEncoders.WebEncoderOptions
    :hidden:

.. dn:class:: Microsoft.Extensions.WebEncoders.WebEncoderOptions

Properties
----------

.. dn:class:: Microsoft.Extensions.WebEncoders.WebEncoderOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.WebEncoders.WebEncoderOptions.TextEncoderSettings
    
        
    
        
        Specifies which code points are allowed to be represented unescaped by the encoders.
    
        
        :rtype: System.Text.Encodings.Web.TextEncoderSettings
    
        
        .. code-block:: csharp
    
            public TextEncoderSettings TextEncoderSettings
            {
                get;
                set;
            }
    

