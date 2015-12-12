

ViewDataEvaluator Class
=======================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ViewFeatures.ViewDataEvaluator`








Syntax
------

.. code-block:: csharp

   public class ViewDataEvaluator





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewFeatures/ViewDataEvaluator.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataEvaluator

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataEvaluator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataEvaluator.Eval(Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary, System.String)
    
        
    
        Gets :any:`Microsoft.AspNet.Mvc.ViewFeatures.ViewDataInfo` for named ``expression`` in given
        ``viewData``.
    
        
        
        
        :param viewData: The  that may contain the  value.
        
        :type viewData: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary
        
        
        :param expression: Expression name, relative to viewData.Model.
        
        :type expression: System.String
        :rtype: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataInfo
        :return: <see cref="T:Microsoft.AspNet.Mvc.ViewFeatures.ViewDataInfo" /> for named <paramref name="expression" /> in given <paramref name="viewData" />.
    
        
        .. code-block:: csharp
    
           public static ViewDataInfo Eval(ViewDataDictionary viewData, string expression)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataEvaluator.Eval(System.Object, System.String)
    
        
    
        Gets :any:`Microsoft.AspNet.Mvc.ViewFeatures.ViewDataInfo` for named ``expression`` in given
        ``indexableObject``.
    
        
        
        
        :param indexableObject: The  that may contain the  value.
        
        :type indexableObject: System.Object
        
        
        :param expression: Expression name, relative to .
        
        :type expression: System.String
        :rtype: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataInfo
        :return: <see cref="T:Microsoft.AspNet.Mvc.ViewFeatures.ViewDataInfo" /> for named <paramref name="expression" /> in given
            <paramref name="indexableObject" />.
    
        
        .. code-block:: csharp
    
           public static ViewDataInfo Eval(object indexableObject, string expression)
    

