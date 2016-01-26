

PropertiesDataFormat Class
==========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.SecureDataFormat{Microsoft.AspNet.Http.Authentication.AuthenticationProperties}`
* :dn:cls:`Microsoft.AspNet.Authentication.PropertiesDataFormat`








Syntax
------

.. code-block:: csharp

   public class PropertiesDataFormat : SecureDataFormat<AuthenticationProperties>, ISecureDataFormat<AuthenticationProperties>





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authentication/DataHandler/PropertiesDataFormat.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.PropertiesDataFormat

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authentication.PropertiesDataFormat
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authentication.PropertiesDataFormat.PropertiesDataFormat(Microsoft.AspNet.DataProtection.IDataProtector)
    
        
        
        
        :type protector: Microsoft.AspNet.DataProtection.IDataProtector
    
        
        .. code-block:: csharp
    
           public PropertiesDataFormat(IDataProtector protector)
    

