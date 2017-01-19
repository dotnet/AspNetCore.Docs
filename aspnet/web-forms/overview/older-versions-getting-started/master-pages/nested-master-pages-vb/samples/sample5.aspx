<%@ Master Language="VB" MasterPageFile="~/NestedMasterPages/Simple.master" AutoEventWireup="false" CodeFile="SimpleNested.master.vb" Inherits="NestedMasterPages_SimpleNested" %> 
 <asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"> 
 <asp:ContentPlaceHolder ID="head" runat="server"> 
 </asp:ContentPlaceHolder>
 </asp:Content> 
 <asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server"> 
 <p>Hello, from SimpleNested!</p>
 <asp:ContentPlaceHolder ID="MainContent" runat="server"> 
 </asp:ContentPlaceHolder>
 </asp:Content>