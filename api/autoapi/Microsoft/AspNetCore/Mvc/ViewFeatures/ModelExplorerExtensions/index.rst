

ModelExplorerExtensions Class
=============================






Extension methods for :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ViewFeatures`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorerExtensions`








Syntax
------

.. code-block:: csharp

    public class ModelExplorerExtensions








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorerExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorerExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorerExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorerExtensions.GetSimpleDisplayText(Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer)
    
        
    
        
        Gets a simple display string for the :dn:prop:`Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer.Model` property
        of <em>modelExplorer</em>.
    
        
    
        
        :param modelExplorer: The :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer`\.
        
        :type modelExplorer: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer
        :rtype: System.String
        :return: A simple display string for the model.
    
        
        .. code-block:: csharp
    
            public static string GetSimpleDisplayText(this ModelExplorer modelExplorer)
    

