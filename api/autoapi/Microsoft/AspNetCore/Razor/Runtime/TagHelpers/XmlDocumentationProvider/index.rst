

XmlDocumentationProvider Class
==============================






Extracts summary and remarks XML documentation from an XML documentation file.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.Runtime.TagHelpers`
Assemblies
    * Microsoft.AspNetCore.Razor.Runtime

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.Runtime.TagHelpers.XmlDocumentationProvider`








Syntax
------

.. code-block:: csharp

    public class XmlDocumentationProvider








.. dn:class:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.XmlDocumentationProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.XmlDocumentationProvider

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.XmlDocumentationProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.XmlDocumentationProvider.XmlDocumentationProvider(System.String)
    
        
    
        
        Instantiates a new instance of the :any:`Microsoft.AspNetCore.Razor.Runtime.TagHelpers.XmlDocumentationProvider`\.
    
        
    
        
        :param xmlFileLocation: Path to the XML documentation file to read.
        
        :type xmlFileLocation: System.String
    
        
        .. code-block:: csharp
    
            public XmlDocumentationProvider(string xmlFileLocation)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.XmlDocumentationProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.XmlDocumentationProvider.GetId(System.Reflection.PropertyInfo)
    
        
    
        
        Generates the :any:`System.String` identifier for the given <em>propertyInfo</em>.
    
        
    
        
        :param propertyInfo: The :any:`System.Reflection.PropertyInfo` to get the identifier for.
        
        :type propertyInfo: System.Reflection.PropertyInfo
        :rtype: System.String
        :return: The :any:`System.String` identifier for the given <em>propertyInfo</em>.
    
        
        .. code-block:: csharp
    
            public static string GetId(PropertyInfo propertyInfo)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.XmlDocumentationProvider.GetId(System.Type)
    
        
    
        
        Generates the :any:`System.String` identifier for the given <em>type</em>.
    
        
    
        
        :param type: The :any:`System.Type` to get the identifier for.
        
        :type type: System.Type
        :rtype: System.String
        :return: The :any:`System.String` identifier for the given <em>type</em>.
    
        
        .. code-block:: csharp
    
            public static string GetId(Type type)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.XmlDocumentationProvider.GetRemarks(System.String)
    
        
    
        
        Retrieves the <code><remarks></code> documentation for the given <em>id</em>.
    
        
    
        
        :param id: The id to lookup.
        
        :type id: System.String
        :rtype: System.String
        :return: <code><remarks></code> documentation for the given <em>id</em>.
    
        
        .. code-block:: csharp
    
            public string GetRemarks(string id)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.XmlDocumentationProvider.GetSummary(System.String)
    
        
    
        
        Retrieves the <code><summary></code> documentation for the given <em>id</em>.
    
        
    
        
        :param id: The id to lookup.
        
        :type id: System.String
        :rtype: System.String
        :return: <code><summary></code> documentation for the given <em>id</em>.
    
        
        .. code-block:: csharp
    
            public string GetSummary(string id)
    

