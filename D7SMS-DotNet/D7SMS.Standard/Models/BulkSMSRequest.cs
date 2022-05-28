/*
 * D7SMS.Standard
 *
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using D7SMS.Standard;
using D7SMS.Standard.Utilities;


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