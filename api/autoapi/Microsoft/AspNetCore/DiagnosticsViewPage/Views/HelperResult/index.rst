

HelperResult Class
==================






Represents a deferred write operation in a :any:`Microsoft.AspNetCore.DiagnosticsViewPage.Views.BaseView`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.DiagnosticsViewPage.Views`
Assemblies
    * Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.DiagnosticsViewPage.Views.HelperResult`








Syntax
------

.. code-block:: csharp

    public class HelperResult








.. dn:class:: Microsoft.AspNetCore.DiagnosticsViewPage.Views.HelperResult
    :hidden:

.. dn:class:: Microsoft.AspNetCore.DiagnosticsViewPage.Views.HelperResult

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.DiagnosticsViewPage.Views.HelperResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.DiagnosticsViewPage.Views.HelperResult.HelperResult(System.Action<System.IO.TextWriter>)
    
        
    
        
        Creates a new instance of :any:`Microsoft.AspNetCore.DiagnosticsViewPage.Views.HelperResult`\.
    
        
    
        
        :param action: The delegate to invoke when :dn:meth:`Microsoft.AspNetCore.DiagnosticsViewPage.Views.HelperResult.WriteTo(System.IO.TextWriter)` is called.
        
        :type action: System.Action<System.Action`1>{System.IO.TextWriter<System.IO.TextWriter>}
    
        
        .. code-block:: csharp
    
            public HelperResult(Action<TextWriter> action)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.DiagnosticsViewPage.Views.HelperResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.DiagnosticsViewPage.Views.HelperResult.WriteAction
    
        
        :rtype: System.Action<System.Action`1>{System.IO.TextWriter<System.IO.TextWriter>}
    
        
        .. code-block:: csharp
    
            public Action<TextWriter> WriteAction { get; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.DiagnosticsViewPage.Views.HelperResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.DiagnosticsViewPage.Views.HelperResult.WriteTo(System.IO.TextWriter)
    
        
    
        
        Method invoked to produce content from the :any:`Microsoft.AspNetCore.DiagnosticsViewPage.Views.HelperResult`\.
    
        
    
        
        :param writer: The :any:`System.IO.TextWriter` instance to write to.
        
        :type writer: System.IO.TextWriter
    
        
        .. code-block:: csharp
    
            public void WriteTo(TextWriter writer)
    

