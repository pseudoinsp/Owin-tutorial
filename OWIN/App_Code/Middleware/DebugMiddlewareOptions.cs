using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DebugMiddlewareOptions
/// </summary>
public class DebugMiddlewareOptions
{
    public Action<IOwinContext> OnIncomingRequest { get; set; }
    public Action<IOwinContext> OnOutgoingRequest { get; set; }
}