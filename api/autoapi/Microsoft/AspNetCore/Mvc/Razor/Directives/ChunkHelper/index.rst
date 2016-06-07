

ChunkHelper Class
=================






Contains helper methods for dealing with Chunks


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Razor.Directives`
Assemblies
    * Microsoft.AspNetCore.Mvc.Razor.Host

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Razor.Directives.ChunkHelper`








Syntax
------

.. code-block:: csharp

    public class ChunkHelper








.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Directives.ChunkHelper
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Directives.ChunkHelper

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Directives.ChunkHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.Directives.ChunkHelper.GetModelChunk(Microsoft.AspNetCore.Razor.Chunks.ChunkTree)
    
        
    
        
        Returns the :any:`Microsoft.AspNetCore.Mvc.Razor.ModelChunk` used to determine the model name for the page generated
        using the specified <em>chunkTree</em>
    
        
    
        
        :param chunkTree: The :any:`Microsoft.AspNetCore.Razor.Chunks.ChunkTree` to scan for :any:`Microsoft.AspNetCore.Mvc.Razor.ModelChunk`\s in.
        
        :type chunkTree: Microsoft.AspNetCore.Razor.Chunks.ChunkTree
        :rtype: Microsoft.AspNetCore.Mvc.Razor.ModelChunk
        :return: The last :any:`Microsoft.AspNetCore.Mvc.Razor.ModelChunk` in the :any:`Microsoft.AspNetCore.Razor.Chunks.ChunkTree` if found, <code>null</code> otherwise.
            
    
        
        .. code-block:: csharp
    
            public static ModelChunk GetModelChunk(ChunkTree chunkTree)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.Directives.ChunkHelper.GetModelTypeName(Microsoft.AspNetCore.Razor.Chunks.ChunkTree, System.String)
    
        
    
        
        Returns the type name of the Model specified via a :any:`Microsoft.AspNetCore.Mvc.Razor.ModelChunk` in the
        <em>chunkTree</em> if specified or the default model type.
    
        
    
        
        :param chunkTree: The :any:`Microsoft.AspNetCore.Razor.Chunks.ChunkTree` to scan for :any:`Microsoft.AspNetCore.Mvc.Razor.ModelChunk`\s in.
        
        :type chunkTree: Microsoft.AspNetCore.Razor.Chunks.ChunkTree
    
        
        :param defaultModelName: The :any:`System.Type` name of the default model.
        
        :type defaultModelName: System.String
        :rtype: System.String
        :return: The model type name for the generated page.
    
        
        .. code-block:: csharp
    
            public static string GetModelTypeName(ChunkTree chunkTree, string defaultModelName)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.Directives.ChunkHelper.ReplaceTModel(System.String, System.String)
    
        
    
        
        Returns a string with the <TModel> token replaced with the value specified in
        <em>modelName</em>.
    
        
    
        
        :param value: The string to replace the token in.
        
        :type value: System.String
    
        
        :param modelName: The model name to replace with.
        
        :type modelName: System.String
        :rtype: System.String
        :return: A string with the token replaced.
    
        
        .. code-block:: csharp
    
            public static string ReplaceTModel(string value, string modelName)
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Directives.ChunkHelper
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Mvc.Razor.Directives.ChunkHelper.TModelToken
    
        
    
        
        Token that is replaced by the model name in <code>@inherits</code> and <code>@inject</code>
        chunks as part of :any:`Microsoft.AspNetCore.Mvc.Razor.Directives.ChunkInheritanceUtility`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static readonly string TModelToken
    

