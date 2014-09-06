using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OpenTokTest.Models
{
    public class SessionEntities : DbContext
    {
        public DbSet<Sessions> SessionList { get; set; }
    }
}