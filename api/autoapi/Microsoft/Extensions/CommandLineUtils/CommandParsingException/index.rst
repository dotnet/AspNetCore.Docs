

CommandParsingException Class
=============================





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
* :dn:cls:`System.Exception`
* :dn:cls:`Microsoft.Extensions.CommandLineUtils.CommandParsingException`








Syntax
------

.. code-block:: csharp

    public class CommandParsingException : Exception, ISerializable, _Exception








.. dn:class:: Microsoft.Extensions.CommandLineUtils.CommandParsingException
    :hidden:

.. dn:class:: Microsoft.Extensions.CommandLineUtils.CommandParsingException

Properties
----------

.. dn:class:: Microsoft.Extensions.CommandLineUtils.CommandParsingException
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.CommandLineUtils.CommandParsingException.Command
    
        
        :rtype: Microsoft.Extensions.CommandLineUtils.CommandLineApplication
    
        
        .. code-block:: csharp
    
            public CommandLineApplication Command
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.Extensions.CommandLineUtils.CommandParsingException
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.CommandLineUtils.CommandParsingException.CommandParsingException(Microsoft.Extensions.CommandLineUtils.CommandLineApplication, System.String)
    
        
    
        
        :type command: Microsoft.Extensions.CommandLineUtils.CommandLineApplication
    
        
        :type message: System.String
    
        
        .. code-block:: csharp
    
            public CommandParsingException(CommandLineApplication command, string message)
    

