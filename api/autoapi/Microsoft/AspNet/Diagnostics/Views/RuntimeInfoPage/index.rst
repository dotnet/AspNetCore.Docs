

RuntimeInfoPage Class
=====================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Diagnostics.Views.BaseView`
* :dn:cls:`Microsoft.AspNet.Diagnostics.Views.RuntimeInfoPage`








Syntax
------

.. code-block:: csharp

   public class RuntimeInfoPage : BaseView





GitHub
------

`View on GitHub <https://github.com/aspnet/diagnostics/blob/master/src/Microsoft.AspNet.Diagnostics/RuntimeInfo/Views/RuntimeInfoPage.cs>`_





.. dn:class:: Microsoft.AspNet.Diagnostics.Views.RuntimeInfoPage

Constructors
------------

.. dn:class:: Microsoft.AspNet.Diagnostics.Views.RuntimeInfoPage
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Diagnostics.Views.RuntimeInfoPage.RuntimeInfoPage()
    
        
    
        
        .. code-block:: csharp
    
           public RuntimeInfoPage()
    
    .. dn:constructor:: Microsoft.AspNet.Diagnostics.Views.RuntimeInfoPage.RuntimeInfoPage(Microsoft.AspNet.Diagnostics.Views.RuntimeInfoPageModel)
    
        
        
        
        :type model: Microsoft.AspNet.Diagnostics.Views.RuntimeInfoPageModel
    
        
        .. code-block:: csharp
    
           public RuntimeInfoPage(RuntimeInfoPageModel model)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Diagnostics.Views.RuntimeInfoPage
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Diagnostics.Views.RuntimeInfoPage.ExecuteAsync()
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public override Task ExecuteAsync()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Diagnostics.Views.RuntimeInfoPage
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Views.RuntimeInfoPage.Model
    
        
        :rtype: Microsoft.AspNet.Diagnostics.Views.RuntimeInfoPageModel
    
        
        .. code-block:: csharp
    
           public RuntimeInfoPageModel Model { get; set; }
    

