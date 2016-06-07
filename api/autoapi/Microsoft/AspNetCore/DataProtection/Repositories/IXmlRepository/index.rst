

IXmlRepository Interface
========================






The basic interface for storing and retrieving XML elements.


Namespace
    :dn:ns:`Microsoft.AspNetCore.DataProtection.Repositories`
Assemblies
    * Microsoft.AspNetCore.DataProtection

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IXmlRepository








.. dn:interface:: Microsoft.AspNetCore.DataProtection.Repositories.IXmlRepository
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.DataProtection.Repositories.IXmlRepository

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.DataProtection.Repositories.IXmlRepository
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.Repositories.IXmlRepository.GetAllElements()
    
        
    
        
        Gets all top-level XML elements in the repository.
    
        
        :rtype: System.Collections.Generic.IReadOnlyCollection<System.Collections.Generic.IReadOnlyCollection`1>{System.Xml.Linq.XElement<System.Xml.Linq.XElement>}
    
        
        .. code-block:: csharp
    
            IReadOnlyCollection<XElement> GetAllElements()
    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.Repositories.IXmlRepository.StoreElement(System.Xml.Linq.XElement, System.String)
    
        
    
        
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
    

