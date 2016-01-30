

ApplicationModelConventions Class
=================================



.. contents:: 
   :local:



Summary
-------

Applies conventions to a :any:`Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModel`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModelConventions`








Syntax
------

.. code-block:: csharp

   public class ApplicationModelConventions





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/ApplicationModels/ApplicationModelConventions.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModelConventions

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModelConventions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModelConventions.ApplyConventions(Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModel, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Mvc.ApplicationModels.IApplicationModelConvention>)
    
        
    
        Applies conventions to a :any:`Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModel`\.
    
        
        
        
        :param applicationModel: The .
        
        :type applicationModel: Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModel
        
        
        :param conventions: The set of conventions.
        
        :type conventions: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.ApplicationModels.IApplicationModelConvention}
    
        
        .. code-block:: csharp
    
           public static void ApplyConventions(ApplicationModel applicationModel, IEnumerable<IApplicationModelConvention> conventions)
    

