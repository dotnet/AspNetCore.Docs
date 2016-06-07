

ViewDataEvaluator Class
=======================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ViewFeatures`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataEvaluator`








Syntax
------

.. code-block:: csharp

    public class ViewDataEvaluator








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataEvaluator
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataEvaluator

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataEvaluator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataEvaluator.Eval(Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary, System.String)
    
        
    
        
        Gets :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataInfo` for named <em>expression</em> in given
        <em>viewData</em>.
    
        
    
        
        :param viewData: 
            The :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary` that may contain the <em>expression</em> value.
        
        :type viewData: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary
    
        
        :param expression: Expression name, relative to <code>viewData.Model</code>.
        
        :type expression: System.String
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataInfo
        :return: 
            :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataInfo` for named <em>expression</em> in given <em>viewData</em>.
    
        
        .. code-block:: csharp
    
            public static ViewDataInfo Eval(ViewDataDictionary viewData, string expression)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataEvaluator.Eval(System.Object, System.String)
    
        
    
        
        Gets :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataInfo` for named <em>expression</em> in given
        <em>indexableObject</em>.
    
        
    
        
        :param indexableObject: 
            The :any:`System.Object` that may contain the <em>expression</em> value.
        
        :type indexableObject: System.Object
    
        
        :param expression: Expression name, relative to <em>indexableObject</em>.
        
        :type expression: System.String
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataInfo
        :return: 
            :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataInfo` for named <em>expression</em> in given
            <em>indexableObject</em>.
    
        
        .. code-block:: csharp
    
            public static ViewDataInfo Eval(object indexableObject, string expression)
    

