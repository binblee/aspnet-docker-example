using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace webapp
{

public class BloggingContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var serverAddress = Environment.GetEnvironmentVariable("SQLSERVER_ADDRESS");
        var serverPort = Environment.GetEnvironmentVariable("SQLSERVER_PORT");
        var userName = Environment.GetEnvironmentVariable("SQLSERVER_USERNAME");
        var password = Environment.GetEnvironmentVariable("SQLSERVER_PASSWORD");

        var connection = string.Format("Server={0},{1};Database=blog;User Id={2};Password={3};",
            serverAddress,serverPort,userName,password);
        optionsBuilder.UseSqlServer(connection);
    }
}

public class Blog
{
    public int BlogId { get; set; }
    public string Url { get; set; }
    public string Name { get; set; }

    public List<Post> Posts { get; set; }
}

public class Post
{
    public int PostId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }

    public int BlogId { get; set; }
    public Blog Blog { get; set; }
}

}