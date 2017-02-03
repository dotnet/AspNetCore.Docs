protected void RegisterUser_CreatingUser(object sender, LoginCancelEventArgs e)
{
     string trimmedUserName = RegisterUser.UserName.Trim();
     if (RegisterUser.UserName.Length != trimmedUserName.Length)
     {
          // Show the error message
          InvalidUserNameOrPasswordMessage.Text = "The username cannot contain leading or trailing spaces.";
          InvalidUserNameOrPasswordMessage.Visible = true;

          // Cancel the create user workflow
          e.Cancel = true;
     }
     else
     {
          // Username is valid, make sure that the password does not contain the username

          if (RegisterUser.Password.IndexOf(RegisterUser.UserName, StringComparison.OrdinalIgnoreCase) >= 0)
          {
               // Show the error message
               InvalidUserNameOrPasswordMessage.Text = "The username may not appear anywhere in the password.";
               InvalidUserNameOrPasswordMessage.Visible = true;
               // Cancel the create user workflow
               e.Cancel = true;
          }
     }
}