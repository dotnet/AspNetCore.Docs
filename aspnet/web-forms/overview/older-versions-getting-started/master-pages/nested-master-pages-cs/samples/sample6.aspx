<%@ Master Language="C#" MasterPageFile="~/NestedMasterPages/Simple.master" AutoEventWireup="false" CodeFile="SimpleNestedAlternate.master.cs" Inherits="NestedMasterPages_SimpleNestedAlternate" %> 
 <asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <asp:ContentPlaceHolder ID="head" runat="server">
 </asp:ContentPlaceHolder> 
 </asp:Content> 
 <asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
 <p>Hello, from SimpleNestedAlternate!</p> 
 <asp:ContentPlaceHolder ID="MainContent" runat="server">
 </asp:ContentPlaceHolder> 
 </asp:Content>