<h3>Leave a Comment</h3>
<p>
     <b>Subject:</b>
     <asp:RequiredFieldValidator ID="SubjectReqValidator" runat="server"
          ErrorMessage="You must provide a value for Subject"
          ControlToValidate="Subject" ValidationGroup="EnterComment">
     </asp:RequiredFieldValidator><br/>
     <asp:TextBox ID="Subject" Columns="40" runat="server"></asp:TextBox>
</p>
<p>
     <b>Body:</b>
     <asp:RequiredFieldValidator ID="BodyReqValidator" runat="server"
          ControlToValidate="Body"
          ErrorMessage="You must provide a value for Body" ValidationGroup="EnterComment">
     </asp:RequiredFieldValidator><br/>
     <asp:TextBox ID="Body" TextMode="MultiLine" Width="95%"
          Rows="8" runat="server"></asp:TextBox>
</p>
<p>
     <asp:Button ID="PostCommentButton" runat="server" 
          Text="Post Your Comment"
          ValidationGroup="EnterComment" />
</p>