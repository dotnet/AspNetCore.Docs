

TagHelperDescriptorFactory Class
================================



.. contents:: 
   :local:



Summary
-------

Factory for :any:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s from :any:`Microsoft.AspNet.Razor.Runtime.TagHelpers.ITypeInfo`\s.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperDescriptorFactory`








Syntax
------

.. code-block:: csharp

   public class TagHelperDescriptorFactory





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor.Runtime/Runtime/TagHelpers/TagHelperDescriptorFactory.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperDescriptorFactory

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperDescriptorFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperDescriptorFactory.CreateDescriptors(System.String, Microsoft.AspNet.Razor.Runtime.TagHelpers.ITypeInfo, System.Boolean, Microsoft.AspNet.Razor.ErrorSink)
    
        
    
        Creates a :any:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor` from the given ``typeInfo``.
    
        
        
        
        :param assemblyName: The assembly name that contains .
        
        :type assemblyName: System.String
        
        
        :param typeInfo: The  to create a  from.
        
        :type typeInfo: Microsoft.AspNet.Razor.Runtime.TagHelpers.ITypeInfo
        
        
        :param designTime: Indicates if the returned s should include
            design time specific information.
        
        :type designTime: System.Boolean
        
        
        :param errorSink: The  used to collect s encountered
            when creating s for the given .
        
        :type errorSink: Microsoft.AspNet.Razor.ErrorSink
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor}
        :return: A collection of <see cref="T:Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor" />s that describe the given <paramref name="typeInfo" />.
    
        
        .. code-block:: csharp
    
           public static IEnumerable<TagHelperDescriptor> CreateDescriptors(string assemblyName, ITypeInfo typeInfo, bool designTime, ErrorSink errorSink)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperDescriptorFactory
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperDescriptorFactory.InvalidNonWhitespaceNameCharacters
    
        
        :rtype: System.Collections.Generic.ICollection{System.Char}
    
        
        .. code-block:: csharp
    
           public static ICollection<char> InvalidNonWhitespaceNameCharacters { get; }
    

