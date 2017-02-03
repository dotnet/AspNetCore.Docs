<asp:TemplateField ShowHeader="False">
     <EditItemTemplate>
          <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True"
               CommandName="Update" Text="Update"></asp:LinkButton>

           <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False"
                CommandName="Cancel" Text="Cancel"></asp:LinkButton>

     </EditItemTemplate>
     <ItemTemplate>
          <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False"
               CommandName="Edit" Text="Edit"></asp:LinkButton>

           <asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False"
               CommandName="Delete" Text="Delete"></asp:LinkButton>

     </ItemTemplate>
</asp:TemplateField>