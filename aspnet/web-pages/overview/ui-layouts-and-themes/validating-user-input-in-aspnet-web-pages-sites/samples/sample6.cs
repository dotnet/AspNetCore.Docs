if(!IsPost){
    if(!Request.QueryString["classid"].IsEmpty() && Request.QueryString["classid"].IsInt()) {
        // Process the value
    }
    else{
        Validation.AddFormError("No class was selected.");
    }
}