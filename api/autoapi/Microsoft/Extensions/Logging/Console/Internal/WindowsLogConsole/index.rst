

WindowsLogConsole Class
=======================





Namespace
    :dn:ns:`Microsoft.Extensions.Logging.Console.Internal`
Assemblies
    * Microsoft.Extensions.Logging.Console

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Logging.Console.Internal.WindowsLogConsole`








Syntax
------

.. code-block:: csharp

    public class WindowsLogConsole : IConsole








.. dn:class:: Microsoft.Extensions.Logging.Console.Internal.WindowsLogConsole
    :hidden:

.. dn:class:: Microsoft.Extensions.Logging.Console.Internal.WindowsLogConsole

Methods
-------

.. dn:class:: Microsoft.Extensions.Logging.Console.Internal.WindowsLogConsole
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.Console.Internal.WindowsLogConsole.Flush()
    
        
    
        
        .. code-block:: csharp
    
            public void Flush()
    
    .. dn:method:: Microsoft.Extensions.Logging.Console.Internal.WindowsLogConsole.Write(System.String, System.Nullable<System.ConsoleColor>, System.Nullable<System.ConsoleColor>)
    
        
    
        
        :type message: System.String
    
        
        :type background: System.Nullable<System.Nullable`1>{System.ConsoleColor<System.ConsoleColor>}
    
        
        :type foreground: System.Nullable<System.Nullable`1>{System.ConsoleColor<System.ConsoleColor>}
    
        
        .. code-block:: csharp
    
            public void Write(string message, ConsoleColor? background, ConsoleColor? foreground)
    
    .. dn:method:: Microsoft.Extensions.Logging.Console.Internal.WindowsLogConsole.WriteLine(System.String, System.Nullable<System.ConsoleColor>, System.Nullable<System.ConsoleColor>)
    
        
    
        
        :type message: System.String
    
        
        :type background: System.Nullable<System.Nullable`1>{System.ConsoleColor<System.ConsoleColor>}
    
        
        :type foreground: System.Nullable<System.Nullable`1>{System.ConsoleColor<System.ConsoleColor>}
    
        
        .. code-block:: csharp
    
            public void WriteLine(string message, ConsoleColor? background, ConsoleColor? foreground)
    

