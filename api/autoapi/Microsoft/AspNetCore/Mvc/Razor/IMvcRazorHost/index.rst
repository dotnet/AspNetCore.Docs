

IMvcRazorHost Interface
=======================






Specifies the contracts for a Razor host that parses Razor files and generates C# code.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Razor`
Assemblies
    * Microsoft.AspNetCore.Mvc.Razor.Host

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IMvcRazorHost








.. dn:interface:: Microsoft.AspNetCore.Mvc.Razor.IMvcRazorHost
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Razor.IMvcRazorHost

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Razor.IMvcRazorHost
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.IMvcRazorHost.DefaultNamespace
    
        
    
        
        Represent the namespace the main entry class in the view.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string DefaultNamespace { get; }
    

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Razor.IMvcRazorHost
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.IMvcRazorHost.GenerateCode(System.String, System.IO.Stream)
    
        
    
        
        Parses and generates the contents of a Razor file represented by <em>inputStream</em>.
    
        
    
        
        :param rootRelativePath: The path of the relative to the root of the application.
            Used to generate line pragmas and calculate the class name of the generated type.
        
        :type rootRelativePath: System.String
    
        
        :param inputStream: A :any:`System.IO.Stream` that represents the Razor contents.
        
        :type inputStream: System.IO.Stream
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratorResults
        :return: A :any:`Microsoft.AspNetCore.Razor.CodeGenerators.GeneratorResults` instance that represents the results of code generation.
    
        
        .. code-block:: csharp
    
            GeneratorResults GenerateCode(string rootRelativePath, Stream inputStream)
    

