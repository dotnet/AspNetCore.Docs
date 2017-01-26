try
{
	file.ReadBlock(buffer, index, buffer.Length);
}
catch (FileNotFoundException e)
{
	Server.Transfer("NoFileErrorPage.aspx", true);
}
catch (System.IO.IOException e)
{
	Server.Transfer("IOErrorPage.aspx", true);
}

finally
{
	if (file != null)
	{
		file.Close();
	}
}