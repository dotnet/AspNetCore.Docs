

OutputElementHintAttribute Class
================================






Provides a hint of the :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper`\'s output element.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.TagHelpers`
Assemblies
    * Microsoft.AspNetCore.Razor.Runtime

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNetCore.Razor.TagHelpers.OutputElementHintAttribute`








Syntax
------

.. code-block:: csharp

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class OutputElementHintAttribute : Attribute, _Attribute








.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.OutputElementHintAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.OutputElementHintAttribute

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.OutputElementHintAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.TagHelpers.OutputElementHintAttribute.OutputElementHintAttribute(System.String)
    
        
    
        
        Instantiates a new instance of the :any:`Microsoft.AspNetCore.Razor.TagHelpers.OutputElementHintAttribute` class.
    
        
    
        
        :param outputElement: 
            The HTML element the :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper` may output.
        
        :type outputElement: System.String
    
        
        .. code-block:: csharp
    
            public OutputElementHintAttribute(string outputElement)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.OutputElementHintAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.TagHelpers.OutputElementHintAttribute.OutputElement
    
        
    
        
        The HTML element the :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper` may output.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string OutputElement { get; }
    

