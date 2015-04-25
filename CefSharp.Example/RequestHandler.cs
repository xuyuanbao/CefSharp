﻿using System;

namespace CefSharp.Example
{
    public class RequestHandler : IRequestHandler
    {
        public static readonly string VersionNumberString = String.Format("Chromium: {0}, CEF: {1}, CefSharp: {2}",
            Cef.ChromiumVersion, Cef.CefVersion, Cef.CefSharpVersion);

        bool IRequestHandler.OnBeforeBrowse(IWebBrowser browser, IRequest request, bool isRedirect, bool isMainFrame)
        {
            return false;
        }

        bool IRequestHandler.OnCertificateError(IWebBrowser browser, CefErrorCode errorCode, string requestUrl)
        {
            return false;
        }

        void IRequestHandler.OnPluginCrashed(IWebBrowser browser, string pluginPath)
        {
            // TODO: Add your own code here for handling scenarios where a plugin crashed, for one reason or another.
        }

        bool IRequestHandler.OnBeforeResourceLoad(IWebBrowser browser, IRequest request, bool isMainFrame)
        {
            //Note to Redirect simply set the request Url
            //if (request.Url.StartsWith("https://www.google.com", StringComparison.OrdinalIgnoreCase))
            //{
            //    request.Url = "https://github.com/";
            //}

            return false;
        }

        bool IRequestHandler.GetAuthCredentials(IWebBrowser browser, bool isProxy, string host, int port, string realm, string scheme, ref string username, ref string password)
        {
            return false;
        }

        bool IRequestHandler.OnBeforePluginLoad(IWebBrowser browser, string url, string policyUrl, WebPluginInfo info)
        {
            bool blockPluginLoad = false;

            // Enable next line to demo: Block any plugin with "flash" in its name
            // try it out with e.g. http://www.youtube.com/watch?v=0uBOtQOO70Y
            //blockPluginLoad = info.Name.ToLower().Contains("flash");
            return blockPluginLoad;
        }

        void IRequestHandler.OnRenderProcessTerminated(IWebBrowser browser, CefTerminationStatus status)
        {
            // TODO: Add your own code here for handling scenarios where the Render Process terminated for one reason or another.
        }

        public bool OnQuotaRequest(IWebBrowser browser, string originUrl, long newSize)
        {
            return false;
        }

        public void OnResourceRedirect(IWebBrowser browser, bool isMainFrame, string oldUrl, ref string newUrl)
        {
            //Example of how to redirect - need to check `newUrl` in the second pass
            //if (string.Equals(oldUrl, "https://www.google.com/", StringComparison.OrdinalIgnoreCase) && !newUrl.Contains("github"))
            //{
            //	newUrl = "https://github.com";
            //}
        }

        public bool OnProtocolExecution(IWebBrowser browser, string url)
        {
            return url.StartsWith("mailto");
        }
    }
}
