/*
 * D7SMS.Standard
 *
 */

using Newtonsoft.Json;

namespace D7SMS.Standard.Models
{
    public class CreateSendSMSInput : BaseModel
    {
        // These fields hold the values for the public properties.
        private Models.SendSMSRequest body;

        private string contentType;
        private string accept;

        /// <summary>
        /// Message Body
        /// </summary>
        [JsonProperty("Body")]
        public Models.SendSMSRequest Body
        {
            get
            {
                return this.body;
            }
            set
            {
                this.body = value;
                onPropertyChanged("Body");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("Content-Type")]
        public string ContentType
        {
            get
            {
                return this.contentType;
            }
            set
            {
                this.contentType = value;
                onPropertyChanged("ContentType");
            }
        }

        /// <summary>
        /// TODO: Write general description for this method
        /// </summary>
        [JsonProperty("Accept")]
        public string Accept
        {
            get
            {
                return this.accept;
            }
            set
            {
                this.accept = value;
                onPropertyChanged("Accept");
            }
        }
    }
}