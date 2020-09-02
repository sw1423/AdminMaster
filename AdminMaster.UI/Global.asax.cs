using AdminMaster.UI.Infrastruture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AdminMaster.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //CreateClassBLL bLL = new CreateClassBLL();
            //bLL.CreateEntityClass();
            DependencyResolver.SetResolver(new UnityDependencyResolver(UnityFactory.CreateContainer()));
        }
    }
}
