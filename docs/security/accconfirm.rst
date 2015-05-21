Account Confirmation and Password Recovery with ASP.NET Identity
================================================================

By `Pranav Rastogi`_

This tutorial shows you how to build an ASP.NET 5 Web site with email confirmation and password reset using the ASP.NET Identity.

In this article:
	- `Create a New ASP.NET 5 Project`_
	- `Running the Application`_
	- `Setup up Email provider`_
	- `Enable Account confirmation and Password recovery`_
	- `Register, confirm email and reset password`_
	- `Require email confirmation before login`_
	- `Next steps`_
	- `Summary`_

Create a New ASP.NET 5 Project
------------------------------

To get started, open Visual Studio 2015. Next, create a New Project (from the Start Page, or via File - New - Project).  On the left part of the New Project window, make sure the Visual C# templates are open and "Web" is selected, as shown:

.. image:: accconfirm/_static/new-project.png

Next you should see another dialog, the New ASP.NET Project window:
 
.. image:: accconfirm/_static/select-project.png
	
Select the ASP.NET 5 Web site template from the set of ASP.NET 5 templates. Make sure you have Individual Authentication selected for this template. After selecting, click OK.

At this point, the project is created. It may take a few moments to load, and you may notice Visual Studio's status bar indicates that Visual Studio id downloading some resources as part of this process.  Visual Studio ensures some required files are pulled into the project when a solution is opened (or a new project is created), and other files may be pulled in at compile time.


Running the Application
-----------------------

Run the application and after a quick build step, you should see it open in your web browser.

.. image:: accconfirm/_static/first-run.png


Setup up Email provider
-----------------------

Although this tutorial only shows how to add email notification through `SendGrid <https://sendgrid.com/>`_, you can send email using SMTP and other mechanisms.
 - Install SendGrid NuGet package
 - Go to the `Azure SendGrid sign up page <http://azure.microsoft.com/en-us/marketplace/partners/sendgrid/sendgrid-azure/>`_ and register for free SendGrid account.
 - Add code in MessageServices similar to the following to configure SendGrid

.. code-block:: c#

    public static Task SendEmailAsync(string email, string subject, string message)
    {
        // Plug in your email service here to send an email.
        var myMessage = new SendGridMessage();
        myMessage.AddTo(email);
        myMessage.From = new System.Net.Mail.MailAddress(
                            "Joe@contoso.com", "Joe S.");
        myMessage.Subject = subject;
        myMessage.Text = message;
        myMessage.Html = message;
        var credentials = new NetworkCredential(
                         "SendGridUser", "SendGridKey"
                         );
        // Create a Web transport for sending email.
        var transportWeb = new Web(credentials);
        // Send the email.
        if (transportWeb != null)
        {
            return transportWeb.DeliverAsync(myMessage);
        }
        else
        {
            return Task.FromResult(0);
        }
    }

.. note:: SendGrid cannot target dnxcore50: If you build your project then you will get compilation errors. This is because SendGrid does not have a package for dnxcore50 and some APIs such as System.Mail are not available on .NET Core. You can remove dnxcore50 from project.json or call the REST API from SendGrid to send email.

.. note:: Security Note: Never store sensitive data in your source code. The account and credentials are added to the code above to keep the sample simple. Follow the steps on how to store secrets using the `Secret Manager <https://github.com/aspnet/Home/wiki/DNX-Secret-Configuration>`_ . The template code is setup to read configuration values from the SecretManager.


Enable Account confirmation and Password recovery
-------------------------------------------------

The app already has the code to enable account confirmation and reset password.. Follow these steps to enable them:

- In your project open **AccountController** and look at **Register** action.
- Uncomment the code to enable account confirmation.

.. code-block:: c#
        
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            var result = await UserManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=532713
                // Send an email with this link
                var code = await UserManager.GenerateEmailConfirmationTokenAsync(user);
                var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Context.Request.Scheme);
                await MessageServices.SendEmailAsync(model.Email, "Confirm your account",
                    "Please confirm your account by clicking this link: <a href=\"" + callbackUrl + "\">link</a>");
                //await SignInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }
            AddErrors(result);
        }

        // If we got this far, something failed, redisplay form
        return View(model);
    }

- Enable Password recovery by uncommenting the code in **ForgotPassword** action

.. code-block:: c#

    public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await UserManager.FindByNameAsync(model.Email);
            if (user == null || !(await UserManager.IsEmailConfirmedAsync(user)))
            {
                // Don't reveal that the user does not exist or is not confirmed
                return View("ForgotPasswordConfirmation");
            }

            // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=532713
            // Send an email with this link
            var code = await UserManager.GeneratePasswordResetTokenAsync(user);
            var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Context.Request.Scheme);
            await MessageServices.SendEmailAsync(model.Email, "Reset Password",
               "Please reset your password by clicking here: <a href=\"" + callbackUrl + "\">link</a>");
            return View("ForgotPasswordConfirmation");
        }

        // If we got this far, something failed, redisplay form
        return View(model);
    }

- Enable Password recovery form by uncommenting the code in **Views\Account\ForgotPassword** 

.. code-block:: html

	<form asp-controller="Account" asp-action="ForgotPassword" method="post" class="form-horizontal" role="form">
		<h4>Enter your email.</h4>
		<hr />
		<div asp-validation-summary="ValidationSummary.All" class="text-danger"></div>
		<div class="form-group">
			<label asp-for="Email" class="col-md-2 control-label"></label>
			<div class="col-md-10">
				<input asp-for="Email" class="form-control" />
				<span asp-validation-for="Email" class="text-danger"></span>
			</div>
		</div>
		<div class="form-group">
			<div class="col-md-offset-2 col-md-10">
				<input type="submit" class="btn btn-default" value="Submit" />
			</div>
		</div>
	</form>


Register, confirm email and reset password
------------------------------------------

Let us run the Web site and show the account confirmation and password recovery flow.

- Run the app and register a new user

.. image:: accconfirm/_static/loginaccconfirm1.png

- Check your email for the account confirmation link.

- Click the link to confirm your email.

.. image:: accconfirm/_static/loginaccconfirm2.PNG

- Login with your email and password.

- Log Off.

- Click Login and select **Forgot your password?**

.. image:: accconfirm/_static/loginaccconfirm3.PNG

- Enter your email which was used to register the account with.

.. image:: accconfirm/_static/loginaccconfirm4.PNG

- An email with the link to reset your password will be sent. Check your email and click it to reset your password.

.. image:: accconfirm/_static/loginaccconfirm5.PNG

- After your password has been successfully reset, you can login with your email and new password.

.. image:: accconfirm/_static/loginaccconfirm6.PNG

         
Require email confirmation before login
---------------------------------------
Currently once a user completes the registration form, they are logged in. You generally want to confirm their email before logging them in. In the section below, we will modify the code to require new users to have a confirmed email before they are logged in (authenticated).  Update the HttpPost Login action with the following highlighted changes.

.. code-block:: c#

    public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
    {
        ViewBag.ReturnUrl = returnUrl;
        if (ModelState.IsValid)
        {
            // Require the user to have a confirmed email before they can log on.
            var user = await UserManager.FindByNameAsync(model.Email);
            if (user != null)
            {
                if (!await UserManager.IsEmailConfirmedAsync(user))
                {
                    ModelState.AddModelError(string.Empty, "You must have a confirmed email to log in.");
                    return View(model);
                }
            }
            // Code removed for brevity. You should have the code that was in the project.

        }

        // If we got this far, something failed, redisplay form
        return View(model);
    }



Next steps
----------
- Once you publish your Web site to Azure Web App, you should reset the secrets for SendGrid. 
- Set the SendGrid Secrets as application setting in the Azure Web App portal. The configuration system is setup to read keys from environment variables.

Summary
-------

ASP.NET Identity can be used to add account confirmation and password recovery.

