Two-factor authentication with SMS using ASP.NET Identity
=========================================================

By `Rick Anderson`_

This tutorial will show you how to set up two-factor authentication (2FA) using SMS. Twilio is used, but you can use any other SMS provider. We recommend you complete :doc:`accconfirm` before starting this tutorial.

.. Add Set up SMS for ASPSMS just after "Setup for Twilio"

In this article:
	- `Create a new ASP.NET 5 project`_
	- `Setup up SMS for two-factor authentication with Twilio`_
	- `Enable two-factor authentication`_
	- `Log in with two-factor authentication`_
	- `Account lockout for protecting against brute force attacks`_
	- `Debugging  Twilio`_

Create a new ASP.NET 5 project
------------------------------

Create a new ASP.NET 5 web app with individual user accounts.

.. image:: accconfirm/_static/new-project.png

After you create the project, follow the instructions in :doc:`accconfirm` to set up and require SSL.

Setup up SMS for two-factor authentication with Twilio
-------------------------------------------------------

 - Create a `Twilio <http://www.twilio.com/>`_ account.
 - On the **Dashboard** tab of your Twilio account, note the **Account SID** and **Authentication token**. Note: Tap **Show API Credentials** to see the Authentication token.
 - On the **Numbers** tab, note the Twilio phone number.
 - Install the Twilio NuGet package. From the Package Manager Console (PMC),  enter the following the following command:

 ``Install-Package Twilio``
  - Add code in the *Services/MessageServices.cs* file to enable SMS.

.. literalinclude:: 2fa/sample/WebSMS/src/WebSMS/Services/MessageServices.cs
   :language: c#
   :lines: 12-39
   :dedent: 4

.. note:: Twilio cannot target dnxcore50: You will get compilation errors if you build your project when dnxcore50 is included because Twilio does not have a package for dnxcore50. You can remove dnxcore50 from the *project.json* file or you can call the Twilio REST API to send SMS messages.

.. note:: You can remove ``//`` line comment characters from the ``System.Diagnostics.Debug.WriteLine(message);`` line to test the application when you can't get SMS messages. A better approach to logging is to use the built in :doc:`../fundamentals/logging`.        

Configure the SMS provider key/value
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

We'll use the :ref:`Options pattern <options-config-objects>` to access the user account and key settings. For more information, see :doc:`../fundamentals/configuration`.

 - Create a class to fetch the secure SMS key. For this sample, the ``AuthMessageSMSSenderOptions`` class is created in the *Services/AuthMessageSMSSenderOptions.cs* file.

.. literalinclude:: 2fa/sample/WebSMS/src/WebSMS/Services/AuthMessageSMSSenderOptions.cs
   :language: c#
   :lines: 3-8
   :dedent: 4

Set ``SID``, ``AuthToken``, and ``SendNumber`` with the `secret-manager tool <http://docs.asp.net/en/latest/security/app-secrets.html>`_. For example:

.. code-block:: none

	C:/WebSMS/src/WebApplication1>user-secret set SID abcdefghi
	info: Successfully saved SID = abcdefghi to the secret store.

.. Setup up SMS for two-factor authentication with ASPSMS
   	-------------------------------------------------------

Configure startup to use ``AuthMessageSMSSenderOptions``
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

Add ``AuthMessageSMSSenderOptions`` to the service container at the end of the ``ConfigureServices`` method in the *Startup.cs* file:

.. literalinclude:: 2fa/sample/WebSMS/src/WebSMS/Startup.cs
   :language: c#
   :lines: 73-77
   :emphasize-lines: 4
   :dedent: 8

Enable two-factor authentication
--------------------------------

- Open the *Views/Manage/Index.cshtml* Razor view file.
- Uncomment the phone number markup which starts at

	``@*@(Model.PhoneNumber ?? "None")``

- Uncomment the ``Model.TwoFactor`` markup which starts at

	``@*@if (Model.TwoFactor)``

- Comment out or remove the ``<p>There are no two-factor authentication providers configured.`` markup.

 The completed code is shown below:

 .. literalinclude:: 2fa/sample/WebSMS/src/WebSMS/Views/Manage/Index.cshtml
   :language: html
   :lines:  32-77
   :dedent: 8

Log in with two-factor authentication
----------------------------------------

- Run the app and register a new user

.. image:: 2fa/_static/login2fa1.png

- Tap on your user name, which activates the ``Index`` action method in Manage controller. Then tap the phone number **Add** link.

.. image:: 2fa/_static/login2fa2.png

- Add a phone number that will receive the verification code, and tap **Send verification code**.

.. image:: 2fa/_static/login2fa3.png

- You will get a text message with the verification code. Enter it and tap **Submit**

.. image:: 2fa/_static/login2fa4.png

If you don't get a text message, see `Debugging  Twilio`_.

- The Manage view shows your phone number was added successfully.

.. image:: 2fa/_static/login2fa5.png

- Tap **Enable** to enable two-factor authentication.

.. image:: 2fa/_static/login2fa6.png

Test two-factor authentication
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

- Log off.
- Log in.
- The user account has enabled two-factor authentication, so you have to provide the second factor of authentication . In this tutorial you have enabled phone verification. The built in templates also allow you to set up email as the second factor. You can set up additional second factors for authentication such as QR codes. Tap **Submit**.

.. image:: 2fa/_static/login2fa7.png

- Enter the code you get in the SMS message.
- Clicking on the **Remember this browser** check box will exempt you from needing to use 2FA to log on when using the same device and browser. Enabling 2FA and clicking on **Remember this browser** will provide you with strong 2FA protection from malicious users trying to access your account, as long as they don't have access to your device. You can do this on any private device you regularly use. By setting  **Remember this browser**, you get the added security of 2FA from devices you don't regularly use, and you get the convenience on not having to go through 2FA on your own devices.

.. image:: 2fa/_static/login2fa8.png

Account lockout for protecting against brute force attacks
----------------------------------------------------------
We recommend you use account lockout with 2FA. Once a user logs in (through a local account or social account), each failed attempt at 2FA is stored, and if the maximum attempts (default is 5) is reached, the user is locked out for five minutes (you can set the lock out time with ``DefaultAccountLockoutTimeSpan``).
The following configures Account to be locked out for 10 minutes after 10 failed attempts.

.. literalinclude:: 2fa/sample/WebSMS/src/WebSMS/Startup.cs
   :language: c#
   :lines: 67-77
   :emphasize-lines: 1-5
   :dedent: 8

Debugging  Twilio
-------------------
If you're able to use the Twilio API, but you don't get an SMS message, try the following:

1. Log in to the Twilio site and navigate to the **Logs** > **SMS & MMS Logs** page. You can verify that messages were sent and delivered.
2. Use the following code in a console application to test Twilio:

.. code-block:: c#

	static void Main(string[] args)
	{
		string AccountSid = "";
		string AuthToken = "";
		var twilio = new Twilio.TwilioRestClient(AccountSid, AuthToken);
		string FromPhone = "";
		string toPhone = "";
		var message = twilio.SendMessage(FromPhone, toPhone, "Twilio Test");
		Console.WriteLine(message.Sid);
	}
