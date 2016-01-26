

TemplateInfo Class
==================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ViewFeatures.TemplateInfo`








Syntax
------

.. code-block:: csharp

   public class TemplateInfo





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewFeatures/TemplateInfo.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.TemplateInfo

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.TemplateInfo
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ViewFeatures.TemplateInfo.TemplateInfo()
    
        
    
        
        .. code-block:: csharp
    
           public TemplateInfo()
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ViewFeatures.TemplateInfo.TemplateInfo(Microsoft.AspNet.Mvc.ViewFeatures.TemplateInfo)
    
        
        
        
        :type original: Microsoft.AspNet.Mvc.ViewFeatures.TemplateInfo
    
        
        .. code-block:: csharp
    
           public TemplateInfo(TemplateInfo original)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.TemplateInfo
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.TemplateInfo.AddVisited(System.Object)
    
        
        
        
        :type value: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool AddVisited(object value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.TemplateInfo.GetFullHtmlFieldName(System.String)
    
        
        
        
        :type partialFieldName: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string GetFullHtmlFieldName(string partialFieldName)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.TemplateInfo.Visited(Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer)
    
        
        
        
        :type modelExplorer: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Visited(ModelExplorer modelExplorer)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.TemplateInfo
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewFeatures.TemplateInfo.FormattedModelValue
    
        
    
        Gets or sets the formatted model value.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public object FormattedModelValue { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewFeatures.TemplateInfo.HtmlFieldPrefix
    
        
    
        Gets or sets the HTML field prefix.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string HtmlFieldPrefix { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewFeatures.TemplateInfo.TemplateDepth
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int TemplateDepth { get; }
    

