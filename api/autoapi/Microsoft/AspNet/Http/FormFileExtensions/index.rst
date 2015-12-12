

FormFileExtensions Class
========================



.. contents:: 
   :local:



Summary
-------

Extension methods for :any:`Microsoft.AspNet.Http.IFormFile`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Http.FormFileExtensions`








Syntax
------

.. code-block:: csharp

   public class FormFileExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.Http.Extensions/FormFileExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Http.FormFileExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Http.FormFileExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.FormFileExtensions.SaveAs(Microsoft.AspNet.Http.IFormFile, System.String)
    
        
    
        Saves the contents of an uploaded file.
    
        
        
        
        :param formFile: The .
        
        :type formFile: Microsoft.AspNet.Http.IFormFile
        
        
        :param filename: The name of the file to create.
        
        :type filename: System.String
    
        
        .. code-block:: csharp
    
           public static void SaveAs(IFormFile formFile, string filename)
    
    .. dn:method:: Microsoft.AspNet.Http.FormFileExtensions.SaveAsAsync(Microsoft.AspNet.Http.IFormFile, System.String, System.Threading.CancellationToken)
    
        
    
        Asynchronously saves the contents of an uploaded file.
    
        
        
        
        :param formFile: The .
        
        :type formFile: Microsoft.AspNet.Http.IFormFile
        
        
        :param filename: The name of the file to create.
        
        :type filename: System.String
        
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public static Task SaveAsAsync(IFormFile formFile, string filename, CancellationToken cancellationToken = null)
    

