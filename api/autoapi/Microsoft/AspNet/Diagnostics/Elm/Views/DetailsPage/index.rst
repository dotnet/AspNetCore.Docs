

DetailsPage Class
=================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Diagnostics.Views.BaseView`
* :dn:cls:`Microsoft.AspNet.Diagnostics.Elm.Views.DetailsPage`








Syntax
------

.. code-block:: csharp

   public class DetailsPage : BaseView





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/diagnostics/src/Microsoft.AspNet.Diagnostics.Elm/Views/DetailsPage.cs>`_





.. dn:class:: Microsoft.AspNet.Diagnostics.Elm.Views.DetailsPage

Constructors
------------

.. dn:class:: Microsoft.AspNet.Diagnostics.Elm.Views.DetailsPage
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Diagnostics.Elm.Views.DetailsPage.DetailsPage()
    
        
    
        
        .. code-block:: csharp
    
           public DetailsPage()
    
    .. dn:constructor:: Microsoft.AspNet.Diagnostics.Elm.Views.DetailsPage.DetailsPage(Microsoft.AspNet.Diagnostics.Elm.Views.DetailsPageModel)
    
        
        
        
        :type model: Microsoft.AspNet.Diagnostics.Elm.Views.DetailsPageModel
    
        
        .. code-block:: csharp
    
           public DetailsPage(DetailsPageModel model)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Diagnostics.Elm.Views.DetailsPage
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Diagnostics.Elm.Views.DetailsPage.ExecuteAsync()
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public override Task ExecuteAsync()
    
    .. dn:method:: Microsoft.AspNet.Diagnostics.Elm.Views.DetailsPage.LogRow(Microsoft.AspNet.Diagnostics.Elm.LogInfo)
    
        
        
        
        :type log: Microsoft.AspNet.Diagnostics.Elm.LogInfo
        :rtype: Microsoft.AspNet.Diagnostics.Views.HelperResult
    
        
        .. code-block:: csharp
    
           public HelperResult LogRow(LogInfo log)
    
    .. dn:method:: Microsoft.AspNet.Diagnostics.Elm.Views.DetailsPage.Traverse(Microsoft.AspNet.Diagnostics.Elm.ScopeNode)
    
        
        
        
        :type node: Microsoft.AspNet.Diagnostics.Elm.ScopeNode
        :rtype: Microsoft.AspNet.Diagnostics.Views.HelperResult
    
        
        .. code-block:: csharp
    
           public HelperResult Traverse(ScopeNode node)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Diagnostics.Elm.Views.DetailsPage
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Elm.Views.DetailsPage.Model
    
        
        :rtype: Microsoft.AspNet.Diagnostics.Elm.Views.DetailsPageModel
    
        
        .. code-block:: csharp
    
           public DetailsPageModel Model { get; set; }
    

