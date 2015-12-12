

Project Class
=============



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Dnx.TestHost.Project`








Syntax
------

.. code-block:: csharp

   public class Project





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/testing/src/Microsoft.Dnx.TestHost/Project.cs>`_





.. dn:class:: Microsoft.Dnx.TestHost.Project

Methods
-------

.. dn:class:: Microsoft.Dnx.TestHost.Project
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Dnx.TestHost.Project.TryGetProject(System.String, out Microsoft.Dnx.TestHost.Project)
    
        
        
        
        :type inputPath: System.String
        
        
        :type project: Microsoft.Dnx.TestHost.Project
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public static bool TryGetProject(string inputPath, out Project project)
    

Properties
----------

.. dn:class:: Microsoft.Dnx.TestHost.Project
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Dnx.TestHost.Project.Commands
    
        
        :rtype: System.Collections.Generic.IDictionary{System.String,System.String}
    
        
        .. code-block:: csharp
    
           public IDictionary<string, string> Commands { get; }
    
    .. dn:property:: Microsoft.Dnx.TestHost.Project.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Name { get; set; }
    

