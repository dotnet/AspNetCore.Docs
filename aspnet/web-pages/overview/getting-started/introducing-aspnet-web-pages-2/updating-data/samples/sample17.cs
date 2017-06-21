if(row != null) {
    title = row.Title;
    genre = row.Genre;
    year = row.Year;
}
else{
    Validation.AddFormError("No movie was found for that ID.");
}