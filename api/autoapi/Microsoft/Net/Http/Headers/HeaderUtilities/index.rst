

HeaderUtilities Class
=====================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Net.Http.Headers.HeaderUtilities`








Syntax
------

.. code-block:: csharp

   public class HeaderUtilities





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.Net.Http.Headers/HeaderUtilities.cs>`_





.. dn:class:: Microsoft.Net.Http.Headers.HeaderUtilities

Methods
-------

.. dn:class:: Microsoft.Net.Http.Headers.HeaderUtilities
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Net.Http.Headers.HeaderUtilities.FormatDate(System.DateTimeOffset)
    
        
        
        
        :type dateTime: System.DateTimeOffset
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public static string FormatDate(DateTimeOffset dateTime)
    
    .. dn:method:: Microsoft.Net.Http.Headers.HeaderUtilities.FormatInt64(System.Int64)
    
        
        
        
        :type value: System.Int64
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public static string FormatInt64(long value)
    
    .. dn:method:: Microsoft.Net.Http.Headers.HeaderUtilities.RemoveQuotes(System.String)
    
        
        
        
        :type input: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public static string RemoveQuotes(string input)
    
    .. dn:method:: Microsoft.Net.Http.Headers.HeaderUtilities.TryParseDate(System.String, out System.DateTimeOffset)
    
        
        
        
        :type input: System.String
        
        
        :type result: System.DateTimeOffset
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public static bool TryParseDate(string input, out DateTimeOffset result)
    
    .. dn:method:: Microsoft.Net.Http.Headers.HeaderUtilities.TryParseInt64(System.String, out System.Int64)
    
        
        
        
        :type value: System.String
        
        
        :type result: System.Int64
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public static bool TryParseInt64(string value, out long result)
    

