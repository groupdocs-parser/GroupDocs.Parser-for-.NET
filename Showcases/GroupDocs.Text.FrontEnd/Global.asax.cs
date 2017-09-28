using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GroupDocs.Text.FrontEnd
{

    public class MvcApplication : System.Web.HttpApplication
    {
        private string _licensePath = "D:\\Aspose Projects\\License\\GroupDocs.Total.lic";
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            GroupDocs.Text.License lic = new GroupDocs.Text.License();
            lic.SetLicense(_licensePath);
        }
    }
}
