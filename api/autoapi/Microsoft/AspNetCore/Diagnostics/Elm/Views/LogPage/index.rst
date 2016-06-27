

LogPage Class
=============





Namespace
    :dn:ns:`Microsoft.AspNetCore.Diagnostics.Elm.Views`
Assemblies
    * Microsoft.AspNetCore.Diagnostics.Elm

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.DiagnosticsViewPage.Views.BaseView`
* :dn:cls:`Microsoft.AspNetCore.Diagnostics.Elm.Views.LogPage`








Syntax
------

.. code-block:: csharp

    public class LogPage : BaseView








.. dn:class:: Microsoft.AspNetCore.Diagnostics.Elm.Views.LogPage
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Diagnostics.Elm.Views.LogPage

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.Elm.Views.LogPage
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Diagnostics.Elm.Views.LogPage.LogPage()
    
        
    
        
        .. code-block:: csharp
    
            public LogPage()
    
    .. dn:constructor:: Microsoft.AspNetCore.Diagnostics.Elm.Views.LogPage.LogPage(Microsoft.AspNetCore.Diagnostics.Elm.Views.LogPageModel)
    
        
    
        
        :type model: Microsoft.AspNetCore.Diagnostics.Elm.Views.LogPageModel
    
        
        .. code-block:: csharp
    
            public LogPage(LogPageModel model)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.Elm.Views.LogPage
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Diagnostics.Elm.Views.LogPage.ExecuteAsync()
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task ExecuteAsync()
    
    .. dn:method:: Microsoft.AspNetCore.Diagnostics.Elm.Views.LogPage.LogRow(Microsoft.AspNetCore.Diagnostics.Elm.LogInfo, System.Int32)
    
        
    
        
        :type log: Microsoft.AspNetCore.Diagnostics.Elm.LogInfo
    
        
        :type level: System.Int32
        :rtype: Microsoft.AspNetCore.DiagnosticsViewPage.Views.HelperResult
    
        
        .. code-block:: csharp
    
            public HelperResult LogRow(LogInfo log, int level)
    
    .. dn:method:: Microsoft.AspNetCore.Diagnostics.Elm.Views.LogPage.Traverse(Microsoft.AspNetCore.Diagnostics.Elm.ScopeNode, System.Int32, System.Collections.Generic.Dictionary<System.String, System.Int32>)
    
        
    
        
        :type node: Microsoft.AspNetCore.Diagnostics.Elm.ScopeNode
    
        
        :type level: System.Int32
    
        
        :type counts: System.Collections.Generic.Dictionary<System.Collections.Generic.Dictionary`2>{System.String<System.String>, System.Int32<System.Int32>}
        :rtype: Microsoft.AspNetCore.DiagnosticsViewPage.Views.HelperResult
    
        
        .. code-block:: csharp
    
            public HelperResult Traverse(ScopeNode node, int level, Dictionary<string, int> counts)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.Elm.Views.LogPage
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.Elm.Views.LogPage.Model
    
        
        :rtype: Microsoft.AspNetCore.Diagnostics.Elm.Views.LogPageModel
    
        
        .. code-block:: csharp
    
            public LogPageModel Model { get; set; }
    

