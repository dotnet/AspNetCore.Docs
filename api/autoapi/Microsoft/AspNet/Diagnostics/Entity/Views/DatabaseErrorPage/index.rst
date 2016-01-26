

DatabaseErrorPage Class
=======================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Diagnostics.Views.BaseView`
* :dn:cls:`Microsoft.AspNet.Diagnostics.Entity.Views.DatabaseErrorPage`








Syntax
------

.. code-block:: csharp

   public class DatabaseErrorPage : BaseView





GitHub
------

`View on GitHub <https://github.com/aspnet/diagnostics/blob/master/src/Microsoft.AspNet.Diagnostics.Entity/Views/DatabaseErrorPage.cs>`_





.. dn:class:: Microsoft.AspNet.Diagnostics.Entity.Views.DatabaseErrorPage

Constructors
------------

.. dn:class:: Microsoft.AspNet.Diagnostics.Entity.Views.DatabaseErrorPage
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Diagnostics.Entity.Views.DatabaseErrorPage.DatabaseErrorPage()
    
        
    
        
        .. code-block:: csharp
    
           public DatabaseErrorPage()
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Diagnostics.Entity.Views.DatabaseErrorPage
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Diagnostics.Entity.Views.DatabaseErrorPage.ExecuteAsync()
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public override Task ExecuteAsync()
    
    .. dn:method:: Microsoft.AspNet.Diagnostics.Entity.Views.DatabaseErrorPage.JavaScriptEncode(System.String)
    
        
        
        
        :type content: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string JavaScriptEncode(string content)
    
    .. dn:method:: Microsoft.AspNet.Diagnostics.Entity.Views.DatabaseErrorPage.UrlEncode(System.String)
    
        
        
        
        :type content: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string UrlEncode(string content)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Diagnostics.Entity.Views.DatabaseErrorPage
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Entity.Views.DatabaseErrorPage.Model
    
        
        :rtype: Microsoft.AspNet.Diagnostics.Entity.Views.DatabaseErrorPageModel
    
        
        .. code-block:: csharp
    
           public DatabaseErrorPageModel Model { get; set; }
    

