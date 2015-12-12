

OutputElementHintAttribute Class
================================



.. contents:: 
   :local:



Summary
-------

Provides a hint of the :any:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper`\'s output element.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNet.Razor.TagHelpers.OutputElementHintAttribute`








Syntax
------

.. code-block:: csharp

   public sealed class OutputElementHintAttribute : Attribute, _Attribute





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor.Runtime/TagHelpers/OutputElementHintAttribute.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.TagHelpers.OutputElementHintAttribute

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.TagHelpers.OutputElementHintAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.TagHelpers.OutputElementHintAttribute.OutputElementHintAttribute(System.String)
    
        
    
        Instantiates a new instance of the :any:`Microsoft.AspNet.Razor.TagHelpers.OutputElementHintAttribute` class.
    
        
        
        
        :param outputElement: The HTML element the  may output.
        
        :type outputElement: System.String
    
        
        .. code-block:: csharp
    
           public OutputElementHintAttribute(string outputElement)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.TagHelpers.OutputElementHintAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.TagHelpers.OutputElementHintAttribute.OutputElement
    
        
    
        The HTML element the :any:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper` may output.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string OutputElement { get; }
    

