

HtmlFormattableString Class
===========================






An :any:`Microsoft.AspNetCore.Html.IHtmlContent` implementation of composite string formatting 
(see https://msdn.microsoft.com/en-us/library/txafckwd(v=vs.110).aspx) which HTML encodes
formatted arguments.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Html`
Assemblies
    * Microsoft.AspNetCore.Html.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Html.HtmlFormattableString`








Syntax
------

.. code-block:: csharp

    [DebuggerDisplay("{DebuggerToString()}")]
    public class HtmlFormattableString : IHtmlContent








.. dn:class:: Microsoft.AspNetCore.Html.HtmlFormattableString
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Html.HtmlFormattableString

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Html.HtmlFormattableString
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Html.HtmlFormattableString.HtmlFormattableString(System.IFormatProvider, System.String, System.Object[])
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Html.HtmlFormattableString` with the given <em>formatProvider</em>,
        <em>format</em> and <em>args</em>.
    
        
    
        
        :param formatProvider: An object that provides culture-specific formatting information.
        
        :type formatProvider: System.IFormatProvider
    
        
        :param format: A composite format string.
        
        :type format: System.String
    
        
        :param args: An array that contains objects to format.
        
        :type args: System.Object<System.Object>[]
    
        
        .. code-block:: csharp
    
            public HtmlFormattableString(IFormatProvider formatProvider, string format, params object[] args)
    
    .. dn:constructor:: Microsoft.AspNetCore.Html.HtmlFormattableString.HtmlFormattableString(System.String, System.Object[])
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Html.HtmlFormattableString` with the given <em>format</em> and
        <em>args</em>.
    
        
    
        
        :param format: A composite format string.
        
        :type format: System.String
    
        
        :param args: An array that contains objects to format.
        
        :type args: System.Object<System.Object>[]
    
        
        .. code-block:: csharp
    
            public HtmlFormattableString(string format, params object[] args)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Html.HtmlFormattableString
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Html.HtmlFormattableString.WriteTo(System.IO.TextWriter, System.Text.Encodings.Web.HtmlEncoder)
    
        
    
        
        :type writer: System.IO.TextWriter
    
        
        :type encoder: System.Text.Encodings.Web.HtmlEncoder
    
        
        .. code-block:: csharp
    
            public void WriteTo(TextWriter writer, HtmlEncoder encoder)
    

