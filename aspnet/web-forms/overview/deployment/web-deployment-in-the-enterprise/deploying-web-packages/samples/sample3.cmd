msdeploy.exe 
-source:package='C:\Users\matt.FABRIKAM\Desktop\ContactManager-03\ContactManager\
 Publish\Out\_PublishedWebsites\ContactManager.Mvc_Package\ContactManager.Mvc.zip' -dest:auto,computerName='TESTWEB1.fabrikam.net', authtype='NTLM',
 includeAcls='False' 
-verb:sync 
-disableLink:AppPoolExtension 
-disableLink:ContentExtension 
-disableLink:CertificateExtension 
-setParamFile:"C:\Users\matt.FABRIKAM\Desktop\ContactManager-03\ContactManager\
 Publish\Out\_PublishedWebsites\ContactManager.Mvc_Package\
 ContactManager.Mvc.SetParameters.xml"