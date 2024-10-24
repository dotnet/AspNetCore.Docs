document.getElementById('register').addEventListener('submit', handleRegisterSubmit);

async function handleRegisterSubmit(event) {
    event.preventDefault();

    let username = this.username.value;
    //let displayName = this.displayName.value;
    // passwordfield is omitted in demo
    // let password = this.password.value;
    // possible values: none, direct, indirect
    let attestation_type = "none";
    // possible values: <empty>, platform, cross-platform
    let authenticator_attachment = "";
    // possible values: preferred, required, discouraged
    let user_verification = "preferred";
    // possible values: true,false
    let require_resident_key = false;
    // prepare form post data
    var data = new FormData();
    data.append('username', username);
   // data.append('displayName', displayName);
    data.append('attType', attestation_type);
    data.append('authType', authenticator_attachment);
    data.append('userVerification', user_verification);
    data.append('requireResidentKey', require_resident_key);

    // send to server for registering
    let makeCredentialOptions;
    try {
        makeCredentialOptions = await fetchMakeCredentialOptions(data);

    } catch (e) {
        console.error(e);
        let msg = "Something wen't really wrong";
        showErrorAlert(msg);
    }

    //console.log("Credential Options Object", makeCredentialOptions);

    if (makeCredentialOptions.status !== "ok") {
        console.log("Error creating credential options");
        console.log(makeCredentialOptions.errorMessage);
        showErrorAlert(makeCredentialOptions.errorMessage);
        return;
    }

    // Turn the challenge back into the accepted format of padded base64
    makeCredentialOptions.challenge = coerceToArrayBuffer(makeCredentialOptions.challenge);
    // Turn ID into a UInt8Array Buffer for some reason
    makeCredentialOptions.user.id = coerceToArrayBuffer(makeCredentialOptions.user.id);

    makeCredentialOptions.excludeCredentials = makeCredentialOptions.excludeCredentials.map((c) => {
        c.id = coerceToArrayBuffer(c.id);
        return c;
    });

    if (makeCredentialOptions.authenticatorSelection.authenticatorAttachment === null) {
        makeCredentialOptions.authenticatorSelection.authenticatorAttachment = undefined;
    }

    //console.log("Credential Options Formatted", makeCredentialOptions);

    const fido2TapYourSecurityKeyToFinishRegistration = document.getElementById('fido2TapYourSecurityKeyToFinishRegistration').innerText;
    document.getElementById('fido2mfadisplay').innerHTML += '<br><b>' + fido2TapYourSecurityKeyToFinishRegistration +'</b><img src = "/images/securitykey.min.svg" alt = "fido login" />';

    //Swal.fire({
    //    title: 'Registering...',
    //    text: 'Tap your security key to finish registration.',
    //    imageUrl: "/images/securitykey.min.svg",
    //    showCancelButton: true,
    //    showConfirmButton: false,
    //    focusConfirm: false,
    //    focusCancel: false
    //});

    //console.log("Creating PublicKeyCredential...");
    //console.log(navigator);
    //console.log(navigator.credentials);
    //console.log(makeCredentialOptions);
    let newCredential;
    try {
        newCredential = await navigator.credentials.create({
            publicKey: makeCredentialOptions
        });
    } catch (e) {
        const fido2RegistrationError = document.getElementById('fido2RegistrationError').innerText;
        console.error(fido2RegistrationError, e);
        document.getElementById('fido2mfadisplay').innerHTML = '';
        showErrorAlert(fido2RegistrationError, e);
    }

    console.log("PublicKeyCredential Created", newCredential);

    try {
        registerNewCredential(newCredential);

    } catch (e) {
        showErrorAlert(err.message ? err.message : err);
    }
}

async function fetchMakeCredentialOptions(formData) {
    let response = await fetch('/mfamakeCredentialOptions', {
        method: 'POST', // or 'PUT'
        body: formData, // data can be `string` or {object}!
        headers: {
            'Accept': 'application/json',
            'RequestVerificationToken': document.getElementById('RequestVerificationToken').value
        }
    });

    let data = await response.json();

    return data;
}

// This should be used to verify the auth data with the server
async function registerNewCredential(newCredential) {
    // Move data into Arrays incase it is super long
    let attestationObject = new Uint8Array(newCredential.response.attestationObject);
    let clientDataJSON = new Uint8Array(newCredential.response.clientDataJSON);
    let rawId = new Uint8Array(newCredential.rawId);

    const data = {
        id: newCredential.id,
        rawId: coerceToBase64Url(rawId),
        type: newCredential.type,
        extensions: newCredential.getClientExtensionResults(),
        response: {
            AttestationObject: coerceToBase64Url(attestationObject),
            clientDataJson: coerceToBase64Url(clientDataJSON)
        }
    };

    let response;
    try {
        response = await registerCredentialWithServer(data);
    } catch (e) {
        showErrorAlert(e);
    }

    //console.log("Credential Object", response);

    // show error
    if (response.status !== "ok") {
        console.log("Error creating credential");
        console.log(response.errorMessage);
        showErrorAlert(response.errorMessage);
        return;
    }

    // show success 
    Swal.fire({
        title: 'Registration Successful!',
        text: 'You\'ve registered successfully.',
       // type: 'success',
        timer: 2000
    });

    // possible values: true,false
    window.location.href = "/Identity/Account/Manage/GenerateRecoveryCodes";
}

async function registerCredentialWithServer(formData) {
    let response = await fetch('/mfamakeCredential', {
        method: 'POST', // or 'PUT'
        body: JSON.stringify(formData), // data can be `string` or {object}!
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
            'RequestVerificationToken': document.getElementById('RequestVerificationToken').value
        }
    });

    let data = await response.json();

    return data;
}