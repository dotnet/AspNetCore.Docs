

TagHelperContentWrapperTextWriter Class
=======================================



.. contents:: 
   :local:



Summary
-------

:any:`System.IO.TextWriter` implementation which writes to a :any:`Microsoft.AspNet.Razor.TagHelpers.TagHelperContent` instance.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.MarshalByRefObject`
* :dn:cls:`System.IO.TextWriter`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.TagHelperContentWrapperTextWriter`








Syntax
------

.. code-block:: csharp

   public class TagHelperContentWrapperTextWriter : TextWriter, IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Razor/TagHelperContentWrapperTextWriter.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.TagHelperContentWrapperTextWriter

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.TagHelperContentWrapperTextWriter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Razor.TagHelperContentWrapperTextWriter.TagHelperContentWrapperTextWriter(System.Text.Encoding)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Mvc.Razor.TagHelperContentWrapperTextWriter` class.
    
        
        
        
        :param encoding: The  in which output is written.
        
        :type encoding: System.Text.Encoding
    
        
        .. code-block:: csharp
    
           public TagHelperContentWrapperTextWriter(Encoding encoding)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Razor.TagHelperContentWrapperTextWriter.TagHelperContentWrapperTextWriter(System.Text.Encoding, Microsoft.AspNet.Razor.TagHelpers.TagHelperContent)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Mvc.Razor.TagHelperContentWrapperTextWriter` class.
    
        
        
        
        :param encoding: The  in which output is written.
        
        :type encoding: System.Text.Encoding
        
        
        :param content: The  to write to.
        
        :type content: Microsoft.AspNet.Razor.TagHelpers.TagHelperContent
    
        
        .. code-block:: csharp
    
           public TagHelperContentWrapperTextWriter(Encoding encoding, TagHelperContent content)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.TagHelperContentWrapperTextWriter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.TagHelperContentWrapperTextWriter.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string ToString()
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.TagHelperContentWrapperTextWriter.Write(System.Char)
    
        
        
        
        :type value: System.Char
    
        
        .. code-block:: csharp
    
           public override void Write(char value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.TagHelperContentWrapperTextWriter.Write(System.String)
    
        
        
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
           public override void Write(string value)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.TagHelperContentWrapperTextWriter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.TagHelperContentWrapperTextWriter.Content
    
        
    
        The :any:`Microsoft.AspNet.Razor.TagHelpers.TagHelperContent` this :any:`Microsoft.AspNet.Mvc.Razor.TagHelperContentWrapperTextWriter` writes to.
    
        
        :rtype: Microsoft.AspNet.Razor.TagHelpers.TagHelperContent
    
        
        .. code-block:: csharp
    
           public TagHelperContent Content { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.TagHelperContentWrapperTextWriter.Encoding
    
        
        :rtype: System.Text.Encoding
    
        
        .. code-block:: csharp
    
           public override Encoding Encoding { get; }
    

