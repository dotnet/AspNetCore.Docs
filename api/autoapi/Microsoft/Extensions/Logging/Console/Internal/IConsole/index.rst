

IConsole Interface
==================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IConsole





GitHub
------

`View on GitHub <https://github.com/aspnet/logging/blob/master/src/Microsoft.Extensions.Logging.Console/Internal/IConsole.cs>`_





.. dn:interface:: Microsoft.Extensions.Logging.Console.Internal.IConsole

Methods
-------

.. dn:interface:: Microsoft.Extensions.Logging.Console.Internal.IConsole
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.Console.Internal.IConsole.Flush()
    
        
    
        
        .. code-block:: csharp
    
           void Flush()
    
    .. dn:method:: Microsoft.Extensions.Logging.Console.Internal.IConsole.Write(System.String, System.Nullable<System.ConsoleColor>, System.Nullable<System.ConsoleColor>)
    
        
        
        
        :type message: System.String
        
        
        :type background: System.Nullable{System.ConsoleColor}
        
        
        :type foreground: System.Nullable{System.ConsoleColor}
    
        
        .. code-block:: csharp
    
           void Write(string message, ConsoleColor? background, ConsoleColor? foreground)
    
    .. dn:method:: Microsoft.Extensions.Logging.Console.Internal.IConsole.WriteLine(System.String, System.Nullable<System.ConsoleColor>, System.Nullable<System.ConsoleColor>)
    
        
        
        
        :type message: System.String
        
        
        :type background: System.Nullable{System.ConsoleColor}
        
        
        :type foreground: System.Nullable{System.ConsoleColor}
    
        
        .. code-block:: csharp
    
           void WriteLine(string message, ConsoleColor? background, ConsoleColor? foreground)
    

