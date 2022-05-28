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
    public class SendSMSRequest : BaseModel 
    {
        // These fields hold the values for the public properties.
        private long to;
        private string mfrom;
        private string content;

        /// <summary>
        /// Destination Mobile Number
        /// </summary>
        [JsonProperty("to")]
        public long To 
        { 
            get 
            {
                return this.to; 
            } 
            set 
            {
                this.to = value;
                onPropertyChanged("To");
            }
        }

        /// <summary>
        /// Sender ID / Number
        /// </summary>
        [JsonProperty("from")]
        public string From 
        { 
            get 
            {
                return this.mfrom; 
            } 
            set 
            {
                this.mfrom = value;
                onPropertyChanged("From");
            }
        }

        /// <summary>
        /// Message Content
        /// </summary>
        [JsonProperty("content")]
        public string Content 
        { 
            get 
            {
                return this.content; 
            } 
            set 
            {
                this.content = value;
                onPropertyChanged("Content");
            }
        }
    }
} 