using System;
using System.Net;

namespace JsonRPC
{
    internal class SessionWebClient : WebClient
    {
        private readonly CookieContainer cookieContainer;

        public int Timeout { get; set; }

        public SessionWebClient()
        {
            this.cookieContainer = new CookieContainer();
        }

        protected override WebResponse GetWebResponse(WebRequest request)
        {
            WebResponse response = base.GetWebResponse(request);

            this.GetCookies(response);

            return response;
        }

        protected override WebResponse GetWebResponse(WebRequest request, IAsyncResult result)
        {
            WebResponse response = base.GetWebResponse(request, result);

            this.GetCookies(response);

            return response;
        }

        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest request = base.GetWebRequest(address);

            var httpRequest = request as HttpWebRequest;

            if (httpRequest != null)
            {
                httpRequest.CookieContainer = this.cookieContainer;
                if (this.Timeout > 0)
                {
                    httpRequest.Timeout = this.Timeout;
                }
            }

            return request;
        }

        private void GetCookies(WebResponse response)
        {
            var httpResponse = response as HttpWebResponse;

            if (httpResponse == null)
                return;

            this.cookieContainer.Add(httpResponse.Cookies);
        }
    }
}
