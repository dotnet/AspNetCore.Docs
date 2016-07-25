

CommandLineApplication Class
============================





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
* :dn:cls:`Microsoft.Extensions.CommandLineUtils.CommandLineApplication`








Syntax
------

.. code-block:: csharp

    public class CommandLineApplication








.. dn:class:: Microsoft.Extensions.CommandLineUtils.CommandLineApplication
    :hidden:

.. dn:class:: Microsoft.Extensions.CommandLineUtils.CommandLineApplication

Constructors
------------

.. dn:class:: Microsoft.Extensions.CommandLineUtils.CommandLineApplication
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.CommandLineUtils.CommandLineApplication.CommandLineApplication(System.Boolean)
    
        
    
        
        :type throwOnUnexpectedArg: System.Boolean
    
        
        .. code-block:: csharp
    
            public CommandLineApplication(bool throwOnUnexpectedArg = true)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.CommandLineUtils.CommandLineApplication
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.CommandLineUtils.CommandLineApplication.Argument(System.String, System.String, System.Action<Microsoft.Extensions.CommandLineUtils.CommandArgument>, System.Boolean)
    
        
    
        
        :type name: System.String
    
        
        :type description: System.String
    
        
        :type configuration: System.Action<System.Action`1>{Microsoft.Extensions.CommandLineUtils.CommandArgument<Microsoft.Extensions.CommandLineUtils.CommandArgument>}
    
        
        :type multipleValues: System.Boolean
        :rtype: Microsoft.Extensions.CommandLineUtils.CommandArgument
    
        
        .. code-block:: csharp
    
            public CommandArgument Argument(string name, string description, Action<CommandArgument> configuration, bool multipleValues = false)
    
    .. dn:method:: Microsoft.Extensions.CommandLineUtils.CommandLineApplication.Argument(System.String, System.String, System.Boolean)
    
        
    
        
        :type name: System.String
    
        
        :type description: System.String
    
        
        :type multipleValues: System.Boolean
        :rtype: Microsoft.Extensions.CommandLineUtils.CommandArgument
    
        
        .. code-block:: csharp
    
            public CommandArgument Argument(string name, string description, bool multipleValues = false)
    
    .. dn:method:: Microsoft.Extensions.CommandLineUtils.CommandLineApplication.Command(System.String, System.Action<Microsoft.Extensions.CommandLineUtils.CommandLineApplication>, System.Boolean)
    
        
    
        
        :type name: System.String
    
        
        :type configuration: System.Action<System.Action`1>{Microsoft.Extensions.CommandLineUtils.CommandLineApplication<Microsoft.Extensions.CommandLineUtils.CommandLineApplication>}
    
        
        :type throwOnUnexpectedArg: System.Boolean
        :rtype: Microsoft.Extensions.CommandLineUtils.CommandLineApplication
    
        
        .. code-block:: csharp
    
            public CommandLineApplication Command(string name, Action<CommandLineApplication> configuration, bool throwOnUnexpectedArg = true)
    
    .. dn:method:: Microsoft.Extensions.CommandLineUtils.CommandLineApplication.Execute(System.String[])
    
        
    
        
        :type args: System.String<System.String>[]
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Execute(params string[] args)
    
    .. dn:method:: Microsoft.Extensions.CommandLineUtils.CommandLineApplication.GetFullNameAndVersion()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string GetFullNameAndVersion()
    
    .. dn:method:: Microsoft.Extensions.CommandLineUtils.CommandLineApplication.HelpOption(System.String)
    
        
    
        
        :type template: System.String
        :rtype: Microsoft.Extensions.CommandLineUtils.CommandOption
    
        
        .. code-block:: csharp
    
            public CommandOption HelpOption(string template)
    
    .. dn:method:: Microsoft.Extensions.CommandLineUtils.CommandLineApplication.OnExecute(System.Func<System.Int32>)
    
        
    
        
        :type invoke: System.Func<System.Func`1>{System.Int32<System.Int32>}
    
        
        .. code-block:: csharp
    
            public void OnExecute(Func<int> invoke)
    
    .. dn:method:: Microsoft.Extensions.CommandLineUtils.CommandLineApplication.OnExecute(System.Func<System.Threading.Tasks.Task<System.Int32>>)
    
        
    
        
        :type invoke: System.Func<System.Func`1>{System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Int32<System.Int32>}}
    
        
        .. code-block:: csharp
    
            public void OnExecute(Func<Task<int>> invoke)
    
    .. dn:method:: Microsoft.Extensions.CommandLineUtils.CommandLineApplication.Option(System.String, System.String, Microsoft.Extensions.CommandLineUtils.CommandOptionType)
    
        
    
        
        :type template: System.String
    
        
        :type description: System.String
    
        
        :type optionType: Microsoft.Extensions.CommandLineUtils.CommandOptionType
        :rtype: Microsoft.Extensions.CommandLineUtils.CommandOption
    
        
        .. code-block:: csharp
    
            public CommandOption Option(string template, string description, CommandOptionType optionType)
    
    .. dn:method:: Microsoft.Extensions.CommandLineUtils.CommandLineApplication.Option(System.String, System.String, Microsoft.Extensions.CommandLineUtils.CommandOptionType, System.Action<Microsoft.Extensions.CommandLineUtils.CommandOption>)
    
        
    
        
        :type template: System.String
    
        
        :type description: System.String
    
        
        :type optionType: Microsoft.Extensions.CommandLineUtils.CommandOptionType
    
        
        :type configuration: System.Action<System.Action`1>{Microsoft.Extensions.CommandLineUtils.CommandOption<Microsoft.Extensions.CommandLineUtils.CommandOption>}
        :rtype: Microsoft.Extensions.CommandLineUtils.CommandOption
    
        
        .. code-block:: csharp
    
            public CommandOption Option(string template, string description, CommandOptionType optionType, Action<CommandOption> configuration)
    
    .. dn:method:: Microsoft.Extensions.CommandLineUtils.CommandLineApplication.ShowHelp(System.String)
    
        
    
        
        :type commandName: System.String
    
        
        .. code-block:: csharp
    
            public void ShowHelp(string commandName = null)
    
    .. dn:method:: Microsoft.Extensions.CommandLineUtils.CommandLineApplication.ShowHint()
    
        
    
        
        .. code-block:: csharp
    
            public void ShowHint()
    
    .. dn:method:: Microsoft.Extensions.CommandLineUtils.CommandLineApplication.ShowRootCommandFullNameAndVersion()
    
        
    
        
        .. code-block:: csharp
    
            public void ShowRootCommandFullNameAndVersion()
    
    .. dn:method:: Microsoft.Extensions.CommandLineUtils.CommandLineApplication.ShowVersion()
    
        
    
        
        .. code-block:: csharp
    
            public void ShowVersion()
    
    .. dn:method:: Microsoft.Extensions.CommandLineUtils.CommandLineApplication.VersionOption(System.String, System.Func<System.String>, System.Func<System.String>)
    
        
    
        
        :type template: System.String
    
        
        :type shortFormVersionGetter: System.Func<System.Func`1>{System.String<System.String>}
    
        
        :type longFormVersionGetter: System.Func<System.Func`1>{System.String<System.String>}
        :rtype: Microsoft.Extensions.CommandLineUtils.CommandOption
    
        
        .. code-block:: csharp
    
            public CommandOption VersionOption(string template, Func<string> shortFormVersionGetter, Func<string> longFormVersionGetter = null)
    
    .. dn:method:: Microsoft.Extensions.CommandLineUtils.CommandLineApplication.VersionOption(System.String, System.String, System.String)
    
        
    
        
        :type template: System.String
    
        
        :type shortFormVersion: System.String
    
        
        :type longFormVersion: System.String
        :rtype: Microsoft.Extensions.CommandLineUtils.CommandOption
    
        
        .. code-block:: csharp
    
            public CommandOption VersionOption(string template, string shortFormVersion, string longFormVersion = null)
    

Fields
------

.. dn:class:: Microsoft.Extensions.CommandLineUtils.CommandLineApplication
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.Extensions.CommandLineUtils.CommandLineApplication.Arguments
    
        
        :rtype: System.Collections.Generic.List<System.Collections.Generic.List`1>{Microsoft.Extensions.CommandLineUtils.CommandArgument<Microsoft.Extensions.CommandLineUtils.CommandArgument>}
    
        
        .. code-block:: csharp
    
            public readonly List<CommandArgument> Arguments
    
    .. dn:field:: Microsoft.Extensions.CommandLineUtils.CommandLineApplication.Commands
    
        
        :rtype: System.Collections.Generic.List<System.Collections.Generic.List`1>{Microsoft.Extensions.CommandLineUtils.CommandLineApplication<Microsoft.Extensions.CommandLineUtils.CommandLineApplication>}
    
        
        .. code-block:: csharp
    
            public readonly List<CommandLineApplication> Commands
    
    .. dn:field:: Microsoft.Extensions.CommandLineUtils.CommandLineApplication.Options
    
        
        :rtype: System.Collections.Generic.List<System.Collections.Generic.List`1>{Microsoft.Extensions.CommandLineUtils.CommandOption<Microsoft.Extensions.CommandLineUtils.CommandOption>}
    
        
        .. code-block:: csharp
    
            public readonly List<CommandOption> Options
    
    .. dn:field:: Microsoft.Extensions.CommandLineUtils.CommandLineApplication.RemainingArguments
    
        
        :rtype: System.Collections.Generic.List<System.Collections.Generic.List`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public readonly List<string> RemainingArguments
    

Properties
----------

.. dn:class:: Microsoft.Extensions.CommandLineUtils.CommandLineApplication
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.CommandLineUtils.CommandLineApplication.Description
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Description { get; set; }
    
    .. dn:property:: Microsoft.Extensions.CommandLineUtils.CommandLineApplication.FullName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string FullName { get; set; }
    
    .. dn:property:: Microsoft.Extensions.CommandLineUtils.CommandLineApplication.Invoke
    
        
        :rtype: System.Func<System.Func`1>{System.Int32<System.Int32>}
    
        
        .. code-block:: csharp
    
            public Func<int> Invoke { get; set; }
    
    .. dn:property:: Microsoft.Extensions.CommandLineUtils.CommandLineApplication.IsShowingInformation
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsShowingInformation { get; protected set; }
    
    .. dn:property:: Microsoft.Extensions.CommandLineUtils.CommandLineApplication.LongVersionGetter
    
        
        :rtype: System.Func<System.Func`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public Func<string> LongVersionGetter { get; set; }
    
    .. dn:property:: Microsoft.Extensions.CommandLineUtils.CommandLineApplication.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Name { get; set; }
    
    .. dn:property:: Microsoft.Extensions.CommandLineUtils.CommandLineApplication.OptionHelp
    
        
        :rtype: Microsoft.Extensions.CommandLineUtils.CommandOption
    
        
        .. code-block:: csharp
    
            public CommandOption OptionHelp { get; }
    
    .. dn:property:: Microsoft.Extensions.CommandLineUtils.CommandLineApplication.OptionVersion
    
        
        :rtype: Microsoft.Extensions.CommandLineUtils.CommandOption
    
        
        .. code-block:: csharp
    
            public CommandOption OptionVersion { get; }
    
    .. dn:property:: Microsoft.Extensions.CommandLineUtils.CommandLineApplication.Parent
    
        
        :rtype: Microsoft.Extensions.CommandLineUtils.CommandLineApplication
    
        
        .. code-block:: csharp
    
            public CommandLineApplication Parent { get; set; }
    
    .. dn:property:: Microsoft.Extensions.CommandLineUtils.CommandLineApplication.ShortVersionGetter
    
        
        :rtype: System.Func<System.Func`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public Func<string> ShortVersionGetter { get; set; }
    
    .. dn:property:: Microsoft.Extensions.CommandLineUtils.CommandLineApplication.Syntax
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Syntax { get; set; }
    

