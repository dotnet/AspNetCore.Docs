using SpaServicesSampleApp.Models;
using System.Collections.Generic;

namespace SpaServicesSampleApp.Data
{
    public static class SampleData
    {
        public static IEnumerable<Blog> Blogs()
        {
            return new List<Blog>()
            {
                new Blog{ BlogId = 1, Url = "http://blog.stevensanderson.com/", Title = "Steve Sanderson's Blog" },
                new Blog{ BlogId = 2, Url = "http://fiyazhasan.me", Title = "Classroom of Fizz" }
            };
        }

        public static IEnumerable<Post> Posts()
        {
            return new List<Post>
            {
                 new Post(){ PostId=1, Title="ASP.NET Core + Angular 2 template for Visual Studio", Author="Steve Sanderson", Link="http://blog.stevensanderson.com/2016/10/04/angular2-template-for-visual-studio/", BlogId=1},
                 new Post(){ PostId=2, Title="Angular 2, React, and Knockout apps on ASP.NET Core", Author="Steve Sanderson", Link="http://blog.stevensanderson.com/2016/05/02/angular2-react-knockout-apps-on-aspnet-core/", BlogId=1},
                 new Post(){ PostId=3, Title="Building Custom Formatters for .NET Core (Yaml Formatters)", Author="Fiyaz Hasan", Link="http://www.fiyazhasan.me/building-custom-formatters-for-net-core-yaml-formatters/", BlogId=2},
                 new Post(){ PostId=4, Title="Preventing XSRF in AngularJS Apps with ASP.NET Core Anti-Forgery Middleware", Author="Fiyaz Hasan", Link="http://www.fiyazhasan.me/angularjs-anti-forgery-with-asp-net-core/", BlogId=2}
            };
        }
    }
}
