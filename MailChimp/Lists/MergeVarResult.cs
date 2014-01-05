using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MailChimp.Lists
{
    [DataContract]
    public class AddListMergeVarResult
    {
        /// <summary>
        /// Name/description of the merge field
        /// </summary>
        [DataMember(Name = "name")]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Denotes whether the field is required (true) or not (false)
        /// </summary>
        [DataMember(Name = "req")]
        public bool Required
        {
            get;
            set;
        }

        /// <summary>
        /// The "data type" of this merge var. One of: email, text, number, radio, dropdown, date, address, phone, url, imageurl
        /// </summary>
        [DataMember(Name = "field_type")]
        public string FieldType
        {
            get;
            set;
        }

        /// <summary>
        /// Whether the field is displayed in thelist dashboard
        /// </summary>
        [DataMember(Name = "show")]
        public bool Show
        {
            get;
            set;
        }

        /// <summary>
        /// The order this field displays in on forms
        /// </summary>
        [DataMember(Name = "order")]
        public string Order
        {
            get;
            set;
        }

        /// <summary>
        /// The default value for this field
        /// </summary>
        [DataMember(Name = "default")]
        public string Default
        {
            get;
            set;
        }

        /// <summary>
        /// The helptext for this field
        /// </summary>
        [DataMember(Name = "helptext")]
        public string HelpText
        {
            get;
            set;
        }

        /// <summary>
        /// The merge tag that's used for forms and lists/subscribe() and lists/update-member()
        /// </summary>
        [DataMember(Name = "tag")]
        public string Tag
        {
            get;
            set;
        }

        /// <summary>
        /// the options available for radio and dropdown field types
        /// </summary>
        [DataMember(Name = "choices")]
        public string[] Choices
        {
            get;
            set;
        }

        /// <summary>
        /// an unchanging id for the merge var
        /// </summary>
        [DataMember(Name = "id")]
        public int Id
        {
            get;
            set;
        }
    }

    [DataContract]
    public class DeleteListMergeVarResult
    {
        [DataMember(Name = "complete")]
        public bool Complete { get; set; }
    }
}
