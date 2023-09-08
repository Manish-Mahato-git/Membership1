using System;
using System.Collections.Generic;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Membership1
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void loginUser_Authenticate(object sender, AuthenticateEventArgs e)
        {
            bool isLogin = Membership.ValidateUser(loginUser.UserName, loginUser.Password);
            if (isLogin)
            {
                loginUser.Visible = true;
                Session["user"] = User.Identity.Name;
                FormsAuthentication.RedirectFromLoginPage(loginUser.UserName, true);
                Response.Redirect("Default.aspx");
            }
        }
    }
}