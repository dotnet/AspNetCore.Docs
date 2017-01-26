protected void  Page_Load(object sender, EventArgs e)

{

	string filePath =  Server.MapPath("~/LastTYASP35Access.txt");

	string contents =  string.Format("Last accessed on {0} by {1}",

		DateTime.Now.ToString(), Request.UserHostAddress);

    System.IO.File.WriteAllText(filePath,  contents);

}