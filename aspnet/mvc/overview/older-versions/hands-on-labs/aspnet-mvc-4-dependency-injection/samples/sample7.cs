namespace MvcMusicStore.Pages
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web;
	using Microsoft.Practices.Unity;
	using MvcMusicStore.Models;
	using MvcMusicStore.Services;

	public class MyBasePage : System.Web.Mvc.WebViewPage<Genre>
	{
		[Dependency]
		public IMessageService MessageService { get; set; }

		public override void 

		Execute()
		{
		}
	}
}