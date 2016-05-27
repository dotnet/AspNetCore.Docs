

MvcForm Class
=============






An HTML form element in an MVC view.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Rendering`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Rendering.MvcForm`








Syntax
------

.. code-block:: csharp

    public class MvcForm : IDisposable








.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.MvcForm
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.MvcForm

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.MvcForm
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Rendering.MvcForm.MvcForm(Microsoft.AspNetCore.Mvc.Rendering.ViewContext, System.Text.Encodings.Web.HtmlEncoder)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.Rendering.MvcForm`\.
    
        
    
        
        :param viewContext: The :any:`Microsoft.AspNetCore.Mvc.Rendering.ViewContext`\.
        
        :type viewContext: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        :param htmlEncoder: The :any:`System.Text.Encodings.Web.HtmlEncoder`\.
        
        :type htmlEncoder: System.Text.Encodings.Web.HtmlEncoder
    
        
        .. code-block:: csharp
    
            public MvcForm(ViewContext viewContext, HtmlEncoder htmlEncoder)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Rendering.MvcForm
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.MvcForm.Dispose()
    
        
    
        
        .. code-block:: csharp
    
            public void Dispose()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.MvcForm.EndForm()
    
        
    
        
        Renders the </form> end tag to the response.
    
        
    
        
        .. code-block:: csharp
    
            public void EndForm()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.MvcForm.GenerateEndForm()
    
        
    
        
        Renders :dn:prop:`Microsoft.AspNetCore.Mvc.ViewFeatures.FormContext.EndOfFormContent` and
        the </form>.
    
        
    
        
        .. code-block:: csharp
    
            protected virtual void GenerateEndForm()
    

