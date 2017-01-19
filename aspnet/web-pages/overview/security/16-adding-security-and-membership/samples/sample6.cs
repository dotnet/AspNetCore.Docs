if (!ReCaptcha.Validate("PRIVATE_KEY")) {
    ModelState.AddError("recaptcha", "Captcha response was not correct");
}