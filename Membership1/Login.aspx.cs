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
                    StatusText.Text = string.Format("Hello {0}!!", User.Identity.GetUserName());
                    LoginStatus.Visible = true;
                    LogoutButton.Visible = true;
                }
                else
                {
                    LoginForm.Visible = true;
                }
            }
        }

        protected void SignIn(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Database=App-DB1;Trusted_Connection=True;MultipleActiveResultSets=true;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM AspNetUsers where UserName='"+UserName.Text.Trim()+"'", connection))
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
                            if (Membership.ValidateUser(UserName.Text, Password.Text))
                            {
                                //good
                                // Successful login

                                //var userStore = new UserStore<IdentityUser>();
                                //var manager = new UserManager<IdentityUser>(userStore);
                                //
                                //var user = manager.FindByName(UserName.Text);

                                //var userStore = new UserStore<IdentityUser>();
                                //var userManager = new UserManager<IdentityUser>(userStore);
                                //var user = userManager.FindByName(UserName.Text);
                                //user.PasswordHash = Password.Text;
                                //
                                //var result = userManager.Update(user);
                                //
                                //if (result.Succeeded)
                                //{
                                //    //StatusMessage.Text = string.Format("User {0} was created successfully!", user.UserName);
                                //}
                                //else
                                //{
                                //    //StatusMessage.Text = result.Errors.FirstOrDefault();
                                //}

                                //var val = User.Identity.GetUserName();
                                //var userStore = new UserStore<IdentityUser>();
                                //var userManager = new UserManager<IdentityUser>(userStore);
                                //var user = new IdentityUser();
                                var userManager = new UserManager<User>(new UserStore<User>(new ApplicationDbContext()));

                                var user = userManager.FindByName(UserName.Text);
                                user.PasswordHash = Password.Text;
                                if (user != null)
                                {
                                    // Update user data
                                    user.PasswordHash = Password.Text;
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
                                //var userManager_ = new UserManager<User>(new UserStore<User>(new ApplicationDbContext()));
                                //var user_ = userManager_.FindByName(User.Identity.Name); // Get the current user
                                //user_.PasswordHash = Password.Text; // Update the email address
                                //var result = userManager_.Update(user_); // Save changes to the database

                            }
                            else
                            {
                                // Invalid login
                                StatusText.Text = "Invalid username or password.";
                            }
                        }
                        else
                        {
                            //login with identity
                            var userStore = new UserStore<IdentityUser>();
                            var userManager = new UserManager<IdentityUser>(userStore);
                            var user = userManager.Find(UserName.Text, Password.Text);
                            
                            if (user != null)
                            {
                                //var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                            
                                //authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, userIdentity);
                                Response.Redirect("~/Default.aspx");
                            }
                            else
                            {
                                StatusText.Text = "Invalid username or password.";
                                LoginStatus.Visible = true;
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