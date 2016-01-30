

ErrorPage Class
===============



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Diagnostics.Views.BaseView`
* :dn:cls:`Microsoft.AspNet.Diagnostics.Views.ErrorPage`








Syntax
------

.. code-block:: csharp

   public class ErrorPage : BaseView





GitHub
------

`View on GitHub <https://github.com/aspnet/diagnostics/blob/master/src/Microsoft.AspNet.Diagnostics/DeveloperExceptionPage/Views/ErrorPage.cs>`_





.. dn:class:: Microsoft.AspNet.Diagnostics.Views.ErrorPage

Constructors
------------

.. dn:class:: Microsoft.AspNet.Diagnostics.Views.ErrorPage
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Diagnostics.Views.ErrorPage.ErrorPage()
    
        
    
        
        .. code-block:: csharp
    
           public ErrorPage()
    
    .. dn:constructor:: Microsoft.AspNet.Diagnostics.Views.ErrorPage.ErrorPage(Microsoft.AspNet.Diagnostics.Views.ErrorPageModel)
    
        
        
        
        :type model: Microsoft.AspNet.Diagnostics.Views.ErrorPageModel
    
        
        .. code-block:: csharp
    
           public ErrorPage(ErrorPageModel model)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Diagnostics.Views.ErrorPage
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Diagnostics.Views.ErrorPage.ExecuteAsync()
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public override Task ExecuteAsync()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Diagnostics.Views.ErrorPage
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Views.ErrorPage.Model
    
        
        :rtype: Microsoft.AspNet.Diagnostics.Views.ErrorPageModel
    
        
        .. code-block:: csharp
    
           public ErrorPageModel Model { get; set; }
    

