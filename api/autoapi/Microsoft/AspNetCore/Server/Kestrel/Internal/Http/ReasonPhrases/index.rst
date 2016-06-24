

ReasonPhrases Class
===================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Kestrel.Internal.Http`
Assemblies
    * Microsoft.AspNetCore.Server.Kestrel

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Internal.Http.ReasonPhrases`








Syntax
------

.. code-block:: csharp

    public class ReasonPhrases








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.ReasonPhrases
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.ReasonPhrases

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.ReasonPhrases
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.ReasonPhrases.ToStatusBytes(System.Int32, System.String)
    
        
    
        
        :type statusCode: System.Int32
    
        
        :type reasonPhrase: System.String
        :rtype: System.Byte<System.Byte>[]
    
        
        .. code-block:: csharp
    
            public static byte[] ToStatusBytes(int statusCode, string reasonPhrase = null)
    

