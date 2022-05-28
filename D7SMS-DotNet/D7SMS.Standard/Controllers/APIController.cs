/*
 * D7SMS.Standard
 *
 */
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using D7SMS.Standard;
using D7SMS.Standard.Utilities;
using D7SMS.Standard.Http.Request;
using D7SMS.Standard.Http.Response;
using D7SMS.Standard.Http.Client;
using D7SMS.Standard.Exceptions;

namespace D7SMS.Standard.Controllers
{
    public partial class APIController: BaseController
    {
        #region Singleton Pattern

        //private static variables for the singleton pattern
        private static object syncObject = new object();
        private static APIController instance = null;

        /// <summary>
        /// Singleton pattern implementation
        /// </summary>
        internal static APIController Instance
        {
            get
            {
                lock (syncObject)
                {
                    if (null == instance)
                    {
                        instance = new APIController();
                    }
                }
                return instance;
            }
        }

        #endregion Singleton Pattern

        /// <summary>
        /// Check account balance
        /// </summary>
        /// <return>Returns the void response from the API call</return>
        public void GetBalance()
        {
            Task t = GetBalanceAsync();
            APIHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// Check account balance
        /// </summary>
        /// <return>Returns the void response from the API call</return>
        public async Task GetBalanceAsync()
        {
            //the base uri for api requests
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/balance");


            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            {
                { "user-agent", "D7SDK 1.0" }
            };

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.Get(_queryUrl,_headers, Configuration.APIUsername, Configuration.APIPassword);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request,_response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 500)
                throw new APIException(@"Internal Server Error", _context);

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

        }

        /// <summary>
        /// Send SMS  to recipients using D7 SMS Gateway
        /// </summary>
        /// <param name="Models.CreateSendSMSInput">Object containing request parameters</param>
        /// <return>Returns the void response from the API call</return>
        public void CreateSendSMS(Models.CreateSendSMSInput input)
        {
            Task t = CreateSendSMSAsync(input);
            APIHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// Send SMS  to recipients using D7 SMS Gateway
        /// </summary>
        /// <param name="Models.CreateSendSMSInput">Object containing request parameters</param>
        /// <return>Returns the void response from the API call</return>
        public async Task CreateSendSMSAsync(Models.CreateSendSMSInput input)
        {
            //the base uri for api requests
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/send");


            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            {
                { "user-agent", "D7SDK 1.0" },
                { "Content-Type", input.ContentType },
                { "Accept", input.Accept }
            };

            //append body params
            var _body = APIHelper.JsonSerialize(input.Body);

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.PostBody(_queryUrl, _headers, _body, Configuration.APIUsername, Configuration.APIPassword);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request,_response);

            //Error handling using HTTP status codes
            if (_response.StatusCode == 500)
                throw new APIException(@"Internal Server Error", _context);

            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

        }

        /// <summary>
        /// Send Bulk SMS  to multiple recipients using D7 SMS Gateway
        /// </summary>
        /// <param name="body">Required parameter: Message Body</param>
        /// <param name="contentType">Required parameter: Example: </param>
        /// <param name="accept">Required parameter: Example: </param>
        /// <return>Returns the void response from the API call</return>
        public void CreateBulkSMS(Models.BulkSMSRequest body, string contentType, string accept)
        {
            Task t = CreateBulkSMSAsync(body, contentType, accept);
            APIHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// Send Bulk SMS  to multiple recipients using D7 SMS Gateway
        /// </summary>
        /// <param name="body">Required parameter: Message Body</param>
        /// <param name="contentType">Required parameter: Example: </param>
        /// <param name="accept">Required parameter: Example: </param>
        /// <return>Returns the void response from the API call</return>
        public async Task CreateBulkSMSAsync(Models.BulkSMSRequest body, string contentType, string accept)
        {
            //the base uri for api requests
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/sendbatch");


            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            {
                { "user-agent", "D7SDK 1.0" },
                { "Content-Type", contentType },
                { "Accept", accept }
            };

            //append body params
            var _body = APIHelper.JsonSerialize(body);

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.PostBody(_queryUrl, _headers, _body, Configuration.APIUsername, Configuration.APIPassword);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request,_response);
            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

        }

    }
} 