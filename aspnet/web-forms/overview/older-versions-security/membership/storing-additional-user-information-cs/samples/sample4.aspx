<asp:DetailsView ID="UserProfile" runat="server"
          AutoGenerateRows="False" DataKeyNames="UserId"
          DataSourceID="UserProfileDataSource" DefaultMode="Edit">
     <Fields>
          <asp:BoundField DataField="HomeTown" HeaderText="HomeTown"
               SortExpression="HomeTown" />
          <asp:BoundField DataField="HomepageUrl" HeaderText="HomepageUrl"
               SortExpression="HomepageUrl" />
          <asp:BoundField DataField="Signature" HeaderText="Signature"
               SortExpression="Signature" />
          <asp:CommandField ShowEditButton="True" />
     </Fields>
</asp:DetailsView>