using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Membership1
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /*        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
                {
                    FormsAuthentication.SetAuthCookie(RegisterUser.UserName, false *//* createPersistentCookie *//*);

                    string continueUrl = RegisterUser.ContinueDestinationPageUrl;
                    if (String.IsNullOrEmpty(continueUrl))
                    {
                        continueUrl = "Login.aspx";
                    }
                    Response.Redirect(continueUrl);
                }*/
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            // Default UserStore constructor uses the default connection string named: DefaultConnection
            var userStore = new UserStore<IdentityUser>();
            var manager = new UserManager<IdentityUser>(userStore);

            var user = new IdentityUser() { UserName = UserName.Text };
            IdentityResult result = manager.Create(user, Password.Text);

            if (result.Succeeded)
            {
                StatusMessage.Text = string.Format("User {0} was created successfully!", user.UserName);
            }
            else
            {
                StatusMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}