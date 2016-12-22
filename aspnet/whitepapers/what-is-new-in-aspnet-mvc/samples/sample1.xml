namespace MyApplication.Areas.Blog {
    public class BlogAreaRegistration : AreaRegistration {
        public override string AreaName {
            get { return "blog"; }
        }

        public override void RegisterArea(AreaRegistrationContext context) {
            context.MapRoute(
                "blog_default",
                "blog/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "blog_whatsnew",
                "whats-new",
                new { action = "WhatsNew", id = UrlParameter.Optional  }
            );
        }
    }
}