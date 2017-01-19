<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
 <ContentTemplate>
 <%= DateTime.Now.ToLongTimeString() %>
 </ContentTemplate>
 <Triggers>
 <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
 </Triggers>
</asp:UpdatePanel>