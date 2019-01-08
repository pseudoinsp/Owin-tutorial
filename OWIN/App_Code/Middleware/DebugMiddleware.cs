using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AppFunc = System.Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>;

/// <summary>
/// Summary description for DebugMiddleware
/// </summary>
public class DebugMiddleware
{
    private readonly AppFunc _next;
    private readonly DebugMiddlewareOptions _options;

    public DebugMiddleware(AppFunc next, DebugMiddlewareOptions options)
    {
        _next = next;
        _options = options;

        if(options.OnIncomingRequest == null)
        {
            _options.OnIncomingRequest = (ctx) => { Debug.WriteLine("Incoming request: " + ctx.Request.Path); };
        }

        if (options.OnOutgoingRequest == null)
        {
            _options.OnOutgoingRequest = (ctx) => { Debug.WriteLine("Outgpoing response: " + ctx.Request.Path); };
        }
    }

    public async Task Invoke(IDictionary<string, object> environment)
    {
        var ctx = new OwinContext(environment);

        _options.OnIncomingRequest(ctx);

        await _next(environment);

        _options.OnOutgoingRequest(ctx);
    }
}