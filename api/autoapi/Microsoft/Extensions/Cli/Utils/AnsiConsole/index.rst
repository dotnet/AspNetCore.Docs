

AnsiConsole Class
=================





Namespace
    :dn:ns:`Microsoft.Extensions.Cli.Utils`
Assemblies
    * Microsoft.AspNetCore.Server.IISIntegration.Tools

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Cli.Utils.AnsiConsole`








Syntax
------

.. code-block:: csharp

    public class AnsiConsole








.. dn:class:: Microsoft.Extensions.Cli.Utils.AnsiConsole
    :hidden:

.. dn:class:: Microsoft.Extensions.Cli.Utils.AnsiConsole

Properties
----------

.. dn:class:: Microsoft.Extensions.Cli.Utils.AnsiConsole
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Cli.Utils.AnsiConsole.OriginalForegroundColor
    
        
        :rtype: System.ConsoleColor
    
        
        .. code-block:: csharp
    
            public ConsoleColor OriginalForegroundColor
            {
                get;
            }
    
    .. dn:property:: Microsoft.Extensions.Cli.Utils.AnsiConsole.Writer
    
        
        :rtype: System.IO.TextWriter
    
        
        .. code-block:: csharp
    
            public TextWriter Writer
            {
                get;
            }
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Cli.Utils.AnsiConsole
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Cli.Utils.AnsiConsole.GetError()
    
        
        :rtype: Microsoft.Extensions.Cli.Utils.AnsiConsole
    
        
        .. code-block:: csharp
    
            public static AnsiConsole GetError()
    
    .. dn:method:: Microsoft.Extensions.Cli.Utils.AnsiConsole.GetOutput()
    
        
        :rtype: Microsoft.Extensions.Cli.Utils.AnsiConsole
    
        
        .. code-block:: csharp
    
            public static AnsiConsole GetOutput()
    
    .. dn:method:: Microsoft.Extensions.Cli.Utils.AnsiConsole.Write(System.String)
    
        
    
        
        :type message: System.String
    
        
        .. code-block:: csharp
    
            public void Write(string message)
    
    .. dn:method:: Microsoft.Extensions.Cli.Utils.AnsiConsole.WriteLine(System.String)
    
        
    
        
        :type message: System.String
    
        
        .. code-block:: csharp
    
            public void WriteLine(string message)
    

