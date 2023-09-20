using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace Membership1
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (User.Identity.IsAuthenticated)
                {
                    //Label1.Text = string.Format("Hello {0}!!", User.Identity.GetUserName());
                    //LoginStatus.Visible = true;
                    //LogoutButton.Visible = true;
                }
                else
                {
                    //Label1.Visible = true;
                }
            }
        }

        protected void SignIn(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Database=App-DB1;Trusted_Connection=True;MultipleActiveResultSets=true;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM AspNetUsers where UserName='" + loginUser.UserName + "'", connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //int id = reader.GetInt32(0);
                        string identityHash = reader["PasswordHash"].ToString();
                        string membershipHash = reader["UserName"].ToString();

                        if (identityHash == null || identityHash == "")
                        {
                            //login with membership and update the value of password hash in identity
                            if (Membership.ValidateUser(loginUser.UserName, loginUser.Password))
                            {

                                var userManager = new UserManager<User>(new UserStore<User>(new ApplicationDbContext()));

                                var user = userManager.FindByName(loginUser.UserName);
                                user.PasswordHash = userManager.PasswordHasher.HashPassword(loginUser.Password);
                                if (user != null)
                                {
                                    // Update user data
                                    //user.PasswordHash = Password.Text;
                                    var result = userManager.Update(user);

                                    if (result.Succeeded)
                                    {
                                        // The user information was successfully updated
                                        Response.Redirect("~/Default.aspx");
                                    }
                                    else
                                    {
                                        // Handle errors
                                        //lblError.Text = "Failed to update user information.";
                                    }
                                }
                                else
                                {
                                    // Handle the case where the user is not found
                                    //lblError.Text = "User not found.";
                                }


                            }
                            else
                            {
                                // Invalid login
                                //Label1.Text = "Invalid username or password.";
                            }
                        }
                        else
                        {
                            //login with identity
                            var userStore = new UserStore<IdentityUser>();
                            var userManager = new UserManager<IdentityUser>(userStore);
                            var user = userManager.Find(loginUser.UserName, loginUser.Password);

                            if (user != null)
                            {
                                //var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                                //authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, userIdentity);
                                Response.Redirect("~/Default.aspx");
                            }
                            else
                            {
                                //Label1.Text = "Invalid username or password.";
                                //loginUser.LoginStatus.Visible = true;
                            }
                        }

                    }
                }
            }



        }

        protected void SignOut(object sender, EventArgs e)
        {
            //var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            //authenticationManager.SignOut();
            Response.Redirect("~/Login.aspx");
        }
    }
}