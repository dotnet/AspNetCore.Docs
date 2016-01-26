

IMvcRazorHost Interface
=======================



.. contents:: 
   :local:



Summary
-------

Specifies the contracts for a Razor host that parses Razor files and generates C# code.











Syntax
------

.. code-block:: csharp

   public interface IMvcRazorHost





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Razor.Host/IMvcRazorHost.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Razor.IMvcRazorHost

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.Razor.IMvcRazorHost
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.IMvcRazorHost.GenerateCode(System.String, System.IO.Stream)
    
        
    
        Parses and generates the contents of a Razor file represented by ``inputStream``.
    
        
        
        
        :param rootRelativePath: The path of the relative to the root of the application.
            Used to generate line pragmas and calculate the class name of the generated type.
        
        :type rootRelativePath: System.String
        
        
        :param inputStream: A  that represents the Razor contents.
        
        :type inputStream: System.IO.Stream
        :rtype: Microsoft.AspNet.Razor.CodeGenerators.GeneratorResults
        :return: A <see cref="T:Microsoft.AspNet.Razor.CodeGenerators.GeneratorResults" /> instance that represents the results of code generation.
    
        
        .. code-block:: csharp
    
           GeneratorResults GenerateCode(string rootRelativePath, Stream inputStream)
    

Properties
----------

.. dn:interface:: Microsoft.AspNet.Mvc.Razor.IMvcRazorHost
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.IMvcRazorHost.DefaultNamespace
    
        
    
        Represent the namespace the main entry class in the view.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string DefaultNamespace { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.IMvcRazorHost.MainClassNamePrefix
    
        
    
        Represent the prefix off the main entry class in the view.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string MainClassNamePrefix { get; }
    

