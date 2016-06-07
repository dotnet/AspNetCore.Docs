

FormatterMappings Class
=======================






Used to specify mapping between the URL Format and corresponding media type.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Formatters`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Formatters.FormatterMappings`








Syntax
------

.. code-block:: csharp

    public class FormatterMappings








.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.FormatterMappings
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.FormatterMappings

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.FormatterMappings
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.FormatterMappings.ClearMediaTypeMappingForFormat(System.String)
    
        
    
        
        Clears the media type mapping for the format.
    
        
    
        
        :param format: The format value.
        
        :type format: System.String
        :rtype: System.Boolean
        :return: <code>true</code> if the format is successfully found and cleared; otherwise, <code>false</code>.
    
        
        .. code-block:: csharp
    
            public bool ClearMediaTypeMappingForFormat(string format)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.FormatterMappings.GetMediaTypeMappingForFormat(System.String)
    
        
    
        
        Gets the media type for the specified format.
    
        
    
        
        :param format: The format value.
        
        :type format: System.String
        :rtype: System.String
        :return: The media type for input format.
    
        
        .. code-block:: csharp
    
            public string GetMediaTypeMappingForFormat(string format)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.FormatterMappings.SetMediaTypeMappingForFormat(System.String, Microsoft.Net.Http.Headers.MediaTypeHeaderValue)
    
        
    
        
        Sets mapping for the format to specified media type. 
        If the format already exists, the media type will be overwritten with the new value.
    
        
    
        
        :param format: The format value.
        
        :type format: System.String
    
        
        :param contentType: The media type for the format value.
        
        :type contentType: Microsoft.Net.Http.Headers.MediaTypeHeaderValue
    
        
        .. code-block:: csharp
    
            public void SetMediaTypeMappingForFormat(string format, MediaTypeHeaderValue contentType)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.FormatterMappings.SetMediaTypeMappingForFormat(System.String, System.String)
    
        
    
        
        Sets mapping for the format to specified media type. 
        If the format already exists, the media type will be overwritten with the new value.
    
        
    
        
        :param format: The format value.
        
        :type format: System.String
    
        
        :param contentType: The media type for the format value.
        
        :type contentType: System.String
    
        
        .. code-block:: csharp
    
            public void SetMediaTypeMappingForFormat(string format, string contentType)
    

