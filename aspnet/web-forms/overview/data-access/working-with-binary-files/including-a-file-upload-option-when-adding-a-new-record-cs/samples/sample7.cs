const string BrochureDirectory = "~/Brochures/";
string brochurePath = BrochureDirectory + BrochureUpload.FileName;
string fileNameWithoutExtension = 
    System.IO.Path.GetFileNameWithoutExtension(BrochureUpload.FileName);
int iteration = 1;
while (System.IO.File.Exists(Server.MapPath(brochurePath)))
{
    brochurePath = string.Concat(BrochureDirectory, 
        fileNameWithoutExtension, "-", iteration, ".pdf");
    iteration++;
}