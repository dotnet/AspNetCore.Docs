

HelperResult Class
==================



.. contents:: 
   :local:



Summary
-------

Represents a deferred write operation in a :any:`Microsoft.AspNet.Diagnostics.Views.BaseView`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Diagnostics.Views.HelperResult`








Syntax
------

.. code-block:: csharp

   public class HelperResult





GitHub
------

`View on GitHub <https://github.com/aspnet/diagnostics/blob/master/src/Microsoft.AspNet.Diagnostics/Views/HelperResult.cs>`_





.. dn:class:: Microsoft.AspNet.Diagnostics.Views.HelperResult

Constructors
------------

.. dn:class:: Microsoft.AspNet.Diagnostics.Views.HelperResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Diagnostics.Views.HelperResult.HelperResult(System.Action<System.IO.TextWriter>)
    
        
    
        Creates a new instance of :any:`Microsoft.AspNet.Diagnostics.Views.HelperResult`\.
    
        
        
        
        :param action: The delegate to invoke when  is called.
        
        :type action: System.Action{System.IO.TextWriter}
    
        
        .. code-block:: csharp
    
           public HelperResult(Action<TextWriter> action)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Diagnostics.Views.HelperResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Diagnostics.Views.HelperResult.WriteTo(System.IO.TextWriter)
    
        
    
        Method invoked to produce content from the :any:`Microsoft.AspNet.Diagnostics.Views.HelperResult`\.
    
        
        
        
        :param writer: The  instance to write to.
        
        :type writer: System.IO.TextWriter
    
        
        .. code-block:: csharp
    
           public void WriteTo(TextWriter writer)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Diagnostics.Views.HelperResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Views.HelperResult.WriteAction
    
        
        :rtype: System.Action{System.IO.TextWriter}
    
        
        .. code-block:: csharp
    
           public Action<TextWriter> WriteAction { get; }
    

