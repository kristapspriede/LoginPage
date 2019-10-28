using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace RegistrationLogin.Models
{
    public class UserDBContext : DbContext
    {
        public DbSet<UserAccount> userAccount { get; set; }
    }
}