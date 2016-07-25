

ModeAttributes<TMode> Class
===========================






A mapping of a :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper` mode to its required attributes.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.TagHelpers.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.TagHelpers

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.TagHelpers.Internal.ModeAttributes\<TMode>`








Syntax
------

.. code-block:: csharp

    public class ModeAttributes<TMode>








.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.Internal.ModeAttributes`1
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.Internal.ModeAttributes<TMode>

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.Internal.ModeAttributes<TMode>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.TagHelpers.Internal.ModeAttributes<TMode>.ModeAttributes(TMode, System.String[])
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.TagHelpers.Internal.ModeAttributes\`1`\.
    
        
    
        
        :param mode: The :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper`\'s mode.
        
        :type mode: TMode
    
        
        :param attributes: The names of attributes required for this mode.
        
        :type attributes: System.String<System.String>[]
    
        
        .. code-block:: csharp
    
            public ModeAttributes(TMode mode, string[] attributes)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.Internal.ModeAttributes<TMode>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.Internal.ModeAttributes<TMode>.Attributes
    
        
    
        
        Gets the names of attributes required for this mode.
    
        
        :rtype: System.String<System.String>[]
    
        
        .. code-block:: csharp
    
            public string[] Attributes { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.Internal.ModeAttributes<TMode>.Mode
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper`\'s mode.
    
        
        :rtype: TMode
    
        
        .. code-block:: csharp
    
            public TMode Mode { get; }
    

