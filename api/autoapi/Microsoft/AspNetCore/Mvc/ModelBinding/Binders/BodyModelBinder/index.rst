

BodyModelBinder Class
=====================






An :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder` which binds models from the request body using an :any:`Microsoft.AspNetCore.Mvc.Formatters.IInputFormatter`
when a model has the binding source :dn:field:`Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource.Body`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ModelBinding.Binders`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.Binders.BodyModelBinder`








Syntax
------

.. code-block:: csharp

    public class BodyModelBinder : IModelBinder








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.BodyModelBinder
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.BodyModelBinder

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.BodyModelBinder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.BodyModelBinder.BodyModelBinder(System.Collections.Generic.IList<Microsoft.AspNetCore.Mvc.Formatters.IInputFormatter>, Microsoft.AspNetCore.Mvc.Internal.IHttpRequestStreamReaderFactory)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Binders.BodyModelBinder`\.
    
        
    
        
        :param formatters: The list of :any:`Microsoft.AspNetCore.Mvc.Formatters.IInputFormatter`\.
        
        :type formatters: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.Formatters.IInputFormatter<Microsoft.AspNetCore.Mvc.Formatters.IInputFormatter>}
    
        
        :param readerFactory: 
            The :any:`Microsoft.AspNetCore.Mvc.Internal.IHttpRequestStreamReaderFactory`\, used to create :any:`System.IO.TextReader`
            instances for reading the request body.
        
        :type readerFactory: Microsoft.AspNetCore.Mvc.Internal.IHttpRequestStreamReaderFactory
    
        
        .. code-block:: csharp
    
            public BodyModelBinder(IList<IInputFormatter> formatters, IHttpRequestStreamReaderFactory readerFactory)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.BodyModelBinder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.BodyModelBinder.BindModelAsync(Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext)
    
        
    
        
        :type bindingContext: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task BindModelAsync(ModelBindingContext bindingContext)
    

