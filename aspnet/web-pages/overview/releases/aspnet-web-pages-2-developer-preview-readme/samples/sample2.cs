Validation.RequireField("MyField");
if (IsPost) {
    Validation.Validate();
    if (ModelState.IsValid) {
        // do something
    }
}