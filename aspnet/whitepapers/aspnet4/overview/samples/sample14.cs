private void btnGet_Click(object sender, EventArgs e) 
{ 
	//Obtain a reference to the default MemoryCache instance. 
	//Note that you can create multiple MemoryCache(s) inside 
	//of a single application. 
	ObjectCache cache = MemoryCache.Default; 

	//In this example the cache is storing the contents of a file string 
	fileContents = cache["filecontents"] as string;

	//If the file contents are not currently in the cache, then 
	//the contents are read from disk and placed in the cache. 
	if (fileContents == null) 
	{
		//A CacheItemPolicy object holds all the pieces of cache 
		//dependency and cache expiration metadata related to a single 
		//cache entry. 
		CacheItemPolicy policy = new CacheItemPolicy(); 

		//Build up the information necessary to create a file dependency. 
		//In this case we just need the file path of the file on disk. 
		List filePaths = new List(); 
		filePaths.Add("c:\\data.txt"); 

		//In the new cache API, dependencies are called "change monitors". 
		//For this example we want the cache entry to be automatically expired 
		//if the contents on disk change. A HostFileChangeMonitor provides 
		//this functionality. 
		policy.ChangeMonitors.Add(new HostFileChangeMonitor(filePaths)); 

		//Fetch the file's contents 
		fileContents = File.ReadAllText("c:\\data.txt"); 

		//And then store the file's contents in the cache 
		cache.Set("filecontents", fileContents, policy); 

	} 
	MessageBox.Show(fileContents); 
}