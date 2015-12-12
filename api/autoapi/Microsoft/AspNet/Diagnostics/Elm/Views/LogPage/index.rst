

LogPage Class
=============



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Diagnostics.Views.BaseView`
* :dn:cls:`Microsoft.AspNet.Diagnostics.Elm.Views.LogPage`








Syntax
------

.. code-block:: csharp

   public class LogPage : BaseView





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/diagnostics/src/Microsoft.AspNet.Diagnostics.Elm/Views/LogPage.cs>`_





.. dn:class:: Microsoft.AspNet.Diagnostics.Elm.Views.LogPage

Constructors
------------

.. dn:class:: Microsoft.AspNet.Diagnostics.Elm.Views.LogPage
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Diagnostics.Elm.Views.LogPage.LogPage()
    
        
    
        
        .. code-block:: csharp
    
           public LogPage()
    
    .. dn:constructor:: Microsoft.AspNet.Diagnostics.Elm.Views.LogPage.LogPage(Microsoft.AspNet.Diagnostics.Elm.Views.LogPageModel)
    
        
        
        
        :type model: Microsoft.AspNet.Diagnostics.Elm.Views.LogPageModel
    
        
        .. code-block:: csharp
    
           public LogPage(LogPageModel model)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Diagnostics.Elm.Views.LogPage
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Diagnostics.Elm.Views.LogPage.ExecuteAsync()
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public override Task ExecuteAsync()
    
    .. dn:method:: Microsoft.AspNet.Diagnostics.Elm.Views.LogPage.LogRow(Microsoft.AspNet.Diagnostics.Elm.LogInfo, System.Int32)
    
        
        
        
        :type log: Microsoft.AspNet.Diagnostics.Elm.LogInfo
        
        
        :type level: System.Int32
        :rtype: Microsoft.AspNet.Diagnostics.Views.HelperResult
    
        
        .. code-block:: csharp
    
           public HelperResult LogRow(LogInfo log, int level)
    
    .. dn:method:: Microsoft.AspNet.Diagnostics.Elm.Views.LogPage.Traverse(Microsoft.AspNet.Diagnostics.Elm.ScopeNode, System.Int32, System.Collections.Generic.Dictionary<System.String, System.Int32>)
    
        
        
        
        :type node: Microsoft.AspNet.Diagnostics.Elm.ScopeNode
        
        
        :type level: System.Int32
        
        
        :type counts: System.Collections.Generic.Dictionary{System.String,System.Int32}
        :rtype: Microsoft.AspNet.Diagnostics.Views.HelperResult
    
        
        .. code-block:: csharp
    
           public HelperResult Traverse(ScopeNode node, int level, Dictionary<string, int> counts)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Diagnostics.Elm.Views.LogPage
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Elm.Views.LogPage.Model
    
        
        :rtype: Microsoft.AspNet.Diagnostics.Elm.Views.LogPageModel
    
        
        .. code-block:: csharp
    
           public LogPageModel Model { get; set; }
    

