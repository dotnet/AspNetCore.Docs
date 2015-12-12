

FormattedLogValues Class
========================



.. contents:: 
   :local:



Summary
-------

LogValues to enable formatting options supported by :dn:meth:`System.String.Format(System.String,System.Object)`\.
This also enables using {NamedformatItem} in the format string.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Logging.Internal.FormattedLogValues`








Syntax
------

.. code-block:: csharp

   public class FormattedLogValues : ILogValues





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/logging/src/Microsoft.Extensions.Logging.Abstractions/Internal/FormattedLogValues.cs>`_





.. dn:class:: Microsoft.Extensions.Logging.Internal.FormattedLogValues

Constructors
------------

.. dn:class:: Microsoft.Extensions.Logging.Internal.FormattedLogValues
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Logging.Internal.FormattedLogValues.FormattedLogValues(System.String, System.Object[])
    
        
        
        
        :type format: System.String
        
        
        :type values: System.Object[]
    
        
        .. code-block:: csharp
    
           public FormattedLogValues(string format, params object[] values)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Logging.Internal.FormattedLogValues
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.Internal.FormattedLogValues.GetValues()
    
        
        :rtype: System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{System.String,System.Object}}
    
        
        .. code-block:: csharp
    
           public IEnumerable<KeyValuePair<string, object>> GetValues()
    
    .. dn:method:: Microsoft.Extensions.Logging.Internal.FormattedLogValues.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string ToString()
    

