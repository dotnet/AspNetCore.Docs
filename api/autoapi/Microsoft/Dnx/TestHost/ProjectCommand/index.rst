

ProjectCommand Class
====================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Dnx.TestHost.ProjectCommand`








Syntax
------

.. code-block:: csharp

   public class ProjectCommand





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/testing/src/Microsoft.Dnx.TestHost/ProjectCommand.cs>`_





.. dn:class:: Microsoft.Dnx.TestHost.ProjectCommand

Methods
-------

.. dn:class:: Microsoft.Dnx.TestHost.ProjectCommand
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Dnx.TestHost.ProjectCommand.Execute(System.IServiceProvider, Microsoft.Dnx.TestHost.Project, System.String, System.String[])
    
        
        
        
        :type services: System.IServiceProvider
        
        
        :type project: Microsoft.Dnx.TestHost.Project
        
        
        :type command: System.String
        
        
        :type args: System.String[]
        :rtype: System.Threading.Tasks.Task{System.Int32}
    
        
        .. code-block:: csharp
    
           public static Task<int> Execute(IServiceProvider services, Project project, string command, string[] args)
    

