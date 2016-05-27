

IConsole Interface
==================





Namespace
    :dn:ns:`Microsoft.Extensions.Logging.Console.Internal`
Assemblies
    * Microsoft.Extensions.Logging.Console

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IConsole








.. dn:interface:: Microsoft.Extensions.Logging.Console.Internal.IConsole
    :hidden:

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
    
        
        :type background: System.Nullable<System.Nullable`1>{System.ConsoleColor<System.ConsoleColor>}
    
        
        :type foreground: System.Nullable<System.Nullable`1>{System.ConsoleColor<System.ConsoleColor>}
    
        
        .. code-block:: csharp
    
            void Write(string message, ConsoleColor? background, ConsoleColor? foreground)
    
    .. dn:method:: Microsoft.Extensions.Logging.Console.Internal.IConsole.WriteLine(System.String, System.Nullable<System.ConsoleColor>, System.Nullable<System.ConsoleColor>)
    
        
    
        
        :type message: System.String
    
        
        :type background: System.Nullable<System.Nullable`1>{System.ConsoleColor<System.ConsoleColor>}
    
        
        :type foreground: System.Nullable<System.Nullable`1>{System.ConsoleColor<System.ConsoleColor>}
    
        
        .. code-block:: csharp
    
            void WriteLine(string message, ConsoleColor? background, ConsoleColor? foreground)
    

