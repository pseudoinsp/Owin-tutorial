﻿using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DebugMiddlewareExtensions
/// </summary>
public static class DebugMiddlewareExtensions
{
    public static void UseDebugMiddleware(this IAppBuilder app, DebugMiddlewareOptions options = null)
    {
        if (options == null)
            options = new DebugMiddlewareOptions();

        app.Use<DebugMiddlewareOptions>(options);
    }
}