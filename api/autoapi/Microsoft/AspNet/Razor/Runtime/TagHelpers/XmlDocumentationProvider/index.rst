

XmlDocumentationProvider Class
==============================



.. contents:: 
   :local:



Summary
-------

Extracts summary and remarks XML documentation from an XML documentation file.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Runtime.TagHelpers.XmlDocumentationProvider`








Syntax
------

.. code-block:: csharp

   public class XmlDocumentationProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor.Runtime/Runtime/TagHelpers/XmlDocumentationProvider.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Runtime.TagHelpers.XmlDocumentationProvider

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Runtime.TagHelpers.XmlDocumentationProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Runtime.TagHelpers.XmlDocumentationProvider.XmlDocumentationProvider(System.String)
    
        
    
        Instantiates a new instance of the :any:`Microsoft.AspNet.Razor.Runtime.TagHelpers.XmlDocumentationProvider`\.
    
        
        
        
        :param xmlFileLocation: Path to the XML documentation file to read.
        
        :type xmlFileLocation: System.String
    
        
        .. code-block:: csharp
    
           public XmlDocumentationProvider(string xmlFileLocation)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Runtime.TagHelpers.XmlDocumentationProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Runtime.TagHelpers.XmlDocumentationProvider.GetId(System.Reflection.PropertyInfo)
    
        
    
        Generates the :any:`System.String` identifier for the given ``propertyInfo``.
    
        
        
        
        :param propertyInfo: The  to get the identifier for.
        
        :type propertyInfo: System.Reflection.PropertyInfo
        :rtype: System.String
        :return: The <see cref="T:System.String" /> identifier for the given <paramref name="propertyInfo" />.
    
        
        .. code-block:: csharp
    
           public static string GetId(PropertyInfo propertyInfo)
    
    .. dn:method:: Microsoft.AspNet.Razor.Runtime.TagHelpers.XmlDocumentationProvider.GetId(System.Type)
    
        
    
        Generates the :any:`System.String` identifier for the given ``type``.
    
        
        
        
        :param type: The  to get the identifier for.
        
        :type type: System.Type
        :rtype: System.String
        :return: The <see cref="T:System.String" /> identifier for the given <paramref name="type" />.
    
        
        .. code-block:: csharp
    
           public static string GetId(Type type)
    
    .. dn:method:: Microsoft.AspNet.Razor.Runtime.TagHelpers.XmlDocumentationProvider.GetRemarks(System.String)
    
        
    
        Retrieves the <c>&lt;remarks&gt;</c> documentation for the given ``id``.
    
        
        
        
        :param id: The id to lookup.
        
        :type id: System.String
        :rtype: System.String
        :return: <c>&lt;remarks&gt;</c> documentation for the given <paramref name="id" />.
    
        
        .. code-block:: csharp
    
           public string GetRemarks(string id)
    
    .. dn:method:: Microsoft.AspNet.Razor.Runtime.TagHelpers.XmlDocumentationProvider.GetSummary(System.String)
    
        
    
        Retrieves the <c>&lt;summary&gt;</c> documentation for the given ``id``.
    
        
        
        
        :param id: The id to lookup.
        
        :type id: System.String
        :rtype: System.String
        :return: <c>&lt;summary&gt;</c> documentation for the given <paramref name="id" />.
    
        
        .. code-block:: csharp
    
           public string GetSummary(string id)
    

