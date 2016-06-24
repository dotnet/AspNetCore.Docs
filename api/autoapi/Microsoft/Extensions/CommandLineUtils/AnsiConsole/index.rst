

AnsiConsole Class
=================





Namespace
    :dn:ns:`Microsoft.Extensions.CommandLineUtils`
Assemblies
    * Microsoft.Extensions.CommandLineUtils

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.CommandLineUtils.AnsiConsole`








Syntax
------

.. code-block:: csharp

    public class AnsiConsole








.. dn:class:: Microsoft.Extensions.CommandLineUtils.AnsiConsole
    :hidden:

.. dn:class:: Microsoft.Extensions.CommandLineUtils.AnsiConsole

Methods
-------

.. dn:class:: Microsoft.Extensions.CommandLineUtils.AnsiConsole
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.CommandLineUtils.AnsiConsole.GetError(System.Boolean)
    
        
    
        
        :type useConsoleColor: System.Boolean
        :rtype: Microsoft.Extensions.CommandLineUtils.AnsiConsole
    
        
        .. code-block:: csharp
    
            public static AnsiConsole GetError(bool useConsoleColor)
    
    .. dn:method:: Microsoft.Extensions.CommandLineUtils.AnsiConsole.GetOutput(System.Boolean)
    
        
    
        
        :type useConsoleColor: System.Boolean
        :rtype: Microsoft.Extensions.CommandLineUtils.AnsiConsole
    
        
        .. code-block:: csharp
    
            public static AnsiConsole GetOutput(bool useConsoleColor)
    
    .. dn:method:: Microsoft.Extensions.CommandLineUtils.AnsiConsole.WriteLine(System.String)
    
        
    
        
        :type message: System.String
    
        
        .. code-block:: csharp
    
            public void WriteLine(string message)
    

Properties
----------

.. dn:class:: Microsoft.Extensions.CommandLineUtils.AnsiConsole
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.CommandLineUtils.AnsiConsole.OriginalForegroundColor
    
        
        :rtype: System.ConsoleColor
    
        
        .. code-block:: csharp
    
            public ConsoleColor OriginalForegroundColor { get; }
    
    .. dn:property:: Microsoft.Extensions.CommandLineUtils.AnsiConsole.Writer
    
        
        :rtype: System.IO.TextWriter
    
        
        .. code-block:: csharp
    
            public TextWriter Writer { get; }
    

