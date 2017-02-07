<asp:GridView runat="server" ID="coursesGrid"
    ItemType="ContosoUniversityModelBinding.Models.Enrollment"
    SelectMethod="GetCourses" AutoGenerateColumns="false"
    OnCallingDataMethods="coursesGrid_CallingDataMethods">