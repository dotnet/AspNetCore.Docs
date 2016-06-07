

ReasonPhrases Class
===================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Kestrel.Http`
Assemblies
    * Microsoft.AspNetCore.Server.Kestrel

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Http.ReasonPhrases`








Syntax
------

.. code-block:: csharp

    public class ReasonPhrases








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.ReasonPhrases
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.ReasonPhrases

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.ReasonPhrases
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.ReasonPhrases.ToReasonPhrase(System.Int32)
    
        
    
        
        :type statusCode: System.Int32
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string ToReasonPhrase(int statusCode)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.ReasonPhrases.ToStatus(System.Int32, System.String)
    
        
    
        
        :type statusCode: System.Int32
    
        
        :type reasonPhrase: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string ToStatus(int statusCode, string reasonPhrase = null)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.ReasonPhrases.ToStatusBytes(System.Int32, System.String)
    
        
    
        
        :type statusCode: System.Int32
    
        
        :type reasonPhrase: System.String
        :rtype: System.Byte<System.Byte>[]
    
        
        .. code-block:: csharp
    
            public static byte[] ToStatusBytes(int statusCode, string reasonPhrase = null)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.ReasonPhrases.ToStatusPhrase(System.Int32)
    
        
    
        
        :type statusCode: System.Int32
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string ToStatusPhrase(int statusCode)
    

