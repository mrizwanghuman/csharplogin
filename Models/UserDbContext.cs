using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication9.Models
{
    public class UserDbContext: DbContext 
    {
       public DbSet<UserData> userData { get; set; }
    }
}