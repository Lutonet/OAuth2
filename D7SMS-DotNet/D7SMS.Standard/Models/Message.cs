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
    public class Message : BaseModel 
    {
        // These fields hold the values for the public properties.
        private List<string> to;
        private string content;
        private string mfrom;

        /// <summary>
        /// Destination Number
        /// </summary>
        [JsonProperty("to")]
        public List<string> To 
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
        /// TODO: Write general description for this method
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

        /// <summary>
        /// TODO: Write general description for this method
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
    }
} 