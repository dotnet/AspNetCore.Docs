

WebApplication Class
====================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Hosting.WebApplication`








Syntax
------

.. code-block:: csharp

   public class WebApplication





GitHub
------

`View on GitHub <https://github.com/aspnet/hosting/blob/master/src/Microsoft.AspNet.Hosting/WebApplication.cs>`_





.. dn:class:: Microsoft.AspNet.Hosting.WebApplication

Methods
-------

.. dn:class:: Microsoft.AspNet.Hosting.WebApplication
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Hosting.WebApplication.Run(System.String[])
    
        
        
        
        :type args: System.String[]
    
        
        .. code-block:: csharp
    
           public static void Run(string[] args)
    
    .. dn:method:: Microsoft.AspNet.Hosting.WebApplication.Run(System.Type)
    
        
        
        
        :type startupType: System.Type
    
        
        .. code-block:: csharp
    
           public static void Run(Type startupType)
    
    .. dn:method:: Microsoft.AspNet.Hosting.WebApplication.Run(System.Type, System.String[])
    
        
        
        
        :type startupType: System.Type
        
        
        :type args: System.String[]
    
        
        .. code-block:: csharp
    
           public static void Run(Type startupType, string[] args)
    
    .. dn:method:: Microsoft.AspNet.Hosting.WebApplication.Run<TStartup>()
    
        
    
        
        .. code-block:: csharp
    
           public static void Run<TStartup>()
    
    .. dn:method:: Microsoft.AspNet.Hosting.WebApplication.Run<TStartup>(System.String[])
    
        
        
        
        :type args: System.String[]
    
        
        .. code-block:: csharp
    
           public static void Run<TStartup>(string[] args)
    

