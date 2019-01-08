using Owin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Nancy.Owin;
using Nancy;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Startup
{
    public static void Configuration(IAppBuilder app)
    {
        app.UseDebugMiddleware(new DebugMiddlewareOptions()
        {
            OnIncomingRequest = (ctx) =>
            {
                var watch = Stopwatch.StartNew();
                ctx.Environment["DebugStopwatch"] = watch;
            },

            OnOutgoingRequest = (ctx) =>
            {
                var watch = (Stopwatch)ctx.Environment["DebugStopwatch"];
                watch.Stop();
                Debug.WriteLine($"Request took: {watch.ElapsedMilliseconds} ms");
            }
        });

        // To only use it when the path is matching "/nancy"
        // other option is the NancyOptions, see below  
        //app.Map("/nancy", mappedApp => { mappedApp.UseNancy(); });
        app.UseNancy(config =>
        {
            config.PassThroughWhenStatusCodesAre(HttpStatusCode.NotFound);
        });

        app.Use(async (ctx, next) =>
        {
            await ctx.Response.WriteAsync("<html><body>Hello world</body></html>");
        });
    }
}