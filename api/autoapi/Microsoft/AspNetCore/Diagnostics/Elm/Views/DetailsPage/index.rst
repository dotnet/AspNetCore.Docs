

DetailsPage Class
=================





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
* :dn:cls:`Microsoft.AspNetCore.Diagnostics.Elm.Views.DetailsPage`








Syntax
------

.. code-block:: csharp

    public class DetailsPage : BaseView








.. dn:class:: Microsoft.AspNetCore.Diagnostics.Elm.Views.DetailsPage
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Diagnostics.Elm.Views.DetailsPage

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.Elm.Views.DetailsPage
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Diagnostics.Elm.Views.DetailsPage.DetailsPage()
    
        
    
        
        .. code-block:: csharp
    
            public DetailsPage()
    
    .. dn:constructor:: Microsoft.AspNetCore.Diagnostics.Elm.Views.DetailsPage.DetailsPage(Microsoft.AspNetCore.Diagnostics.Elm.Views.DetailsPageModel)
    
        
    
        
        :type model: Microsoft.AspNetCore.Diagnostics.Elm.Views.DetailsPageModel
    
        
        .. code-block:: csharp
    
            public DetailsPage(DetailsPageModel model)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.Elm.Views.DetailsPage
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Diagnostics.Elm.Views.DetailsPage.ExecuteAsync()
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task ExecuteAsync()
    
    .. dn:method:: Microsoft.AspNetCore.Diagnostics.Elm.Views.DetailsPage.LogRow(Microsoft.AspNetCore.Diagnostics.Elm.LogInfo)
    
        
    
        
        :type log: Microsoft.AspNetCore.Diagnostics.Elm.LogInfo
        :rtype: Microsoft.AspNetCore.DiagnosticsViewPage.Views.HelperResult
    
        
        .. code-block:: csharp
    
            public HelperResult LogRow(LogInfo log)
    
    .. dn:method:: Microsoft.AspNetCore.Diagnostics.Elm.Views.DetailsPage.Traverse(Microsoft.AspNetCore.Diagnostics.Elm.ScopeNode)
    
        
    
        
        :type node: Microsoft.AspNetCore.Diagnostics.Elm.ScopeNode
        :rtype: Microsoft.AspNetCore.DiagnosticsViewPage.Views.HelperResult
    
        
        .. code-block:: csharp
    
            public HelperResult Traverse(ScopeNode node)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.Elm.Views.DetailsPage
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.Elm.Views.DetailsPage.Model
    
        
        :rtype: Microsoft.AspNetCore.Diagnostics.Elm.Views.DetailsPageModel
    
        
        .. code-block:: csharp
    
            public DetailsPageModel Model { get; set; }
    

