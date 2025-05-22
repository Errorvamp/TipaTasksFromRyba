using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace WebAspNet2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authCookie = Context.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie == null || authCookie.Value == "")
                return;
            FormsAuthenticationTicket authTicket;
            try
            {
                authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            }

            catch
            {
                return;

            }
            string[] roles = authTicket.UserData.Split(':');
            if (Context.User != null)
                Context.User = new GenericPrincipal(Context.User.Identity, roles);
        }



    }
    public class UserVM
    {
        [Required]
        [DisplayName("Логин")]
        public string Login { get; set; }
        [Required]
        [DisplayName("Пароль")]
        public string Password { get; set; }


        string ReturnHashCode(string loginAndSalt)
        {
            string hash = "";
            using (SHA1 shalHash = SHA1.Create())
            {
                byte[] data = shalHash.ComputeHash(Encoding.UTF8.GetBytes(loginAndSalt)); StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                hash = sBuilder.ToString().ToUpper();

            }
            return hash;
        }
    }

    public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("ListOfPeople", "Lab2");
        }
    }
}
