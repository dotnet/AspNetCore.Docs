# Upload Files Sample App

This sample app demonstrates concepts described in the [Upload files in ASP.NET Core](https://learn.microsoft.com/aspnet/core/mvc/models/file-uploads) topic.

## Security considerations

Use caution when providing users with the ability to upload files to a server. Attackers may execute [denial of service](/windows-hardware/drivers/ifs/denial-of-service) attacks, attempt to upload viruses or malware, or attempt to compromise networks and servers in other ways.

Security steps that reduce the likelihood of a successful attack are:

* Upload files to a dedicated file upload area on the system, preferably to a non-system drive. Use of a dedicated location makes it easier to impose security measures on uploaded files. Disable execute permissions on the file upload location.&dagger;
* Never persist uploaded files in the same directory tree as the app.&dagger;
* Use a safe file name determined by the app. Don't use a file name provided by user input or the untrusted file name of the uploaded file.&dagger;
* Only allow a specific set of approved file extensions.&dagger;
* Check the file format signature to prevent a user from uploading a masqueraded file (for example, uploading an *.exe* file with a *.txt* extension).&dagger;
* Verify that client-side checks are also performed on the server. Client-side checks are easy to circumvent.&dagger;
* Check the size of the upload and prevent uploads that are larger than expected.&dagger;
* When files shouldn't be overwritten by an uploaded file with the same name, check the file name against the database or physical storage before uploading the file.
* **Run a virus/malware scanner on uploaded content before the file is stored.**

&dagger;The sample app demonstrates an approach that meets the criteria.

> [!WARNING]
> Uploading malicious code to a system is frequently the first step to executing code that can:
>
> * Completely takeover a system.
> * Overload a system with the result that the system crashes.
> * Compromise user or system data.
> * Apply graffiti to a public UI.
>
> For information on reducing the attack surface area when accepting files from users, see the following resources:
>
> * [Unrestricted File Upload](https://www.owasp.org/index.php/Unrestricted_File_Upload)
> * [Azure Security: Ensure appropriate controls are in place when accepting files from users](/azure/security/azure-security-threat-modeling-tool-input-validation#controls-users)

For additional information, see [Upload files in ASP.NET Core](https://learn.microsoft.com/aspnet/core/mvc/models/file-uploads).

## How to use the sample

In the `appsettings.json` file:

1. Set the path for stored files (`StoredFilesPath`).

   * The sample app sets the value to `c:\\files`, which assumes that a folder named *files* exists at the system's C: drive root.
   * The path must exist. Create a *files* folder on the system's C: drive or set the path to a suitable location.
   * The app's process requires read/write permissions to the path.
   * **IMPORTANT!** Disable execute permissions for all users at the path.

1. Set the file size limit (`FileSizeLimit`) in bytes. The sample app's default value of `2097152` (2,097,152 bytes) permits file uploads up to 2 MB.
