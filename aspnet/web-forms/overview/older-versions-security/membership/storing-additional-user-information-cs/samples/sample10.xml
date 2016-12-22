<asp:ListView ID="CommentList" runat="server" DataSourceID="CommentsDataSource">
     <LayoutTemplate>
          <span ID="itemPlaceholder" runat="server" />
          <p>
               <asp:DataPager ID="DataPager1" runat="server">
                    <Fields>
                         <asp:NextPreviousPagerField ButtonType="Button" 
                              ShowFirstPageButton="True"
                              ShowLastPageButton="True" />
                    </Fields>
               </asp:DataPager>
          </p>
     </LayoutTemplate>
     <ItemTemplate>
          <h4><asp:Label ID="SubjectLabel" runat="server" 
               Text='<%# Eval("Subject") %>' /></h4>
          <asp:Label ID="BodyLabel" runat="server" 
               Text='<%# Eval("Body").ToString().Replace(Environment.NewLine, "<br />") %>' />
          <p>
               ---<br />
               <asp:Label ID="SignatureLabel" Font-Italic="true" runat="server"
                    Text='<%# Eval("Signature") %>' />
               <br />
               <br />
               My Home Town:
               <asp:Label ID="HomeTownLabel" runat="server" 
                    Text='<%# Eval("HomeTown") %>' />
               <br />
               My Homepage:
               <asp:HyperLink ID="HomepageUrlLink" runat="server" 
                    NavigateUrl='<%# Eval("HomepageUrl") %>' 
                    Text='<%# Eval("HomepageUrl") %>' />
          </p>
          <p align="center">
               Posted by
               <asp:Label ID="UserNameLabel" runat="server" 
                    Text='<%# Eval("UserName") %>' /> on
               <asp:Label ID="CommentDateLabel" runat="server" 
                    Text='<%# Eval("CommentDate") %>' />
          </p>
     </ItemTemplate>
     <ItemSeparatorTemplate>
          <hr />
     </ItemSeparatorTemplate>
</asp:ListView>