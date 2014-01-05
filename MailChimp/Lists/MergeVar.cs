using System.Collections.Generic;
using System.Runtime.Serialization;


namespace MailChimp.Lists
{
    /// <summary>
    /// optional merges for the email (FNAME, LNAME, etc.) 
    /// Note that a merge field can only hold up to 255 bytes. Also, there are a few "special" keys
    /// </summary>
    [DataContract]
    public class MergeVar
    {
        /// <summary>
        /// set this to change the email address. This is only respected on calls using update_existing or 
        /// when passed to listUpdateMember().
        /// </summary>
        [DataMember(Name = "new-email")]
        public string NewEmail
        {
            get;
            set;
        }

        /// <summary>
        /// Interest Groupings 
        /// </summary>
        [DataMember(Name = "groupings")]
        public List<Grouping> Groupings
        {
            get;
            set;
        }

        /// <summary>
        /// Set the Opt-in IP field. Abusing this may cause your account to 
        /// be suspended. We do validate this and it must not 
        /// be a private IP address.
        /// </summary>
        [DataMember(Name = "optin_ip")]
        public string OptInIP
        {
            get;
            set;
        }

        /// <summary>
        /// Set the Opt-in Time field. Abusing this may cause your account to be 
        /// suspended. We do validate this and it must be a valid date. 
        /// Use - 24 hour format in GMT, eg "2013-12-30 20:30:00" to be safe. 
        /// Generally, though, anything strtotime() understands we'll understand - http://us2.php.net/strtotime
        /// </summary>
        [DataMember(Name = "optin_time")]
        public string OptInTime
        {
            get;
            set;
        }

        /// <summary>
        /// Set the member's geographic location either by optin_ip or geo data.
        /// </summary>
        [DataMember(Name = "mc_location")]
        public MCLocation LocationData
        {
            get;
            set;
        }

        /// <summary>
        /// Set the member's language preference. Supported codes are fully 
        /// case-sensitive and can be found here: 
        /// http://kb.mailchimp.com/article/can-i-see-what-languages-my-subscribers-use#code
        /// </summary>
        [DataMember(Name = "mc_language")]
        public string Language
        {
            get;
            set;
        }

        /// <summary>
        /// List of notes
        /// </summary>
        [DataMember(Name = "mc_notes")]
        public List<MCNote> Notes
        {
            get;
            set;
        }

    }

    [DataContract]
    public class MergeVarOptions
    {
        /// <summary>
        /// optional one of: text, number, radio, dropdown, date, address, phone, url, imageurl, zip, birthday - 
        /// defaults to text
        /// </summary>
        [DataMember(Name = "field_type")]
        public string FieldType
        {
            get;
            set;
        }

        /// <summary>
        /// optional indicates whether the field is required - defaults to false
        /// </summary>
        [DataMember(Name = "req")]
        public bool? Required
        {
            get;
            set;
        }

        /// <summary>
        /// optional indicates whether the field is displayed in public - defaults to true
        /// </summary>
        [DataMember(Name = "public")]
        public bool? Public
        {
            get;
            set;
        }

        /// <summary>
        /// optional indicates whether the field is displayed in the app's list member view - defaults to true
        /// </summary>
        [DataMember(Name = "show")]
        public bool? Show
        {
            get;
            set;
        }

        /// <summary>
        /// The order this merge tag should be displayed in - this will cause existing values to be reset so this fits
        /// </summary>
        [DataMember(Name = "order")]
        public int Order
        {
            get;
            set;
        }

        /// <summary>
        /// optional the default value for the field. See lists/subscribe() for formatting info. Defaults to blank - max 255 bytes
        /// </summary>
        [DataMember(Name = "default_value")]
        public string DefaultValue
        {
            get;
            set;
        }

        /// <summary>
        /// optional the help text to be used with some newer forms. Defaults to blank - max 255 bytes
        /// </summary>
        [DataMember(Name = "helptext")]
        public string HelpText
        {
            get;
            set;
        }
        	 
        /// <summary>
        /// optional kind of - an array of strings to use as the choices for radio and dropdown type fields
        /// </summary>
        [DataMember(Name = "choices")]
        public string[] Choices
        {
            get;
            set;
        }
	 
        /// <summary>
        /// optional only valid for birthday and date fields. For birthday type, must be "MM/DD" (default) or "DD/MM". For date type, must be "MM/DD/YYYY" (default) or "DD/MM/YYYY". Any other values will be converted to the default.
        /// </summary>
        [DataMember(Name = "dateformat")]
        public string DateFormat
        {
            get;
            set;
        }
	 
        /// <summary>
        /// optional "US" is the default - any other value will cause them to be unformatted (international)
        /// </summary>
        [DataMember(Name = "phoneformat")]
        public string PhoneFormat
        {
            get;
            set;
        }
	 
        /// <summary>
        /// the ISO 3166 2 digit character code for the default country. Defaults to "US". Anything unrecognized will be converted to the default.
        /// </summary>
        [DataMember(Name = "defaultcountry")]
        public string DefaultCountry
        {
            get;
            set;
        }
    }


}
