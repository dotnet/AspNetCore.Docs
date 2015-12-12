

LogFormatter Class
==================



.. contents:: 
   :local:



Summary
-------

Formatters for common logging scenarios.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Logging.LogFormatter`








Syntax
------

.. code-block:: csharp

   public class LogFormatter





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/logging/src/Microsoft.Extensions.Logging.Abstractions/LogFormatter.cs>`_





.. dn:class:: Microsoft.Extensions.Logging.LogFormatter

Methods
-------

.. dn:class:: Microsoft.Extensions.Logging.LogFormatter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.LogFormatter.FormatLogValues(Microsoft.Extensions.Logging.ILogValues)
    
        
    
        Formats an :any:`Microsoft.Extensions.Logging.ILogValues`\.
    
        
        
        
        :param logValues: The  to format.
        
        :type logValues: Microsoft.Extensions.Logging.ILogValues
        :rtype: System.String
        :return: A string representation of the given <see cref="T:Microsoft.Extensions.Logging.ILogValues" />.
    
        
        .. code-block:: csharp
    
           public static string FormatLogValues(ILogValues logValues)
    
    .. dn:method:: Microsoft.Extensions.Logging.LogFormatter.Formatter(System.Object, System.Exception)
    
        
    
        Formats a message from the given state and exception, in the form
        "state
        exception".
        If state is an :any:`Microsoft.Extensions.Logging.ILogValues`\, :dn:meth:`Microsoft.Extensions.Logging.LogFormatter.FormatLogValues(Microsoft.Extensions.Logging.ILogValues)`
        is used to format the message, otherwise the state's ToString() is used.
    
        
        
        
        :type state: System.Object
        
        
        :type e: System.Exception
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public static string Formatter(object state, Exception e)
    

