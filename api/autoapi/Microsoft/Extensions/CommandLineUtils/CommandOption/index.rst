

CommandOption Class
===================





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
* :dn:cls:`Microsoft.Extensions.CommandLineUtils.CommandOption`








Syntax
------

.. code-block:: csharp

    public class CommandOption








.. dn:class:: Microsoft.Extensions.CommandLineUtils.CommandOption
    :hidden:

.. dn:class:: Microsoft.Extensions.CommandLineUtils.CommandOption

Constructors
------------

.. dn:class:: Microsoft.Extensions.CommandLineUtils.CommandOption
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.CommandLineUtils.CommandOption.CommandOption(System.String, Microsoft.Extensions.CommandLineUtils.CommandOptionType)
    
        
    
        
        :type template: System.String
    
        
        :type optionType: Microsoft.Extensions.CommandLineUtils.CommandOptionType
    
        
        .. code-block:: csharp
    
            public CommandOption(string template, CommandOptionType optionType)
    

Properties
----------

.. dn:class:: Microsoft.Extensions.CommandLineUtils.CommandOption
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.CommandLineUtils.CommandOption.Description
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Description { get; set; }
    
    .. dn:property:: Microsoft.Extensions.CommandLineUtils.CommandOption.LongName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string LongName { get; set; }
    
    .. dn:property:: Microsoft.Extensions.CommandLineUtils.CommandOption.OptionType
    
        
        :rtype: Microsoft.Extensions.CommandLineUtils.CommandOptionType
    
        
        .. code-block:: csharp
    
            public CommandOptionType OptionType { get; }
    
    .. dn:property:: Microsoft.Extensions.CommandLineUtils.CommandOption.ShortName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ShortName { get; set; }
    
    .. dn:property:: Microsoft.Extensions.CommandLineUtils.CommandOption.SymbolName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string SymbolName { get; set; }
    
    .. dn:property:: Microsoft.Extensions.CommandLineUtils.CommandOption.Template
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Template { get; set; }
    
    .. dn:property:: Microsoft.Extensions.CommandLineUtils.CommandOption.ValueName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ValueName { get; set; }
    
    .. dn:property:: Microsoft.Extensions.CommandLineUtils.CommandOption.Values
    
        
        :rtype: System.Collections.Generic.List<System.Collections.Generic.List`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public List<string> Values { get; }
    

Methods
-------

.. dn:class:: Microsoft.Extensions.CommandLineUtils.CommandOption
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.CommandLineUtils.CommandOption.HasValue()
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool HasValue()
    
    .. dn:method:: Microsoft.Extensions.CommandLineUtils.CommandOption.TryParse(System.String)
    
        
    
        
        :type value: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool TryParse(string value)
    
    .. dn:method:: Microsoft.Extensions.CommandLineUtils.CommandOption.Value()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Value()
    

