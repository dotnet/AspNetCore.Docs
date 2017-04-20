<asp:DetailsView ID="UserProfile" runat="server"
          AutoGenerateRows="False" DataKeyNames="UserId"

          DataSourceID="UserProfileDataSource">
     <Fields>
          <asp:BoundField DataField="HomeTown" HeaderText="HomeTown"
               SortExpression="HomeTown" />
          <asp:BoundField DataField="HomepageUrl" HeaderText="HomepageUrl"

               SortExpression="HomepageUrl" />
          <asp:BoundField DataField="Signature" HeaderText="Signature"
               SortExpression="Signature" />
     </Fields>

</asp:DetailsView>
<asp:SqlDataSource ID="UserProfileDataSource" runat="server"
          ConnectionString="<%$ ConnectionStrings:SecurityTutorialsConnectionString %>"
          SelectCommand="SELECT [UserId], [HomeTown], [HomepageUrl], [Signature] FROM
          [UserProfiles] WHERE ([UserId] = @UserId)">
     <SelectParameters>

          <asp:Parameter Name="UserId" Type="Object" />
     </SelectParameters>
</asp:SqlDataSource>