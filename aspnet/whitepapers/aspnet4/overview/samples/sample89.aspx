<asp:CreateUserWizard ID="CreateUserWizard1" runat="server" ActiveStepIndex="1"> 
  <LayoutTemplate> 
    <asp:PlaceHolder ID="headerPlaceholder" runat="server" /> 
    <asp:PlaceHolder ID="sideBarPlaceholder" runat="server" /> 
    <asp:PlaceHolder id="wizardStepPlaceholder" runat="server" /> 
    <asp:PlaceHolder id="navigationPlaceholder" runat="server" /> 
  </LayoutTemplate> 
  <HeaderTemplate> 
    Header 
  </HeaderTemplate> 
  <WizardSteps> 
    <asp:CreateUserWizardStep runat="server"> 
      <ContentTemplate> 
      </ContentTemplate> 
    </asp:CreateUserWizardStep> 
    <asp:CompleteWizardStep runat="server"> 
      <ContentTemplate> 
      </ContentTemplate> 
    </asp:CreateUserWizardStep> 
  </WizardSteps> 

</asp:CreateUserWizard>