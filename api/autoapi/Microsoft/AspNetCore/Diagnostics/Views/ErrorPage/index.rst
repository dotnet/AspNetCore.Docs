

ErrorPage Class
===============





Namespace
    :dn:ns:`Microsoft.AspNetCore.Diagnostics.Views`
Assemblies
    * Microsoft.AspNetCore.Diagnostics

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.DiagnosticsViewPage.Views.BaseView`
* :dn:cls:`Microsoft.AspNetCore.Diagnostics.Views.ErrorPage`








Syntax
------

.. code-block:: csharp

    public class ErrorPage : BaseView








.. dn:class:: Microsoft.AspNetCore.Diagnostics.Views.ErrorPage
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Diagnostics.Views.ErrorPage

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.Views.ErrorPage
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.Views.ErrorPage.Model
    
        
        :rtype: Microsoft.AspNetCore.Diagnostics.Views.ErrorPageModel
    
        
        .. code-block:: csharp
    
            public ErrorPageModel Model
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.Views.ErrorPage
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Diagnostics.Views.ErrorPage.ErrorPage()
    
        
    
        
        .. code-block:: csharp
    
            public ErrorPage()
    
    .. dn:constructor:: Microsoft.AspNetCore.Diagnostics.Views.ErrorPage.ErrorPage(Microsoft.AspNetCore.Diagnostics.Views.ErrorPageModel)
    
        
    
        
        :type model: Microsoft.AspNetCore.Diagnostics.Views.ErrorPageModel
    
        
        .. code-block:: csharp
    
            public ErrorPage(ErrorPageModel model)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.Views.ErrorPage
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Diagnostics.Views.ErrorPage.ExecuteAsync()
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task ExecuteAsync()
    

