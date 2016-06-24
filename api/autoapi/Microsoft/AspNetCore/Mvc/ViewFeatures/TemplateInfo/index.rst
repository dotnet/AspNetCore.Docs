

TemplateInfo Class
==================





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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewFeatures.TemplateInfo`








Syntax
------

.. code-block:: csharp

    public class TemplateInfo








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.TemplateInfo
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.TemplateInfo

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.TemplateInfo
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ViewFeatures.TemplateInfo.TemplateInfo()
    
        
    
        
        .. code-block:: csharp
    
            public TemplateInfo()
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ViewFeatures.TemplateInfo.TemplateInfo(Microsoft.AspNetCore.Mvc.ViewFeatures.TemplateInfo)
    
        
    
        
        :type original: Microsoft.AspNetCore.Mvc.ViewFeatures.TemplateInfo
    
        
        .. code-block:: csharp
    
            public TemplateInfo(TemplateInfo original)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.TemplateInfo
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.TemplateInfo.AddVisited(System.Object)
    
        
    
        
        :type value: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool AddVisited(object value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.TemplateInfo.GetFullHtmlFieldName(System.String)
    
        
    
        
        :type partialFieldName: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string GetFullHtmlFieldName(string partialFieldName)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.TemplateInfo.Visited(Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer)
    
        
    
        
        :type modelExplorer: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Visited(ModelExplorer modelExplorer)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.TemplateInfo
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.TemplateInfo.FormattedModelValue
    
        
    
        
        Gets or sets the formatted model value.
    
        
        :rtype: System.Object
        :return: The formatted model value.
    
        
        .. code-block:: csharp
    
            public object FormattedModelValue { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.TemplateInfo.HtmlFieldPrefix
    
        
    
        
        Gets or sets the HTML field prefix.
    
        
        :rtype: System.String
        :return: The HTML field prefix.
    
        
        .. code-block:: csharp
    
            public string HtmlFieldPrefix { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.TemplateInfo.TemplateDepth
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int TemplateDepth { get; }
    

