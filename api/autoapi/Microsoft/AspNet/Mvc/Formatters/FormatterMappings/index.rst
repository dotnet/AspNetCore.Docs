

FormatterMappings Class
=======================



.. contents:: 
   :local:



Summary
-------

Used to specify mapping between the URL Format and corresponding :any:`Microsoft.Net.Http.Headers.MediaTypeHeaderValue`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Formatters.FormatterMappings`








Syntax
------

.. code-block:: csharp

   public class FormatterMappings





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/Formatters/FormatterMappings.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Formatters.FormatterMappings

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.FormatterMappings
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.FormatterMappings.ClearMediaTypeMappingForFormat(System.String)
    
        
    
        Clears the :any:`Microsoft.Net.Http.Headers.MediaTypeHeaderValue` mapping for the format.
    
        
        
        
        :param format: The format value.
        
        :type format: System.String
        :rtype: System.Boolean
        :return: <c>true</c> if the format is successfully found and cleared; otherwise, <c>false</c>.
    
        
        .. code-block:: csharp
    
           public bool ClearMediaTypeMappingForFormat(string format)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.FormatterMappings.GetMediaTypeMappingForFormat(System.String)
    
        
    
        Gets :any:`Microsoft.Net.Http.Headers.MediaTypeHeaderValue` for the specified format.
    
        
        
        
        :param format: The format value.
        
        :type format: System.String
        :rtype: Microsoft.Net.Http.Headers.MediaTypeHeaderValue
        :return: The <see cref="T:Microsoft.Net.Http.Headers.MediaTypeHeaderValue" /> for input format.
    
        
        .. code-block:: csharp
    
           public MediaTypeHeaderValue GetMediaTypeMappingForFormat(string format)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.FormatterMappings.SetMediaTypeMappingForFormat(System.String, Microsoft.Net.Http.Headers.MediaTypeHeaderValue)
    
        
    
        Sets mapping for the format to specified :any:`Microsoft.Net.Http.Headers.MediaTypeHeaderValue`\.
        If the format already exists, the :any:`Microsoft.Net.Http.Headers.MediaTypeHeaderValue` will be overwritten with the new value.
    
        
        
        
        :param format: The format value.
        
        :type format: System.String
        
        
        :param contentType: The  for the format value.
        
        :type contentType: Microsoft.Net.Http.Headers.MediaTypeHeaderValue
    
        
        .. code-block:: csharp
    
           public void SetMediaTypeMappingForFormat(string format, MediaTypeHeaderValue contentType)
    

