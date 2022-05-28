/*
 * D7SMS.Tests
 *
 */
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using D7SMS.Standard;
using D7SMS.Standard.Utilities; 
using D7SMS.Standard.Http.Client;
using D7SMS.Standard.Http.Response;
using D7SMS.Tests.Helpers;
using NUnit.Framework;
using D7SMS.Standard;
using D7SMS.Standard.Controllers;
using D7SMS.Standard.Exceptions;

namespace D7SMS.Tests
{
    [TestFixture]
    public class APIControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests)
        /// </summary>
        private static APIController controller;

        /// <summary>
        /// Setup test class
        /// </summary>
        [SetUp]
        public static void SetUpClass()
        {
            controller = GetClient().Client;
        }

        /// <summary>
        /// Check Balance 
        /// </summary>
        [Test]
        public async Task TestBalance() 
        {

            // Perform API call

            try
            {
                await controller.GetBalanceAsync();
            }
            catch(APIException) {};

            // Test response code
            Assert.AreEqual(500, httpCallBackHandler.Response.StatusCode,
                    "Status should be 500");

        }

        /// <summary>
        /// Send SMS  to a recipient using D7 SMS Gateway 
        /// </summary>
        [Test]
        public async Task TestSendSMS() 
        {
            // Parameters for the API call
            Standard.Models.CreateSendSMSInput input = new Standard.Models.CreateSendSMSInput();
            input.Body = APIHelper.JsonDeserialize<Standard.Models.SendSMSRequest>("{  \"to\": 971562316353,  \"from\": \"SignSMS\",  \"content\": \"Send single SMS Testing\"}");
            input.ContentType = "application/json";
            input.Accept = "application/json";

            // Perform API call

            try
            {
                await controller.CreateSendSMSAsync(input);
            }
            catch(APIException) {};

            // Test response code
            Assert.AreEqual(500, httpCallBackHandler.Response.StatusCode,
                    "Status should be 500");

        }

        /// <summary>
        /// Send SMS  to multiple recipients using D7 SMS Gateway 
        /// </summary>
        [Test]
        public async Task TestBulkSMS() 
        {
            // Parameters for the API call
            Standard.Models.BulkSMSRequest body = APIHelper.JsonDeserialize<Standard.Models.BulkSMSRequest>("{  \"messages\": [    {      \"to\": [        \"971562316353\",        \"971562316354\",        \"971562316355\"      ],      \"content\": \"Same content goes to three numbers\",      \"from\": \"SignSMS\"    }  ]}");
            string contentType = "application/json";
            string accept = "application/json";

            // Perform API call

            try
            {
                await controller.CreateBulkSMSAsync(body, contentType, accept);
            }
            catch(APIException) {};

            // Test response code
            Assert.AreEqual(500, httpCallBackHandler.Response.StatusCode,
                    "Status should be 500");

        }

    }
}