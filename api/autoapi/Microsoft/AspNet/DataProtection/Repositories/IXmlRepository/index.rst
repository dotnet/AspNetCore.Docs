

IXmlRepository Interface
========================



.. contents:: 
   :local:



Summary
-------

The basic interface for storing and retrieving XML elements.











Syntax
------

.. code-block:: csharp

   public interface IXmlRepository





GitHub
------

`View on GitHub <https://github.com/aspnet/dataprotection/blob/master/src/Microsoft.AspNet.DataProtection/Repositories/IXmlRepository.cs>`_





.. dn:interface:: Microsoft.AspNet.DataProtection.Repositories.IXmlRepository

Methods
-------

.. dn:interface:: Microsoft.AspNet.DataProtection.Repositories.IXmlRepository
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.DataProtection.Repositories.IXmlRepository.GetAllElements()
    
        
    
        Gets all top-level XML elements in the repository.
    
        
        :rtype: System.Collections.Generic.IReadOnlyCollection{System.Xml.Linq.XElement}
    
        
        .. code-block:: csharp
    
           IReadOnlyCollection<XElement> GetAllElements()
    
    .. dn:method:: Microsoft.AspNet.DataProtection.Repositories.IXmlRepository.StoreElement(System.Xml.Linq.XElement, System.String)
    
        
    
        Adds a top-level XML element to the repository.
    
        
        
        
        :param element: The element to add.
        
        :type element: System.Xml.Linq.XElement
        
        
        :param friendlyName: An optional name to be associated with the XML element.
            For instance, if this repository stores XML files on disk, the friendly name may
            be used as part of the file name. Repository implementations are not required to
            observe this parameter even if it has been provided by the caller.
        
        :type friendlyName: System.String
    
        
        .. code-block:: csharp
    
           void StoreElement(XElement element, string friendlyName)
    

