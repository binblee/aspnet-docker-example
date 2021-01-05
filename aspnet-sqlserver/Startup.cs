using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace webapp
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.Run(context =>
            {
                using (var db = new BloggingContext())
                {
                    var result = "";
                    db.Blogs.Add(new Blog { Url = "https://yq.aliyun.com/teams/11" });
                    var count = db.SaveChanges();
                    result += string.Format("{0} records saved to database\n", count);

                    result += string.Format("All blogs in database:\n");
                    foreach (var blog in db.Blogs)
                    {
                        result += string.Format(" - {0}\n", blog.Url);
                    }                
                    return context.Response.WriteAsync(result);
                }
            });
        }
    }
}