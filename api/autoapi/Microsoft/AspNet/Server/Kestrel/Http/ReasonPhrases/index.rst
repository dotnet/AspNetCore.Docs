

ReasonPhrases Class
===================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.ReasonPhrases`








Syntax
------

.. code-block:: csharp

   public class ReasonPhrases





GitHub
------

`View on GitHub <https://github.com/aspnet/kestrelhttpserver/blob/master/src/Microsoft.AspNet.Server.Kestrel/Http/ReasonPhrases.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.ReasonPhrases

Methods
-------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.ReasonPhrases
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.ReasonPhrases.ToReasonPhrase(System.Int32)
    
        
        
        
        :type statusCode: System.Int32
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public static string ToReasonPhrase(int statusCode)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.ReasonPhrases.ToStatus(System.Int32, System.String)
    
        
        
        
        :type statusCode: System.Int32
        
        
        :type reasonPhrase: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public static string ToStatus(int statusCode, string reasonPhrase = null)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.ReasonPhrases.ToStatusPhrase(System.Int32)
    
        
        
        
        :type statusCode: System.Int32
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public static string ToStatusPhrase(int statusCode)
    

