<asp:ListView ID="LessonsList" runat="server" DataSourceID="LessonsDataSource">
 <LayoutTemplate>
 <ul>
 <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
 </ul>
 </LayoutTemplate>
 
 <ItemTemplate>
 <li><asp:HyperLink runat="server" ID="lnkLesson" NavigateUrl='<%# Eval("Url") %>'
 Text='<%# Eval("Title") %>' /></li>
 </ItemTemplate>
</asp:ListView>