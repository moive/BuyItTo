using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace BuyItTo
{
	public class MvcApplication : System.Web.HttpApplication
	{

		protected void Application_Start(object sender, EventArgs e) 		
		{
			AreaRegistration.RegisterAllAreas();
			RouteConfig.RegisterRoutes(RouteTable.Routes);
		}
	}
}