using Autofac;
using Autofac.Integration.Mvc;
using OdetoFood.data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using Autofac.Integration.WebApi;

namespace OdetoFood.web
{
    public class ContainerConfig
    {
        internal static void RegisterContainer(HttpConfiguration httpConfiguracion )
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<SqlRestaurantData>()
                   .As<IRestauranteData>()
                   .InstancePerRequest();
            builder.RegisterType<OdeToFoodDBContext>().InstancePerRequest();

            var Container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(Container));
            httpConfiguracion.DependencyResolver = new AutofacWebApiDependencyResolver(Container);
        }
    }
}