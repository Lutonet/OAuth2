/*
 * D7SMS.Standard
 *
 */

using Newtonsoft.Json;
using System.Collections.Generic;

namespace D7SMS.Standard.Models
{
    public class BulkSMSRequest : BaseModel
    {
        // These fields hold the values for the public properties.
        private List<Models.Message> messages;

        /// <summary>
        /// Sendbatch message body
        /// </summary>
        [JsonProperty("messages")]
        public List<Models.Message> Messages
        {
            get
            {
                return this.messages;
            }
            set
            {
                this.messages = value;
                onPropertyChanged("Messages");
            }
        }
    }
}