Publishing to IIS
=============================

By :ref:`Rick Anderson <pubIIS-author>`  | Updated : 21 May 2015

In this article:
	- `Publish from Visual Studio`_
	- `Xcopy to IIS Server`_
	- `Xcopy Alternative: MSDeploy (Web Deploy) to IIS Server`_
	- `Addition Resources`_
	
Publish from Visual Studio  
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
1. Create an ASP.NET 5 app. In this sample, I'll create a MVC 6 app using the **Web Site** template under **ASP.NET 5 Preview Templates**. If you're not using the ``web`` and ``gen`` commands in your development and production work flow, you can remove them from the *project.json* file.

.. code-block:: javascript

	"commands": {
		"web": "Microsoft.AspNet.Hosting --server Microsoft.AspNet.Server.WebListener --server.urls http://localhost:5000",
		"gen": "Microsoft.Framework.CodeGeneration"
	  },
  
With these commands in the *project.json* file, the publish folder will contain web and gen scripts. See `DNX Commands <http://docs.asp.net/en/latest/dnx/overview.html?highlight=command#dnx-concept-commands>`_ for more information.

2. In **Solution Explorer**, right-click on the project and select **Publish**.

.. image:: pubIIS/_static/p1.png

3. In the **Publish Web** dialog, on the **Profile** tab, select **File System**. 

.. image:: pubIIS/_static/fs.png

4. Enter a profile name. Click **Next**.
5. On the **Connection** tab you can change the publishing target path from the default *..\\..\\artifacts\\bin\\WebApp9\\Release\\Publish folder*. Click **Next**.
6. On the **Settings** tab you can select the configuration, target DNX version and publish options. Currently your deployment server must have .NET 4.5.1 or higher to use DNX core. We hope to have a native module in the future that will allow you to use DNX core in the app pool regardless of the full CLR. If you select **Precompile during publishing**, the *Publish\\approot\\src* directory and source files will not be created. If you don't check **Precompile during publishing**, your source files will be found in the  *Publish\\approot\\src* directory. Click **Next**.
7. The **Preview** tab shows you the publish path (by default, the same directory as the ".sln" solution file).

Xcopy to IIS Server
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

#. Navigate to the the publish folder (*..\\..\\artifacts\\bin\\WebApp9\\Release\\Publish folder* in this sample). 
#. Copy the **approot** and **wwwroot** directories to the target IIS server.
#. In IIS manager, configure the app with application path to the **wwwroot** path. You can click on **Browse *.80(http)** to see your deployed app in the browser. 

.. image:: pubIIS/_static/b8.png

Xcopy Alternative: MSDeploy (Web Deploy) to IIS Server
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

#. Confirm that you have included **Microsoft.AspNet.Server.IIS** in the project (or framework) dependencies of **project.json**.
#. Confirm the server has .NET Framework 4.5.1 installed.
#. Install the latest version of Web Deploy on the server and locally. This is most easily accomplished using the `Web Platform Installer <http://www.iis.net/learn/install/web-platform-installer/web-platform-installer-direct-downloads/>`_.
#. On the server, create the physical folder layout for the deployment consisting of two folders: Create a root level folder to hold all of the deployed assets. You will probably name the root folder with the same name you give to the website in IIS. Within the root folder, create a **wwwroot** folder. These two folders are all that are required when configuring for the initial deployment. The **approot** folder will be created by MSDeploy when you initially deploy the application, so there is no need to create it at the outset.
#. Create the website in the IIS Manager. Set the IIS physical path for the application to the **wwwroot** folder you created.
#. Note for 32-bit applications: Set **Enable 32-Bit Applications** to **True** in the Application Pool Advanced Settings.
#. Issue three MSDeploy commands in sequence: (1) Shutdown the AppPool, (2) Deploy the application, and (3) Start the AppPool. The purpose of killing the AppPool before deployment is to force IIS to release any file locks that it holds. Stopping/starting the AppPool must be performed every time you deploy to the server. These three commands will be issued for each server/VM where you are deploying. For Azure VM's, each VM will have a different port mapped to port 8172 in the Azure Cloud Service. Confirm that you've opened the firewall on each VM for traffic on 8172, as well.

.. code-block:: none

    "C:\Program Files (x86)\IIS\Microsoft Web Deploy V3\msdeploy.exe" -verb:sync -allowUntrusted -source:recycleApp -dest:recycleApp="IIS_SITE_NAME",recycleMode="StopAppPool",ComputerName="https://CLOUD_SERVICE_NAME.cloudapp.net:PORT/msdeploy.axd",UserName="USERNAME",Password="PASSWORD",AuthType="Basic"

    "C:\Program Files (x86)\IIS\Microsoft Web Deploy V3\msdeploy.exe" -verb:sync -allowUntrusted -source:contentPath="OUTPUT_FOLDER_PATH" -dest:contentPath="SERVER_FOLDER_PATH",ComputerName="https://CLOUD_SERVICE_NAME.cloudapp.net:PORT/msdeploy.axd",UserName="USERNAME",Password="PASSWORD",AuthType="Basic"

    "C:\Program Files (x86)\IIS\Microsoft Web Deploy V3\msdeploy.exe" -verb:sync -allowUntrusted -source:recycleApp -dest:recycleApp="IIS_SITE_NAME",recycleMode="StartAppPool",ComputerName="https://CLOUD_SERVICE_NAME.cloudapp.net:PORT/msdeploy.axd",UserName="USERNAME",Password="PASSWORD",AuthType="Basic"

* IIS_SITE_NAME = Enter your IIS website name.
* OUTPUT_FOLDER_PATH = Provide the local physical path to your project's **output** folder (in the **bin** folder of the project), which is created when you publish to the file system in Visual Studio. The **output** folder contains the **approot** and **wwwroot** folders.
* SERVER_FOLDER_PATH = Enter the root folder path on the server that you created in Step 4. This is the folder above the **wwwroot** folder on the server.
* ComputerName = Provide your server location. The commands shown above assume an Azure VM is used for hosting [CLOUD_SERVICE_NAME = Azure Cloud Service, PORT = Publish port (mapped to port 8172 on each VM where you will publish)]
* UserName = Enter your Web Deploy username.
* Password = Enter your Web Deploy account password.

Addition Resources
^^^^^^^^^^^^^^^^^^^^^^^^^

- `Understanding ASP.NET 5 Web Apps <http://docs.asp.net/en/latest/conceptual-overview/understanding-aspnet5-apps.html>`_
- `Introducing .NET Core <http://docs.asp.net/en/latest/conceptual-overview/dotnetcore.html>`_
 
 .. _pubIIS-author:

.. include:: /_authors/rick-anderson.txt
