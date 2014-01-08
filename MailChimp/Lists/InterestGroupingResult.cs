using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace MailChimp.Lists
{
    [DataContract]
    public class InterestGroupingResult
    {
        /// <summary>
        /// the total matching records
        /// </summary>
        [DataMember(Name = "id")]
        public int Id
        {
            get;
            set;
        }
    }
}
