<asp:FormView runat="server" ID="addStudentForm"
    ItemType="ContosoUniversityModelBinding.Models.Student"
    InsertMethod="InsertStudent" DefaultMode="Insert"
    OnCallingDataMethods="addStudentForm_CallingDataMethods"
    RenderOuterTable="false" OnItemInserted="addStudentForm_ItemInserted">