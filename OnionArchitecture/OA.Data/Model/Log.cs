//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OA.Data.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Log
    {
        public long Id { get; set; }
        public Nullable<long> UserId { get; set; }
        public string RequestIpAddress { get; set; }
        public string RequestUri { get; set; }
        public string RequestMethod { get; set; }
        public string RequestPostData { get; set; }
        public Nullable<System.DateTime> RequestTimestamp { get; set; }
        public string ResponseStatusCode { get; set; }
        public string ResponseReasonPhrase { get; set; }
        public string ResponseErrorMessage { get; set; }
        public Nullable<System.DateTime> ResponseTimestamp { get; set; }
    }
}
