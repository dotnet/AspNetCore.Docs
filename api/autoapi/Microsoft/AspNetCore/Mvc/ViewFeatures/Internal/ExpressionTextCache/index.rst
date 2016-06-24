

ExpressionTextCache Class
=========================






This class holds the cache for the expression text that is computed by ExpressionHelper.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ViewFeatures.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ExpressionTextCache`








Syntax
------

.. code-block:: csharp

    public class ExpressionTextCache








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ExpressionTextCache
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ExpressionTextCache

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ExpressionTextCache
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ExpressionTextCache.Entries
    
        
        :rtype: System.Collections.Concurrent.ConcurrentDictionary<System.Collections.Concurrent.ConcurrentDictionary`2>{System.Linq.Expressions.LambdaExpression<System.Linq.Expressions.LambdaExpression>, System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public ConcurrentDictionary<LambdaExpression, string> Entries { get; }
    

