using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OpenTokTest.Models
{
    public class Sessions
    {
        [Key]
        public int SessionId { get; set; }
        public string SessionName { get; set; }
        public string SessionToken { get; set; }
    }
}