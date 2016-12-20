---
title: "Presetting List Entries with CascadingDropDown (C#) | Microsoft Docs"
author: wenz
description: "The CascadingDropDown control in the AJAX Control Toolkit extends a DropDownList control so that changes in one DropDownList loads associated values in anoth..."
ms.author: riande
manager: wpickett
ms.date: 06/02/2008
ms.topic: article
ms.assetid: 
ms.technology: dotnet-webforms
ms.prod: .net-framework
msc.legacyurl: /web-forms/overview/ajax-control-toolkit/cascadingdropdown/presetting-list-entries-with-cascadingdropdown-cs
---
Presetting List Entries with CascadingDropDown (C#)
====================
by [Christian Wenz](https://github.com/wenz)

[Download Code](http://download.microsoft.com/download/9/0/7/907760b1-2c60-4f81-aeb6-ca416a573b0d/cascadingdropdown2.cs.zip) or [Download PDF](http://download.microsoft.com/download/2/d/c/2dc10e34-6983-41d4-9c08-f78f5387d32b/cascadingDropDown2CS.pdf)

> The CascadingDropDown control in the AJAX Control Toolkit extends a DropDownList control so that changes in one DropDownList loads associated values in another DropDownList. With a little bit of code it is possible that a list element is preselected once the data has been dynamically loaded.


## Overview

The CascadingDropDown control in the AJAX Control Toolkit extends a DropDownList control so that changes in one DropDownList loads associated values in another DropDownList. (For instance, one list provides a list of US states, and the next list is then filled with major cities in that state.) With a little bit of code it is possible that a list element is preselected once the data has been dynamically loaded.

## Steps

In order to activate the functionality of ASP.NET AJAX and the Control Toolkit, the `ScriptManager` control must be put anywhere on the page (but within the `<form>` element):

    <asp:ScriptManager ID="asm" runat="server" />

Then, a DropDownList control is required:

    <div>
     Vendor: <asp:DropDownList ID="VendorsList" runat="server"/>
    </div>

For this list, a CascadingDropDown extender is added, providing web service URL and method information:

    <ajaxToolkit:CascadingDropDown ID="ccd1" runat="server"
     ServicePath="CascadingDropdown2.cs.asmx" ServiceMethod="GetVendors"
     TargetControlID="VendorsList" Category="Vendor" />

The CascadingDropDown extender then asynchronously calls a web service with the following method signature:

    public CascadingDropDownNameValue[] MethodNameHere(string knownCategoryValues, string
     category)

The method returns an array of type CascadingDropDown value. The type's constructor expects first the list entry's caption and then the value (HTML `value` attribute). If the third argument is set to true, the list element is automatically selected in the browser.

    <%@ WebService Language="C#" Class="CascadingDropdown2" %>
    using System.Web.Script.Services;
    using AjaxControlToolkit;
    using System;
    using System.Web;
    using System.Web.Services;
    using System.Web.Services.Protocols;
    using System.Collections.Generic;
    [ScriptService]
    public class CascadingDropdown2 : System.Web.Services.WebService
    {
     [WebMethod]
     public CascadingDropDownNameValue[] GetVendors(string knownCategoryValues, string
     category)
     {
     List<CascadingDropDownNameValue> l = new List<CascadingDropDownNameValue>();
     l.Add(new CascadingDropDownNameValue(
     "International", "1"));
     l.Add(new CascadingDropDownNameValue(
     "Electronic Bike Repairs & Supplies", "2", true));
     l.Add(new CascadingDropDownNameValue(
     "Premier Sport, Inc.", "3"));
     return l.ToArray();
     }
    }

Loading the page in the browser will fill the dropdown list with three vendors, the second one being preselected.


[![The list is filled and preselected automatically](presetting-list-entries-with-cascadingdropdown-cs/_static/image2.png)](presetting-list-entries-with-cascadingdropdown-cs/_static/image1.png)

The list is filled and preselected automatically ([Click to view full-size image](presetting-list-entries-with-cascadingdropdown-cs/_static/image3.png))

>[!div class="step-by-step"] [Previous](using-cascadingdropdown-with-a-database-cs.md) [Next](using-auto-postback-with-cascadingdropdown-cs.md)