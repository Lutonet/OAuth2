/*
 * D7SMS.Tests
 *
 */
using D7SMS.Standard.Http.Client;
using D7SMS.Standard.Http.Request;
using D7SMS.Standard.Http.Response;

namespace D7SMS.Tests.Helpers
{
    public class HttpCallBackEventsHandler
    {
        public HttpRequest Request { get; private set; }

        public HttpResponse Response { get; private set; }

        public void OnBeforeHttpRequestEventHandler(IHttpClient source, HttpRequest request)
        {
            this.Request = request;
        }

        public void OnAfterHttpResponseEventHandler(IHttpClient source, HttpResponse response)
        {
            this.Response = response;
        }
    }
}
