<asp:CreateUserWizard ID="NewUserWizard" runat="server"

          ContinueDestinationPageUrl="~/Membership/AdditionalUserInfo.aspx">
     <WizardSteps>
          <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
          </asp:CreateUserWizardStep>
          <asp:WizardStep runat="server" ID="UserSettings" StepType="Step"

                    Title="Your Settings">
               <p>
                    <b>Home Town:</b><br />
                    <asp:TextBox ID="HomeTown" runat="server"></asp:TextBox>

               </p>
               <p>
                    <b>Homepage URL:</b><br />
                    <asp:TextBox ID="HomepageUrl" Columns="40" runat="server"></asp:TextBox>

               </p>
               <p>
                    <b>Signature:</b><br />
                    <asp:TextBox ID="Signature" TextMode="MultiLine" Width="95%"

                         Rows="5" runat="server"></asp:TextBox>
               </p>
          </asp:WizardStep>
          <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">

          </asp:CompleteWizardStep>
     </WizardSteps>
</asp:CreateUserWizard>