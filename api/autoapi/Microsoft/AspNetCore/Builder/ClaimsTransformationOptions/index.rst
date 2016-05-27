

ClaimsTransformationOptions Class
=================================






Contains the options used by the :any:`Microsoft.AspNetCore.Authentication.ClaimsTransformationMiddleware`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Builder`
Assemblies
    * Microsoft.AspNetCore.Authentication

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Builder.ClaimsTransformationOptions`








Syntax
------

.. code-block:: csharp

    public class ClaimsTransformationOptions








.. dn:class:: Microsoft.AspNetCore.Builder.ClaimsTransformationOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.ClaimsTransformationOptions

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Builder.ClaimsTransformationOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Builder.ClaimsTransformationOptions.Transformer
    
        
    
        
        Responsible for transforming the claims principal.
    
        
        :rtype: Microsoft.AspNetCore.Authentication.IClaimsTransformer
    
        
        .. code-block:: csharp
    
            public IClaimsTransformer Transformer
            {
                get;
                set;
            }
    

