/*
 * D7SMS.Standard
 *
 */

using Newtonsoft.Json;
using System.Collections.Generic;

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