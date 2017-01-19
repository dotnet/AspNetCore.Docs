<asp:TemplateField HeaderText="Total Credits">  
    <ItemTemplate>
        <asp:Label Text="<%# Item.Enrollments.Sum(en => en.Course.Credits) %>" 
            runat="server" />
    </ItemTemplate>
</asp:TemplateField>
<asp:HyperLinkField Text="Courses" DataNavigateUrlFormatString="~/Courses.aspx?StudentID={0}"
    DataNavigateUrlFields="StudentID" />