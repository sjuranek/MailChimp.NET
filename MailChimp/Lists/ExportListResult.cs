using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MailChimp.Lists
{
    [DataContract]
    public class ExportListResult
    {
        /// <summary>
        /// Name/description of the merge field
        /// </summary>
        [DataMember(Name = "text")]
        public string Text
        {
            get;
            set;
        }
    }
}
