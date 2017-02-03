public void Init(HttpApplication
context)
 {
   // Wrap the Task-based method so that it can be used with 
   // the older async programming model.
   EventHandlerTaskAsyncHelper helper = 
 	   new EventHandlerTaskAsyncHelper(ScrapeHtmlPage);
 
   // The helper object makes it easy to extract Begin/End methods out of
   // a method that returns a Task object. The ASP.NET pipeline calls the 
   // Begin and End methods to start and complete calls on asynchronous 
   // HTTP modules.
   context.AddOnPostAuthorizeRequestAsync(
	   helper.BeginEventHandler, helper.EndEventHandler);
}