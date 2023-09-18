using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Membership1
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
    }
}