

ModelNames Class
================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.ModelNames`








Syntax
------

.. code-block:: csharp

   public class ModelNames





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/ModelBinding/ModelNames.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.ModelNames

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.ModelNames
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelNames.CreateIndexModelName(System.String, System.Int32)
    
        
        
        
        :type parentName: System.String
        
        
        :type index: System.Int32
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public static string CreateIndexModelName(string parentName, int index)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelNames.CreateIndexModelName(System.String, System.String)
    
        
        
        
        :type parentName: System.String
        
        
        :type index: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public static string CreateIndexModelName(string parentName, string index)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelNames.CreatePropertyModelName(System.String, System.String)
    
        
        
        
        :type prefix: System.String
        
        
        :type propertyName: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public static string CreatePropertyModelName(string prefix, string propertyName)
    

