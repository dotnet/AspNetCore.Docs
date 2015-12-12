

MvcForm Class
=============



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Rendering.MvcForm`








Syntax
------

.. code-block:: csharp

   public class MvcForm : IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ViewFeatures/Rendering/MvcForm.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Rendering.MvcForm

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Rendering.MvcForm
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Rendering.MvcForm.MvcForm(Microsoft.AspNet.Mvc.Rendering.ViewContext)
    
        
        
        
        :type viewContext: Microsoft.AspNet.Mvc.Rendering.ViewContext
    
        
        .. code-block:: csharp
    
           public MvcForm(ViewContext viewContext)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Rendering.MvcForm
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.MvcForm.Dispose()
    
        
    
        
        .. code-block:: csharp
    
           public void Dispose()
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.MvcForm.Dispose(System.Boolean)
    
        
        
        
        :type disposing: System.Boolean
    
        
        .. code-block:: csharp
    
           protected virtual void Dispose(bool disposing)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.MvcForm.EndForm()
    
        
    
        Renders the &lt;/form&gt; end tag to the response.
    
        
    
        
        .. code-block:: csharp
    
           public void EndForm()
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.MvcForm.GenerateEndForm()
    
        
    
        
        .. code-block:: csharp
    
           protected virtual void GenerateEndForm()
    

