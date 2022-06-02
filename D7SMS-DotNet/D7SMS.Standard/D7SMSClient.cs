/*
 * D7SMS.Standard
 *
 */

using D7SMS.Standard.Controllers;
using D7SMS.Standard.Http.Client;

namespace D7SMS.Standard
{
    public partial class D7SMSClient
    {
        /// <summary>
        /// Singleton access to Client controller
        /// </summary>
        public APIController Client
        {
            get
            {
                return APIController.Instance;
            }
        }

        /// <summary>
        /// The shared http client to use for all API calls
        /// </summary>
        public IHttpClient SharedHttpClient
        {
            get
            {
                return BaseController.ClientInstance;
            }
            set
            {
                BaseController.ClientInstance = value;
            }
        }

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public D7SMSClient()
        { }

        /// <summary>
        /// Client initialization constructor
        /// </summary>
        public D7SMSClient(string aPIUsername, string aPIPassword)
        {
            Configuration.APIUsername = aPIUsername;
            Configuration.APIPassword = aPIPassword;
        }

        #endregion Constructors
    }
}