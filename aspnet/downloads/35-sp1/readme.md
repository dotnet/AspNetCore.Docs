---
title: "Readme | Microsoft Docs"
author: rick-anderson
description: "The .NET Framework 3.5 Service Pack 1 includes both fixes for existing ASP.NET features as well as new ASP.NET functionality. This document describes how to..."
ms.author: riande
manager: wpickett
ms.date: 04/21/2010
ms.topic: article
ms.assetid: 
ms.technology: 
ms.prod: .net-framework
msc.legacyurl: /downloads/35-sp1/readme
---
[Edit .md file](C:\Projects\msc\dev\Msc.Www\Web.ASP\App_Data\github\downloads\35-sp1\readme.md) | [Edit dev content](http://www.aspdev.net/umbraco#/content/content/edit/36271) | [View dev content](http://docs.aspdev.net/tutorials/downloads/35-sp1/readme.html) | [View prod content](http://www.asp.net/downloads/35-sp1/readme) | Picker: 36271

Readme
====================
> The .NET Framework 3.5 Service Pack 1 includes both fixes for existing ASP.NET features as well as new ASP.NET functionality.
> 
> This document describes how to get started with new features in ASP.NET. It also describes changes from the ASP.NET 3.5 Extensions December CTP and steps you should take to upgrade applications that were written using that CTP to .NET Framework 3.5 Service Pack 1.
> 
> <a id="_Toc198012539"></a>
> 
> ### Table of Contents
> 
> 1. [Links and Resources](#_Toc198012540)
> 2. [Documentation](#_Toc198012541)
> 3. [Downloads](#_Toc198012542)
> 4. [Installation Instructions](#_Toc198012543)
> 5. [Compatibility with Previous Releases](#_Toc198012544)
> 6. [ASP.NET AJAX Script Combining](#_Toc198012546)
> 7. [Getting Started](#_Toc198012547)
> 8. [ASP.NET AJAX History](#_Toc198012548)
> 9. [Getting Started](#_Toc198012549)
> 10. [Changes Made Since the ASP.NET 3.5 Extensions Preview December CTP Release](#_Toc198012550)
> 11. [ASP.NET Dynamic Data](#_Toc198012551)
> 12. [Getting Started](#_Toc198012552)
> 13. [Changes Made Since the ASP.NET 3.5 Extensions Preview December CTP Release](#_Toc198012553)
> 14. [Routing](#_Toc198012554)
> 15. [Model Registration](#_Toc198012555)
> 16. [Directory Structure](#_Toc198012556)
> 17. [Attributes](#_Toc198012557)
> 18. [API Signatures](#_Toc198012558)
> 19. [Converting an ASP.NET 3.5 Extensions December CTP Dynamic Data Web Site to the 3.5 Framework Service Pack 1 Release](#_Toc198012559)
> 20. [Configuration Changes for IIS 7](#_Toc198012560)


<a id="_Toc198012540"></a>

## Links and Resources

<a id="_Toc198012541"></a>

### Documentation

For details about new functionality, review the following documentation:

- [Visual Studio 2008 Service Pack 1 Readme](https://go.microsoft.com/fwlink/?LinkId=110456)
- <a id="Visual_Studio_2008_Express_Editions_Read"></a>[Visual Studio 2008 Express Editions Readme](https://go.microsoft.com/fwlink/?LinkID=111607)
- <a id=".Net_Framework_Readme"></a>[.NET Framework Readme](https://go.microsoft.com/fwlink/?LinkId=112154)

<a id="_Toc198012542"></a><a id="_Downloads"></a>

### Downloads

You can download the release and related materials from the sites in the following list:

- [Combined Visual Studio 2008 Service Pack 1](https://go.microsoft.com/fwlink/?LinkId=122094)
- [.NET Framework 3.5 Service Pack 1](https://go.microsoft.com/fwlink/?LinkId=124150)
- [ScriptReferenceProfiler](https://go.microsoft.com/?LinkID=8843390) control.  
 This control is useful for the information that is provided in the     [ASP.NET AJAX Script Combining](#ASP.NET_AJAX_Script_Combining) section; it is not part of the .NET Framework 3.5 Service Pack 1installation.

<a id="_Toc198012543"></a>

### Installation Instructions

For information about how to install the Visual Studio 2008 3.5 Service Pack 1 and .NET Framework 3.5 Service Pack 1 releases, see the [combined Visual Studio 2008 3.5 Servce Pack 1 and .NET Framework 3.5 Service Pack 1 documentation](https://go.microsoft.com/fwlink/?LinkId=122094).

<a id="_Toc198012544"></a><a id="_Toc195437068"></a>

## Compatibility with Previous Releases

We recommend that you read the documentation Visual Studio 2008 Service Pack 1 , Visual Studio 2008 Express Editions, and the .NET Framework. You must also uninstall the following releases (if you have them installed) before you install the .NET 3.5 Framework Service Pack release.

ASP.NET 3.5 Extensions Preview December CTP. This CTP contains earlier versions of the ASP.NET Dynamic Data framework and of ASP.NET AJAX browser history and Script Combining. These releases are incompatible with those shipped in ASP.NET 3.5 Service Pack 1 . You can remove the Microsoft ASP.NET 3.5 Extensions December CTP by using the Add or Remove Programs application in the Windows Control Panel.

In addition, follow the instructions in this readme file in order to modify existing applications that use the ASP.NET AJAX browser history feature or ASP.NET Dynamic Data from the ASP.NET 3.5 Extensions Preview December CTP. These instructions enable existing applications to function correctly with .NET 3.5 Service Pack 1 .

If you currently have the ADO.NET Entity Framework 3 installed, see [here](https://go.microsoft.com/fwlink/?LinkId=8864500) for information about how to use the .NET Framework 3.5 Service Pack 1 release.

For more information about possible installation issues, see the [.NET Framework Readme](https://go.microsoft.com/fwlink/?LinkId=112154), [Visual Studio 2008 Service Pack 1 Readme](https://go.microsoft.com/fwlink/?LinkId=110456), and [Visual Studio 2008 Express Editions Readme](https://go.microsoft.com/fwlink/?LinkID=111607).

<a id="_Toc198012546"></a><a id="ASP.NET_AJAX_Script_Combining"></a>

## ASP.NET AJAX Script Combining

ASP.NET AJAX Script Combining enables performance increases for AJAX applications by combining multiple script requests into a single download.

<a id="_Toc198012547"></a><a id="_Toc195437076"></a>

### Getting Started

For an overview of ASP.NET AJAX Script Combining, see the [Script Combining](../../web-forms/videos/aspnet-35/aspnet-ajax/using-script-combining-to-improve-ajax-performance.md) screencast. After you install the Visual Studio 2008 and .NET Framework 3.5 Service Pack 1 , you can create an ASP.NET Web site that supports ASP.NET AJAX Script Combining. Follow these steps:

1. Start Visual Studio 2008 Service Pack 1 .
2. On the **File** menu, click **New Website**, select **ASP.NET Web Site**, and then click **OK**.
3. In the Default.aspx page, add a `ScriptManager` control to the page.
4. Add multiple AJAX-enabled controls to the page. A great way to see the advantage of script combining is to use a number of controls from the [AJAX Control Toolkit](http://www.codeplex.com/Wiki/View.aspx?ProjectName=AtlasControlToolkit).
5. Add the `ScriptReferenceProfiler` control to the page. This control enables you to retrieve the references to the client script requests that are used in the page.  

    > [!NOTE] This is not a required step. The `ScriptReferenceProfiler` control is not part of the installation, and you must install it separately. For more information, see [Downloads](#_Downloads) earlier in this document.
6. Run the page. You will see a list of script references like those in the following example. You can see that the example list of script references below includes script references for a number of controls from the ASP.NET AJAX Control Toolkit. 

        <asp:ScriptReference name="MicrosoftAjax.js"/>
        <asp:ScriptReference name="MicrosoftAjaxWebForms.js"/>
        <asp:ScriptReference name="AjaxControlToolkit.Common.Common.js" assembly=" AjaxControlToolkit"/>
        <asp:ScriptReference name="AjaxControlToolkit.Common.DateTime.js" assembly=" AjaxControlToolkit"/>
        <asp:ScriptReference name="AjaxControlToolkit.Compat.Timer.Timer.js" assembly=" AjaxControlToolkit"/>
7. In the page, add `<CompositeScript>` and `<Scripts>` elements as children of the `ScriptManager` control.
8. Copy the script references from the page and paste them into the `<Scripts>` element inside the `ScriptManager` control in the .aspx page. The resulting markup will look like the following example. 

        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false">
           <CompositeScript>
                <Scripts>
                    <asp:ScriptReference name="MicrosoftAjax.js"/>
                    <asp:ScriptReference name="MicrosoftAjaxWebForms.js"/>
                    <asp:ScriptReference name="AjaxControlToolkit.Common.Common.js" assembly="AjaxControlToolkit"/>
                    <asp:ScriptReference name="AjaxControlToolkit.Common.DateTime.js" assembly="AjaxControlToolkit"/>
                    <asp:ScriptReference name="AjaxControlToolkit.Compat.Timer.Timer.js" assembly=" AjaxControlToolkit"/>   
                </Scripts>
            </CompositeScript>
        </asp:ScriptManager>
9. Run the page and view the source. You will see just one script reference now instead of many. If you want to understand the effect on performance, run Fiddler or Firebug to see the network traffic.<a id="ASP.NET_AJAX_History"></a>

<a id="_Toc198012548"></a>

## ASP.NET AJAX History

An inherent problem with AJAX-style applications is browser navigation. An AJAX-style page can interact with the server by using asynchronous postbacks, therefore users can perform many tasks without leaving the page. However, if users click the browser's Back button, by default the browser does not return to a previous state of the page (for example, the state before the most recent asynchronous postback). Instead, the browser unloads the page entirely and returns to the page that was displayed before your page was started. Very frequently, this is not what the user intended.

You can manage history (Back and Forward button navigation) to provide a more logical and natural navigation model in your Web application. You control the state that is required to recreate the page and can manage history navigation in both server and client code. You do this by defining points in your application that act like bookmarks that users return to when they navigate with the Back and Forward buttons.

<a id="_Toc198012549"></a><a id="_Toc195437077"></a>

### Getting Started

For an overview of browser history, see the [ASP.NET AJAX history](../../web-forms/videos/aspnet-ajax/how-do-i-use-the-aspnet-ajax-history-control.md) screencast. After you install the Visual Studio 2008 and .NET Framework 3.5 Service Pack 1 you can create an ASP.NET Web site that supports ASP.NET AJAX browser history. For an example, follow these steps:

1. Start Visual Studio 2008 Service Pack 1.
2. On the **File** menu, click **New Website**, select `ASP.NET Web Site`, and then click `OK`.
3. In the Default.aspx page, drag a `ScriptManager` control from the `AJAX Extensions` section in the `Toolbox` and drop it on the page. Make sure that you drop the control between the opening and closing tags of the `form` element.
4. Set the `EnableHistory` property of the `ScriptManager` control to `true`. This enables the ASP.NET AJAX history feature.
5. Drag an `UpdatePanel` control from the `AJAX Extensions` section in the `Toolbox` and drop it below the `ScriptManager` control.
6. Drag a `Wizard` control and drop it inside the `UpdatePanel` control.
7. Add a new `WizardStep` element to the `Wizard` control. This step is optional, but it makes it easier to see how the history feature works.
8. Add a `TextBox` control into each step in the `Wizard` control. Use the `Step` list to select each stage.
9. Create a handler for the `ActiveStepChanged` event of the `Wizard` control.
10. In the generated handler, enter the following code: 

        protected void Wizard1_ActiveStepChanged(object sender, EventArgs e)
        {
        if (ScriptManager1.IsInAsyncPostBack && !ScriptManager1.IsNavigating)
            {
                ScriptManager1.AddHistoryPoint("index",
                    Wizard1.ActiveStepIndex.ToString(), "Wizard step " +
                    Wizard1.ActiveStepIndex.ToString());
            }
        }
11. Create a handler for the `Navigate` event of the `ScriptManager` control.
12. In the generated handler, enter the following code: 

        protected void ScriptManager1_Navigate(object sender, HistoryEventArgs e)
        {
            string indexString = e.State["index"];
        
            if (!string.IsNullOrEmpty(indexString))
            {
                Wizard1.ActiveStepIndex = 0;
            }
            else
            {
                Wizard1.ActiveStepIndex = Int32.Parse(indexString);
            }
            
            Page.Title = "Wizard step " + indexString;
         }
13. Run the application.Move through the wizard steps, entering information into each text box. Use the browser's Back and Forward button. Instead of moving to the page where you were before you started the current page, you can navigate to the next and previous steps of the wizard.

<a id="_Toc198012550"></a><a id="_Toc195437078"></a>

### Changes Made Since the ASP.NET 3.5 Extensions Preview December CTP Release

The following changes have been made to the ASP.NET AJAX history feature since the ASP.NET 3.5 Extensions December 2007 CTP Release:The `EnableHistoryHash` property of the `ScriptManager` control has been renamed `EnableSecureHistoryState`.

<a id="_Toc198012551"></a><a id="ASP.NET_Dynamic_Data"></a>

## ASP.NET Dynamic Data

ASP.NET Dynamic Data is a new feature that provides two significant usability improvements to data controls in ASP.NET. You can find screencasts and additional information in the [ASP.NET Dynamic Data](https://msdn.microsoft.com/en-us/library/cc488545.aspx) section of the ASP.NET Web site.The first improvement is for existing applications that use `DetailsView`, `FormView`, `GridView`, or `ListView` controls. The `DetailsView` and `GridView` controls have been extended to display fields by using a new model of templates instead of by using hard-coded rules that are programmed in the controls. These templates are part of your Dynamic Data Web application and you can customize them to change their appearance or to specify what controls they use for rendering. This makes it very easy to make a change in one place that specifies how to present dates for editing, as one example. `FormView` and `ListView` controls can implement similar behavior by using a `DynamicControl` control in their templates and by specifying which field in the row to display. Dynamic Data will then automatically build the UI for these controls based on the templates that you specify.The second improvement is that the templates look at the metadata for a LINQ to SQL or Entity Framework data model and provide automatic validation based on the model. For example, if a column in the database is limited to 50 characters, and if a column is marked as not nullable, a `RequiredFieldValidator` control is automatically enabled for the column. (The controls also automatically support data-model-level validation.) You can apply other metadata to take further control over display and validation.

<a id="_Toc198012552"></a><a id="_Toc195437058"></a>

### Getting Started

For an overview of using ASP.NET Dynamic Data, see the [Dynamic Data](../../web-forms/videos/aspnet-dynamic-data/getting-started-with-dynamic-data.md) screencast. After you run the installation process, you can create an ASP.NET Web site that supports Dynamic Data. Follow these steps:

1. Start Visual Studio 2008 Service Pack 1.
2. In the `File` menu, click `New Web Site`.
3. Select the `Dynamic Data Website` template and then click `OK`.The new Web site is created.
4. Add a connection to a new or existing database, and add some tables to the model. (This step is not specific to Dynamic Data.)
5. Add a LINQ to SQL class and add the tables from the database to the class.
6. Open the Global.asax file.
7. Uncomment the call to `model.RegisterContext`, and change the parameters to pass the type of the LINQ to SQL data model that you are using.
8. Set `ScaffoldAllTables` to `true`.
9. Run the application.The default page for the site displays a list of the tables that are available in the data model.

<a id="_Toc198012553"></a><a id="_Toc195437060"></a>

### Changes Made Since the ASP.NET 3.5 Extensions Preview December CTP Release

Dynamic Data projects have undergone major changes since the ASP.NET 3.5 Extensions Preview December CTP release ("December CTP"). The changes are listed below. The best way to upgrade a project from the December CTP release is to create a new Dynamic Data project and copy the code from the old project into the new directories. For a detailed description of how Dynamic Data elements have moved, see `Directory Structure` later in this document.After you create a Dynamic Data project, open the Global.asax file and register the data model by using the commented-out registration line in the `RegisterRoutes` method. (See `Model Registration`.) Turn on the scaffolding flag. At this point you have an application very similar to the starting application from the December CTP release.

<a id="_Toc198012554"></a><a id="_Toc195437061"></a>

#### Routing

The December CTP of Dynamic Data has its own routing mechanism that is configured by using the `<mappings>` element in the `DynamicData` configuration block in the Web.config file. This routing mechanism has been changed to use the URL-routing APIs that are used with ASP.NET MVC Preview 2 and later projects. Routes are now configured in the Global.asax file. The following example shows how default routes are enabled in a new Dynamic Data

    project.routes.Add(new DynamicDataRoute("{table}/ListDetails.aspx"){
        Action = PageAction.List,
        ViewName = "ListDetails",
        Model = model
    });
    routes.Add(new DynamicDataRoute("{table}/ListDetails.aspx") {
        Action = PageAction.Details,
        ViewName = "ListDetails",
        Model = model});
    //routes.Add(new DynamicDataRoute("{table}/{action}.aspx") {
    //Constraints = new RouteValueDictionary(new
        { action = "List|Details|Edit|Insert" }),
    //Model = model//});

The first route in the example sends users to the `ListDetails` template for both List and Details views. You can comment out these sections and uncomment the subsequent section. In that case, the bottom route supports having separate List and Details pages.

<a id="_Toc198012555"></a><a id="_Toc195437062"></a><a id="_Model_Registration"></a>

#### Model Registration

The December CTP release automatically finds the data model that the project is using. Alternatively, you can specify a single data model in the Web.config file. The 3.5 Service Pack 1 release requires that all data models be registered in the Global.asax file. The following example shows how to register the `NorthwindDataContext` data model class in the `RegisterRoutes` method in the Global.asax file so that it can be used with Dynamic Data. The example also shows how to enable scaffolding for the whole data model.

    MetaModel model = new MetaModel();
    // Uncomment this line to register your LINQ to SQL or ADO.NET Entity data model
    // for ASP.NET Dynamic Data. Set ScaffoldAllTables = true only if you are sure
    // that you want all tables in the data model to support a scaffold (i.e. templates)
    // view. To control scaffolding for individual tables, create a partial class for
    // the table and apply the [Scaffold(true)] attribute to the partial class.
    // Note: Make sure that you change "YourDataContextType" to the name of the data context
    // class in your application.model.
    RegisterContext(typeof(NorthwindDataContext), new
        ContextConfiguration() { ScaffoldAllTables = true });

Scaffolding can be enabled on a table-by-table and field-by-field basis by applying the `Scaffold` attribute to a table in the data model. The `Scaffold` attribute also works on fields in the table.

<a id="_Toc198012556"></a><a id="_Toc195437063"></a><a id="_Directory_Structure"></a>

#### Directory Structure

The directory structure and placement of default templates has changed in Dynamic Data since the December CTP release. The following example shows the directory layout for the December CTP release.

    /App_Shared
        /DynamicDataFields
        /DynamicDataPages
        /Images/Products/ListDetails.aspx

The directory structure has been completely revamped to make it clear that it is for Dynamic Data. In addition, overrides for .aspx files for the scaffolding have been moved into their own directory named CustomPages inside the DynamicData directory to make sure that they have no directory or naming conflicts with the rest of the site. The following example shows the directory layout for the .NET 3.5 Service Pack 1 release.

    /DynamicData
      /Content
      /CustomPages
        /Products
          ListDetails.aspx
      /FieldTemplates
      /PagesTemplates

<a id="_Toc198012557"></a><a id="_Toc195437064"></a><a id="_Attributes"></a>

#### Attributes

Field template controls in the December CTP release referenced metadata that was added to the model as a dictionary of name/value pairs. The .NET 3.5 Service Pack 1 release exposes the metadata as a list of the actual CLR attributes that are available to a field template control, which provides easier access that is also type safe.In addition, in the December CTP release, metadata was applied directly to the top of the partial class for the data model. This was not optimal, because you could not determine easily which fields in the table the metadata was being applied to. The .NET Framework currently does not support adding metadata to existing members in a partial class. To work around this limitation, Dynamic Data uses a secondary class that is used exclusively for applying metadata. The following example shows a secondary class with the attribute applied.

    [MetadataType(typeof(ProductMetadata))]
    public partial class Product {}

In the previous example, a `MetaDatatype` attribute has been added to the partial class for the Product table. The attribute points to the `ProductMetadata` class, which contains the metadata for the fields in the Product table.The following example shows the `ProductMetadata` class, which contains the metadata for the fields in the Product table. Placeholder fields have been added to the `ProductMetadata` class that map to the fields in the actual Product class. Metadata attributes can then be added on a field-by-field basis, as shown for the `UnitsOnOrder` field.

    public class ProductMetadata {
        public object ProductID { get; set; }
        public object ProductName { get; set; }
        public object Supplier { get; set; }
        public object Category { get; set; }
        public object QuantityPerUnit { get; set; }
        public object UnitPrice { get; set; }
        public object UnitsInStock { get; set; }
        [Range(0, 100)]
        [Description("Enter the units in stock in this field.")]
        public object UnitsOnOrder { get; set; }
        public object ReorderLevel { get; set; }
        public object Discontinued { get; set; }
    }

The Dynamic Data Wizard, which is available on the Dynamic Data Preview site, is a tool that will automatically generate the partial classes. We are also working on adding a mechanism in future .NET Framework runtimes to be able to apply the metadata directly to partial classes.

<a id="_Toc198012558"></a><a id="_Toc195437065"></a>

#### API Signatures

Changes have been made to types and members in the Dynamic Data library to give them more consistent names. This section provides highlights of the changed areas.

##### Controls (DynamicGridView, DynamicDetailsView, DynamicFormView, and DynamicListView)

"Dynamic" been removed from the name of the control.The `DataKeyNames` property must now be set explicitly; previously, controls identified **DataKeyNames** automatically.

##### Attributes

Metadata must be associated by using `MetadataType` attribute. For more information, see the [Attributes](#_Toc195437064) section earlier in this document.`RenderHint` has been renamed to `UIHint`.`Regex` has been renamed to `RegularExpression`.For the `DynamicDataField` class (field templates), the following changes have been made:`FieldTemplateUserControlBase` no longer exists. Change any instances of the `Inherits` attribute that reference the old class to reference the `FieldTemplateUserControl` class instead.`DataValue` has been changed to `FieldValue`.`DataValueString` has been changed to `FieldValueString`.`DataValueEditString` has been changed to `FieldValueEditString`.`DataField` has been changed to `Column.Name`.`SetupRequiredFieldValidator` has been changed to `SetUpValidator`.`SetupRegexValidator` has been changed to `SetUpValidator`.`SetupDynamicValidator` has been changed to `SetUpValidator`.`TemplateMode` has been changed to `Mode`.`DynamicTemplateMode.EditItemTemplate` has been changed to `DataBoundControlMode.Edit`.`MetaMember.MetaTable` has been changed to `Column.Table`.`MetaMember.MetaTable.Query` has been changed to `Column.Table.GetQuery`.`DataItem` has been changed to `Row`.

<a id="_Toc198012559"></a><a id="_Toc195437066"></a>

#### Converting an ASP.NET 3.5 Extensions December CTP Dynamic Data Web Site to the 3.5 Framework Service Pack 1 Release

The following steps describe changes that you must make in the Web.config file in order to change a Dynamic Data Web site created with the December CTP release to work with the .NET 3.5 Service Pack 1 release.

1. Make sure that you have uninstalled the software described in [Compatibility with Previous Releases](#_Compatibility_with_Previous) earlier in this document
2. Make sure you have installed the combined Visual Studio 2008 and .NET Framework 3.5 Service Pack 1 release.
3. Start Visual Studio 2008 Service Pack 1 and open the existing Dynamic Data application.
4. Change all references of `System.Web.Extensions, Version=3.6.0.0` to `System.Web.Extensions, Version=3.5.0.0`. - 5.Remove the following configuration section: 

        <section name="dynamicData"
            type="System.Web.DynamicData.DynamicDataControlsSection"
            requirePermission="false"
            allowDefinition="MachineToApplication"/>
- In the `<assemblies>` element, add the following elements: 

        <add assembly="System.Web.Abstractions, Version=3.5.0.0, Culture=neutral,
            PublicKeyToken=31BF3856AD364E35"/>
        <add assembly="System.Web.Routing, Version=3.5.0.0, Culture=neutral,
            PublicKeyToken=31BF3856AD364E35"/>
        <add assembly="System.ComponentModel.DataAnnotations, Version=3.5.0.0,
            Culture=neutral, PublicKeyToken=31BF3856AD364E35"/>
        <add assembly="System.Web.DynamicData, Version=3.5.0.0, Culture=neutral,
            PublicKeyToken=31BF3856AD364E35"/>
- In the `<assemblies>` element, remove the following item: 

        <add assembly="System.Web.DynamicData, Version=3.6.0.0,
            Culture=neutral, PublicKeyToken=31BF3856AD364E35"/>
- In the `<controls>` section, remove the following elements: 

        <add tagPrefix="asp" namespace="System.Web.DynamicData"
            assembly="System.Web.Extensions, Version=3.6.0.0, Culture=neutral,
            PublicKeyToken=31BF3856AD364E35"/>
        <add tagPrefix="asp" tagName="DynamicFilter"
            src="~/App_Shared/DynamicDataFields/FilterUserControl.ascx"/>
- In the `<controls>` section, add the following element: 

        <add tagPrefix="asp" namespace="System.Web.DynamicData"
            assembly="System.Web.DynamicData, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"/>
- In the `<httpModules>` section, remove the following elements: 

        <add name="DynamicDataModule"
            type="System.Web.DynamicData.DynamicDataHttpModule,
            System.Web.Extensions, Version=3.6.0.0, Culture=neutral,
            PublicKeyToken=31BF3856AD364E35"/>
        <add name="UrlRoutingModule" type="System.Web.Mvc.UrlRoutingModule,
            System.Web.Extensions, Version=3.6.0.0, Culture=neutral,
            PublicKeyToken=31BF3856AD364E35"/>
- In the `<httpModules>` section, add the following entry: 

        <add name="UrlRoutingModule"
            type="System.Web.Routing.UrlRoutingModule, System.Web.Routing,Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"/>
- Remove the `<dynamicData>` configuration section. - In the `<runtime>` section, replace the following section: 

        <runtime>
          <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
            <dependentAssembly>
              <assemblyIdentity name="System.Web.Extensions"
                   publicKeyToken="31bf3856ad364e35"/>
              <bindingRedirect oldVersion="1.0.0.0-3.5.0.0" newVersion="3.6.0.0"/>
            </dependentAssembly>
            <dependentAssembly>
              <assemblyIdentity name="System.Web.Extensions.Design"
                publicKeyToken="31bf3856ad364e35"/>
              <bindingRedirect oldVersion="1.0.0.0-3.5.0.0" newVersion="3.6.0.0"/>
            </dependentAssembly>
          </assemblyBinding>
        </runtime>

 With the following section: 

        <runtime>
          <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
            <dependentAssembly>
              <assemblyIdentity name="System.Web.Extensions"
                  publicKeyToken="31bf3856ad364e35"/>
              <bindingRedirect oldVersion="1.0.0.0-1.1.0.0" newVersion="3.5.0.0"/>
            </dependentAssembly>
            <dependentAssembly>
              <assemblyIdentity name="System.Web.Extensions.Design"
                  publicKeyToken="31bf3856ad364e35"/>
              <bindingRedirect oldVersion="1.0.0.0-1.1.0.0" newVersion="3.5.0.0"/>
            </dependentAssembly>
          </assemblyBinding>
        </runtime>

<a id="_Toc198012560"></a><a id="_Toc195437067"></a>

#### Configuration Changes for IIS 7

If you are using IIS 7, you must make the following additional changes in the `<system.WebServer>` section of the Web.config file: 

1. In the `<modules>` section, remove the following elements: 

        <remove name="DynamicDataModule"/>
        <add name="DynamicDataModule" preCondition="managedHandler"    
        type="System.Web.DynamicData.DynamicDataHttpModule,
            System.Web.Extensions, Version=3.6.0.0, Culture=neu4tral,
            PublicKeyToken=31BF3856AD364E35"/>
2. In the `<handlers>` section, remove the following elements: 

        <add name="MvcScriptMap" preCondition="classicMode" verb="*"
            path="*.mvc" modules="IsapiModule"
            scriptProcessor="%windir%\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll"/>
        <add name="MvcHandler" preCondition="integratedMode" verb="*"
            path="Mvc.axd"
            type="System.Web.Mvc.MvcHandler, System.Web.Extensions, Version=3.6.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"/>
3. In the `<modules>` section, add the following element: 

        <add name="UrlRoutingModule"
            type="System.Web.Routing.UrlRoutingModule, System.Web.Routing, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"/>
4. In the `<handlers>` section, add the following element: 

        <add name="UrlRoutingHandler"
            preCondition="integratedMode"
            verb="*"
            path="UrlRouting.axd"
            type="System.Web.Routing.UrlRoutingHandler, System.Web.Routing, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"/>