using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Membership1
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager()
        : base(new UserStore<ApplicationUser>(new ApplicationDbContext()))
        {
            this.PasswordHasher = new SqlPasswordHasher();
        }
    }
}