// Save the file to disk and set the value of the brochurePath parameter
BrochureUpload.SaveAs(Server.MapPath(brochurePath));
e.Values["brochurePath"] = brochurePath;