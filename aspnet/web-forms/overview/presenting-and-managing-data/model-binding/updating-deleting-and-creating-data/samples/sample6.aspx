<asp:ValidationSummary runat="server" ShowModelStateErrors="true" />
<asp:FormView runat="server" ID="addStudentForm"
    ItemType="ContosoUniversityModelBinding.Models.Student" 
    InsertMethod="addStudentForm_InsertItem" DefaultMode="Insert"
    RenderOuterTable="false" OnItemInserted="addStudentForm_ItemInserted">
    <InsertItemTemplate>
        <fieldset>
            <ol>
                <asp:DynamicEntity runat="server" Mode="Insert" />
            </ol>
            <asp:Button runat="server" Text="Insert" CommandName="Insert" />
            <asp:Button runat="server" Text="Cancel" CausesValidation="false" OnClick="cancelButton_Click" />
        </fieldset>
    </InsertItemTemplate>
</asp:FormView>