<%@ Master Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="AdminNested.master.vb" Inherits="Admin_AdminNested" %> 
 <asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"> 
 <asp:ContentPlaceHolder ID="head" runat="server"> 
 </asp:ContentPlaceHolder>
 </asp:Content> 
 <asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server"> 
 <div class="instructions">
 <b>Administration Instructions:</b>
 <br /> 
 The pages in the Administration section allow you, the Administrator, to 
 add new products and view existing products. 
 </div>
 <asp:ContentPlaceHolder ID="MainContent" runat="server"> 
 </asp:ContentPlaceHolder>
 </asp:Content> 
 <asp:Content ID="Content3" ContentPlaceHolderID="QuickLoginUI" Runat="Server"> 
 <asp:ContentPlaceHolder ID="QuickLoginUI" runat="server"> 
 </asp:ContentPlaceHolder>
 </asp:Content> 
 <asp:Content ID="Content4" ContentPlaceHolderID="LeftColumnContent" Runat="Server"> 
 <asp:ContentPlaceHolder ID="LeftColumnContent" runat="server"> 
 </asp:ContentPlaceHolder>
 </asp:Content>