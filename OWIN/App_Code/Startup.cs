using Owin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Startup
{
    public static void Configuration(IAppBuilder app)
    {
        app.Use(async (ctx, next) =>
        {
            Debug.WriteLine("Incoming request: " + ctx.Request.Path);

            await next();

            Debug.WriteLine("Outgpoing response: " + ctx.Request.Path);
        });

        app.Use(async (ctx, next) =>
        {
            await ctx.Response.WriteAsync("<html><body>Hello world</body></html>");
        });
    }
}